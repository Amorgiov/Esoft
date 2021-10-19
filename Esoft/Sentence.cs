using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Esoft
{
    public partial class Sentence
    {
        public Sentence()
        {
            Deal = new HashSet<Deal>();
        }

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? RealtorId { get; set; }
        public decimal? Cost { get; set; }
        public string TypeOfProperty { get; set; }
        public bool? State { get; set; }
        public int? HouseId { get; set; }
        public int? ApartId { get; set; }
        public int? PlotId { get; set; }

        public virtual Apartments Apart { get; set; }
        public virtual Clients Client { get; set; }
        public virtual Houses House { get; set; }
        public virtual LandPlots Plot { get; set; }
        public virtual Realtors Realtor { get; set; }
        public virtual ICollection<Deal> Deal { get; set; }
    }
}
