using ObjectiveApp.Services;
using Xunit;

namespace ObjectiveApp.Tests.Services.Tests
{
    public class DateTimeServiceTests
    {
        [Fact]
        public void TimeOfDayText_When_Hour_Is_Before_12_Return_MorningText()
        {
            //Arrange
            var timeOfDayNow = DateTime.Now.TimeOfDay;
            var testSubject = DateTimeService.TimeOfDayText();

            //Act
            var result = testSubject == "mornning";
            
            //Assert
            if (timeOfDayNow <= TimeSpan.FromHours(12))
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
            
        }

        [Fact]
        public void TimeOfDayText_When_Hour_Is_After_12_Return_AfternoonText()
        {
            //Arrange
            var timeOfDayNow = DateTime.Now.TimeOfDay;
            var testSubject = DateTimeService.TimeOfDayText();

            //Act
            var result = testSubject == "afternoon";

            //Assert
            if (timeOfDayNow > TimeSpan.FromHours(12) && timeOfDayNow <= TimeSpan.FromHours(18))
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
        }

        [Fact]
        public void TimeOfDay_When_Hour_Is_After_18_Return_EveningText()
        {
            //Arrange
            var timeOfDayNow = DateTime.Now.TimeOfDay;
            var testSubject = DateTimeService.TimeOfDayText();

            //Act
            var result = testSubject == "evening";

            //Assert
            if ( timeOfDayNow > TimeSpan.FromHours(18))
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }

        }
    }
}
