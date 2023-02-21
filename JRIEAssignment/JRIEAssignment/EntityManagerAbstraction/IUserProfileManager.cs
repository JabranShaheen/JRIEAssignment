using EntitiesAbstraction.Entities;

namespace EntityManagerAbstraction
{
    public interface IUserProfileManager : IEntityManager<UserProfile> 
    {
        UserProfile GetNewUser();
    }
}