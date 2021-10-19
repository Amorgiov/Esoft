using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Esoft
{
    public partial class Coordinates
    {
        public Coordinates()
        {
            Apartments = new HashSet<Apartments>();
            Houses = new HashSet<Houses>();
            LandPlots = new HashSet<LandPlots>();
        }

        public int Id { get; set; }
        public int? Longitude { get; set; }
        public int? Latitude { get; set; }

        public virtual ICollection<Apartments> Apartments { get; set; }
        public virtual ICollection<Houses> Houses { get; set; }
        public virtual ICollection<LandPlots> LandPlots { get; set; }
    }
}
