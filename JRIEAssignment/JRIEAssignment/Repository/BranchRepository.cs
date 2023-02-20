using EntitiesAbstraction.Entities;
using RepositoryAbstraction.Repositories;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class BranchRepository : IEntityRepository<Branch>
    {
        public void Delete(Branch EntityData)
        {
            throw new NotImplementedException();
        }

        public Branch Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Branch> GetAll(Branch EntityData)
        {
            throw new NotImplementedException();
        }

        public void Insert(Branch EntityData)
        {
            throw new NotImplementedException();
        }

        public void Update(Branch EntityData)
        {
            throw new NotImplementedException();
        }
    }
}