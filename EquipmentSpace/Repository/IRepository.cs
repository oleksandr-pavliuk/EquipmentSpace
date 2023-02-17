namespace EquipmentSpace.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T item);
        T Read(Func<T, bool> predicate);
    }
}
