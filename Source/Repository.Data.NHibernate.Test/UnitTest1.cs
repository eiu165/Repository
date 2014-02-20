namespace Repository.Data.Hibernate.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repository.Data.Hibernate;
    using Repostiory.Data.Interface;
    using  NHibernate ;
    using Repository.Entity;
    
     
    [TestClass]
    public class UnitTest1
    {
        private static NHibernate.ISessionFactory _sessionFactory;

        [TestInitialize()]
        public void SetupTest()
        {
            _sessionFactory = DatabaseConfiguration.CreateSessionFactory();
        }
         



        [TestMethod]
<<<<<<< HEAD:Source/Repository.Data.NHibernate.Test/UnitTest1.cs
        public void TestMethod1()
        {
=======
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
                }
            }
>>>>>>> d5eaa23... change the namespace:Source/Repository.Data.NHibernate.Test/ConfigRepositoryTest.cs
        }
    }
}
