using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellsLife
{
    /// <summary>
    /// Class Cell describe a life cell.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Cell populating state flag. If cell populate - true, else - false.
        /// </summary>
        private bool _isPopulate;

        /// <summary>
        /// Check the cell state. True if the cell populated, otherwise - false.
        /// </summary>
        public bool IsPopulate { get { return _isPopulate; } }

        /// <summary>
        /// Populate cell. Change cell populating state flag to true.
        /// </summary>
        public void Populate() { this._isPopulate = true; }

        /// <summary>
        /// Unpopulate cell. Change cell populating state flag to false.
        /// </summary>
        public void Unpopulate() { this._isPopulate = false; }
    }
}
