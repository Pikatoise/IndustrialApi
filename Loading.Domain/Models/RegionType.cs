namespace Loading.Domain.Models
{
    public class RegionType
    {
        public int Id {  get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Region> Regions { get; set;}

        public RegionType()
        {
            Regions = new List<Region>();
        }
    }
}
