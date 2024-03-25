using WordPuzzle.Model;
using WordPuzzle.Validators;

namespace WordPuzzle.Tests.Validators
{
    public class WordValidatorTests
    {
        [Fact]
        public void IsValidWord_Success()
        {
            //Arrange
            string word = "data";

            List<Data> wordsList = new List<Data>();
            Data data1 = new Data();
            data1.value = "data";
            wordsList.Add(data1);

            //Act
            WordValidator validator = new WordValidator();
            bool isValid = validator.IsValidWord(wordsList, word);

            //Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidWord_False_WordNotInList()
        {
            //Arrange
            string word = "zoom";

            List<Data> wordsList = new List<Data>();
            Data data1 = new Data();
            data1.value = "data";
            wordsList.Add(data1);

            //Act
            WordValidator validator = new WordValidator();
            bool isValid = validator.IsValidWord(wordsList, word);

            //Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidWord_False_WordSizeIncorret()
        {
            //Arrange
            string word = "database";

            List<Data> wordsList = new List<Data>();
            Data data1 = new Data();
            data1.value = "database";
            wordsList.Add(data1);

            //Act
            WordValidator validator = new WordValidator();
            bool isValid = validator.IsValidWord(wordsList, word);

            //Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsWordInList_True()
        {
            //Arrange
            string word = "came";
            
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
            WordValidator validator = new WordValidator();
            bool isValid = validator.IsWordInList(word, wordsList);

            //Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsWordInList_False()
        {
            //Arrange
            string word = "zoom";

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
            WordValidator validator = new WordValidator();
            bool isValid = validator.IsWordInList(word, wordsList);

            //Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsWordWithFourCharacters_True()
        {
            //Arrange
            string word = "data";

            //Act
            WordValidator validator = new WordValidator();
            bool isValid = validator.IsWordWithFourCharacters(word);

            //Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsWordWithFourCharacters_False()
        {
            //Arrange
            string word = "database";

            //Act
            WordValidator validator = new WordValidator();
            bool isValid = validator.IsWordWithFourCharacters(word);

            //Assert
            Assert.False(isValid);
        }
    }
}
