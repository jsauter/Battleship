using Battleship.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleship.Tests
{
    public class TestsBase
    {protected Mock<ISettingService> _settingService;

        [TestInitialize]
        public void Initialize()
        {
            _settingService = new Mock<ISettingService>();
            _settingService.Setup(x => x.BoardHeight).Returns(8);
            _settingService.Setup(x => x.BoardWidth).Returns(8);
            _settingService.Setup(x => x.NumberOfPlayers).Returns(2);
        }
    }
}