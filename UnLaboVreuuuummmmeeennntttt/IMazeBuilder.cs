namespace UnLaboVreuuuummmmeeennntttt
{
    public interface IMazeBuilder
    {
        void start(string name);
        void AddRoom(int line, int column);
        void AddWall(int line, int column);
        void AddPersonage(int line, int column);
        void finish();
        void AddDoor(int line, int column);
        void AddKey(int line, int column);
    }
}
