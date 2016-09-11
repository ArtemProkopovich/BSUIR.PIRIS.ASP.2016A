using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using CM = System.Configuration.ConfigurationManager;

namespace DAL
{
    public class ConfigurationManager : IConfigurationManager
    {
        public string ConnectionName { get; private set; }
        public ConfigurationManager()
        {
            this.ConnectionName = "DbContext";
        }     
        public string GetConnectionString()
        {
            return CM.ConnectionStrings[ConnectionName].ConnectionString;
        }
    }
}
