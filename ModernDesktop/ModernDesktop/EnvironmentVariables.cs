namespace ModernDesktop.Environment
{
	public static class System
	{
		public static string RootPath { get { return "C:/ModernDesktop/System/"; } }
		public static string Logger { get { return RootPath + "/logger/"; } }
		public static string Wallpapers { get { return RootPath + "/wallpapers/"; } }
		public static string Widgets { get { return RootPath + "/widgets/"; } }
	}

	public static class CurrentUser
	{
		public static string Name { get { return "Administrator"; } }
		public static string RootPath { get { return "C:/ModernDesktop/Users/" + Name + "/"; } }
		public static string Documents { get { return RootPath + "/Documents/"; } }
		public static string Downloads { get { return RootPath + "/Downloads/"; } }
		public static string Music { get { return RootPath + "/Music/"; } }
		public static string Pictures { get { return RootPath + "/Pictures/"; } }
		public static string Videos { get { return RootPath + "/Videos/"; } }
	}

	public static class Extensions
	{
		public static string Parse(this string e)
		{
			e = e.Replace("%CurrentUser%", CurrentUser.Name);
			e = e.Replace("%CurrentUser.RootPath%", CurrentUser.RootPath);
			e = e.Replace("%CurrentUser.Documents%", CurrentUser.Documents);
			e = e.Replace("%CurrentUser.Downloads%", CurrentUser.Downloads);
			e = e.Replace("%CurrentUser.Music%", CurrentUser.Music);
			e = e.Replace("%CurrentUser.Pictures%", CurrentUser.Pictures);
			e = e.Replace("%CurrentUser.Videos%", CurrentUser.Videos);

			return e;
		}
	}
}