using WordPuzzle.Model;

namespace WordPuzzle.Validators
{
    public class WordValidator
    {
        public bool IsValidWord(List<Data> words, string word)
        {
            bool isValid = true;

            if (!IsWordInList(word, words) || !IsWordWithFourCharacters(word))
            {
                Console.WriteLine($"word '{word}' is not a valid startWord, try again!");
                isValid = false;
            }

            return isValid;
        }

        public bool IsWordInList(string word, List<Data> words)
        {
            bool isValid = true;

            var wordInList = words.FirstOrDefault(w => w.value.ToUpper() == word.ToUpper());

            if (wordInList == null)
            {
                isValid = false;
            }

            return isValid;
        }

        public bool IsWordWithFourCharacters(string word)
        {
            bool isValid = true;

            if (word.Length != 4)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
