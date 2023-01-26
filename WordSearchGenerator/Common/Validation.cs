/*=============================================================*
*  Helper functions for validating input and generated values  *
*==============================================================*/
namespace WordSearchGenerator
{
    public static class Validation
    {
        /*=========================================================*
        *  Ensure words will fit in grid based on width and height *
        *==========================================================*/
        public static bool ValidateWords(List<string> words, int width, int height)
        {
            foreach (string word in words)
            {
                if (word.Length > width && word.Length > height)
                {
                    return false;
                }
            }
            return true;
        }

        /*========================================================================*
        *  Validates word will fit in the grid based on coordinates and direction *
        *=========================================================================*/
        public static bool ValidateGridSpot(string direction, int wordLength, int width, int height, int x, int y)
        {
            switch (direction)
            {
                case "N":
                    return y - wordLength + 1 >= 0;
                case "E":
                    return x + wordLength < width;
                case "S":
                    return y + wordLength < height;
                case "W":
                    return x - wordLength + 1 >= 0;
                case "SE":
                    return (y + wordLength < height) && (x + wordLength < width);
                case "NE":
                    return (y - wordLength + 1 >= 0) && (x + wordLength < width);
                case "SW":
                    return (y + wordLength < height) && (x - wordLength + 1 >= 0);
                case "NW":
                    return (y - wordLength + 1 >= 0) && (x - wordLength + 1 >= 0);
                default:
                    return false;
            }
        }

        /*====================================================*
        *  Check that the word fits with current placed words *
        *=====================================================*/
        public static bool ValidateWordFits(char[,] grid, string word, int x, int y, string direction)
        {
            int xcoor = x;
            int ycoor = y;
            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                if (Constants.alphabet.Contains(grid[ycoor, xcoor]))
                {
                    if (letter != grid[ycoor, xcoor])
                    {
                        return false;
                    }
                }
                int[] newCoordinates = Helper.MoveCoordinates(direction, xcoor, ycoor);
                xcoor = newCoordinates[0];
                ycoor = newCoordinates[1];
            }
            return true;
        }
    }
}