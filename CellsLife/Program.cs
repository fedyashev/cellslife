using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellsLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int viewDelay = 100;
            int rows = 20;
            int cols = 20;
            
            const int FINAL_GENERATION = 200;

            var view = new ConsoleView();
            var pattern = new Field(rows, cols);
            var life = new CellsLife(pattern);
            
            // Glider
            pattern.PopulateCell(0, 1);
            pattern.PopulateCell(1, 2);
            pattern.PopulateCell(2, 0);
            pattern.PopulateCell(2, 1);
            pattern.PopulateCell(2, 2);

            pattern.PopulateCell(5, 15);
            pattern.PopulateCell(6, 15);
            pattern.PopulateCell(6, 16);
            pattern.PopulateCell(6, 17);
            pattern.PopulateCell(7, 16);

            view.ViewMessage(String.Format("Generation: {0}", life.Generation));
            view.ViewField(life.Field);
            System.Threading.Thread.Sleep(viewDelay);

            while (life.Generation < FINAL_GENERATION)
            {
                life.NextGeneration();
                view.ViewMessage(String.Format("Generation: {0}", life.Generation));
                view.ViewField(life.Field);
                System.Threading.Thread.Sleep(viewDelay);
            }
        }

    }
}
