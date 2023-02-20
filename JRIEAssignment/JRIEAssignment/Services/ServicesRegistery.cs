using EntitiesAbstraction.Entities;
using EntityManagerAbstraction;
using Repository;
using RepositoryAbstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JRIEAssignment.Services
{
    public static class ServicesRegistery
    {
        public static IUserProfileManager userProfileManager;
        public static IEntityRepository<LocalSystem> localSystemRepository =  new LocalSystemRepository();

    }
}