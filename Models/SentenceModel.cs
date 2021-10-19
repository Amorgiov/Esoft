using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SentenceModel
    {
        public int Id { get; set; }

        public Decimal Cost { get; set; }

        public ClientModel Client { get; set; }

        public RealtorModel Realtor { get; set; }

        public HouseModel House { get; set; }

        public ApartmentModel Apartment { get; set; }

        public LandPlot Plot { get; set; }
    }
}
