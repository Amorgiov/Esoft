using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Esoft
{
    public partial class Apartments
    {
        public Apartments()
        {
            Sentence = new HashSet<Sentence>();
        }

        public int Id { get; set; }
        public int? Floor { get; set; }
        public int? RoomCount { get; set; }
        public int? Square { get; set; }
        public int? AddressId { get; set; }
        public int? CoordId { get; set; }
        public bool? State { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Coordinates Coord { get; set; }
        public virtual ICollection<Sentence> Sentence { get; set; }
    }
}
