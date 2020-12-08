//NUnit 3 tests
//See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using Monopoly.Models;
using NUnit.Framework;
using System.Linq;

namespace Monopoly
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void GetPlayersListReturnCorrectList()
        {
            // Arrange
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };
            var expectedPlayers = new Player[]
            {
                new Player("Peter",6000),
                new Player("Ekaterina",6000),
                new Player("Alexander",6000)
            };

            // Act
            Monopoly monopoly = new Monopoly(players, 3);
            var actualPlayers = monopoly.GetPlayersList().ToArray();

            Assert.AreEqual(expectedPlayers, actualPlayers);
        }

        [Test]
        public void GetFieldsListReturnCorrectList()
        {
            // Arrange
            string[] players = new string[] { "Peter", "Ekaterina", "Alexander" };

            var expectedCompanies = new BaseField[]
            {
                new CompanyField("Ford", 250, 500, 250),
                new CompanyField("MCDonald", 250, 250, 250),
                new CompanyField("Lamoda", 100, 100, 1000),
                new CompanyField("Air Baltic", 300, 700, 300),
                new CompanyField("Nordavia", 300, 700, 300),
                new SpecialField("Prison", 1000),
                new CompanyField("MCDonald", 250, 250, 250),
                new CompanyField("TESLA", 250, 500, 250),
            };

            // Act
            Monopoly monopoly = new Monopoly(players, 3);

            // Assert
            var actualCompanies = monopoly.GetFieldsList().ToArray();
            Assert.AreEqual(expectedCompanies, actualCompanies);
        }

        [Test]
        public void PlayerBuyNoOwnedCompanies()
        {
            // Arrange
            var players = new string[] { "Peter", "Ekaterina", "Alexander" };
            var monopoly = new Monopoly(players, 3);
            var expectedPlayer = new Player("Peter", 5500);
            var field = monopoly.GetFieldByName("Ford");

            // Act
            monopoly.Buy(monopoly.GetPlayerInfo(1), field);

            // Assert
            var actualPlayer = monopoly.GetPlayerInfo(1);
            var actualField = monopoly.GetFieldByName("Ford");

            Assert.AreEqual(expectedPlayer, actualPlayer);
            Assert.AreEqual(expectedPlayer, actualField.Owner);
        }

        [Test]
        public void RentaShouldBeCorrectTransferMoney()
        {
            // Arrange
            var players = new string[] { "Peter", "Ekaterina", "Alexander" };
            Monopoly monopoly = new Monopoly(players, 3);
            var player1 = monopoly.GetPlayerInfo(1);
            var player2 = monopoly.GetPlayerInfo(2);
            var field = monopoly.GetFieldByName("Ford");

            // Act
            monopoly.Buy(player1, field);
            monopoly.Renta(player2, field);

            // Assert
            Assert.AreEqual(5750, player1.Money);
            Assert.AreEqual(5750, player2.Money);
        }
    }
}
