namespace AnimalShelter.Models
{
    public class Detail
    {
        public int DetailId { get; set; }
        public string Description { get; set; }

        public int TypeClassId { get; set; }
        public virtual TypeClass TypeClass { get; set; }
    }
}