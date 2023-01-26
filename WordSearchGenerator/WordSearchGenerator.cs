/*=====================================================================*
*  Manages fields and performs main functions to generate word search  *
*======================================================================*/

namespace WordSearchGenerator
{
    class WordSearchGenerator
    {
        /*===========================================================*
        *  words: List of words to be placed on grid                 *
        *  wordSearch: Grid that makes up the word search            *
        *  width, height: Dimensions of word search from user input  *
        *============================================================*/
        private List<string> words { get; set; } = default!;
        private char[,] wordSearch { get; set; } = default!;
        private int width;
        private int height;


        /*=====================================================*
        *  Words.txt text file is read into a List of strings  *
        *  Spaces and special characters are removed           *
        *======================================================*/
        public void ReadWords()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Words.txt");
            words = new List<string>(System.IO.File.ReadAllLines(path));
            words = Helper.FormatWords(words);
        }

        /*=====================================================================*
        *  Height and width are gathered from user input using Frontend class  *
        *======================================================================*/
        public void GetDimensions()
        {
            width = Frontend.GetWidth();
            height = Frontend.GetHeight();
        }

        /*==========================================================*
        *  Words are validated to ensure they will fit on the grid  *
        *===========================================================*/
        public void ValidateInput()
        {
            bool wordsFit = Validation.ValidateWords(words, width, height);
            if (!wordsFit)
            {
                Console.WriteLine("One or more words will not fit in the grid.\nPlease remove them or increase the dimensions.");
                Environment.Exit(0);
            }
        }

        /*=====================================================================*
        *  Main function to setup the grid, place the words, and print results *
        *======================================================================*/
        public void GenerateWordSearch()
        {
            SetupGrid();
            PlaceWords();
            Frontend.PrintAnswerKey(wordSearch);
            wordSearch = Helper.FillRemaining(wordSearch);
            Frontend.PrintWordSearch(wordSearch);
        }

        /*=====================================================================*
        *  Grid is initially filled with asterisks to provide answer key later *
        *======================================================================*/
        public void SetupGrid()
        {
            wordSearch = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    wordSearch[i, j] = '*';
                }
            }
        }

        /*==============================================================================*
        *  A random direction and random coordinates are generated                      *
        *  Validation to ensure word will fit given direction, length, and coordiantes  *
        *===============================================================================*/
        public void PlaceWords()
        {
            foreach (string word in words)
            {
                bool needsPlaced = true;
                do
                {
                    string direction = Helper.GetRandomDirection();
                    int[] coordinates = Helper.GetRandomGridSpot(width, height);
                    int x = coordinates[0];
                    int y = coordinates[1];

                    bool spotIsValid = Validation.ValidateGridSpot(direction, word.Length, width, height, x, y);

                    if (spotIsValid)
                    {
                        bool fitsInGrid = Validation.ValidateWordFits(wordSearch, word, x, y, direction);
                        if (fitsInGrid)
                        {
                            PlaceWord(word, direction, x, y);
                            needsPlaced = false;
                        }
                    }
                } while (needsPlaced);
            }
        }

        /*==================================================*
        *  Word is placed on the grid once fully validated  *
        *===================================================*/
        public void PlaceWord(string word, string direction, int x, int y)
        {
            int xcoor = x;
            int ycoor = y;
            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                wordSearch[ycoor, xcoor] = letter;
                int[] newCoordinates = Helper.MoveCoordinates(direction, xcoor, ycoor);
                xcoor = newCoordinates[0];
                ycoor = newCoordinates[1];
            }
        }
    }
}