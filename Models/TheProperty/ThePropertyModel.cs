using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ThePropertyModel
    {
        public HouseModel HouseId { get; set; }

        public ApartmentModel ApartId { get; set; }

        public LandPlot PlotId { get; set; }
    }
}
