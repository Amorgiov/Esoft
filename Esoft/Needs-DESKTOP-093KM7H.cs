using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Esoft
{
    public partial class Needs
    {
        public Needs()
        {
            Deal = new HashSet<Deal>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RealtorId { get; set; }
        public string TypeOfProperty { get; set; }
        public int AdressId { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int? MinSquare { get; set; }
        public int? MaxSquare { get; set; }
        public int? MinCountRoom { get; set; }
        public int? MaxCountRoom { get; set; }
        public int? MinFloor { get; set; }
        public int? MaxFloor { get; set; }
        public int? MinCountFloor { get; set; }
        public int? MaxCountFloor { get; set; }
        public bool? State { get; set; }
        public string NeedInfo { get; set; }

        public virtual Addresses Adress { get; set; }
        public virtual Clients Client { get; set; }
        public virtual Realtors Realtor { get; set; }
        public virtual ICollection<Deal> Deal { get; set; }
    }
}
