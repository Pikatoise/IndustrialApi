namespace Loading.Api.DTO
{
    [Serializable]
    public class ChangeEquipmentData
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? ManufacturerId { get; set; }
    }
}
