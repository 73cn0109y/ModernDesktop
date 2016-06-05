using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace ModernDesktop.Components.Taskbar
{
	public partial class ApplicationWatcher : Component
	{
		private BackgroundWorker Watcher;
		private List<Process> ListedProcess = new List<Process>();
		private readonly string[] ExcludedApplicationNames =
		{
			"applicationframehost",
			"explorer"
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

		public void Run()
		{
			Watcher.RunWorkerAsync();
		}

		public void Stop()
		{
			Watcher.CancelAsync();
		}

		public void Refresh()
		{

		}

		private void Watcher_DoWork(object sender, DoWorkEventArgs e)
		{
			while(!e.Cancel && !Watcher.CancellationPending)
			{
				foreach (Process proc in Process.GetProcesses())
				{
					if (proc.MainWindowTitle == "" || ExcludedApplicationNames.Contains(proc.ProcessName.ToLower()))
						continue;

					if (!proc.Responding)
						continue;

					if (Exists(proc.ProcessName))
						continue;

					// Remove Application
					if (!IsOpen(proc.ProcessName))
					{
						ListedProcess.Remove(proc);
						continue;
					}

					// Generate Taskbar Control

					// --

					ListedProcess.Add(proc);
				}

				System.Threading.Thread.Sleep(500);
			}
		}

		private bool IsOpen(string name)
		{
			return Process.GetProcessesByName(name).Length > 0;
		}

		private bool Exists(string name)
		{
			return ListedProcess.Where(x => x.ProcessName == name).Count() > 0;
		}
	}
}
