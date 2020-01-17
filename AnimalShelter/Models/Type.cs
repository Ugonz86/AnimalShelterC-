using System.Collections.Generic;

namespace AnimalShelter.Models
{
    public class TypeClass
    {
        public TypeClass()
        {
            this.DetailGroup = new HashSet<Detail>();
        }

        public int TypeClassId { get; set; }
        public string Name { get; set; }
        // public int RestaurantId { get; set; }
        public virtual ICollection<Detail> DetailGroup { get; set; }
    }
}