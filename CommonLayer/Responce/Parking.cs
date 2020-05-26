using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Responce
{
    public class Parking
    {
        public int Receipt_Number { get; set; }


        public string Vehicle_Owner_Name { get; set; }

        public string Vehicle_Number { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public string Driver_Name { get; set; }


        public string Parking_Slot { get; set; }

        public DateTime ParkingDate { get; set; }
    }
}
