using System.Collections;
using System.Collections.Generic;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeModel : IEnumerable<KeyValuePair<MazePosition, IMazeElement>>
    {
        public string Name { get; }
        private readonly SortedDictionary<MazePosition, IMazeElement> _grid;

        private readonly Dictionary<char, Personage> _personageMap = new Dictionary<char, Personage>();
        private readonly List<char> _personnageKey = new();
        private int _personageActif = 0;
        
        public Personage? Personage => _personnageKey.Count > 0
        ? _personageMap[_personnageKey[_personageActif]] :  null;
        
        public IEnumerable<Personage> ActivePersonages => _personnageKey.Select(k => _personageMap[k]);

        public MazeModel(string nom)
        {
            Name = nom;
            _grid = new SortedDictionary<MazePosition, IMazeElement>();
        }

        public IMazeElement? this[MazePosition position]
        {
            get => _grid.ContainsKey(position) ? _grid[position] : null;
            set
            {
                _grid[position] = value;

                if (value != null && value.Content is Personage perso)
                {
                    perso.Position = position;
                    if (!_personageMap.ContainsKey(perso.Symbol))
                    {
                        _personageMap.Add(perso.Symbol, perso);
                        _personnageKey.Add(perso.Symbol);
                    }
                }

            }
        }
        public void ActivePersonage()
        {
            if (_personnageKey.Count == 0) return;
            _personageActif = (_personageActif + 1) % _personageMap.Count;
        }

        public void ActivatePersonage(char symbol)
        {
            int index = _personnageKey.IndexOf(symbol);
            if (index != -1) _personageActif = index;
        }
        public void Move(Direction direction)
        {
            if (Personage == null || Personage.Position == null) return;

            var currentPerso = Personage;
            MazePosition destination = Personage.Position[direction];

            if (this[destination] == null)
            {
                Personage.Position = null;
                
                _personnageKey.Remove(currentPerso.Symbol);

                if (_personnageKey.Count > 0) _personageActif = _personageActif % _personnageKey.Count;
                throw new OutOfMazeException($"Le personnage {currentPerso.Symbol} est sorti du Labyrinthe.");
            }

            this[destination]?.Visite(currentPerso);
            this[currentPerso.Position]?.Content = null;
            currentPerso.Position = destination;
        }

        public IEnumerator<KeyValuePair<MazePosition, IMazeElement>> GetEnumerator() => _grid.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}