using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Framework.Data.Repository;

namespace Framework.Data
{
    public partial interface IUnitOfWork : IDisposable
    {
        ISession CurrentSession { get; }
        void Commit();
        void Rollback();
        void Enlist(IRepository repository);
    }
}
