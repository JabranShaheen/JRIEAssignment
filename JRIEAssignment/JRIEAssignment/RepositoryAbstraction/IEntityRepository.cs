using EntitiesAbstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryAbstraction.Repositories
{
    public interface IEntityRepository <T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        object Insert(T EntityData);
        object Delete(T EntityData);
        object Update(T EntityData);
    }
}
