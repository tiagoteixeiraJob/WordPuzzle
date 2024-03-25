using WordPuzzle.Stream;

namespace WordPuzzle.Tests.Stream
{
    public class ExportTests
    {
        [Fact]
        public void ExportFile_Success()
        {
            //Arrange
            string directory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            string file = @"Files\export-wordSteps.txt";

            List<string> wordsList = new List<string>();
            wordsList.Add("same");
            wordsList.Add("came");

            try
            {
                //Act
                Export export = new Export();
                export.ExportTxtFile(directory, file, wordsList);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Null(ex.Message);
            }
        }

        [Fact]
        public void ExportFile_Exception()
        {
            //Arrange
            string directory = "XYZ:\\";
            string file = @"file.txt";

            List<string> wordsList = new List<string>();
            wordsList.Add("same");
            wordsList.Add("came");

            try
            {
                //Act
                Export export = new Export();
                export.ExportTxtFile(directory, file, wordsList);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.NotNull(ex.Message);
            }
        }

        [Fact]
        public void FileNameBeautifyWithSteps_Success()
        {
            //Arrange
            string startWord = "same";
            string endWord = "cost";

            //Act
            Export export = new Export();
            string fileName = export.FileNameBeautifyWithSteps(startWord, endWord);

            //Assert
            Assert.Equal("intermediateSteps-SAME-to-COST.txt", fileName);
        }

        [Fact]
        public void FileNameBeautifyWithSteps_WrongFileName()
        {
            //Arrange
            string startWord = "same";
            string endWord = "cost";

            //Act
            Export export = new Export();
            string fileName = export.FileNameBeautifyWithSteps(startWord, endWord);

            //Assert
            Assert.NotEqual("intermediateSteps-SAME-to-ZOOM.txt", fileName);
        }

    }
}
