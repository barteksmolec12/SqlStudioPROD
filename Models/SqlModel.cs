using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStudioPROD
{
	public class SqlModel
	{
		public SqlModel()
		{
			ReturnedDataSet = new DataTable();
		}
		public DataTable ReturnedDataSet { get; set; }
		public bool AnyErrors { get; set; }
		public string ReturnedMessage { get; set; }
		public string QueryTime { get; set; }
	}
}
