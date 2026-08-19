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

        public void AddPersonage(int line, int column)
        {
            Personage personage = new Personage();
            _model[new MazePosition(line, column)] = new Room(personage);;
        }

        public void finish()
        {
        }

        public MazeModel build()
        {
            return _model;
        }
    }
}
