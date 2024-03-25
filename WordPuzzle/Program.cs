using WordPuzzle.Model;
using WordPuzzle.Service;
using WordPuzzle.Stream;
using WordPuzzle.Validators;

internal class Program
{
    private static void Main(string[] args)
    {
        string stillWorking = "Y";

        //Import dictionary file.
        Import import = new Import();
        string filePath = @"Files\words-english.txt";
        List<Data> words = import.ImportTxtFile(filePath);

        while (stillWorking == "Y")
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("             -Welcome to the WordPuzzle-              ");
            Console.WriteLine();
            Console.WriteLine("     Type StartWord and EndWord with 4 characters     ");
            Console.WriteLine("------------------------------------------------------\n");

            //StartWord and EndWord.
            WordValidator validator = new WordValidator();

            bool isValidStartWord = false;
            string startWord = string.Empty;

            while (!isValidStartWord)
            {
                Console.Write("\nType a valid StartWord: ");

                startWord = Console.ReadLine().Trim();
                isValidStartWord = validator.IsValidWord(words, startWord);
            }

            bool isValidEndWord = false;
            string endWord = string.Empty;

            Console.WriteLine("------------------------------------------------------");
            while (!isValidEndWord)
            {
                Console.Write("\nType a valid EndWord: ");

                endWord = Console.ReadLine().Trim();
                isValidEndWord = validator.IsValidWord(words, endWord);
            }

            //Puzzle Logic.
            PuzzleService puzzleService = new PuzzleService();
            List<string> puzzleWords = puzzleService.BuildPuzzle(words, startWord.Trim().ToUpper(), endWord.Trim().ToUpper());

            if (puzzleWords == null)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("\nIt was not possible to create a puzzle! Can you try again? Y/N");
                stillWorking = Console.ReadLine().ToUpper();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("------------------------------------------------------");
                Console.Write($"\nSteps to transform startWord '{startWord.ToUpper()}' in endWord '{endWord.ToUpper()}':\n\n");
                foreach (var word in puzzleWords)
                {
                    Console.WriteLine(word);
                }

                //Export file with steps between StartWord and EndWord.
                Export export = new Export();
                string directory = "C:\\WordPuzzleFiles\\";
                string file = export.FileNameBeautifyWithSteps(startWord, endWord);
                export.ExportTxtFile(directory, file, puzzleWords);

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("\nDo you want test new interval of words? Y/N");
                stillWorking = Console.ReadLine().ToUpper();
                Console.Clear();
            }
        }
    }
}