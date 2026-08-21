namespace UnLaboVreuuuummmmeeennntttt;

public class doors : IMazeElement
{   
    public IMazeObject Content { get; set; }
    private bool Open { get; set; }

    public char Symbol
    {
        get
        {
            if (!Open) return '|';
            if (Content != null) return Content.Symbol;
            return '_';
        }
    }
    public void Visite(Personage personage)
    {
        if (!Open)
        {
            var key = personage.Bag.OfType<MazeKey>().FirstOrDefault();

            if (key == null)
            {
                throw new MazeException("T'as pas la clé connard");
            }
            Open = true;
            personage.Bag.Remove(key);
        }
        Content = personage;
    }
}