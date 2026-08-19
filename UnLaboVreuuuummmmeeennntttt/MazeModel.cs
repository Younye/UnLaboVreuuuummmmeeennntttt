using System.Collections;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeModel(string nom) : IEnumerable<KeyValuePair<MazePosition, IMazeElement>>
    {
        public string Name { get; } = nom;
        private readonly SortedDictionary<MazePosition, IMazeElement?> _grid = new();

        public IMazeElement? this[MazePosition position]
        {
            get => _grid.ContainsKey(position) ? _grid[position] : null;
            set => _grid[position] = value;
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