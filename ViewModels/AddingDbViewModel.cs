using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using System.Linq;
using System.Windows;
using System.Threading;
using SqlStudioPROD;


namespace SqlStudioPROD {
    public class AddingDbViewModel : BaseViewModel {

        #region FIELDS
        public  ApplicationStore _appStore;
        private string password;
        private string filePath;
        private string fileName;
        private bool includeHeaders;
        private int imex;
        private FileType fileType;
        private string errFileMessage;
        private string mainErrMessage;
        private Visibility spinnerVisibility;
        private Visibility addNewConnBtnIsVis;
        private bool spinnerIsSpin;
        private bool imexIsEnabled;
        private bool hdrIsEnabled;
        private bool passwordIsEnabled;

        public DatabaseModel db;
        public Action CloseAction { get; set; }
        #endregion

        public AddingDbViewModel(ApplicationStore appStore) {

            db = new DatabaseModel();
            AddNewConnectionCommand = new NewConnectionCommand(this, new OdbcService(),new NotificationService());
            OpenFileDialogCommand = new OpenFileDialogCommand(this, new GuiService());
            _appStore = appStore;
            Password = "";
            IncludeHeaders = true;
            ErrorFileFormatMessage = "";
            SpinnerVisibilty = Visibility.Hidden;
            SpinnerIsSpin = true;
            AddNewConnButtonIsVisib = Visibility.Visible;
            ImexIsEnabled = false;
            HdrIsEnabled = false;
            PasswordIsEnabled = false;

          
        }

        #region PROPERTIES  
        
        public string FilePath 
        {
            get { return filePath; }

            set {
                filePath = value;
                db.FilePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }
        public string FileName   
        {
            get { return fileName; }

            set {
                fileName = value;
                db.Name = value;
                OnPropertyChanged(nameof(FileName));
            }
        }
        public bool IncludeHeaders {
            get { return includeHeaders; }

            set {
                includeHeaders = value;
                db.IncludeHeaders = value;
                OnPropertyChanged(nameof(IncludeHeaders));
            }
        }
        public int Imex {
            get { return imex; }

            set {
                imex = value;
                db.Imex = value;
                OnPropertyChanged(nameof(Imex));
            }
        }
        public string Password 
        { 
            get { return password; }
            
            set 
            {
                password = value;
                db.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorFileFormatMessage {
            get { return errFileMessage; }

            set {
                errFileMessage = value;
                OnPropertyChanged(nameof(ErrorFileFormatMessage));
            }
        }
        public string MainErrorMessage {
            get { return mainErrMessage; }

            set {
                mainErrMessage = value;
                OnPropertyChanged(nameof(MainErrorMessage));
            }
        }
        public FileType DbType 
        {

            get { return fileType; }

            set {
                fileType = value;
                OnPropertyChanged(nameof(DbType));
            }
        }
        public Visibility SpinnerVisibilty {
            get { return spinnerVisibility; }

            set {
                spinnerVisibility = value;
                OnPropertyChanged(nameof(SpinnerVisibilty));
            }
        }
        public Visibility AddNewConnButtonIsVisib {
            get { return addNewConnBtnIsVis; }

            set {
                addNewConnBtnIsVis = value;
                OnPropertyChanged(nameof(AddNewConnButtonIsVisib));
            }
        }
        public bool SpinnerIsSpin 
        {
            get { return spinnerIsSpin; }

            set {
                spinnerIsSpin = value;
                OnPropertyChanged(nameof(SpinnerIsSpin));
            }
        }
        public bool ImexIsEnabled {
            get { return imexIsEnabled; }

            set {
                imexIsEnabled = value;
                OnPropertyChanged(nameof(ImexIsEnabled));
            }
        }
        public bool HdrIsEnabled {
            get { return hdrIsEnabled; }

            set {
                hdrIsEnabled = value;
                OnPropertyChanged(nameof(HdrIsEnabled));
            }
        }
        public bool PasswordIsEnabled {
            get { return passwordIsEnabled; }

            set {
                passwordIsEnabled = value;
                OnPropertyChanged(nameof(PasswordIsEnabled));
            }
        }


        #endregion

        #region COMMANDS  

        public ICommand AddNewConnectionCommand { get; set; }
        public ICommand OpenFileDialogCommand { get; set; }

        #endregion

    
       

      
    }
}
