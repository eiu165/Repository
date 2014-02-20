using FluentNHibernate.Mapping;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Hibernate.Mappings
{
    public class ConfigMapping: ClassMap<Config>
    {
        public ConfigMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Value);
            Table("Config");
        }
    }
}
