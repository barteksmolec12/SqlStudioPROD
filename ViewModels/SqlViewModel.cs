using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using SqlStudioPROD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SqlStudioPROD{
    public class SqlViewModel : BaseViewModel {


        #region FIELDS

        private readonly ApplicationStore _appStore;
        private ObservableCollection<DatabaseModel> databases_;
        private string _sqlQuery;
        private DatabaseModel dbModel;
        private DataTable retTable;
        private TextDocument document;
        private bool errTabSelected;
        private bool dtGridSelected;
        private string message;
        private Visibility spinnerIsVisib;

        #endregion

        #region PROPERTIES

        public string SelectedTextt { get; set; }
        public ObservableCollection<DatabaseModel> Databases {
            get { return databases_; }

            set {
                databases_ = value;
   
            }
        }
        public DatabaseModel ActiveDatabase 
         {
            get { return dbModel; }

            set {
                dbModel = value;
                OnPropertyChanged(nameof(ActiveDatabase));
            }
        }
        public DataTable ReturnedTable 
         {
            get { return retTable; }
            set {
                retTable = value;
                OnPropertyChanged(nameof(ReturnedTable));
                _appStore.ReturnedTable = value;
                
            }
        }
        public string SqlQuery 
        {
            get { return _sqlQuery; }
            set {
                _sqlQuery = value;
                OnPropertyChanged(nameof(SqlQuery));
            }
        }
        public TextDocument Document 
        {
            get { return document; }
            set {
                document = value;
                OnPropertyChanged(nameof(Document));
            }
        }
        public bool ErrorTabIsSelected 
        {
            get { return errTabSelected; }
            set {
                errTabSelected = value;
                OnPropertyChanged(nameof(ErrorTabIsSelected));
            }
        }
        public bool DataGridTabIsSelected 
        {
            get { return dtGridSelected; }
            set {
                dtGridSelected = value;
                OnPropertyChanged(nameof(DataGridTabIsSelected));
            }
        }
        public string MessageSql {
            get { return message; }
            set {
                message = value;
                OnPropertyChanged(nameof(MessageSql));
            }
        }
        public Visibility SpinnerIsVisible {
            get { return spinnerIsVisib; }
            set {
                spinnerIsVisib = value;
                OnPropertyChanged(nameof(SpinnerIsVisible));
            }
        }

        #endregion

        #region COMMANDS
        public ICommand ExecuteQueryCommand { get; set; }
        #endregion

        #region CONSTRUCTOR
        public SqlViewModel(ApplicationStore appStore) {

           
             _appStore = appStore;
            Databases = new ObservableCollection<DatabaseModel>();
            Databases = appStore.Databases; //Loading all previous connections, which were being configured by user
                                            // ExecuteQueryCommand = new RelayCommand(ExecuteQuery);
            ExecuteQueryCommand = new ExecuteSqlQueryCommand(this, new OdbcService(),new NotificationService());
            Document = new TextDocument();
            ReturnedTable = new DataTable();
            DataGridTabIsSelected = true;
            ErrorTabIsSelected = false;
            SpinnerIsVisible = Visibility.Hidden;
            //SelectedTextt = "";
        }

        #endregion



    }
}
