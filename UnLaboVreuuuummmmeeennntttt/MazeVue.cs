using System;
using System.Linq;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeVue
    {
        public void Display(MazeModel model, string message)
        {
            if (!model.Any()) return;

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }

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

            foreach (var perso in model.ActivePersonages)
            {
                string prefix = (perso == model.Personage) ? "=> " : "   ";
                string items = string.Join(", ", perso.Bag.Select(item => item is MazeKey ? "clé" : item.Symbol.ToString()));
                Console.WriteLine($"{prefix}{perso.Symbol} {{ vie : {perso.Life} , force : {perso.Strength} , défense : {perso.Defensive} , panier : [{items}]}}");
            }

            var monsters = model.Select(kvp => kvp.Value.Content).OfType<Monster>();
            foreach (var monster in monsters)
            {
                Console.WriteLine($"   {monster.Symbol} {{ vie : {monster.Life} , force : {monster.Strength} , défense : {monster.Defensive} }} [MONSTRE]");
            }
        }
    }
}