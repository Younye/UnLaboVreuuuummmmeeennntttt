using System;
using System.Linq;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeVue
    {
        public void Display(MazeModel model, string message)
        {
            if (!model.Any()) return;
            Console.WriteLine(message);
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
            var persos = model.Select(kvp => kvp.Value.Content).OfType<Personage>();

            foreach (var perso in model.ActivePersonages)
            {
                string prefix = (perso == model.Personage) ? "=> " : "   ";
                string items = string.Join(", ",perso.Bag.Select(item =>item is MazeKey ? "clé" : item.Symbol.ToString()));
                Console.WriteLine($"{prefix}{perso.Symbol}  :{{{items}}}");
            }
        }
    }
}