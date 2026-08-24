namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeModelBuilder : IMazeBuilder
    {
        private MazeModel _model;

        public void start(string name)
        {
            _model = new MazeModel(name);
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
            Personage personage = new Personage(symbol)
            {
                Symbol = symbol
            };
            _model[new MazePosition(line, column)] = new Room(personage);
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
