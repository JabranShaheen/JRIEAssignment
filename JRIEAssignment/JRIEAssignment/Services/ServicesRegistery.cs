using EntitiesAbstraction.Entities;
using EntityManager;
using EntityManagerAbstraction;
using Repository;
using RepositoryAbstraction.Repositories;

namespace JRIEAssignment.Services
{
    public static class ServicesRegistery
    {
        
        public static IEntityRepository<LocalSystem> LocalSystemRepository =  new LocalSystemRepository();
        public static IEntityRepository<Branch> BranchRepository = new BranchRepository();
        public static IEntityRepository<UserLevelCategory> UserLevelCategoryRepository = new UserLevelCategoryRepository();
        public static IUserProfileManager UserProfileManager = new UserProfileManager(new UserProfileRepository());
    }
}