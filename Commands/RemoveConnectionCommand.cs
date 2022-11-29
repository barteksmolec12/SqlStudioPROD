using DocumentFormat.OpenXml.EMMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace SqlStudioPROD.Commands
{
	public class RemoveConnectionCommand : AsyncCommandBase

	{
		private readonly DatabaseViewModel addingDbViewModel;

		public RemoveConnectionCommand(DatabaseViewModel addingDbViewModel)
		{
			this.addingDbViewModel = addingDbViewModel;
		}

		protected override async Task ExecuteAsync(object parameter)
		{
			// TO_DO :)
			await Task.Run(() =>
			{
				//ONLY TEST
				var z = 3 / 1;
				Console.WriteLine(z);
			});

		}
	}
}
