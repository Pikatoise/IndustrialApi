namespace Loading.Api.DTO
{
    [Serializable]
    public class ChangeRegionData
    {
        public string Code { get; set; }

        public string? Name { get; set; }

        public int? RegionTypeId { get; set; }
    }
}
