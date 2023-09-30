namespace Loading.Api.DTO
{
    [Serializable]
    public class CreateRegionData
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int RegionTypeId {  get; set; }
    }
}
