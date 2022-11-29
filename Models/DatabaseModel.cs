using SqlStudioPROD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SqlStudioPROD
{
	public class DatabaseModel
	{
		public DatabaseModel()
		{
			IsActive = true;
			QueryTime = 30;
			Imex = -1;
		}
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public bool IsActive { get; set; }
		public bool IncludeHeaders { get; set; }
		public int Imex { get; set; }
		public string FilePath { get; set; }
		public int QueryTime { get; set; }
		public FileType DbType { get; set; }
		public List<TableModel> Tables { get; set; }
		public string ConnectionString { get; set; }
		public string IconPath { get; set; }

	
	}
}
