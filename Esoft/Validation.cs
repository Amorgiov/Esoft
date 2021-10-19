using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esoft
{
    public static class Validation
    {
        public static string UserPattern { get; set; } = @"^[a-zA-Z][a-zA-Z0-9-_\\.]{1,20}$";

        public static string PhonePattern { get; set; } = @"^((8|\+7)[\-]?)?(\(?\d{3}\)?[\-]?)?[\d\-]{7,10}$";

        public static string SharePattern { get; set; } = @"^[0-9][0-9]?$|^100|";

        //public static string CoordinatePattern { get; set; } 
    }
}
