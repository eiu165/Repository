using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Configuration
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual string Description { get; set; }


        public override string ToString()
        {
            return string.Format(" Id:{0}  Name:{1} value:{2}", this.Id, this.Name, this.Value);
        }
    }
}
