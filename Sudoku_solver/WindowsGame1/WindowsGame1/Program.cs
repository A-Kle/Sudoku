using System;

namespace SudokuGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Sudoku1 game = new Sudoku1())
            {
                game.Run();
            }
        }
    }
#endif
}

