namespace UnLaboVreuuuummmmeeennntttt
{
    public interface IMazeBuilder
    {
        void start(string name);
        void AddRoom(int line, int column);
        void AddWall(int line, int column);
        void AddPersonage(int line, int column);
        void finish();
    }
}
