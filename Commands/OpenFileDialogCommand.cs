using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace SqlStudioPROD
{
	public class OpenFileDialogCommand : AsyncCommandBase
	{

		private readonly AddingDbViewModel addingDbViewModel;
		private readonly IGuiService guiService;

		public OpenFileDialogCommand(AddingDbViewModel addingDbViewModel, IGuiService guiService)
		{

			this.addingDbViewModel = addingDbViewModel;
			this.guiService = guiService;
		}

		protected override async Task ExecuteAsync(object parameter)
		{

			try
			{
				AddFileModel model = new AddFileModel();
				addingDbViewModel.ErrorFileFormatMessage = "";

				await Task.Run(() =>
				{
					model = guiService.OpenFileDialog();
					if (model.AnyErrors == true)
					{
						addingDbViewModel.ErrorFileFormatMessage = "Format file is incorrect !";
					}
					else
					{
						addingDbViewModel.FileName = model.FileName;
						addingDbViewModel.FilePath = model.FilePath;
						addingDbViewModel.DbType = model.FileType;
						addingDbViewModel.db.IconPath = model.IconPath;
						addingDbViewModel.db.ConnectionString = model.ConnectionString;

						if (model.FileType != FileType.MDB & model.FileType != FileType.ACCDB)
						{
							addingDbViewModel.ImexIsEnabled = true;
							addingDbViewModel.HdrIsEnabled = true;
							addingDbViewModel.PasswordIsEnabled = false;
						}
						else
						{
							addingDbViewModel.PasswordIsEnabled = true;
						}
					}


				});


			}
			catch (Exception)
			{

				addingDbViewModel.ErrorFileFormatMessage = "";

			}


		}


	}
}

