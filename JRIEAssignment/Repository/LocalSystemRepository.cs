using RepositoryAbstraction.Repositories;
using EntitiesAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    internal class LocalSystemRepository : IEntityRepository<LocalSystem>
    {
        public void Delete(LocalSystem EntityData)
        {
            throw new NotImplementedException();
        }

        public LocalSystem Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocalSystem> GetAll(LocalSystem EntityData)
        {
            throw new NotImplementedException();
        }

        public void Insert(LocalSystem EntityData)
        {
            throw new NotImplementedException();
        }

        public void Update(LocalSystem EntityData)
        {
            throw new NotImplementedException();
        }
    }
}
