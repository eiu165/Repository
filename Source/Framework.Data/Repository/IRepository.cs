namespace Framework.Data.Repository
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; set; }
    }
}
