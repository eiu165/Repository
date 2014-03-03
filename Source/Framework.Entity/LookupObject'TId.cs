namespace Framework.Entity
{
    public abstract class LookupObject<TId> : DomainEntity<TId>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
