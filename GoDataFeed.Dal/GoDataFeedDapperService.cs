using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

namespace GoDataFeed.Dal
{
    public class GoDataFeedDapperService
    {
        private readonly static string DbConn = "GoDataFeedDbConnection";

        public Retailer Get(long id)
        {
            Retailer retailer = null;
            using (var connection = GetConn())
            {
                retailer = connection.Query<Retailer>("select * from dbo.retailer where id = @id", new { id = id }).First();
            }
            return retailer;
        }

        public IEnumerable<Retailer> GetAll()
        {
            var connection = GetConn();
            return connection.Query<Retailer>("select * from dbo.retailer");
        }

        internal static IDbConnection GetConn()
        {
            string databaseConnectionString = ConfigurationManager.ConnectionStrings[DbConn].ConnectionString;
            IDbConnection connection = new SqlConnection(databaseConnectionString);
            connection.Open();
            return connection;
        }
    }
}
