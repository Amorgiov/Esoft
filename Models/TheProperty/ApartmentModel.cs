using Models.TheProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApartmentModel
    {
        public int Id { get; set; }

        public int Floor { get; set; }

        public int RoomCount { get; set; }

        public int Square { get; set; }

        /*public AddressModel Address { get; set; }*/
    }
}
