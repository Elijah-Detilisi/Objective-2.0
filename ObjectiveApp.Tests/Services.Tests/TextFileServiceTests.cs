using ObjectiveApp.Services;
using Xunit;

namespace ObjectiveApp.Tests.Services.Tests
{
    public class TextFileServiceTests
    {
        [Fact]
        public async void ReadFile_InputIs_ValidFileName_ReturnTextString()
        {
            //Arrange
            var validTextFile = Configs.ConstantValues.QUOTES_TEXT_FILE;

            //Act
            var result = await TextFileService.ReadFile(validTextFile);   

            //Assert
            Assert.IsType<string>(result);
        }

        [Fact]
        public async void ReadFile_InputIsNot_ValidFileName_ThrowExceptionAsync()
        {
            //Arrange
            var validTextFile = "fake_text_file.txt";

            //Act
            var result = await TextFileService.ReadFile(validTextFile);

            //Assert
            Assert.ThrowsAny<ArgumentException>(() => result);
        }
    }
}
