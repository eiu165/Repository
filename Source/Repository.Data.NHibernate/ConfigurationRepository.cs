using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Entity;

namespace Repostiory.Data.Interface
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public ConfigurationRepository()
        {

        }
        public Configuration Get(int Id)
        {
            throw new NotImplementedException();
        }
        public Configuration Get(string name)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Configuration> Get()
        {
            throw new NotImplementedException();
        }
    }
}
