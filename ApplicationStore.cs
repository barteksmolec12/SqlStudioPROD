using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;

namespace SqlStudioPROD {
    public class ApplicationStore {


        public ObservableCollection<DatabaseModel> Databases { get; set; }
        public DataTable ReturnedTable { get; set; }
        
        public ApplicationStore() {
			Databases = new ObservableCollection<DatabaseModel>();
        }
 
      
     


    }
}
