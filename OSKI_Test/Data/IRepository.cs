namespace OSKI_Test.Data
{
    public interface IRepository<TEntity>
    {
        TEntity ReadById(int id);

        List<TEntity> ReadAll();

        void Create(TEntity ent);

        void Delete(int id);

        TEntity Update(TEntity ent);

    }
}
