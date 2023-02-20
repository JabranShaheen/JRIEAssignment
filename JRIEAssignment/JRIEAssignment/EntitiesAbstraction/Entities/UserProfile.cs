using System;
using System.Collections.Generic;

namespace EntitiesAbstraction.Entities
{
    public class UserProfile : IEntity
    {
        public int UserProfileId { get; set; }
        public int? UserProfileStatus { get; set; }
        public string UserProfileAccount { get; set; }
        public string UserProfileDomainName { get; set; }
        public string UserProfileName { get; set; }
        public string UserProfileMailAddress { get; set; }
        public string UserProfileUserLevelToUserAdmin { get; set; }
        public int? UserProfileOperatorId { get; set; }
        public DateTime? UserProfileTimeStamp { get; set; }

        public List<LocalSystemBranch> LocalSystemBranchList;
        public List<UserAccess> UserAccessList;

    }
}