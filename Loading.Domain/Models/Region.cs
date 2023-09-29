namespace Loading.Domain.Models
{
    public class Region
    {
        public string Code { get; set; }

        public int RegionTypeId { get; set; }

        public RegionType RegionType { get; set; } = null!;

        public string Name { get; set; }
    }
}
