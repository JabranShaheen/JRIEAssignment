namespace EntitiesAbstraction.Entities
{
    public class UserLevelCategory : IEntity
    {
        public int UserLevelCategoryId { get; set; }

        public string UserLevelCategoryName { get; set; }

        public int? UserLevelCategoryLocalSystemId { get; set; }

    }
}
