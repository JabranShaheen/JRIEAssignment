using EntitiesAbstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityManagerAbstraction
{
    public interface IEntityManager<T> where T : IEntity
    {
        IEnumerable<T> GetAll(T EntityData);
        T Get(int id);
        void Insert(T EntityData);
        void Delete(T EntityData);
        void Update(T EntityData);
    }
}
