using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SqlStudioPROD {
    public class OdbcService : IOdbcService 

    {
        public async Task <List<TableModel>> GetTablesFromFile(string connectionString) 
        {
            List<TableModel> tbl_list_ = new List<TableModel>();

            //create connection with database file
            OleDbConnection MyConnection = new OleDbConnection(connectionString);
            await MyConnection.OpenAsync();

            //load all tables in database file
            DataTable schemaTbl = MyConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


            // Display the table name from each row in the schema  
            foreach (DataRow row in schemaTbl.Rows) {
                TableModel tblModel = new TableModel();

                string tableName = (row["TABLE_NAME"]).ToString();
                tblModel.TableName = tableName; //add table name
                DataTable schemaCols = MyConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName, null });
                List<ColumnModel> col_list_ = new List<ColumnModel>();

                foreach (DataRow col in schemaCols.Rows) //add all columns names for current table
                {
                    string colName = (col["COLUMN_NAME"]).ToString();
                    ColumnModel colModel = new ColumnModel();
                    colModel.Name = colName;
                    col_list_.Add(colModel);
                }

                tblModel.Columns = col_list_;
                tbl_list_.Add(tblModel);
            }

             MyConnection.Close();
            return tbl_list_;
        }

        public async Task <SqlModel> RunSqlQuery(string query, string connectionString) 
        {

            SqlModel sql = new SqlModel();
            OleDbConnection MyConnection = new OleDbConnection(connectionString);
            await MyConnection.OpenAsync();

            try {
                var timer = new Stopwatch();
                timer.Start();

                OleDbDataAdapter MyCommand = new OleDbDataAdapter(query, MyConnection);
                MyCommand.Fill(sql.ReturnedDataSet);

                timer.Stop();

                sql.QueryTime = timer.ElapsedMilliseconds.ToString();
                sql.ReturnedMessage = "Sukces";
                sql.AnyErrors = false;
            } catch (Exception e) {
                sql.ReturnedMessage = "Błąd: " + e.Message;
                sql.AnyErrors = true;

            } finally {  MyConnection.Close(); }
            return sql;
        }

        public string SetSqlQueryFromDocument(string SqlQuery,TextDocument Document) {

            
                
            SqlQuery = "";
            string temp_query;
            var lines = Document.Lines;
            foreach (var line in lines) {
                temp_query = "";
                temp_query = Document.GetText(line.Offset, line.TotalLength).Trim();
                if (temp_query != "") { SqlQuery = SqlQuery + temp_query + " "; }

            }

            SqlQuery.Trim();
            return SqlQuery;
        }
    }
}
