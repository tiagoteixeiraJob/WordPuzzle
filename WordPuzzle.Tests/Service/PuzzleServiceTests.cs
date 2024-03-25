using WordPuzzle.Model;
using WordPuzzle.Service;

namespace WordPuzzle.Tests.Service
{
    public class PuzzleServiceTests
    {
        [Fact]
        public void BuildPuzzle_Success()
        {
            //Arrange
            string startWord = "same";
            string endWord = "case";

            List<Data> wordsList = new List<Data>();

            Data data1 = new Data();
            data1.value = "same";
            wordsList.Add(data1);

            Data data2 = new Data();
            data2.value = "came";
            wordsList.Add(data2);

            Data data3 = new Data();
            data3.value = "case";
            wordsList.Add(data3);

            //Act
            PuzzleService puzzleService = new PuzzleService();
            List<string> steps = puzzleService.BuildPuzzle(wordsList, startWord, endWord);

            string firstStep = steps[0];
            string lastStep = steps[steps.Count - 1];

            //Assert
            Assert.NotEmpty(steps);
            Assert.Equal("same", firstStep);
            Assert.Equal("case", lastStep);
        }

        [Fact]
        public void BuildPuzzle_StepsListIsNull()
        {
            //Arrange
            string startWord = "aaaa";
            string endWord = "bbbb";

            List<Data> wordsList = new List<Data>();

            Data data1 = new Data();
            data1.value = "same";
            wordsList.Add(data1);

            Data data2 = new Data();
            data2.value = "came";
            wordsList.Add(data2);

            //Act
            PuzzleService puzzleService = new PuzzleService();
            List<string> steps = puzzleService.BuildPuzzle(wordsList, startWord, endWord);

            //Assert
            Assert.Null(steps);
        }

        [Fact]
        public void BuildPuzzle_WrongFirstStep()
        {
            //Arrange
            string startWord = "same";
            string endWord = "came";

            List<Data> wordsList = new List<Data>();

            Data data1 = new Data();
            data1.value = "same";
            wordsList.Add(data1);

            Data data2 = new Data();
            data2.value = "came";
            wordsList.Add(data2);

            //Act
            PuzzleService puzzleService = new PuzzleService();
            List<string> steps = puzzleService.BuildPuzzle(wordsList, startWord, endWord);

            string firstStep = steps[0];

            //Assert
            Assert.NotEmpty(steps);
            Assert.NotEqual("zoom", firstStep);
        }

        [Fact]
        public void BuildPuzzle_WrongLastStep()
        {
            //Arrange
            string startWord = "same";
            string endWord = "came";

            List<Data> wordsList = new List<Data>();

            Data data1 = new Data();
            data1.value = "same";
            wordsList.Add(data1);

            Data data2 = new Data();
            data2.value = "came";
            wordsList.Add(data2);

            //Act
            PuzzleService puzzleService = new PuzzleService();
            List<string> steps = puzzleService.BuildPuzzle(wordsList, startWord, endWord);

            string lastStep = steps[steps.Count - 1];

            //Assert
            Assert.NotEmpty(steps);
            Assert.NotEqual("zoom", lastStep);
        }

        [Fact]
        public void GetSimilarWords_Success()
        {
            //Arrange
            string currentWord = "same";

            List<Data> wordsList = new List<Data>();

            Data data1 = new Data();
            data1.value = "same";
            wordsList.Add(data1);

            Data data2 = new Data();
            data2.value = "came";
            wordsList.Add(data2);

            Data data3 = new Data();
            data3.value = "name";
            wordsList.Add(data3);

            //Act
            PuzzleService puzzleService = new PuzzleService();
            List<string> similarWords = puzzleService.GetSimilarWords(currentWord, wordsList);

            //Assert
            Assert.NotEmpty(similarWords);
            Assert.Equal(2, similarWords.Count());
        }

        [Fact]
        public void GetSimilarWords_WrongNumberOFSimilarWords()
        {
            //Arrange
            string currentWord = "same";

            List<Data> wordsList = new List<Data>();

            Data data1 = new Data();
            data1.value = "same";
            wordsList.Add(data1);

            Data data2 = new Data();
            data2.value = "came";
            wordsList.Add(data2);

            Data data3 = new Data();
            data3.value = "name";
            wordsList.Add(data3);

            //Act
            PuzzleService puzzleService = new PuzzleService();
            List<string> similarWords = puzzleService.GetSimilarWords(currentWord, wordsList);

            //Assert
            Assert.NotEmpty(similarWords);
            Assert.NotEqual(10, similarWords.Count());
        }

        [Fact]
        public void GetSimilarWords_SimilarWordsIsEmpty()
        {
            //Arrange
            string currentWord = "same";

            List<Data> wordsList = new List<Data>();

            Data data1 = new Data();
            data1.value = "zamm";
            wordsList.Add(data1);

            Data data2 = new Data();
            data2.value = "zemm";
            wordsList.Add(data2);

            Data data3 = new Data();
            data3.value = "zimm";
            wordsList.Add(data3);

            //Act
            PuzzleService puzzleService = new PuzzleService();
            List<string> similarWords = puzzleService.GetSimilarWords(currentWord, wordsList);

            //Assert
            Assert.Empty(similarWords);
        }
    }
}


