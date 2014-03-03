using System.Collections.Generic;

using Framework.Entity;

namespace Framework.Data.Repository
{
    using System;
     

    public interface IRepository<TEntity, TId> : IRepository
        where TEntity : DomainEntity<TId>
    {
        TEntity GetById(TId id, bool shouldLock);

        IList<TEntity> GetByIds(params TId[] ids);

        TEntity GetKnownById(TId id, bool shouldLock);

        IList<TEntity> GetAll();
         

        IList<TEntity> GetByExample(TEntity exampleInstance, params string[] propertiesToExclude);

        IList<TEntity> GetByExample(TEntity exampleInstance, bool enableLike, params string[] propertiesToExclude);

        TEntity GetUniqueByExample(TEntity exampleInstance, bool enableLike, params string[] propertiesToExclude);

        IList<TEntity> GetByAssociation(string associationProperty, object associationEntity);

        int GetAssociationCount(TEntity exampleInstance, string associationProperty, Type associationEntity);
         

        TEntity GetUniqueByExample(TEntity exampleInstance, params string[] propertiesToExclude);

        TEntity Save(TEntity entity);

        TEntity SaveOrUpdate(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
