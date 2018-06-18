using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;


namespace DbManagers
{
    public class TuinCentrumDbManager
    {
        private static ConnectionStringSettings conTuinCentrumSetting = ConfigurationManager.ConnectionStrings["Tuincentrum"];
        private static DbProviderFactory factory = DbProviderFactories.GetFactory(conTuinCentrumSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conTuinCentrum = factory.CreateConnection();
            conTuinCentrum.ConnectionString = conTuinCentrumSetting.ConnectionString;
            return conTuinCentrum;
        }
    }
}
