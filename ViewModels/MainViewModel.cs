
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlStudioPROD {
   public class MainViewModel:BaseViewModel {
        public SqlViewModel SqlViewModel { get; set; }
        public DatabaseViewModel DatabaseViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        public MainViewModel(SqlViewModel sqlViewModel, DatabaseViewModel dbViewModel, MenuViewModel menuViewModel) {

            SqlViewModel = sqlViewModel;
            DatabaseViewModel = dbViewModel;
            MenuViewModel = menuViewModel;
        }
    }
}
