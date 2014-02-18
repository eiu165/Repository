using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repostiory.Data.Interface
{
    public interface IConfigurationRepository
    {
        Configuration Get(int Id);
        Configuration Get(string name);
        IEnumerable<Configuration> Get();
    }
}
