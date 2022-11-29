using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SqlStudioPROD
{
	public class NewConnectionCommand : AsyncCommandBase
	{
		private readonly AddingDbViewModel addingDbViewModel;
		private readonly IOdbcService odbcService;
		private readonly INotificationService notificationService;

		public NewConnectionCommand(AddingDbViewModel addingDbViewModel, IOdbcService odbcService, INotificationService notificationService)
		{

			this.addingDbViewModel = addingDbViewModel;
			this.odbcService = odbcService;
			this.notificationService = notificationService;
		}


		protected override async Task ExecuteAsync(object parameter)
		{

			//if file is not chosen, return error
			if (addingDbViewModel.FileName == null) { addingDbViewModel.ErrorFileFormatMessage = "Brak wybranego pliku !"; return; }

			string hdr = addingDbViewModel.IncludeHeaders ? "Yes" : "No";
			string imex_ = addingDbViewModel.Imex.ToString();
			addingDbViewModel.db.ConnectionString = addingDbViewModel.db.ConnectionString.Replace("[HDR]", hdr); //set HDR in connecting string
			addingDbViewModel.db.ConnectionString = addingDbViewModel.db.ConnectionString.Replace("[IMEX]", imex_);//set IMEX in connecting string
			if (addingDbViewModel.Password.Length > 0) addingDbViewModel.db.ConnectionString = addingDbViewModel.db.ConnectionString + "Jet OLEDB:Database Password=" + addingDbViewModel.Password;

			{
				try
				{

					addingDbViewModel.AddNewConnButtonIsVisib = Visibility.Hidden;
					addingDbViewModel.SpinnerVisibilty = Visibility.Visible;

					await Task.Run(async () =>
					{
						addingDbViewModel.db.Tables = await odbcService.GetTablesFromFile(addingDbViewModel.db.ConnectionString);

					});


					addingDbViewModel._appStore.Databases.ToList().ForEach(x => x.IsActive = false);
					addingDbViewModel._appStore.Databases.Add(addingDbViewModel.db);
					addingDbViewModel.CloseAction();
					notificationService.AddNotificaton(NotificationsType.Succes, 3, "The new database has been added successfully");


				}
				catch

				{
					addingDbViewModel.AddNewConnButtonIsVisib = Visibility.Visible;
					addingDbViewModel.SpinnerVisibilty = Visibility.Hidden;
					addingDbViewModel.MainErrorMessage = "Problem with connection to " + addingDbViewModel.FileName;
					notificationService.AddNotificaton(NotificationsType.Error, 5, "Problem with connection to " + addingDbViewModel.FileName);
				}

			}
		}

	}
}
