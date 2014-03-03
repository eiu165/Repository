using System;
using System.Collections.Generic; 
using Framework.Entity;
using NHibernate;
using NHibernate.Criterion;

namespace Framework.Data.Repository
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : DomainEntity<TId>
    {
        private IUnitOfWork _unitOfWork; 

        public Repository()
        {}

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IList<Order> _orders = new List<Order>();
        public IList<Order> Orders 
        {
            get
            {
                return _orders;
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
            set
            {
                _unitOfWork = value;
            }
        }

        /// <summary>
        /// Retrieves an instance of type T from the DB based on its ID.
        /// </summary>
        public TEntity GetById(TId id, bool shouldLock)
        {
            TEntity entity;

            if (shouldLock)
            {
                entity = (TEntity)Session.Get<TEntity>(id, LockMode.Upgrade);
            }
            else
            {
                entity = (TEntity)Session.Get<TEntity>(id);
            }

            return entity;
        }

        public IList<TEntity> GetByIds(params TId[] ids)
        {
            return this.GetByCriteria(Restrictions.In("ID", ids));
        }

        public void EnsureUsable(DomainEntity<long> domainEntity)
        {
            NHibernateUtil.Initialize(domainEntity);
        }

        /// <summary>
        /// Creates a Proxy for a known entity of type T in the database.  Will throw ObjectNotFoundException
        /// if the entity doesn't exist in the persistent store on SaveOrUpdate and Delete operations.
        /// </summary>
        /// <returns>Proxy for type T</returns>
        public TEntity GetKnownById(TId id, bool shouldLock)
        {
            TEntity entity;

            if (shouldLock)
            {
                entity = (TEntity)Session.Load<TEntity>(id, LockMode.Upgrade);
            }
            else
            {
                entity = (TEntity)Session.Load<TEntity>(id);
            }

            return entity;
        }

        /// <summary>
        /// Loads every instance of the requested type with no filtering.
        /// </summary>
        public virtual IList<TEntity> GetAll()
        {
            return GetByCriteria();
        }
         
        /// <summary>
        /// Loads every instance of the requested type using the supplied <see cref="ICriterion" />.
        /// If no <see cref="ICriterion" /> is supplied, this behaves like <see cref="GetAll" />.
        /// </summary>
        protected internal virtual IList<TEntity> GetByCriteria(params ICriterion[] criterion)
        {
            ICriteria criteria = Session.CreateCriteria(persistentType);

            foreach (ICriterion criterium in criterion)
            {
                criteria.Add(criterium);
            }

            foreach (Order order in Orders)
            {
                criteria.AddOrder(order.ToNHibernateOrder());
            }

            return criteria.List<TEntity>() as List<TEntity>;
        }
         

        public virtual IList<TEntity> GetByExample(TEntity exampleInstance, params string[] propertiesToExclude)
        {
            return GetByExample(exampleInstance, false, propertiesToExclude);
        }

        public virtual void ThrowAway(TEntity exampleInstance)
        {
            this.Session.Evict(exampleInstance);
        }

        public virtual IList<TEntity> GetByExample(TEntity exampleInstance, bool enableLike, params string[] propertiesToExclude)
        {
            ICriteria criteria = Session.CreateCriteria(persistentType);
            Example example = Example.Create(exampleInstance);
            
            if (enableLike)
            {
                example.EnableLike();
            }

            foreach (string propertyToExclude in propertiesToExclude)
            {
                example.ExcludeProperty(propertyToExclude);
            }

            criteria.Add(example);

            return criteria.List<TEntity>() as List<TEntity>;
        }

        public virtual IList<TEntity> GetByAssociation(string associationProperty, object associationEntity)
        {
            ICriteria criteria = Session.CreateCriteria(persistentType)
                .Add(Restrictions.Eq(associationProperty, associationEntity));
                
            foreach (var order in Orders)
            {
                criteria.AddOrder(order.ToNHibernateOrder());
            }

            return criteria.List<TEntity>() as List<TEntity>;
        }

        public virtual int GetAssociationCount(TEntity exampleInstance, string associationProperty, Type associationEntity)
        {
            return Session.CreateCriteria(associationEntity)
                .Add(Restrictions.Eq(associationProperty, exampleInstance))
                .SetProjection(Projections.Count(associationProperty))
                .UniqueResult<int>();
        }
         
        /// <summary>
        /// Looks for a single instance using the example provided.
        /// </summary>
        /// <exception cref="NonUniqueResultException" />
        public virtual TEntity GetUniqueByExample(TEntity exampleInstance, params string[] propertiesToExclude)
        {
            IList<TEntity> foundList = GetByExample(exampleInstance, propertiesToExclude);

            if (foundList.Count > 1)
            {
                throw new NonUniqueResultException(foundList.Count);
            }

            if (foundList.Count > 0)
            {
                return foundList[0];
            }

            return default(TEntity);
        }

        /// <summary>
        /// Looks for a single instance using the example provided.
        /// </summary>
        /// <exception cref="NonUniqueResultException" />
        public virtual TEntity GetUniqueByExample(TEntity exampleInstance, bool enableLike, params string[] propertiesToExclude)
        {
            IList<TEntity> foundList = GetByExample(exampleInstance, enableLike, propertiesToExclude);

            if (foundList.Count > 1)
            {
                throw new NonUniqueResultException(foundList.Count);
            }

            if (foundList.Count > 0)
            {
                return foundList[0];
            }

            return default(TEntity);
        }

        /// <summary>
        /// For entities that have assigned ID's, you must explicitly call Save to add a new one.
        /// See http://www.hibernate.org/hib_docs/reference/en/html/mapping.html#mapping-declaration-id-assigned.
        /// </summary>
        public virtual TEntity Save(TEntity entity)
        {
            Session.Save(entity);
            return entity;
        }

        /// <summary>
        /// For entities with automatatically generated IDs, such as identity, SaveOrUpdate may 
        /// be called when saving a new entity.  SaveOrUpdate can also be called to update any 
        /// entity, even if its ID is assigned.
        /// </summary>
        public virtual TEntity SaveOrUpdate(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            Session.Update(entity);
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            Session.Delete(entity);
        }

        /// <summary>
        /// Exposes the ISession used within the DAO.
        /// </summary>
        internal ISession Session
        {
            get
            {
                return _unitOfWork.CurrentSession;
            }
        }

        private Type persistentType = typeof (TEntity);
    }

    public class Order
    {
        private NHibernate.Criterion.Order _order;

        public Order(string propertyName, bool isAscending)
        {
            _order = new NHibernate.Criterion.Order(propertyName, isAscending);
        }

        public NHibernate.Criterion.Order ToNHibernateOrder()
        {
            return _order;
        }
    }



}


