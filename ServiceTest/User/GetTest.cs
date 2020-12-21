using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.ServiceInterfaces;
using Moq;
using Xunit;

namespace ServiceTest.User
{
    public class GetTest : UserTest
    {
        private IUserService _userService;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Metodo GET em funcionamento")]
        public async Task ExecuteGet()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUser)).ReturnsAsync(userDTOSelect);
            _userService = _serviceMock.Object;

            var result = await _userService.Get(IdUser);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUser);
            Assert.Equal(result.Name, NameUser);
        }
    }
}
