using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStudioPROD
{
	public class AddFileModel

	{
		public string FileName { get; set; }
		public string FilePath { get; set; }
		public string IconPath { get; set; }
		public FileType FileType { get; set; }
		public bool AnyErrors { get; set; }
		public string ConnectionString { get; set; }

	}
}
