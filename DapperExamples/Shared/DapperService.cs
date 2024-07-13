using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperExamples.Share;

public class DapperService
{
    #region ExecuteQuery

    public void ExecuteQuery(string query, object item, string successMessage, string failMessage)
    {
        using IDbConnection db = new SqlConnection(Connection.connectionString.ConnectionString);
        int result = db.Execute(query, item);
        string message = result > 0 ? successMessage : failMessage;
        Console.WriteLine(message);
    }

    #endregion
}
