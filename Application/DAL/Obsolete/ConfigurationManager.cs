using DAL.Interface;
using CM = System.Configuration.ConfigurationManager;

namespace DAL.Obsolete
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
