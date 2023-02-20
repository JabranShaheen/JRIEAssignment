using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesAbstraction.Entities
{
    public class LocalSystem : IEntity
    {
        public int? LocalSystemId { get; set; }
        public string LocalSystemName { get; set; }

    }
}
