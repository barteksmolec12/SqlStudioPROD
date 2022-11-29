
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SqlStudioPROD
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{

			ApplicationStore appStore = new ApplicationStore();

			SqlViewModel sqlViewModel = new SqlViewModel(appStore);
			DatabaseViewModel dbViewModel = new DatabaseViewModel(appStore);
			MenuViewModel menuViewModel = new MenuViewModel(appStore);
			MainViewModel mainViewModel = new MainViewModel(sqlViewModel, dbViewModel, menuViewModel);

			MainWindow = new MainWindow()
			{
				DataContext = mainViewModel
			};
			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}
