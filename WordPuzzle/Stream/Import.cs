using WordPuzzle.Model;
using WordPuzzle.Validators;

namespace WordPuzzle.Stream
{
    public class Import
    {
        public List<Data> ImportTxtFile(string filePath)
        {
            WordValidator wordValidator = new WordValidator();
            
            List<Data> words = new List<Data>();

            string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var wordValue = reader.ReadLine().Trim().ToUpper();

                    if (wordValidator.IsWordWithFourCharacters(wordValue))
                    {
                        var data = new Data();
                        data.value = wordValue;

                        words.Add(data);
                    }
                }
            }

            return words;
        }
    }
}
