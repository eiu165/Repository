using Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class Config : DomainEntity<Int32>
    { 
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        public virtual string Description { get; set; }



        public override int GetHashCode()
        {
            return (this.GetType().FullName + "|" + this)
                .GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(
                "Id:{0}  Name:{1} Value:{2}",
                 Id,     Name,    Value); 
        }

    }
}
