using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommonLayer.DBContext;
using CommonLayer.Models;
using CommonLayer.Responce;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using ParkingLot.Controllers;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using Xunit;

namespace ParkingLotXUnitTestCases
{
    public class ParkingLotTestCases
    {
        ParkingLotsController ParkingLotsController;
        UserController UserController;

        private readonly IParkingLotBusiness _parkingLotBusiness;
        private readonly IParkingLotRepository parkingLotRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserBusiness _userBusiness;
        private readonly IConfiguration configuration;
        public static DbContextOptions<ParkingLotDBContext> dbContextOptions { get; }

        public static string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ParkingLot;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static ParkingLotTestCases()
        {
            dbContextOptions = new DbContextOptionsBuilder<ParkingLotDBContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public ParkingLotTestCases()
        {
            var context = new ParkingLotDBContext(dbContextOptions);

            userRepository = new UserRepository(context);
            _userBusiness = new UserBusiness(userRepository);

            parkingLotRepository = new ParkingLotRepository(context);
            _parkingLotBusiness = new ParkingLotBusiness(parkingLotRepository);


            IConfigurationBuilder _configuration = new ConfigurationBuilder();

            _configuration.AddJsonFile("appsettings.json");
            configuration = _configuration.Build();

            ParkingLotsController = new ParkingLotsController(_parkingLotBusiness);
            UserController = new UserController(_userBusiness, configuration);
        }


        [Fact]
        public void Get_AllParkingData_ReturnOKResult()
        {
            var okResult = ParkingLotsController.GetAllParkingCarsDetails();

            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public void Get_CarDetailByCarNumber_ReturnOKResult()
        {

            var okResult = ParkingLotsController.GetCarDetailsByVehicleNumber("MH-12-AA-9841");

            Assert.IsType<OkObjectResult>(okResult);

        }


        [Fact]
        public void Get_CarDetailByCarNumber_ReturnBadRequest()
        {

            var badRequest = ParkingLotsController.GetCarDetailsByVehicleNumber("");

            Assert.IsType<BadRequestObjectResult>(badRequest);
        }


        [Fact]
        public void Get_CarDetailByCarBrand_ReturnOKResult()
        {
            var okResult = ParkingLotsController.GetCarDetailsByVehicleBrand("Jaguar");
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_CarDetailByCarBrand_ReturnBadRequest()
        {
            var badRequest = ParkingLotsController.GetCarDetailsByVehicleBrand("");
            Assert.IsType<BadRequestObjectResult>(badRequest);
        }


        [Fact]
        public void Get_CarDetailByParkingSlot_ReturnOKResult()
        {
            var okResult = ParkingLotsController.GetCarDetailsByParkingSlot("A");
            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public void Get_CarDetailByParkingSlot_ReturnBadRequest()
        {
            var okResult = ParkingLotsController.GetCarDetailsByParkingSlot("");
            Assert.IsType<BadRequestObjectResult>(okResult);
        }


        [Fact]
        public void AddingParkingDetails_ReturnOKResult()
        {

            ParkingLotDetails details = new ParkingLotDetails()
            {
                Vehicle_Owner_Name = "Abhi",
                Vehicle_Number = "MH-12-AA-9116",
                Brand = "Jaguar",
                Color = "Black",
                Driver_Name = "RamuKaka",
                Parking_Slot = "A",
                ParkingDate = DateTime.Now,
                Status = "Park"

            };

            // Act
            var okResult = ParkingLotsController.CarDetailsForParking(details);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void AddingParkingDetails_ReturnBadRequest()
        {


            ParkingLotDetails details = new ParkingLotDetails()
            {
                Vehicle_Owner_Name = "Abhi",
                Brand = "Jaguar",
                Color = "Black",
                Driver_Name = "RamuKaka",
                Parking_Slot = "A",
                ParkingDate = DateTime.Now,
                Status = "Park"

            };

            // Act
            var badRequest = ParkingLotsController.CarDetailsForParking(details);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequest);
        }



        [Fact]
        public void UnParkDetails_ReturnOKResult()
        {

            VehicleUnPark details = new VehicleUnPark()
            {
                Receipt_Number = 1013

            };

            // Act
            var okResult = ParkingLotsController.CarUnPark(details);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public void UnParkDetails_ReturnBadRequest()
        {

            VehicleUnPark details = new VehicleUnPark()
            {
                Receipt_Number = 1

            };

            // Act
            var badRequest = ParkingLotsController.CarUnPark(details);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequest);
        }


        [Fact]
        public void CarUnParkDetails_ReturnOKResult()
        {
            // Act
            var okResult = ParkingLotsController.GetUnParkCarDetail();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public void DeleteParkingDetails_ReturnOKResult()
        {
            // Act
            var okResult = ParkingLotsController.DeleteCarParkingDetails(12106);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public void DeleteParkingDetails_ReturnBadRequest()
        {

            // Act
            var badRequest = ParkingLotsController.DeleteCarParkingDetails(1);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequest);
        }


        // For UserController

        [Fact]
        public void GetUserDetails_ReturnOKResult()
        {
            UserController controller = new UserController(_userBusiness, configuration);

            var okResult = controller.GetAllUserDetails();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public void UserLogin_ReturnOKResult()
        {
            UserController controller = new UserController(_userBusiness, configuration);

            Login details = new Login()
            {
                UserName = "abhi",
                Password = "abhi123",
                User_Type = "Admin"

            };
            // Act
            var okResult = UserController.UserLogin(details);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public void UserLogin_ReturnBadRequest()
        {

            Login details = new Login()
            {
                UserName = "abhi",
                Password = "abhi123"

            };
            // Act
            var badRequest = UserController.UserLogin(details);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequest);
        }

        [Fact]
        public void UserRegistration_ReturnOKResult()
        {

            var details = new UserRegistration()
            {
                UserName = "yoshika1",
                Email = "yoshika1@gmail.com",
                Password = "yoshika",
                User_Type = "Admin"

            };

            var okResult = UserController.UserRegistration(details);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void UserRegistration_ReturnBadRequest()
        {

            var details = new UserRegistration()
            {
                UserName = "yoshika1",
                Email = "yoshika1@gmail.com",
                Password = "yoshika",
                User_Type = "Admin"

            };

            //Act
            var badRequest = UserController.UserRegistration(details);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequest);
        }
    }
}
