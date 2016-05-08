namespace MyDevTools.Dto
{
    public class BranchDto
    {
        public string Name { get; set; }
        public string LastAuthor { get; set; }
        public string LastUpdate { get; set; }
        public string IsMerged { get; set; }
        public string NeedUpdate { get; set; }
        public string IsObsolete { get; set; }
        public string Remote { get; set; }
    }
}
