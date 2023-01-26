/*================================================*
*  Helper functions used to generate word search  *
*=================================================*/

namespace WordSearchGenerator
{
    public static class Helper
    {
        private static Random random = new Random();

        /*=====================================================*
        *  Remove special characters and convert to upper case *
        *======================================================*/
        public static List<string> FormatWords(List<string> words)
        {
            List<string> formattedWords = new List<string>();
            foreach (string word in words)
            {
                char[] arr = word.ToCharArray();
                arr = Array.FindAll<char>(arr, (c => char.IsLetter(c)));
                formattedWords.Add(new string(arr).ToUpper());
            }
            return formattedWords;
        }

        /*======================================*
        *  Return a random position on the grid *
        *=======================================*/
        public static int[] GetRandomGridSpot(int width, int height)
        {
            return new int[] { random.Next(width), random.Next(height) };
        }

        /*==========================================*
        *  Generate a random direction for the word *
        *===========================================*/
        public static string GetRandomDirection()
        {
            return Constants.directions.ElementAt(random.Next(Constants.directions.Length));
        }

        /*===========================================================*
        *  Generate a random letter to fill the remaining grid space *
        *  The letter will exclude vowels if noVowels is true        *
        *============================================================*/
        public static char GetRandomLetter(bool noVowels)
        {
            return Constants.alphabet.ElementAt(random.Next(26));
        }

        /*=================================================*
        *  Fill remaining grid spaces with random letters  *
        *==================================================*/
        public static char[,] FillRemaining(char[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (!Constants.alphabet.Contains(grid[i, j]))
                    {
                        grid[i, j] = GetRandomLetter(false);
                    }
                }
            }
            return grid;
        }

        /*==============================================*
        *  Move coordinates on grid based on direction  *
        *===============================================*/
        public static int[] MoveCoordinates(string direction, int xcoor, int ycoor)
        {
            switch (direction)
            {
                case "N":
                    ycoor--;
                    break;
                case "E":
                    xcoor++;
                    break;
                case "S":
                    ycoor++;
                    break;
                case "W":
                    xcoor--;
                    break;
                case "SE":
                    xcoor++;
                    ycoor++;
                    break;
                case "NE":
                    xcoor++;
                    ycoor--;
                    break;
                case "SW":
                    xcoor--;
                    ycoor++;
                    break;
                case "NW":
                    xcoor--;
                    ycoor--;
                    break;
                default:
                    break;
            }
            return new int[] { xcoor, ycoor };
        }
    }
}
