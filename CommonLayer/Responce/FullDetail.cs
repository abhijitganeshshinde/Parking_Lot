using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Responce
{
    public class FullDetail
    {
        public int Receipt_Number { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        [Required(ErrorMessage = "Wrong Field Name Please Write Vehicle_Owner_Name")]
        public string Vehicle_Owner_Name { get; set; }

        [RegularExpression(@"^(([A-Za-z]){2}(|-)(?:[0-9]){1,2}(|-)(?:[A-Za-z]){2}(|-)([0-9]){1,4})|(([A-Za-z]){2,3}(|-)([0-9]){1,4})$")]
        [Required(ErrorMessage = "Wrong Field Name Please Write Vehicles_Number")]
        public string Vehicle_Number { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write Brand")]
        [RegularExpression(@"^[A-Z][a-z]*$")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write Color")]
        [RegularExpression(@"^[A-Z][a-z]*$")]
        public string Color { get; set; }

        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        [Required(ErrorMessage = "Wrong Field Name Please Write Driver_Name")]
        public string Driver_Name { get; set; }

        [RegularExpression(@"^([A-Z]){1,2}$")]
        [Required(ErrorMessage = "Wrong Field Name Please Write Parking_Slot")]
        public string Parking_Slot { get; set; }

        public string Status { get; set; }

        public System.DateTime ParkingDate { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write UserType")]
        [RegularExpression(@"^Admin|^Security$|^Police$|^Driver$")]
        public string User_Type { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write Password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }


        public int VehicleUnParkID { get; set; }

        public System.DateTime UnParkDate { get; set; }

        public double TotalTime { get; set; }

        public double Total_Amount { get; set; }
    }
}
