using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellsLife
{
    /// <summary>
    /// Class ConsoleView implements IView interface API for viewing
    /// field of life cells and string messages info console.
    /// </summary>
    public class ConsoleView : IView
    {
        /// <summary>
        /// View field if the life cells into console.
        /// </summary>
        /// <param name="field">The field of the life cells.</param>
        public void ViewField(Field field)
        {
            for (var row = 0; row < field.Rows; row++)
            {
                for (var col = 0; col < field.Cols; col++)
                {
                    Console.CursorVisible = false;
                    Console.CursorTop = row + 1;
                    Console.CursorLeft = col + 1;
                    Console.Write(field.IsPopulate(row, col) ? "#" : " ");
                }
            }
        }

        /// <summary>
        /// View string message to the console.
        /// </summary>
        /// <param name="message">Some string message.</param>
        public void ViewMessage(string message)
        {
            Console.CursorVisible = false;
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            Console.Write(message);
        }
    }
}
