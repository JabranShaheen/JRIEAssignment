using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace EntitiesAbstraction.Entities
{
    public class UserLevelCategory : IEntity
    {
        public int UserLevelCategoryId { get; set; }

        public string UserLevelCategoryName { get; set; }

        public int? UserLevelCategoryLocalSystemId { get; set; }

    }
}
