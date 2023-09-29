namespace Loading.Domain.Models
{
    public class Manufacturer
    {
        public int Id {  get; set; }

        public string Name { get; set; }

        public ICollection<Equipment> Equipments { get; set; }

        public Manufacturer()
        {
            Equipments = new List<Equipment>();
        }
    }
}
