namespace EntitiesAbstraction.Entities
{
    public class LocalSystemBranch : IEntity
    {
        public int LocalSystemBranchId { get; set; }

        public int? LocalSystemBranchStatus { get; set; }

        public int? LocalSystemBranchUserProfileId { get; set; }

        public int? LocalSystemBranchLocalSystemId { get; set; }

        public string LocalSystemBranchCode { get; set; }

    }
}
