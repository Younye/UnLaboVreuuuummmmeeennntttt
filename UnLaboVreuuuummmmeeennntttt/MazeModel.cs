using System.Collections;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeModel(string nom) : IEnumerable<KeyValuePair<MazePosition, IMazeElement>>
    {
        public string Name { get; } = nom;
        public Personage Personage { get; set; }
        private readonly SortedDictionary<MazePosition, IMazeElement?> _grid = new();

        public IMazeElement? this[MazePosition position]
        {
            get => _grid.ContainsKey(position) ? _grid[position] : null;
            set
            {
                _grid[position] = value;

                if (value == null || value.Content is not Personage perso) return;
                Personage = perso;
                Personage.Position =  position;
            }
        }

        public IEnumerator<KeyValuePair<MazePosition, IMazeElement>> GetEnumerator()
        {
            return _grid.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}