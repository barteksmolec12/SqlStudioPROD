using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStudioPROD
{
	public class ExportGridToExcelCommand : AsyncCommandBase
	{
		private readonly MenuViewModel menuViewModel;
		private readonly IHelperService helperService;
		private readonly INotificationService notificationService;

		public ExportGridToExcelCommand(MenuViewModel menuViewModel, IHelperService helperService, INotificationService notificationService)
		{ 

			this.menuViewModel = menuViewModel;
			this.helperService = helperService;
			this.notificationService = notificationService;
		}
		protected override async Task ExecuteAsync(object parameter)
		{


			try
			{
				ExportDataModel model = new ExportDataModel();
				await Task.Run(() =>
				{
					 model = helperService.ExportDataGrid(menuViewModel._appStore.ReturnedTable); //saving data grid on excel file
				});
				

				if (model.UserClickCancel == false)

				{
					if (model.AnyErrors == false)
					{
						notificationService.AddNotificaton(NotificationsType.Succes, 3, model.Message); //adding notification with succes on right bottom corner
					}
					else
					{
						notificationService.AddNotificaton(NotificationsType.Error, 4, model.Message); //adding notification with error on right bottom corner
					}
				}





			}
			catch
			{

				//when notififcation won't show - it's not crtical error
			}

		}
	}
}
