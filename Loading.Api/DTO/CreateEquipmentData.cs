namespace Loading.Api.DTO
{
    [Serializable]
    public class CreateEquipmentData
    {
        public string Name { get; set; } = null!;   
        public int? ManufacturerId {  get; set; }
    }
}
