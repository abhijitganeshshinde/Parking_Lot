using BusinessLayer.Interface;
using CommonLayer.Models;
using CommonLayer.Responce;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using ParkingLot.Controllers;
using System;
using Xunit;

namespace ParkingLotXUnitTestCases
{
    public class ParkingLotTestCases
    {
        ParkingLotsController ParkingLotsController;
        UserController UserController;
        private readonly Mock<IParkingLotBusiness> parkingLotBusiness;
        private readonly Mock<IUserBusiness> userBusiness;
        private readonly Mock<IConfiguration> _configuration;

        public ParkingLotTestCases()
        {
            parkingLotBusiness = new Mock<IParkingLotBusiness>();
            userBusiness = new Mock<IUserBusiness>();
            _configuration = new Mock<IConfiguration>();
            ParkingLotsController = new ParkingLotsController(parkingLotBusiness.Object);
            UserController = new UserController(userBusiness.Object, _configuration.Object);
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
            var okResult = ParkingLotsController.GetCarDetailsByVehicleNumber("MH-12-AA-9122");
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_CarDetailByCarBrand_ReturnOKResult()
        {
            var okResult = ParkingLotsController.GetCarDetailsByVehicleBrand("Jaguar");
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_CarDetailByParkingSlot_ReturnOKResult()
        {
            var okResult = ParkingLotsController.GetCarDetailsByParkingSlot("A");
            Assert.IsType<OkObjectResult>(okResult);
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
        public void UnParkDetails_ReturnOKResult()
        {
            VehicleUnPark details = new VehicleUnPark()
            {
                Receipt_Number = 11

            };

            // Act
            var okResult = ParkingLotsController.CarUnPark(details);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
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
            var okResult = ParkingLotsController.DeleteCarParkingDetails(12);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }


        // For UserController

        [Fact]
        public void GetUserDetails_ReturnOKResult()
        {

            // Act
            var okResult = UserController.GetAllUserDetails();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void UserLogin_ReturnOKResult()
        {
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
        public void UserRegistration_ReturnOKResult()
        {
            UserRegistration details = new UserRegistration()
            {
                UserName = "abhi",
                Email = "abhi@gmail.com",
                Password = "abhi123",
                User_Type = "Admin"

            };

            // Act
            var okResult = UserController.UserRegistration(details);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
