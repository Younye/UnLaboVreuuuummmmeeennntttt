using System.Collections.Generic;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeModelBuilder : IMazeBuilder
    {
        private MazeModel _model;
        private readonly Dictionary<char, Personage> _definedPersonages = new();

        public void start(string name)
        {
            _model = new MazeModel(name);
            _definedPersonages.Clear();
        }

        public void DefinePersonnage(char symbol, int life, int strength, int defensive)
        {
            _definedPersonages[symbol] = new Personage(symbol, life, strength, defensive);
        }

        public void AddRoom(int line, int column)
        {
            _model[new MazePosition(line, column)] = new Room();
        }

        public void AddWall(int line, int column)
        {
            _model[new MazePosition(line, column)] = new Wall();
        }

        public void AddPersonage(int line, int column, char symbol)
        {
            Personage personage = _definedPersonages.ContainsKey(symbol)
                ? _definedPersonages[symbol]
                : new Personage(symbol);

            _model[new MazePosition(line, column)] = new Room(personage);
        }

        public void AddMonster(int line, int column)
        {
            _model[new MazePosition(line, column)] = new Room(new Monster());
        }

        public void finish()
        {
        }

        public MazeModel build()
        {
            return _model;
        }

        public void AddDoor(int line, int column)
        {
            _model[new MazePosition(line, column)] = new doors();
        }

        public void AddKey(int line, int column)
        {
            _model[new MazePosition(line, column)] = new Room(new MazeKey());
        }
    }
}
