namespace SwissTransport
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using SwissTransport.Core;
    using SwissTransport.Models;
    using Xunit;

    public class TransportTest
    {
        private readonly ITransport testee;

        public TransportTest()
        {
            this.testee = new Transport();
        }

        [Fact]
        public void Locations()
        {
            Stations stations = this.testee.GetStations("Sursee,");

            stations.StationList.Should().HaveCount(10);
        }

        [Fact]
        public void StationBoard()
        {
            StationBoardRoot stationBoard = this.testee.GetStationBoard("Sursee", "8502007");

            stationBoard.Should().NotBeNull();
        }

        [Fact]
        public void Connections()
        {
            Connections connections = this.testee.GetConnections("Sursee", "Luzern");

            connections.Should().NotBeNull();
        }

        [Fact]
        public void ConnectionsWithDateTime()
        {
            // Arrange
            DateTime dateTime = DateTime.Now.AddDays(1);

            // Act
            Connections connections = this.testee.GetConnections("Sursee", "Luzern", dateTime);
            DateTime connectionDateTime = Convert.ToDateTime(connections.ConnectionList.FirstOrDefault().From.Departure);

            // Assert
            Assert.NotNull(connections);
            Assert.Equal(connectionDateTime.Date, dateTime.Date);
            Assert.True(connectionDateTime.TimeOfDay >= dateTime.TimeOfDay);
        }
    }
}