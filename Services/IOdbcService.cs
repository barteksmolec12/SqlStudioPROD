using ICSharpCode.AvalonEdit.Document;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqlStudioPROD{
    public interface IOdbcService 
    {
        Task <SqlModel> RunSqlQuery(string query, string connectionString);
        Task <List<TableModel>> GetTablesFromFile(string connectionString);

        string SetSqlQueryFromDocument(string SqlQuery,TextDocument Document);
    }
}
