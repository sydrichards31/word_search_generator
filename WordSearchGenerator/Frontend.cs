/*==================================================*
*  Get user input and print output through console  *
*===================================================*/

#pragma warning disable 8604
namespace WordSearchGenerator
{
    public static class Frontend
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Word Search Generator!");
            Console.WriteLine("Words will be placed in all directions, N, E, S, W, NE, NW, SE, SW");
            Console.WriteLine("Add the words you want placed to Words.txt, separated by newlines.");
            Console.WriteLine("White space and special characters will be automatically removed.");
            Console.WriteLine();
        }

        public static int GetWidth()
        {
            bool validWidth;
            int width;
            do
            {
                Console.Write("Enter grid width: ");
                validWidth = Int32.TryParse(Console.ReadLine(), out width);
                if (!validWidth) Console.WriteLine("Please enter a valid number");
            } while (!validWidth);
            return width;
        }

        public static int GetHeight()
        {
            bool validHeight;
            int height;
            do
            {
                Console.Write("Enter grid height: ");
                validHeight = Int32.TryParse(Console.ReadLine(), out height);
                if (!validHeight) Console.WriteLine("Please enter a valid number");
            } while (!validHeight);
            return height;
        }

        public static void PrintAnswerKey(char[,] answerKey)
        {
            Console.WriteLine();
            Console.WriteLine("-ANSWER KEY-");
            Console.WriteLine();
            PrintGrid(answerKey);
            Console.WriteLine();
        }

        public static void PrintWordSearch(char[,] wordSearch)
        {
            Console.WriteLine();
            Console.WriteLine("-WORD SEARCH-");
            Console.WriteLine();
            PrintGrid(wordSearch);
            Console.WriteLine();
        }

        public static void PrintGrid(char[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j].ToString());
                    if (j != grid.GetLength(1) - 1) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
