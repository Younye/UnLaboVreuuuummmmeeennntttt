namespace UnLaboVreuuuummmmeeennntttt
{
    public class Room : IMazeElement
    {
        public IMazeObject Content { get; set; }

        public Room() { Content = null; }
        public Room(IMazeObject content) { Content = content; }

        public char Symbol
        {
            get { return Content != null ? Content.Symbol : '.'; }
        }

        public void Visite(Personage personage)
        {
            if (Content != null)
            {
                Content.Visite(personage);
            }
            this.Content = personage;
        }
    }
}
