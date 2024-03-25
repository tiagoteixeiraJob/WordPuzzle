namespace WordPuzzle.Stream
{
    public class Export
    {
        public void ExportTxtFile(string directory, string file, List<string> words)
        {
            try
            {
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                
                string fileName = Path.Combine(directory, file);

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var word in words)
                    {
                        writer.WriteLine(word);
                    }
                }

                Console.WriteLine($"\nFile with steps created in this address {fileName}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception [{ex.Message}] found in ExportTxtFile() method!");
            }
        }

        public string FileNameBeautifyWithSteps(string startWord, string endWord)
        {
            return $"intermediateSteps-{SanitizeWord(startWord)}-to-{SanitizeWord(endWord)}.txt";
        }

        private static string SanitizeWord(string startWord)
        {
            return startWord.Replace('\\', ' ').Trim().ToUpper();
        }
    }
}
