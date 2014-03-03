namespace Framework.Entity
{
    public abstract class ConstantLookupObject<TId> : LookupObject<TId>
    {
        public virtual string EnumName { get; set; }        
    }
}
