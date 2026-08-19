using System;
using System.Linq;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeVue
    {
        public void Display(MazeModel model, string message)
        {
            if (!model.Any()) return;

            int maxLine = model.Max(kvp => kvp.Key.Line);
            int maxCol = model.Max(kvp => kvp.Key.Column);

            for (int i = 0; i <= maxLine; i++)
            {
                for (int j = 0; j <= maxCol; j++)
                {
                    var pos = new MazePosition(i, j);
                    if (model[pos] != null)
                    {
                        Console.Write(model[pos].Symbol + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}