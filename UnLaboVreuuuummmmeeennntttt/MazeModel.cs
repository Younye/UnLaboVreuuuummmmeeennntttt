using System.Collections;
using System.Collections.Generic;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeModel : IEnumerable<KeyValuePair<MazePosition, IMazeElement>>
    {
        public string Name { get; }
        private SortedDictionary<MazePosition, IMazeElement> grid;

        public MazeModel(string nom)
        {
            Name = nom;
            grid = new SortedDictionary<MazePosition, IMazeElement>();
        }

        public IMazeElement this[MazePosition position]
        {
            get => grid.ContainsKey(position) ? grid[position] : null;
            set => grid[position] = value;
        }

        public IEnumerator<KeyValuePair<MazePosition, IMazeElement>> GetEnumerator()
        {
            return grid.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}