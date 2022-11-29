using SqlStudioPROD;
using SqlStudioPROD.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace SqlStudioPROD
{
	public class DatabaseViewModel:BaseViewModel {

        private readonly ApplicationStore _appStore;
        public ObservableCollection<DatabaseModel> Databases { get; set; }
		public string MyProperty { get; set; }
		public DatabaseViewModel(ApplicationStore appStore) {

            _appStore = appStore;
            Databases = new ObservableCollection<DatabaseModel>();
			DeleteConnectionCommand = new RemoveConnectionCommand(this);
			Databases = appStore.Databases;


        }

		public ICommand DeleteConnectionCommand { get; set; }

	}
}
