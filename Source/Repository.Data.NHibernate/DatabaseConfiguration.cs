using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Hibernate
{
    public class DatabaseConfiguration
    {
        private static string  _connectionString = @"Data Source=.\sqlexpress; Database=Repository;Integrated Security=true;";

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                //.ConnectionString(c => c.FromConnectionStringWithKey("aaaaaaaaaaaaaa")))
                .ConnectionString(_connectionString))  
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DatabaseConfiguration>())
            .BuildSessionFactory();
        }
    }
}
