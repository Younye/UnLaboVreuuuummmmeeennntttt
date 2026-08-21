namespace UnLaboVreuuuummmmeeennntttt
{
    public class Personage : IMazeObject
    {
        public char Symbol => 'O';
        public MazePosition Position { get; set; }

        public void Visite(Personage personage)
        {
        }
        
        public ICollection<IMazeObject> Bag { get; set; } = new HashSet<IMazeObject>();
    }
}
