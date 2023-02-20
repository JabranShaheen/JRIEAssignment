using RepositoryAbstraction.Repositories;
using EntitiesAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    internal class UserAccessRepository : IEntityRepository<UserAccess>
    {
        public void Delete(UserAccess EntityData)
        {
            throw new NotImplementedException();
        }

        public UserAccess Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAccess> GetAll(UserAccess EntityData)
        {
            throw new NotImplementedException();
        }

        public void Insert(UserAccess EntityData)
        {
            throw new NotImplementedException();
        }

        public void Update(UserAccess EntityData)
        {
            throw new NotImplementedException();
        }
    }
}
