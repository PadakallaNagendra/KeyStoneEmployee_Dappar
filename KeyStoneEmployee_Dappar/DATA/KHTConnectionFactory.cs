using KeyStoneEmployee_Dappar.InterFace;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace KeyStoneEmployee_Dappar.DATA
{
    public class KHTConnectionFactory : IKHTConnectionFactary
    {
        public readonly IOptions<KHTConfiguration> _options;
        IConfiguration _config;
        public KHTConnectionFactory(IOptions<KHTConfiguration> options)
        {
            _options = options;
        }

        public IDbConnection GetHotal()
        {
            //string connectionstring ="data source=DESKTOP-NORDVAN\\MSSQLSERVER01;integrated security=sspi;initial catalog=NagendraDB";
            IDbConnection _connection = new SqlConnection(Convert.ToString(_config.GetSection("ConnectionStrings")["hotelmanagementSqlConnectionString"]));
          //  IDbConnection dbConnection=new SqlConnection(connectionstring);
            return _connection;
        
        }
    }
}
