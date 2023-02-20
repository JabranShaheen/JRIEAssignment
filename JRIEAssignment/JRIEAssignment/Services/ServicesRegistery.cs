using EntitiesAbstraction.Entities;
using EntityManagerAbstraction;
using Repository;
using RepositoryAbstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JRIEAssignment.Services
{
    public static class ServicesRegistery
    {
        public static IUserProfileManager UserProfileManager;
        public static IEntityRepository<LocalSystem> LocalSystemRepository =  new LocalSystemRepository();
        public static IEntityRepository<Branch> BranchRepository = new BranchRepository();
        public static IEntityRepository<UserLevelCategory> UserLevelCategoryRepository = new UserLevelCategoryRepository();
        
    }
}