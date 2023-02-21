using EntitiesAbstraction.Entities;
using JRIEAssignment.Repository.SQLDataProvider;
using RepositoryAbstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repository
{
    public class BranchRepository :SQLDataProvider, IEntityRepository<Branch>
    {
        public object Delete(Branch EntityData)
        {
            throw new NotImplementedException();
        }

        public Branch Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Branch> GetAll()
        {
            List<Branch> branches = new List<Branch>();
            var data = GetData("SELECT BranchCode, BranchName FROM Branch (NOLOCK)");
            foreach (DataRow dataRow in data.Rows)
            {
                var branch = new Branch() { BranchCode = dataRow.Field<string>("BranchCode"), BranchName = dataRow.Field<string>("BranchName") };
                branches.Add(branch);
            }
            return branches;
        }

        public object Insert(Branch EntityData)
        {
            throw new NotImplementedException();
        }

        public object Update(Branch EntityData)
        {
            throw new NotImplementedException();
        }
    }
}