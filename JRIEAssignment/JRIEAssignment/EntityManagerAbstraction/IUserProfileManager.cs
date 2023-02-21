using EntitiesAbstraction;
using EntitiesAbstraction.Entities;
using System;
using System.Collections.Generic;

namespace EntityManagerAbstraction
{
    public interface IUserProfileManager : IEntityManager<UserProfile> 
    {
        UserProfile GetNewUser();
    }
}