namespace Repository.Data.Hibernate.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repository.Data.Hibernate;
    using Repostiory.Data.Interface;
    using  NHibernate ;
    using Repository.Entity;
    
     
    [TestClass]
    public class ConfigRepositoryTest 
    {
        private static NHibernate.ISessionFactory _sessionFactory;

        [TestInitialize()]
        public void SetupTest()
        {
            _sessionFactory = DatabaseConfiguration.CreateSessionFactory();
        }
         



        [TestMethod]
        public void GetByName_validName_GetsRecord()
        { 
            using (var session = _sessionFactory.OpenSession())
            {
                //using ( var transaction= session.BeginTransaction())
                { 
                    var configs = session.CreateCriteria(typeof(Config))
                        .List<Config>() ; 
                    foreach(var config in configs)
                    {
                        Console.WriteLine(config.ToString());
                    } 
                    Assert.AreEqual(3, configs.Count);
                }
            }
        }
    }
}
