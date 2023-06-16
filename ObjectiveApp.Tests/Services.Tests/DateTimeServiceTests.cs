using ObjectiveApp.Services;
using Xunit;

namespace ObjectiveApp.Tests.Services.Tests
{
    public class DateTimeServiceTests
    {
        [Fact]
        public void DayOfWeek_ReturnsCorrectDayOfWeek()
        {
            // Arrange
            var expectedDayOfWeek = DateTime.Today.DayOfWeek.ToString();

            // Act
            var actualDayOfWeek = DateTimeService.DayOfWeek();

            // Assert
            Assert.Equal(expectedDayOfWeek, actualDayOfWeek);
        }

        [Fact]
        public void TimeNow_ReturnsValidTime()
        {
            // Arrange
            var currentTime = DateTime.Now;
            var expectedTime = currentTime.ToString("hh:mm tt");

            // Act
            var actualTime = DateTimeService.TimeNow();

            // Assert
            Assert.Equal(expectedTime, actualTime);
        }

        [Fact]
        public void TodayDate_ReturnsValidDate()
        {
            // Arrange
            var currentDate = DateTime.Now;
            var expectedDate = currentDate.ToString("D");

            // Act
            var actualDate = DateTimeService.TodayDate();

            // Assert
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void TimeOfDayText_ReturnsCorrectTimeOfDayText()
        {
            // Arrange
            var currentTime = DateTime.Now.TimeOfDay;
            var expectedText = (
                currentTime < TimeSpan.FromHours(12) ? "morning" :
                currentTime < TimeSpan.FromHours(18) ? "afternoon" :
                "evening"
            );

            // Act
            var actualText = DateTimeService.TimeOfDayText();

            // Assert
            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void ConvertToTimeSpan_ReturnsValidTimeSpan()
        {
            // Arrange
            var dateTime = new DateTime(2023, 6, 16, 10, 30, 0);
            var expectedTimeSpan = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);

            // Act
            var actualTimeSpan = DateTimeService.ConvertToTimeSpan(dateTime);

            // Assert
            Assert.Equal(expectedTimeSpan, actualTimeSpan);
        }
    }
}
