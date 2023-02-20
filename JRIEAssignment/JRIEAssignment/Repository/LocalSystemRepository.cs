using RepositoryAbstraction.Repositories;
using EntitiesAbstraction.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using JRIEAssignment.Repository.SQLDataProvider;
using System.Data;

namespace Repository
{
    internal class LocalSystemRepository : SQLDataProvider, IEntityRepository<LocalSystem> 
    {
        public void Delete(LocalSystem EntityData)
        {
            throw new NotImplementedException();
        }

        public LocalSystem Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocalSystem> GetAll()
        {
            List<LocalSystem> localSystems = new List<LocalSystem>();
            var data = GetData("SELECT LocalSystemId, LocalSystemName FROM LocalSystem (NOLOCK)");
            //Looping through each record
            foreach (DataRow aRow in data.Rows)
            {
                var localSystem = new LocalSystem() { LocalSystemId = aRow.Field<int>("LocalSystemId"), LocalSystemName = aRow.Field<string>("LocalSystemName") };
                localSystems.Add(localSystem);
            }
            return localSystems;
        }

        public void Insert(LocalSystem EntityData)
        {
            throw new NotImplementedException();
        }

        public void Update(LocalSystem EntityData)
        {
            throw new NotImplementedException();
        }
    }
}
