using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStudioPROD
{
	public class TableModel
	{
		public int ID { get; set; }
		public int IdDatabase { get; set; }
		public string TableName { get; set; }
		public List<ColumnModel> Columns { get; set; }
	}
}
