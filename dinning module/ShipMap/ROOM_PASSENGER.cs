using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipMap
{
    class ROOM_PASSENGER
    {
        public int room_id { get; set; }
        public int pass_id { get; set; }
        public int trip_id { get; set; }
        public bool isBillHolder { get; set; }
        public int roomPass_id { get; set; }
    }
}
