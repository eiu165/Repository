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
    public class ConfigurationRepository : IConfigurationRepository
    {
<<<<<<< HEAD:Source/Repository.Data.NHibernate/ConfigurationRepository.cs
        public ConfigurationRepository()
        {
=======
        private string _connectionString;
        private readonly ISessionFactory _sessionFactory;
>>>>>>> d5eaa23... change the namespace:Source/Repository.Data.NHibernate/ConfigRepository.cs

        public ConfigRepository(ISessionFactory sessionFactory, string connectionString)
        {
            _connectionString = connectionString;
            this._sessionFactory = sessionFactory;
        }
<<<<<<< HEAD:Source/Repository.Data.NHibernate/ConfigurationRepository.cs
        public Configuration Get(int Id)
        {
            throw new NotImplementedException();
        }
        public Configuration Get(string name)
=======
        //public ConfigRepository()
        //{
        //    _connectionString = @"Data Source=.\sqlexpress; Database=Repository;Integrated Security=true;";
        //}


        public Config Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Config Get(string name)
>>>>>>> d5eaa23... change the namespace:Source/Repository.Data.NHibernate/ConfigRepository.cs
        {
            throw new NotImplementedException();
          
        }
        public IEnumerable<Configuration> Get()
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
