/*======================================================================================*
* Word Search Generator Project. Sydney Richards, 2023                                 *
* =====================================================================================*/

namespace WordSearchGenerator
{
    class Program
    {
        private static void Main()
        {
            SetupGame();
        }

        private static void SetupGame()
        {
            WordSearchGenerator wordSearchGenerator = new WordSearchGenerator();
            Frontend.WelcomeMessage();
            wordSearchGenerator.ReadWords();
            wordSearchGenerator.GetDimensions();
            wordSearchGenerator.ValidateInput();
            wordSearchGenerator.GenerateWordSearch();
        }
    }
}
