using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

using ModernDesktop.Misc;
using System.Runtime.InteropServices;

namespace ModernDesktop.Components.Taskbar
{
	public partial class ApplicationWatcher : Component
	{
		public event EventHandler ApplicationLaunched;

		private const int ITEM_WIDTH = 40;
		private const int ITEM_HEIGHT = 40;

		private BackgroundWorker Watcher;
		private HashSet<ProcessInfo> ListedProcesses = new HashSet<ProcessInfo>();
		private Control TargetContainer;
		private bool firstRun = true;
		private readonly string[] ExcludedApplicationNames =
		{
			"applicationframehost",
			"explorer",
			"chrome"
		};

		public ApplicationWatcher()
		{
			InitializeComponent();

			if (!DesignMode)
				Initialize();
		}

		public ApplicationWatcher(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			if (!DesignMode)
				Initialize();
		}

		public void Initialize()
		{
			Watcher = new BackgroundWorker();
			Watcher.DoWork += Watcher_DoWork;
			Watcher.WorkerSupportsCancellation = true;
		}

		public void Run(Control ctrl)
		{
			TargetContainer = ctrl;
			Watcher.RunWorkerAsync();
		}

		public void Stop()
		{
			Watcher.CancelAsync();
		}

		public void Refresh()
		{

		}

		public void HidePreview()
		{
			if (TargetContainer == null)
				return;

			foreach(Controls.Taskbar.TaskbarItem item in TargetContainer.Controls.OfType<Controls.Taskbar.TaskbarItem>())
				item.HidePreview();
		}

		private void Watcher_DoWork(object sender, DoWorkEventArgs e)
		{
			while(!e.Cancel && !Watcher.CancellationPending)
			{
				bool hasChanged = false;
				int left = 50 + (ListedProcesses.Count * (40 + 5));

				Dictionary<uint[], string> chromeWindows = new Dictionary<uint[], string>();
				chromeWindows.Add(WindowsByClassFinder.WindowTitlesForClass("Chrome_WidgetWin_0"), WindowsByClassFinder.WindowTitlesForClass("Chrome_WidgetWin_1"));

				foreach (Process proc in Process.GetProcesses("."))
				{
					try
					{
						if (proc.MainWindowTitle == "" || ExcludedApplicationNames.Contains(proc.ProcessName.ToLower()))
							continue;

						if (!proc.Responding)
							continue;

						ProcessInfo exists = Exists(proc.MainWindowHandle);

						if (exists != null)
						{
							if (exists.Title != proc.MainWindowTitle)
							{
								UpdateTitle(exists);
							}
							continue;
						}

						ProcessInfo pi = new ProcessInfo()
						{
							Location = proc.MainModule.FileName,
							MainHandle = proc.MainWindowHandle,
							ThreadID = proc.MainWindowHandle.GetThreadProcessId(),
							Name = proc.ProcessName,
							TargetHandle = IntPtr.Zero,
							Title = proc.MainWindowTitle
						};

						GenerateItem(new Point(left, 0), pi, proc.MainModule.FileName);
						hasChanged = true;

						if (!firstRun)
							ApplicationLaunched?.Invoke(pi, null);

						left += ITEM_WIDTH + 5;

						ListedProcesses.Add(pi);
					}
					catch (Win32Exception wexp)
					{

					}
				}

				foreach (KeyValuePair<uint[], string> window in chromeWindows)
				{
					if (!string.IsNullOrWhiteSpace(window.Value))
					{
						try
						{
							Process proc = Process.GetProcessById((int)window.Key[1]);

							ProcessInfo exists = Exists(new IntPtr(window.Key[0]));

							if (exists != null)
							{
								if (exists.Title != window.Value)
								{
									UpdateTitle(exists);
								}
								continue;
							}

							ProcessInfo pi = new ProcessInfo()
							{
								Location = proc.MainModule.FileName,
								MainHandle = new IntPtr(window.Key[0]),
								Name = proc.ProcessName,
								TargetHandle = new IntPtr(window.Key[1]),
								Title = window.Value
							};

							GenerateItem(new Point(left, 0), pi, proc.MainModule.FileName, window.Value);
							hasChanged = true;

							if (!firstRun)
								ApplicationLaunched?.Invoke(pi, null);

							left += ITEM_WIDTH + 5;

							ListedProcesses.Add(pi);
						}
						catch (Win32Exception wex)
						{

						}
					}
				}

				foreach (Controls.Taskbar.TaskbarItem item in TargetContainer.Controls.OfType<Controls.Taskbar.TaskbarItem>())
				{
					if (!IsOpen(item.ProcessInformation.Name, item.ProcessInformation.TargetHandle == IntPtr.Zero ? item.ProcessInformation.MainHandle : IntPtr.Zero, item.ProcessInformation.ThreadID))
					{
						ListedProcesses.Remove(item.ProcessInformation);
						TargetContainer.Invoke(new MethodInvoker(() =>
						{
							item.Dispose();
						}));
						hasChanged = true;
					}
					else if(item.ProcessInformation.MainHandle.GetWindowState() == Extensions.WindowState.Minimized)
						item.ProcessInformation.MainHandle.SendToBack();
				}

				if (hasChanged)
					Reposition();

				if (firstRun)
					firstRun = false;

				System.Threading.Thread.Sleep(500);
			}
		}

		private void Reposition()
		{
			int left = 50;

			foreach(Controls.Taskbar.TaskbarItem item in TargetContainer.Controls.OfType<Controls.Taskbar.TaskbarItem>())
			{
				TargetContainer.Invoke(new MethodInvoker(() => { item.Location = new Point(left, 0); }));
				left += item.Width + 5;
			}
		}

		private void GenerateItem(Point location, ProcessInfo processInfo, string FileName, string title = "")
		{
			Controls.Taskbar.TaskbarItem item = new Controls.Taskbar.TaskbarItem();
			item.Size = new Size(ITEM_WIDTH, ITEM_HEIGHT);
			item.Location = location;
			item.BackgroundImage = FileName.GetLargeIcon();
			item.Name = processInfo.MainHandle.ToString();
			item.ProcessInformation = processInfo;

			TargetContainer.Invoke(new MethodInvoker(() => { TargetContainer.Controls.Add(item); }));
		}

		private void UpdateTitle(ProcessInfo info)
		{
			IntPtr handle = info.TargetHandle == IntPtr.Zero ? info.MainHandle : info.TargetHandle;

			ListedProcesses.Remove(info);
			ListedProcesses.Add(info);
		}

		private bool IsOpen(string name, IntPtr id, uint threadID = 0)
		{
			if (id == IntPtr.Zero)
				return Process.GetProcessesByName(name).Count() > 0;

			if (threadID != 0)
				foreach (Process proc in Process.GetProcessesByName(name))
					if (proc.MainWindowHandle.GetThreadProcessId() == threadID)
						return true;

			return Process.GetProcessesByName(name).Where(x => x.MainWindowHandle == id).Count() > 0;
		}

		private ProcessInfo Exists(IntPtr id)
		{
			return ListedProcesses.Where(x => id == x.MainHandle).FirstOrDefault();
		}
	}
}
