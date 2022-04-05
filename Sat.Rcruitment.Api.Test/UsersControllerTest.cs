using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Domain.Model;
using Sat.Recruitment.Api.Domain.Helpers;
using System;
using Xunit;
using Sat.Recruitment.Api.Domain.IHelpers;

namespace Sat.Rcruitment.Api.Test
{
    public class UsersControllerTest
    {
        protected Mock<IUserHelper> _userHelper;
        protected UsersController _userController;

        public UsersControllerTest()
        {
            _userHelper = new Mock<IUserHelper>();
            _userController = new UsersController(_userHelper.Object);
        }

        [Fact]
        public void CreateUser__Successful()
        {
            //Arrange
            var user = new NormalUser()
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                Money = 124
            };
            _userHelper.Setup(x => x.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>())).Returns(user);

            //Act
            ActionResult<Result> response = _userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", 124).Result;

            //Assert
            using (var scope = new AssertionScope())
            {
                //Verify the response is not null
                response.Should().NotBeNull();

                //Verify there were no errors in the response
                var result = response.Result;
                result.Should().NotBeNull();
                result.Should().BeOfType<OkObjectResult>();

                //Verify the User was created ok
                var resultValue = result.As<ObjectResult>().Value;

                resultValue.Should().NotBeNull();                                       //The final result should not be null
                resultValue.As<Result>().IsSuccess.Should<bool>().Be(true);             //IsSuccess should be true
                resultValue.As<Result>().Errors.Should<string>().Be("User Created");    //The "errors" description must be "User Created"
            }
        }

        [Fact]
        public void CreateUser__UnSuccessful()
        {
            //Arrange
            var user = new NormalUser()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                Money = 124
            };
            _userHelper.Setup(x => x.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>())).Returns(user);

            //Act
            ActionResult<Result> response = _userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", 124).Result;

            // Assert

            //Verify the response is not null
            response.Should().NotBeNull();

            //Verify there were no errors in the response
            var result = response.Result;
            result.Should().NotBeNull();
            result.Should().BeOfType<BadRequestObjectResult>();

            //Verify the User was created ok
            var resultValue = result.As<ObjectResult>().Value;
            resultValue.Should().NotBeNull();                                               //The final result should not be null
            resultValue.As<Result>().IsSuccess.Should<bool>().Be(false);                    //IsSuccess should be false
            resultValue.As<Result>().Errors.Should<string>().Be("The user is duplicated");  //The "errors" description must be "The user is duplicated"
        }
    }
}
