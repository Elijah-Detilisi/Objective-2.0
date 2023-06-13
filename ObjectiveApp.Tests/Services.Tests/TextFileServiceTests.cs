using ObjectiveApp.Services;
using Xunit;

namespace ObjectiveApp.Tests.Services.Tests
{
    public class TextFileServiceTests
    {
        [Fact]
        public void ReadFile_InputIs_ValidFileName_ReturnTextString()
        {
            //Arrange
            var validTextFile = "real_text_file.txt";

            //Act
            var result = TextFileService.ReadFile(validTextFile);   

            //Assert
            Assert.IsType<string>(result);
        }

        [Fact]
        public void ReadFile_InputIsNot_ValidFileName_ThrowException()
        {
            //Arrange
            var validTextFile = "fake_text_file.txt";

            //Act
            var result = TextFileService.ReadFile(validTextFile);

            //Assert
            Assert.ThrowsAny<ArgumentException>(() => result);
        }
    }
}
