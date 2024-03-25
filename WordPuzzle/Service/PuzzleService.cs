using WordPuzzle.Model;

namespace WordPuzzle.Service
{
    public class PuzzleService
    {
        public List<string> BuildPuzzle(List<Data> words, string startWord, string endWord)
        {
            Queue<List<string>> possiblePathWordsList = new Queue<List<string>>();

            HashSet<string> validatedWords = new HashSet<string>();

            try
            {
                //insert startWord in possiblePathWordsList before to start validation process.
                possiblePathWordsList.Enqueue(new List<string> { startWord });

                while (possiblePathWordsList.Count > 0)
                {
                    //remove possiblePathWordsList until the last item AND include in stepsList.
                    List<string> steps = possiblePathWordsList.Dequeue();

                    int lastPosition = steps.Count - 1;
                    string currentWord = steps[lastPosition];

                    if (currentWord == endWord)
                    {
                        return steps;
                    }

                    var similarWords = GetSimilarWords(currentWord, words);

                    foreach (string similarWord in similarWords)
                    {
                        if (!validatedWords.Contains(similarWord))
                        {
                            //include listOfWords already validated.
                            validatedWords.Add(similarWord);

                            //update original listOfWords in a updatedStepsList.
                            List<string> updatedSteps = new List<string>(steps);
                            updatedSteps.Add(similarWord);

                            //insert new words in possiblePathWordsList.
                            possiblePathWordsList.Enqueue(updatedSteps);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception [{ex.Message}] found in BuildPuzzle() method!");
            }      

            return null;
        }

        public List<string> GetSimilarWords(string currentWord, List<Data> words)
        {
            char[] currentWordLetters = currentWord.ToCharArray();

            List<string> similarWords = new List<string>();

            try
            {
                foreach (var word in words)
                {
                    int differentLettersCounter = 0;

                    for (int i = 0; i < word.value.Length; i++)
                    {
                        if (currentWordLetters[i] != word.value[i])
                        {
                            differentLettersCounter++;
                        }
                    }

                    //include in similarWordsList only words with 1 different character.
                    if (differentLettersCounter == 1)
                    {
                        similarWords.Add(word.value);
                    }
                }

                return similarWords;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception [{ex.Message}] found in BuildPuzzle() method!");
            }
        }
    }
}
