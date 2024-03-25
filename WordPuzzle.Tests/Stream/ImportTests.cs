using WordPuzzle.Model;
using WordPuzzle.Stream;

namespace WordPuzzle.Tests.Stream
{
    public class ImportTests
    {
        [Fact]
        public void ImportTxtFile_Success()
        {
            //Arrange
            string filePath = @"Files\import-words-english.txt";
            string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

            List<Data> words = new List<Data>();

            //Act
            Import import = new Import();
            words = import.ImportTxtFile(fileName);

            //Assert
            Assert.NotEmpty(words);
        }

        [Fact]
        public void ImportTxtFile_EmptyFile()
        {
            //Arrange
            string filePath = @"Files\import-words-english-empty.txt";
            string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

            List<Data> words = new List<Data>();

            //Act
            Import import = new Import();
            words = import.ImportTxtFile(fileName);

            //Assert
            Assert.Empty(words);
        }
    }
}
