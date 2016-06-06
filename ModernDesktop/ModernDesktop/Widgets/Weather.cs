using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ModernDesktop.Widgets
{
	public partial class Weather : Form
	{
		private const string CURRENT_WEATHER_URL = "http://api.openweathermap.org/data/2.5/weather?appid=";
		private const string FORECAST_WEATHER_URL = "http://api.openweathermap.org/data/2.5/forecast?appid=";
		private const string API_KEY = "2ab507b5a63b9071d50374e43a942f23";

		public event WeatherUpdatedHandler ForecastUpdated;
		public event WeatherUpdatedHandler CurrentUpdated;

		private System.Timers.Timer WeatherUpdater;

		public Weather()
		{
			InitializeComponent();

			WeatherUpdater = new System.Timers.Timer();
			WeatherUpdater.Interval = (30 * 60 * 1000); // 30 minutes
			WeatherUpdater.AutoReset = true;
			WeatherUpdater.Elapsed += WeatherUpdater_Elapsed;
			WeatherUpdater.Start();

			ForecastUpdated += Weather_ForecastUpdated;
			CurrentUpdated += Weather_CurrentUpdated;
		}

		public void UpdateForecast()
		{
			new Thread(() =>
			{
				string url = FORECAST_WEATHER_URL + API_KEY + "&id=" + Properties.Settings.Default.Widget_Weather_CityID;
				string data = url.DownloadString();

				ForecastUpdated?.Invoke(null, null);
			}).Start();
		}

		/*
		"coord":{"lon":150.9,"lat":-32.27
		"weather":[{"id":500,"main":"Rain","description":"light rain","icon":"10n"}
		"base":"cmc stations"
		"main":{"temp":285.219,"pressure":979.25,"humidity":86,"temp_min":285.219,"temp_max":285.219,"sea_level":1012.14,"grnd_level":979.25
		"wind":{"speed":5.62,"deg":275.001
		"rain":{"3h":0.585
		"clouds":{"all":92
		"dt":1465138121
		"sys":{"message":0.003,"country":"AU","sunrise":1465073495,"sunset":1465109900
		"id":2156034
		"name":"Muswellbrook"
		"cod":200}
		*/
		public void UpdateCurrent()
		{
			new Thread(() =>
			{
				WeatherData weather = new WeatherData();
				weather.Time = DateTime.Now;
				weather.Unit = WeatherData.UnitType.Celcius;

				string url = CURRENT_WEATHER_URL + API_KEY + "&id=" + Properties.Settings.Default.Widget_Weather_CityID;
				string[] data = SplitData(url.DownloadString());

				foreach (string d in data)
				{
					if (d.StartsWith("\"weather\""))
					{
						// Condition
						string condition = d.Split(new string[] { "main" }, StringSplitOptions.None)[1].Split(new string[] { "," }, StringSplitOptions.None)[0];
						WeatherData.WeatherCondition weatherCondition;
						Enum.TryParse(condition.Substring(3, condition.Length - 4), out weatherCondition);
						weather.Condition = weatherCondition;
						// --
					}
					else if (d.StartsWith("\"main\""))
					{
						// Current Temperature
						string currentTemp = d.Split("temp")[1].Split(",")[0];
						double current;
						if (double.TryParse(currentTemp.Substring(2, currentTemp.Length - 2), out current))
							weather.Current = current;
						// --
						// Minimum Temperature
						string minTemp = d.Split("temp_min")[1].Split(",")[0];
						double min;
						if (double.TryParse(minTemp.Substring(2, minTemp.Length - 2), out min))
							weather.Minimum = min;
						// --
						// Maximum Temperature
						string maxTemp = d.Split("temp_max")[1].Split(",")[0];
						double max;
						if (double.TryParse(maxTemp.Substring(2, maxTemp.Length - 2), out max))
							weather.Maximum = max;
						// --
						// Humidity
						string humidityVal = d.Split("humidity")[1].Split(",")[0];
						double humidity;
						if (double.TryParse(humidityVal.Substring(2, humidityVal.Length - 2), out humidity))
							weather.Humidity = humidity;
						// --
					}
					else if (d.StartsWith("\"sys\""))
					{
						string location = d.Split("country")[1].Split(",")[0];
						location = location.Substring(3, location.Length - 4);

						if (weather.Location == "Location Unknown")
							weather.Location = ", " + location;
						else
							weather.Location += ", " + location;
					}
					else if (d.StartsWith("\"name\""))
					{
						if (weather.Location == "Location Unknown")
							weather.Location = d.Substring(d.IndexOf(":") + 2, d.Length - d.IndexOf(":") - 3);
						else
							weather.Location = d.Substring(d.IndexOf(":") + 2, d.Length - d.IndexOf(":") - 3) + weather.Location;
					}
				}

				CurrentUpdated?.Invoke(null, new WeatherArgs(new WeatherData[] { weather }, WeatherArgs.UpdateType.Current));
			}).Start();
		}

		private string[] SplitData(string d)
		{
			List<string> data = new List<string>();
			string[] splitData = d.Split("},");

			foreach(string str in splitData)
			{
				string mod = str;

				bool hasSub = false;

				if (mod.StartsWith("{"))
					mod = mod.Substring(1, mod.Length - 1);

				if(mod.IndexOf("[") > -1)
				{
					hasSub = true;

					string[] subsplit = mod.Split("]");
					foreach (string sub in subsplit)
					{
						string subMod = sub;
						if (subMod.StartsWith(","))
							subMod = subMod.Substring(1, subMod.Length - 1);
						if (subMod.CharBeforeChar(',', '{'))
						{
							data.Add(subMod.Substring(0, subMod.IndexOf(",")));
							data.Add(subMod.Substring(subMod.IndexOf(",") + 1, subMod.Length - subMod.IndexOf(",") - 1));
						}
						else
							data.Add(subMod);
					}
				}

				if (!hasSub)
				{
					if (mod.CharBeforeChar(',', '{'))
					{
						data.Add(mod.Substring(0, mod.IndexOf(",")));
						data.Add(mod.Substring(mod.IndexOf(",") + 1, mod.Length - mod.IndexOf(",") - 1));
					}
					else if(mod.IndexOf("{") == -1)
					{
						foreach (string m in mod.Split(","))
							data.Add(m);
					}
					else
						data.Add(mod);
				}
			}

			return data.ToArray();
		}

		public string[] FindLocation(string query)
		{
			List<string> ReleventCityID = new List<string>();

			query = query.ToLower();

			using (StreamReader reader = new StreamReader("C:/ModernDesktop/System/widgets/weather/city_list.txt"))
			{
				while(!reader.EndOfStream)
				{
					string line = reader.ReadLine();

					string[] data = line.Split('\t');
					string relevant = data[1] + ", " + data[4];

					if(relevant.ToLower().Contains(query))
						ReleventCityID.Add(data[0] + "," + data[1] + "," + data[4]);
				}
			}

			return ReleventCityID.ToArray();
		}

		private void WeatherUpdater_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			
		}

		private void Weather_CurrentUpdated(object sender, WeatherArgs e)
		{
			if (e == null)
				return;
			if (e.Data == null)
				return;
			if (e.Data.Length <= 0)
				return;

			WeatherData Data = e.Data[0];
			DateTime upt = Data.Time;
			string UnitString = Extensions.ToString(Data.Unit);

			Invoke(new MethodInvoker(() =>
			{
				picCurrentCondition.Image = ConditionImage(Data.Condition);
				lblCurrentTemp.Text = string.Format("{0:N1}", Data.Current.Convert(Data.Unit)) + UnitString;
				lblMinMaxHumValues.Text = string.Format("{0}\r\n{1}\r\n{2}", string.Format("{0:N0}{1}", Data.Minimum.Convert(Data.Unit), UnitString), string.Format("{0:N0}{1}", Data.Maximum.Convert(Data.Unit), UnitString), string.Format("{0:N0}%", Data.Humidity));
				lblLastUpdated.Text = string.Format("{0}:{1}{2} {3}/{4}/{5}", (upt.Hour % 12 == 0 ? 12 : upt.Hour % 12), upt.Minute.ToString("D2"), (upt.Hour % 12 < 11 ? "AM" : "PM"), upt.Day.ToString("D2"), upt.Month.ToString("D2"), upt.Year);
				lblCurrentLocation.Text = Data.Location;
			}));
		}

		private void Weather_ForecastUpdated(object sender, WeatherArgs e)
		{
			if (e == null)
				return;
			if (e.Data == null)
				return;
			if (e.Data.Length <= 0)
				return;

			DateTime upt = e.Data[0].Time;

			Invoke(new MethodInvoker(() =>
			{
				lblLastUpdated.Text = string.Format("{0}:{1}{2} {3}/{4}/{5}", (upt.Hour % 12 == 0 ? 12 : upt.Hour % 12), upt.Minute.ToString("D2"), (upt.Hour % 12 < 11 ? "AM" : "PM"), upt.Day.ToString("D2"), upt.Month.ToString("D2"), upt.Year);
			}));
		}

		private Image ConditionImage(WeatherData.WeatherCondition e)
		{
			switch (e)
			{
				case WeatherData.WeatherCondition.Fog:
					return Properties.Resources.Widget_Weather_Fog;
				case WeatherData.WeatherCondition.Rain:
					return Properties.Resources.Widget_Weather_Rain;
				case WeatherData.WeatherCondition.Snow:
					return Properties.Resources.Widget_Weather_Snow;
				case WeatherData.WeatherCondition.Sun:
					return Properties.Resources.Widget_Weather_Sunny;
				case WeatherData.WeatherCondition.LightningStorm:
					return Properties.Resources.Widget_Weather_Lightning_Storm;
				case WeatherData.WeatherCondition.Wind:
					return Properties.Resources.Widget_Weather_Windy;
				case WeatherData.WeatherCondition.Clouds:
					return Properties.Resources.Widget_Weather_Cloudy;
			}

			return Properties.Resources.Widget_Weather_Clear;
		}
	}

	public class WeatherData
	{
		public enum UnitType
		{
			Kelvin,
			Fahrenheit,
			Celcius
		}

		public enum WeatherCondition
		{
			UNKNOWN,
			Clear,
			Sun,
			Rain,
			Snow,
			LightningStorm,
			Wind,
			Fog,
			Clouds
		}

		public WeatherData() { }

		public DateTime Time { get; set; }
		public UnitType Unit { get; set; }
		public WeatherCondition Condition { get; set; }
		public double Minimum { get; set; } = -9999;
		public double Maximum { get; set; } = -9999;
		public double Current { get; set; } = -9999;
		public double Humidity { get; set; } = 100;
		public string Location { get; set; } = "Location Unknown";
	}

	public class WeatherArgs : EventArgs
	{
		public WeatherArgs(WeatherData[] data, UpdateType type)
		{
			Data = data;
			Type = type;
		}

		public enum UpdateType
		{
			Current,
			Forecast
		}

		public UpdateType Type { get; set; } = UpdateType.Current;
		// If Type is set to Current, this only contains one item
		// If Type is set to Forecast, this may contain up to 7 items
		public WeatherData[] Data { get; set; }
	}

	public delegate void WeatherUpdatedHandler(object sender, WeatherArgs e);
}
