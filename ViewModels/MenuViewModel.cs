using SqlStudioPROD;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace SqlStudioPROD {
     public class MenuViewModel:BaseViewModel {

        #region FIELDS  
        #endregion

        public ApplicationStore _appStore;
        public MenuViewModel(ApplicationStore appStore) {


            AddConnection = new RelayCommand(AddNewDatabase);
            _appStore = appStore;
            ExportGridToExcel = new ExportGridToExcelCommand(this, new HelperService(),new NotificationService());
      

        }

        #region COMMANDS  
        #endregion
        public ICommand AddConnection { get; set; }
        public ICommand ExportGridToExcel { get; set; }
       

        #region FUNCTIONS  
        #endregion

        public void AddNewDatabase() {
            AddingDatabase ad = new AddingDatabase();
            AddingDbViewModel vm = new AddingDbViewModel(_appStore);
            ad.DataContext = vm;
            ad.Show();

            
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(ad.Close);

        }

     
    }
}
