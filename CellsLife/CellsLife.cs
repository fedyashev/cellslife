using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellsLife
{
    /// <summary>
    /// Class CellLife describe conway's cells life.
    /// </summary>
    public class CellsLife
    {
        /// <summary>
        /// The field of the life cells.
        /// </summary>
        private Field _field;

        /// <summary>
        /// Number of cells generation.
        /// </summary>
        private int _generation;

        /// <summary>
        /// Minimum number of neighbors.
        /// </summary>
        private const int MIN_NEIGHBORS = 2;

        /// <summary>
        /// Maximum number of neighbors.
        /// </summary>
        private const int MAX_NEIGHBORS = 3;

        /// <summary>
        /// The field of the life cells.
        /// </summary>
        public Field Field
        {
            get
            {
                return _field;
            }

            set
            {
                if (value == null) throw new NullReferenceException();
                _field = value;
            }
        }

        /// <summary>
        /// Number of cells generation.
        /// </summary>
        public int Generation
        {
            get
            {
                return _generation;
            }

            private set
            {
                if (value < 0) throw new ArgumentException();
                _generation = value;
            }
        }

        /// <summary>
        /// Create a new CellsLife object with the clean field.
        /// </summary>
        /// <param name="fieldRows">Field rows number.</param>
        /// <param name="fieldColumns">Field columns number.</param>
        public CellsLife(int fieldRows, int fieldColumns)
        {
            Field = new Field(fieldRows, fieldColumns);
            Generation = 0;
        }
        
        /// <summary>
        /// Create a new CellsLife object with a field pattern.
        /// </summary>
        /// <param name="pattern">Pattern of the field.</param>
        public CellsLife(Field pattern)
        {
            Field = pattern;
            Generation = 0;
        }

        /// <summary>
        /// Set next generation cells in the field.
        /// </summary>
        public void NextGeneration()
        {
            var tmp = new Field(Field.Rows, Field.Cols);
            for (var row = 0; row < Field.Rows; row++)
            {
                for (var col = 0; col < Field.Cols; col++)
                {
                    if (Field.IsPopulate(row, col))
                    {
                        if (Field.GetNeighborsCount(row, col) < MIN_NEIGHBORS || Field.GetNeighborsCount(row, col) > MAX_NEIGHBORS)
                        {
                            tmp.UnpopulateCell(row, col);
                        }
                        else
                        {
                            tmp.PopulateCell(row, col);
                        }
                    }
                    else
                    {
                        if (Field.GetNeighborsCount(row, col) == MAX_NEIGHBORS)
                        {
                            tmp.PopulateCell(row, col);
                        }
                    }
                }
            }
            Field = tmp;
            Generation = Generation + 1;
        }
        
    }
}
