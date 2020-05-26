using CommonLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DBContext
{
    public class ParkingLotDBContext : DbContext
    {
        public ParkingLotDBContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<ParkingLotDetails> ParkingDetail { get; set; }
        public DbSet<UserRegistration> UserDetail { get; set; }


        public DbSet<VehicleUnPark> VehicleUnPark { get; set; }
    }
}
