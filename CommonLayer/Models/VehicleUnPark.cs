using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Models
{
    public class VehicleUnPark
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleUnParkID { get; set; }


        [ForeignKey("ParkingLotDetails")]
        public int Receipt_Number { get; set; }

        public string Status { get; set; }
        public System.DateTime UnParkDate { get; set; }

        public double TotalTime { get; set; }

        public double Total_Amount { get; set; }
    }
}
