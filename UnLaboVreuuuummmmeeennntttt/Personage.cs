namespace UnLaboVreuuuummmmeeennntttt
{
    public class Personage(char symbol) : IMazeObject
    {
        public char Symbol { get; set; } = symbol;
        public MazePosition? Position { get; set; }

        public void Visite(Personage visiteur)
        {
            visiteur.Bag.ToList().ForEach(item => this.Bag.Add(item));
            
            visiteur.Bag.Clear();

            throw new MazeException("La colision est un personnage");
        }
        
        public ICollection<IMazeObject> Bag { get; set; } = new HashSet<IMazeObject>();
    }
}
