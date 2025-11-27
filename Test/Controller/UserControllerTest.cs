using Api.Controllers;
using Api.Models;
using Api.Repository;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controller
{
    public class UserControllerTest
    {
        private readonly IUserInterface UserInterface;
        private readonly UserController UserController;
        public UserControllerTest()
        {
            // Set up Dependencies
            this.UserInterface = A.Fake<IUserInterface>();
            // SUT -> System Under Test
            this.UserController = new UserController(UserInterface);
        }
        private static User CreateFakeUser() => A.Fake<User>();
        // Create 
        // This method returns Created(success) | BadRequest(fails) action results
        [Fact]
        public async void UserController_Create_ReturnCreated()
        {
            // Arrange
            var user = CreateFakeUser();
            // Act
            A.CallTo(() => UserInterface.CreateAsync(user)).Returns(true);
            var result = (CreatedAtActionResult)await UserController.Create(user);
            // Assert
            result.StatusCode.Should().Be(201);
            result.Should().NotBeNull();
        }
        // Read All
        // This method returns Ok(success) | NotFound(fails) action results
        [Fact]
        public async void UserController_GetUsers_ReturnOk()
        {
            // Arrange 
            var users = A.Fake<List<User>>();
            users.Add(new User { Name = "TestController", Email = "Controller Email" });
            // Act
            A.CallTo(() => UserInterface.GetAllAsync()).Returns(users);
            var result = (OkObjectResult)await UserController.GetUsers();
            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Should().NotBeNull();
        }
        // Read Single
        // This method return Ok(success) | NotFound(fails) action results
        [Theory]
        [InlineData(1)]
        public async void UserController_GetUser_ReturnOk(int id)
        {
            // Arrange 
            var user = CreateFakeUser();
            user.Name = "TestController"; user.Email = "Controller Email"; user.Id = id;
            // Act
            A.CallTo(() => UserInterface.GetByIdAsync(id)).Returns(user);
            var result = (OkObjectResult)await UserController.GetUser(id);
            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Should().NotBeNull();
        }
        // Update
        // This method returns Ok(success) | NotFound(fails) action results
        [Fact]
        public async void UserController_Update_ReturnOk()
        {
            // Arrange 
            var user = CreateFakeUser();
            // Act
            A.CallTo(() => UserInterface.UpdateAsync(user)).Returns(true);
            var result = (OkResult)await UserController.UpdateUser(user);
            // Assert
            result.StatusCode.Should().Be(200);
            result.Should().NotBeNull();
        }
        // Delete
        // This method returns NoContent(success) | NotFound(fails) action results
        [Fact]
        public async void UserController_Delete_ReturnNoContent()
        {
            // Arrange
            int userId = 1;
            // Act
            A.CallTo(() => UserInterface.DeleteAsync(userId)).Returns(true);
            var result = (NoContentResult)await UserController.DeleteUser(userId);
            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
            result.Should().NotBeNull();
        }
    }
}
