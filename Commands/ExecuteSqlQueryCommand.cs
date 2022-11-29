using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SqlStudioPROD
{
	public class ExecuteSqlQueryCommand : AsyncCommandBase
	{

		private readonly SqlViewModel sqlViewModel;
		private readonly IOdbcService odbcService;
		private readonly INotificationService notificationService;

		public ExecuteSqlQueryCommand(SqlViewModel sqlViewModel, IOdbcService odbcService, INotificationService notificationService)
		{

			this.sqlViewModel = sqlViewModel;
			this.odbcService = odbcService;
			this.notificationService = notificationService;
		}
		protected override async Task ExecuteAsync(object parameter)
		{

			try
			{

				sqlViewModel.SpinnerIsVisible = Visibility.Visible;
				if (sqlViewModel.ActiveDatabase == null) throw new Exception("Choose a database file !");
				sqlViewModel.SqlQuery = odbcService.SetSqlQueryFromDocument(sqlViewModel.SqlQuery, sqlViewModel.Document);
				SqlModel model = new SqlModel();
				await Task.Run(async () =>
				{
					model = await odbcService.RunSqlQuery(sqlViewModel.SqlQuery, sqlViewModel.ActiveDatabase.ConnectionString);
				});

				if (model.AnyErrors == true)
				{
					sqlViewModel.ErrorTabIsSelected = true;
					sqlViewModel.DataGridTabIsSelected = false;
				}
				else
				{
					sqlViewModel.ReturnedTable = model.ReturnedDataSet;
					sqlViewModel.DataGridTabIsSelected = true;
					sqlViewModel.ErrorTabIsSelected = false;
					notificationService.AddNotificaton(NotificationsType.Succes, 2, "The query was processed correctly. Time: " + model.QueryTime + " ms");
				}

				sqlViewModel.MessageSql = model.ReturnedMessage;

			}

			catch (Exception e)
			{


				sqlViewModel.ErrorTabIsSelected = true;
				sqlViewModel.DataGridTabIsSelected = false;
				sqlViewModel.MessageSql = e.Message;
			}

			finally
			{

				sqlViewModel.SpinnerIsVisible = Visibility.Hidden;

			}


		}
	}
}
