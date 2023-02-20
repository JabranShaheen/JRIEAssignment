using EntitiesAbstraction.Entities;
using EntityManagerAbstraction;
using RepositoryAbstraction.Repositories;
using System;
using System.Collections.Generic;

namespace EntityManager
{
    public class UserProfileManager : IUserProfileManager<UserProfile>
    {
        IEntityRepository<LocalSystemBranch> _localSystemBranchRepositoy;
        IEntityRepository<UserAccess> _userAccessRepositoy;
        IEntityRepository<UserProfile> _userProfileRepositoy;
        public UserProfileManager   (
                                        IEntityRepository<LocalSystemBranch> localSystemBranchRepositoy, 
                                        IEntityRepository<UserAccess> userAccess, 
                                        IEntityRepository<UserProfile> userProfileRepositoy
                                    ) 
        {
            _localSystemBranchRepositoy=localSystemBranchRepositoy;
            _userAccessRepositoy = userAccess;
            _userProfileRepositoy=userProfileRepositoy;
        }        

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

        public UserProfile GetNewUser(int id)
        {
            UserProfile userProfile = new UserProfile();
            List<LocalSystemBranch> localSystemBranchList = new List<LocalSystemBranch>();
            List<UserAccess> lserAccessList = new List<UserAccess>();

            userProfile.LocalSystemBranchList  =localSystemBranchList;
            userProfile.UserAccessList =lserAccessList; 

            return userProfile;
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
