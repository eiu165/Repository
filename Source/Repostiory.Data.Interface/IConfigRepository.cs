using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repostiory.Data.Interface
{
    public interface IConfigRepository
    {
        Config Get(string name);
        IEnumerable<Config> Get();
    }
}
