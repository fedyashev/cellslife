using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellsLife
{
    public interface IView
    {
        /// <summary>
        /// View field.
        /// </summary>
        /// <param name="field">The field of the life cells.</param>
        void ViewField(Field field);

        /// <summary>
        /// View message.
        /// </summary>
        /// <param name="message">Some message.</param>
        void ViewMessage(String message);
    }
}
