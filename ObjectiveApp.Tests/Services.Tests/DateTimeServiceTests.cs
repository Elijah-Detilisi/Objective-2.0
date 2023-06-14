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
            if (timeOfDayNow < TimeSpan.FromHours(12))
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


            //Act


            //Assert

        }

        [Fact]
        public void TimeOfDay_When_Hour_Is_After_18_Return_EveningText()
        {
            //Arrange


            //Act


            //Assert

        }
    }
}
