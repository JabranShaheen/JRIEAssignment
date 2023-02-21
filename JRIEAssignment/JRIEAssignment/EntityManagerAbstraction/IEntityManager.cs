using EntitiesAbstraction;
using System.Collections.Generic;

namespace EntityManagerAbstraction
{
    public interface IEntityManager<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        object Insert(T EntityData);
        object Delete(T EntityData);
        object Update(T EntityData);
    }
}
