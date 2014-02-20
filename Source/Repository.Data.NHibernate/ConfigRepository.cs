using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Entity;
using System.Data;
using Repostiory.Data.Interface;
using NHibernate;

namespace Repostiory.Data.Hiberante
{
    public class ConfigRepository : IConfigRepository
    {
        private string _connectionString;
        private readonly ISessionFactory _sessionFactory;

        public ConfigRepository(ISessionFactory sessionFactory, string connectionString)
        {
            _connectionString = connectionString;
            this._sessionFactory = sessionFactory;
        }
        //public ConfigRepository()
        //{
        //    _connectionString = @"Data Source=.\sqlexpress; Database=Repository;Integrated Security=true;";
        //}


        public Config Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Config Get(string name)
        {
            throw new NotImplementedException();
          
        }
        public IEnumerable<Config> Get()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var configs = session.CreateCriteria(typeof(Config))
                    .List<Config>() ;
                return configs;
            }
        }
    }
}
