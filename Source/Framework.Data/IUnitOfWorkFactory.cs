namespace Framework.Data
{
    public interface IUnitOfWorkFactory
    {
        #region Public Methods and Operators

        IUnitOfWork Create();

        #endregion
    }
}