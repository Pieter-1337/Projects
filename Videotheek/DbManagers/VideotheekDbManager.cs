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
   public  class VideotheekDbManager
    {
        private static ConnectionStringSettings conVideotheekSetting = ConfigurationManager.ConnectionStrings["Videotheek"];
        private static DbProviderFactory factory = DbProviderFactories.GetFactory(conVideotheekSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conVideotheek = factory.CreateConnection();
            conVideotheek.ConnectionString = conVideotheekSetting.ConnectionString;
            return conVideotheek;
        }
    }
}
