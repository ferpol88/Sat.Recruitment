using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;

using Xunit;
using Sat.Recruitment.Model;
using Sat.Recruitment.Model.DTO;
using AutoMapper;
using Sat.Recruitment.Services;
using Sat.Recruitment.Services.Repository;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class TestUserController
    {
        private UsersController userController;
        private UserFactory userFactory;
        private UserServices userServices;
        private UserRepository userRepository;

        public TestUserController() {
            SetUpFactory();
        }

        [Fact]
        public async void IsCreatedValidUser()
        {
            UserDTO user = createUserTemplate();
            IActionResult actionResult = await userController.CreateUser(user);
            CreatedResult createdResult = actionResult as CreatedResult;


            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);


        }

        [Fact]
        public async void IsRejectedDuplicatedUser()
        {
            UserDTO user = createUserTemplate(name: "Agustina", email: "Agustina@gmail.com");

            IActionResult result = await userController.CreateUser(user);
            ObjectResult noOkResult = result as ObjectResult;

            Assert.Equal(412, noOkResult.StatusCode);
            Assert.Equal("The user is duplicated", noOkResult.Value);

        }

        [Fact]
        public void IsCreatedNormalUser()
        {
            UserDTO user = createUserTemplate(userType: "normal");
            User userNormal = userServices.CreateUser(user);

            Assert.IsType<NormalUser>(userNormal);
        }

        [Fact]
        public void IsNameCorrectlyCreated()
        {
            UserDTO user = createUserTemplate(name: "fernando");

            User userNormal = userServices.CreateUser(user);

            Assert.Equal("fernando", userNormal.Name);
        }

        [Fact]
        public void IsOkNormalUserMoneyCalculate()
        {
            UserDTO user = createUserTemplate(money: 20000);
            User userNormal = userServices.CreateUser(user);
            //Normal Money for 20000 is 22400

            Assert.Equal(22400, userNormal.Money);
        }

        [Fact]
        public void IsOkPremiumUserMoneyCalculate()
        {
            UserDTO user = createUserTemplate(money: 120,userType:"premium");
            User userPremium = userServices.CreateUser(user);
            //Premium Money for 120 is 360

            Assert.Equal(360, userPremium.Money);
        }

        [Fact]
        public void IsOkSuperUserMoneyCalculate()
        {
            UserDTO user = createUserTemplate(money: 1000, userType: "super");
            User userSuper = userServices.CreateUser(user);
            //Super Money for 1000 is 1200

            Assert.Equal(1200, userSuper.Money);
        }


        public void SetUpFactory() {
            userFactory = new UserFactory();
            userFactory.Initialize();
            userRepository = new UserRepository(userFactory);
            userRepository.Initialize();
            userServices = new UserServices(userFactory, userRepository);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile()); //your automapperprofile 
            });
            var mapper = mockMapper.CreateMapper();

            userController = new UsersController(userServices, mapper);
        }

        public UserDTO createUserTemplate(String name = "Mike", String email= "mike@gmail.com", String phone= "+349 1122354215", String address="Av. Juan G", String userType ="normal", decimal money = 1000) {
            UserDTO user = new UserDTO()
            {
                Name = name,
                Email = email,
                Phone = phone,
                Address = address,
                UserType = userType,
                Money = money,
            };

            return user;
        }

    }
}
