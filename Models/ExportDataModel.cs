using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStudioPROD
{
	public class ExportDataModel
	{
		public ExportDataModel()
		{
			AnyErrors = false;
			UserClickCancel = false;
		}
		public bool AnyErrors { get; set; }
		public string Message { get; set; }
		public bool UserClickCancel { get; set; }
	}
}
