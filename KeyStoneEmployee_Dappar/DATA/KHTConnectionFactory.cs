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
        public KHTConnectionFactory(IOptions<KHTConfiguration> options, IConfiguration config)
        {
            _options = options;
            _config= config;
        }

        public IDbConnection GetHotal()
        {
            string connectionstring ="data source=DESKTOP-NORDVAN\\MSSQLSERVER01;integrated security=sspi;initial catalog=NagendraDB";

            //connectionstring reading from appsetting.json file (this is first way)


             IDbConnection _connection = new SqlConnection(Convert.ToString(_config.GetSection("ConnectionStrings")["HotelManageMentSqlConnectionString"]));
            
            //connection string reading from appsetting.json file  (This is second way)



           // IDbConnection _SqlKravyMFScon = new SqlConnection(this._options.Value.HotelManageMentSqlConnectionString);
            return _connection;
        
        }
    }
}
