namespace UnLaboVreuuuummmmeeennntttt
{
    public class Room : IMazeElement
    {
        public IMazeObject Content { get; set; }

        public Room()
        {
            Content = null;
        }

        public Room(IMazeObject content)
        {
            Content = content;
        }

        public char Symbol
        {
            get
            {
                if (Content != null)
                {
                    return Content.Symbol;
                }
                return '.';
            }
        }
    }
}
