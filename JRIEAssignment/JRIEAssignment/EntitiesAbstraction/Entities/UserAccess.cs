namespace EntitiesAbstraction.Entities
{
    public class UserAccess : IEntity
    {
        public int UserAccessId { get; set; }

        public int? UserAccessStatus { get; set; }

        public int? UserAccessUserProfileId { get; set; }

        public int? UserAccessLocalSystemId { get; set; }

        public int? UserAccessUserLevelCategoryId { get; set; }

    }
}
