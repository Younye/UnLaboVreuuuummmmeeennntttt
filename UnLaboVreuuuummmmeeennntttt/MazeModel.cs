using System.Collections;
using System.Collections.Generic;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeModel : IEnumerable<KeyValuePair<MazePosition, IMazeElement>>
    {
        public string Name { get; }
        private SortedDictionary<MazePosition, IMazeElement> grid;
        public Personage Personage { get; private set; }

        public MazeModel(string nom)
        {
            Name = nom;
            grid = new SortedDictionary<MazePosition, IMazeElement>();
        }

        public IMazeElement this[MazePosition position]
        {
            get => grid.ContainsKey(position) ? grid[position] : null;
            set
            {
                grid[position] = value;
                if (value != null && value.Content is Personage perso)
                {
                    this.Personage = perso;
                    this.Personage.Position = position;
                }
            }
        }

        public void Move(Direction direction)
        {
            if (Personage == null || Personage.Position == null) return;
            
            MazePosition destination = Personage.Position[direction];

            if (this[destination] == null)
            {
                Personage.Position = null;
                throw new OutOfMazeException("Le personnage est sorti du Labyrinthe.");
            }

            this[destination].Visite(Personage);

            this[Personage.Position].Content = null;

            Personage.Position = destination;
        }

        public IEnumerator<KeyValuePair<MazePosition, IMazeElement>> GetEnumerator() => grid.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}