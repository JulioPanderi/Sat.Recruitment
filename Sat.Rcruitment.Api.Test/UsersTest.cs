using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Domain.Model;
using System;
using Xunit;

namespace Sat.Rcruitment.Api.Test
{
    public class UsersTest
    {
        [Fact]
        public void CreateUser__Successful()
        {
            //Arrange
            var userController = new UsersController();

            //Act
            ActionResult<Result> response = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", 124).Result;

            // Assert

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

        [Fact]
        public void CreateUser__UnSuccessful()
        {
            //Arrange
            var userController = new UsersController();

            //Act
            ActionResult<Result> response = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", 124).Result;

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
