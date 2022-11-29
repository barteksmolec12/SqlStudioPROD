
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlStudioPROD {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {

            //DatabasesViewModel db = new DatabasesViewModel();
            //DataContext = new SqlViewModel();
            InitializeComponent();
            LoadSqlSyntaxHighlighting();
            
        }
        private void LoadSqlSyntaxHighlighting() {
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SqlStudioPROD.Resources.SQL.xshd")) {
                using (var reader = new System.Xml.XmlTextReader(stream)) {
                    sql_query_textarea.SyntaxHighlighting =
                        ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(reader,
                        ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance);
                }
            }
        }

    
       

    }
}
