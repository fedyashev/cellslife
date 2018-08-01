using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellsLife
{
    /// <summary>
    /// Class Field describe the field of the life cells.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Array cells on the field.
        /// </summary>
        private Cell[][] _cells;

        /// <summary>
        /// Amount rows on the cells field.
        /// </summary>
        private int _rows;

        /// <summary>
        /// Amount colums on the cells field.
        /// </summary>
        private int _cols;

        /// <summary>
        /// Amount rows on the cells field.
        /// </summary>
        public int Rows {
            get { return _rows;}

            private set {
                if (value <= 0) throw new ArgumentException("Incorrect rows value.");
                this._rows = value;
            }
        }

        /// <summary>
        /// Amount columns on the cells field.
        /// </summary>
        public int Cols
        {
            get { return _cols; }

            private set
            {
                if (value <= 0) throw new ArgumentException("Incorrect columns value.");
                this._cols = value;
            }
        }

        /// <summary>
        /// Create a new field with the rows and columns dimensions.
        /// </summary>
        /// <param name="rows">Amount rows in the field of the cells.</param>
        /// <param name="cols">Amount columns in the field of the cells.</param>
        public Field(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            InitializeField();
        }

        /// <summary>
        /// Initialize field of the cells.
        /// </summary>
        private void InitializeField()
        {
            this._cells = new Cell[Rows][];
            for (var row = 0; row < Rows; row++)
            {
                this._cells[row] = new Cell[Cols];
                for (var col = 0; col < Cols; col++)
                {
                    this._cells[row][col] = new Cell();
                }
            }
        }

        /// <summary>
        /// Get cell at from field by coordinates.
        /// </summary>
        /// <param name="row">Number of row.</param>
        /// <param name="col">Number of column.</param>
        /// <returns></returns>
        public Cell GetCell(int row, int col)
        {
            if (row < 0 || row >= Rows) throw new ArgumentException("Incorrect row value.");
            if (col < 0 || col >= Cols) throw new ArgumentException("Incorrect columns value.");
            return this._cells[row][col];
        }

        /// <summary>
        /// Populate cell in the field by row and col coordinates.
        /// </summary>
        /// <param name="row">Cells row.</param>
        /// <param name="col">Cells column.</param>
        public void PopulateCell(int row, int col)
        {
            var cell = GetCell(row, col);
            if (cell == null) throw new NullReferenceException("Cell refrrence is null.");
            cell.Populate();
        }

        /// <summary>
        /// Unpopulate cell in the field by row and col coordinates.
        /// </summary>
        /// <param name="row">Cells row.</param>
        /// <param name="col">Cells column.</param>
        public void UnpopulateCell(int row, int col)
        {
            var cell = GetCell(row, col);
            if (cell == null) throw new NullReferenceException("Cell refrrence is null.");
            cell.Unpopulate();
        }

        /// <summary>
        /// Check if cell in the field is populated.
        /// </summary>
        /// <param name="row">Cells row.</param>
        /// <param name="col">Cells column.</param>
        /// <returns></returns>
        public bool IsPopulate(int row, int col)
        {
            var cell = GetCell(row, col);
            if (cell == null) throw new NullReferenceException("Cell refrrence is null.");
            return cell.IsPopulate;
        }
        
        /// <summary>
        /// Get cells neighbors count.
        /// </summary>
        /// <param name="row">Cells row.</param>
        /// <param name="col">Cells column.</param>
        /// <returns></returns>
        public int GetNeighborsCount(int row, int col)
        {
            if (row < 0 || row >= Rows) throw new ArgumentException("Incorrect row value.");
            if (col < 0 || col >= Cols) throw new ArgumentException("Incorrect columns value.");
            if (this._cells[row][col] == null) throw new NullReferenceException("Cell refrrence is null.");

            int count = 0;

            if (row - 1 >= 0)
            {
                if (col - 1 >= 0 && this._cells[row - 1][col - 1].IsPopulate) count++;
                if (col >= 0 && this._cells[row - 1][col].IsPopulate) count++;
                if (col + 1 <= Cols - 1 && this._cells[row - 1][col + 1].IsPopulate) count++;
            }
            if (row + 1 <= Rows - 1)
            {
                if (col - 1 >= 0 && this._cells[row + 1][col - 1].IsPopulate) count++;
                if (col >= 0 && this._cells[row + 1][col].IsPopulate) count++;
                if (col + 1 <= Cols - 1 && this._cells[row + 1][col + 1].IsPopulate) count++;
            }
            if (col - 1 >= 0 && this._cells[row][col - 1].IsPopulate) count++;
            if (col + 1 <= Cols - 1 && this._cells[row][col + 1].IsPopulate) count++;
            return count;
        }

    }
}
