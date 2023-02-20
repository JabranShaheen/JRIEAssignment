using RepositoryAbstraction.Repositories;
using EntitiesAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using JRIEAssignment.Repository.SQLDataProvider;

namespace Repository
{
    internal class UserLevelCategoryRepository :SQLDataProvider,  IEntityRepository<UserLevelCategory>
    {
        public void Delete(UserLevelCategory EntityData)
        {
            throw new NotImplementedException();
        }

        public UserLevelCategory Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserLevelCategory> GetAll()
        {
            List<UserLevelCategory> UserLevelCategories = new List<UserLevelCategory>();
            var data = GetData("SELECT [UserLevelCategoryId] ,[UserLevelCategoryName] ,[UserLevelCategoryLocalSystemId] FROM [Assignment].[dbo].[UserLevelCategory] (NOLOCK)");
            foreach (DataRow aRow in data.Rows)
            {
                var UserLevelCategory = new UserLevelCategory() { UserLevelCategoryId = aRow.Field<int>("UserLevelCategoryId"), UserLevelCategoryName = aRow.Field<string>("UserLevelCategoryName") , UserLevelCategoryLocalSystemId = aRow.Field<int>("UserLevelCategoryLocalSystemId"), };
                UserLevelCategories.Add(UserLevelCategory);
            }
            return UserLevelCategories;
        }

        public void Insert(UserLevelCategory EntityData)
        {
            throw new NotImplementedException();
        }

        public void Update(UserLevelCategory EntityData)
        {
            throw new NotImplementedException();
        }
    }
}
