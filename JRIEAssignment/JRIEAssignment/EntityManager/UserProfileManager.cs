using EntitiesAbstraction.Entities;
using EntityManagerAbstraction;
using Repository;
using RepositoryAbstraction.Repositories;
using System;
using System.Collections.Generic;

namespace EntityManager
{
    public class UserProfileManager : IUserProfileManager
    {
        IEntityRepository<UserProfile> _userProfileRepositoy;
        public UserProfileManager   (
                                        IEntityRepository<UserProfile> userProfileRepositoy
                                    ) 
        {
            _userProfileRepositoy=userProfileRepositoy;
        }        

        public object Delete(UserProfile EntityData)
        {
            throw new NotImplementedException();
        }

        public UserProfile Get(int id)
        {
            return _userProfileRepositoy.Get(id);            
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return _userProfileRepositoy.GetAll();
        }

        public UserProfile GetNewUser()
        {
            UserProfile userProfile = new UserProfile();
            List<LocalSystemBranch> localSystemBranchList = new List<LocalSystemBranch>();
            List<UserAccess> lserAccessList = new List<UserAccess>();
            userProfile.UserProfileId = -1;
            userProfile.LocalSystemBranchList  =localSystemBranchList;
            userProfile.UserAccessList =lserAccessList; 

            return userProfile;
        }

        public object Insert(UserProfile EntityData)
        {
            return _userProfileRepositoy.Insert(EntityData);
        }

        public object Update(UserProfile EntityData)
        {
            throw new NotImplementedException();
        }

    }
}
