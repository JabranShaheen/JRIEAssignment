using RepositoryAbstraction.Repositories;
using EntitiesAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using JRIEAssignment.Repository.SQLDataProvider;
using System.Linq;

namespace Repository
{
    internal class UserProfileRepository : SQLDataProvider, IEntityRepository<UserProfile>
    {
        public void Delete(UserProfile EntityData)
        {
            throw new NotImplementedException();
        }

        public UserProfile Get(int id)
        {
            UserProfile userProfile;

            var data = GetData("SELECT [UserProfileId] ,[UserProfileStatus] ,[UserProfileAccount] ,[UserProfileDomainName] ,[UserProfileName] ,[UserProfileMailAddress] ,[UserProfileUserLevelToUserAdmin] ,[UserProfileOperatorId] ,[UserProfileTimeStamp] FROM [Assignment].[dbo].[UserProfile](NOLOCK) WHERE UserProfileId = " + id.ToString());

            userProfile = new UserProfile() { 
                
                UserProfileId = data.Rows[0].Field<int>("UserProfileId"),
                UserProfileStatus = data.Rows[0].Field<int>("UserProfileStatus"),
                UserProfileAccount = data.Rows[0].Field<string>("UserProfileAccount"),
                UserProfileDomainName = data.Rows[0].Field<string>("UserProfileDomainName"),
                UserProfileName = data.Rows[0].Field<string>("UserProfileName"),
                UserProfileMailAddress = data.Rows[0].Field<string>("UserProfileMailAddress"),
                UserProfileUserLevelToUserAdmin = data.Rows[0].Field<string>("UserProfileUserLevelToUserAdmin"),
                UserProfileOperatorId = data.Rows[0].Field<int>("UserProfileOperatorId"),
                UserProfileTimeStamp = data.Rows[0].Field<DateTime>("UserProfileTimeStamp")
            };
                        

            userProfile.LocalSystemBranchList = new List<LocalSystemBranch>();

            var localSystemBranchData = GetData("SELECT [LocalSystemBranchId] ,[LocalSystemBranchStatus] ,[LocalSystemBranchUserProfileId] ,[LocalSystemBranchLocalSystemId] ,[LocalSystemBranchCode] FROM [Assignment].[dbo].[LocalSystemBranch] (NOLOCK) WHERE LocalSystemBranchUserProfileId = " + id.ToString());

            foreach (DataRow dataRow in localSystemBranchData.Rows)
            {
                var localSystemBranch = new LocalSystemBranch
                { 
                    LocalSystemBranchId = dataRow.Field<int>("LocalSystemBranchId"),
                    LocalSystemBranchStatus = dataRow.Field<int>("LocalSystemBranchStatus"),
                    LocalSystemBranchUserProfileId = dataRow.Field<int>("LocalSystemBranchUserProfileId"),
                    LocalSystemBranchLocalSystemId = dataRow.Field<int>("LocalSystemBranchLocalSystemId"),
                    LocalSystemBranchCode = dataRow.Field<string>("LocalSystemBranchCode")
                };
                userProfile.LocalSystemBranchList.Add(localSystemBranch);
            }


            userProfile.UserAccessList = new List<UserAccess>();

            var UserAccessData = GetData("SELECT [UserAccessId] ,[UserAccessStatus] ,[UserAccessUserProfileId] ,[UserAccessLocalSystemId] ,[UserAccessUserLevelCategoryId]  FROM [Assignment].[dbo].[UserAccess] (NOLOCK) WHERE UserAccessUserProfileId = " + id.ToString());

            foreach (DataRow dataRow in UserAccessData.Rows)
            {
                var userAccess = new UserAccess
                {
                    UserAccessId = dataRow.Field<int>("UserAccessId"),
                    UserAccessStatus = dataRow.Field<int>("UserAccessStatus"),
                    UserAccessUserProfileId = dataRow.Field<int>("UserAccessUserProfileId"),
                    UserAccessLocalSystemId = dataRow.Field<int>("UserAccessLocalSystemId"),
                    UserAccessUserLevelCategoryId = dataRow.Field<int>("UserAccessUserLevelCategoryId")
                };

                userProfile.UserAccessList.Add(userAccess);
            }

            return userProfile;
        }

        public IEnumerable<UserProfile> GetAll()
        {
            List<UserProfile> userProfiles = new List<UserProfile>();

            var data = GetData("SELECT [UserProfileId] ,[UserProfileStatus] ,[UserProfileAccount] ,[UserProfileDomainName] ,[UserProfileName] ,[UserProfileMailAddress] ,[UserProfileUserLevelToUserAdmin] ,[UserProfileOperatorId] ,[UserProfileTimeStamp] FROM [Assignment].[dbo].[UserProfile](NOLOCK)");
            foreach (DataRow dataRow in data.Rows)
            {
                var userProfile = new UserProfile()
                {

                    UserProfileId = dataRow.Field<int>("UserProfileId"),
                    UserProfileStatus = dataRow.Field<int>("UserProfileStatus"),
                    UserProfileAccount = dataRow.Field<string>("UserProfileAccount"),
                    UserProfileDomainName = dataRow.Field<string>("UserProfileDomainName"),
                    UserProfileName = dataRow.Field<string>("UserProfileName"),
                    UserProfileMailAddress = dataRow.Field<string>("UserProfileMailAddress"),
                    UserProfileUserLevelToUserAdmin = dataRow.Field<string>("UserProfileUserLevelToUserAdmin"),
                    UserProfileOperatorId = dataRow.Field<int>("UserProfileOperatorId"),
                    UserProfileTimeStamp = dataRow.Field<DateTime>("UserProfileTimeStamp")
                };

                userProfiles.Add(userProfile);
            }

            return userProfiles;
        }

        public void Insert(UserProfile EntityData)
        {
            string queryString = $@"INSERT INTO [UserProfile]
                                                   ([UserProfileStatus]
                                                   ,[UserProfileAccount]
                                                   ,[UserProfileDomainName]
                                                   ,[UserProfileName]
                                                   ,[UserProfileMailAddress]
                                                   ,[UserProfileUserLevelToUserAdmin]
                                                   ,[UserProfileOperatorId]
                                                   ,[UserProfileTimeStamp])
                                             VALUES
                                                   (
                                                        {0}
                                                       ,'{EntityData.UserProfileAccount}'
                                                       ,'{EntityData.UserProfileDomainName}'
                                                       ,'{EntityData.UserProfileDomainName + @"\" + EntityData.UserProfileName}'
                                                       ,'{EntityData.UserProfileMailAddress}'
                                                       ,'{EntityData.UserProfileUserLevelToUserAdmin}'
                                                       ,{1}
                                                       ,GETDATE()
                                                    )";

            profileId = ;
        }

        public void Update(UserProfile EntityData)
        {
            throw new NotImplementedException();
        }
    }
}
