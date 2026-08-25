using System;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class Monster : Combattant
    {
        public Monster(char symbol = 'M', int life = 12, int strength = 4, int defensive = 1) 
            : base(symbol, life, strength, defensive)
        {
        }

        public override void Visite(Personage personage)
        {
            int damageToMonster = Math.Max(1, personage.Strength - Defensive);
            Life -= damageToMonster;

            if (Life > 0)
            {
                int damageToPlayer = Math.Max(1, Strength - personage.Defensive);
                personage.Life -= damageToPlayer;
                throw new MazeException($"Combat contre le monstre {Symbol} ! Monstre PV: {Life} | Vos PV: {personage.Life}");
            }
        }
    }
}
