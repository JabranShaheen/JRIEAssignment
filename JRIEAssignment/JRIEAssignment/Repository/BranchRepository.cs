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
        public void Delete(Branch EntityData)
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
            foreach (DataRow aRow in data.Rows)
            {
                var branch = new Branch() { BranchCode = aRow.Field<string>("BranchCode"), BranchName = aRow.Field<string>("BranchName") };
                branches.Add(branch);
            }
            return branches;
        }

        public void Insert(Branch EntityData)
        {
            throw new NotImplementedException();
        }

        public void Update(Branch EntityData)
        {
            throw new NotImplementedException();
        }
    }
}