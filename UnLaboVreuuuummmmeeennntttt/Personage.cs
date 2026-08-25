using System.Collections.Generic;
using System.Linq;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class Personage : Combattant
    {
        public Personage(char symbol, int life = 10, int strength = 5, int defensive = 2) 
            : base(symbol, life, strength, defensive)
        {
        }

        public override void Visite(Personage personage)
        {
            personage.Bag.ToList().ForEach(item => Bag.Add(item));
            personage.Bag.Clear();
            throw new MazeException("Collision avec un personnage !");
        }
    }
}
