using RepositoryAbstraction.Repositories;
using EntitiesAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    internal class UserProfileRepository : IEntityRepository<UserProfile>
    {
        public void Delete(UserProfile EntityData)
        {
            throw new NotImplementedException();
        }

        public UserProfile Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProfile> GetAll(UserProfile EntityData)
        {
            throw new NotImplementedException();
        }

        public void Insert(UserProfile EntityData)
        {
            throw new NotImplementedException();
        }

        public void Update(UserProfile EntityData)
        {
            throw new NotImplementedException();
        }
    }
}
