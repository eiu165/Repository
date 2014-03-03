namespace Framework.Entity
{
    public abstract class DomainEntity<TId>  : IAuditable, IEntity
    {
        /// <summary>
        /// ID may be of type string, int, custom type, etc.
        /// Setter is protected to allow unit tests to set this property via reflection and to allow 
        /// domain objects more flexibility in setting this for those objects with assigned IDs.
        /// </summary>
        public virtual TId Id { get; protected set; }

        public virtual Audit Audit { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as DomainEntity<TId>;

            return (compareTo != null) &&
                   (HasSameNonDefaultIdAs(compareTo) ||
                    // Since the IDs aren't the same, either of them must be transient to 
                    // compare business value signatures
                    (((IsTransient) || compareTo.IsTransient) &&
                     HasSameBusinessSignatureAs(compareTo)));
        }

        /// <summary>
        /// Transient objects are not associated with an item already in storage.  For instance,
        /// a <see cref="User" /> is transient if its Id is 0.  This really is more data related but really 
        /// needs the hook into the entities
        /// </summary>
        public virtual bool IsTransient
        {
            get
            {
                return Id == null || Id.Equals(default(TId));
            }
        }

        /// <summary>
        /// Must be provided to properly compare two objects
        /// </summary>
        public abstract override int GetHashCode();

        private bool HasSameBusinessSignatureAs(DomainEntity<TId> compareTo)
        {
            return GetHashCode().Equals(compareTo.GetHashCode());
        }

        /// <summary>
        /// Returns true if self and the provided persistent object have the same ID values 
        /// and the IDs are not of the default ID value
        /// </summary>
        private bool HasSameNonDefaultIdAs(DomainEntity<TId> compareTo)
        {
            return (Id != null && !Id.Equals(default(TId))) &&
                   (compareTo.Id != null && !compareTo.Id.Equals(default(TId))) &&
                   Id.Equals(compareTo.Id);
        }
    }
}