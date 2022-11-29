using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlStudioPROD {
    public interface IHelperService {
        ExportDataModel ExportDataGrid(DataTable dataToExport);
      
    }
}
