namespace Customer.Datalayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity Read(int entityID);
        void Update(TEntity entity);
        void Delete(int entityID);
    }
}
