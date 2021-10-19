using Models.TheProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HouseModel
    {
        public int Id { get; set; }

        public int FloorCount { get; set; }

        public int RoomCount { get; set; }

        public int Square { get; set; }

        public AddressModel Adress { get; set; }
        
        public int AdressId { get; set; }

        public CoordinatesModel Coord { get; set; }

        public int CoordId { get; set; }
    }
}
