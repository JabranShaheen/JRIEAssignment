using EntitiesAbstraction;
using System;
using System.Collections.Generic;

namespace EntityManagerAbstraction
{
    public interface IUserProfileManager<T> where T : IEntity
    {
        T GetNewUser(int id);
        IEnumerable<T> GetAll(T EntityData);
        T Get(int id);
        void Insert(T EntityData);
        void Delete(T EntityData);
        void Update(T EntityData);
    }
}