using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Esoft
{
    public partial class Addresses
    {
        public Addresses()
        {
            Apartments = new HashSet<Apartments>();
            Houses = new HashSet<Houses>();
            LandPlots = new HashSet<LandPlots>();
            Needs = new HashSet<Needs>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public virtual ICollection<Apartments> Apartments { get; set; }
        public virtual ICollection<Houses> Houses { get; set; }
        public virtual ICollection<LandPlots> LandPlots { get; set; }
        public virtual ICollection<Needs> Needs { get; set; }
    }
}
