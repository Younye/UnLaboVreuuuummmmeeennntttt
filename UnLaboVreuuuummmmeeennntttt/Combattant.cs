namespace UnLaboVreuuuummmmeeennntttt
{
    public abstract class Combattant(char symbol, int life, int strength, int defensive)
        : IMazeObject
    {
        public char Symbol { get;} = symbol;
        public MazePosition? Position { get; set; }
        public int Life { get; set; } = life;
        public int Strength { get;} = strength;
        public int Defensive { get;} = defensive;
        public ICollection<IMazeObject> Bag { get;} = new HashSet<IMazeObject>();

        public abstract void Visite(Personage personage);
    }
}
