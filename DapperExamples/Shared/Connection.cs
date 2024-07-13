using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExamples.Share;

public class Connection
{
    #region Connection

    public static SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "MTKDotNetCore",
        UserID = "sa",
        Password = "sasa@123",
        TrustServerCertificate = true
    };

    #endregion
}
