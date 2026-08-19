namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeFactory
    {
        public MazeModel CreateLabyrinthe(string name)
        {
            MazeModelBuilder builder = new MazeModelBuilder();
            MazeFileReader reader = new MazeFileReader(builder);
            
            reader.read(name);
            
            return builder.build();
        }
    }
}