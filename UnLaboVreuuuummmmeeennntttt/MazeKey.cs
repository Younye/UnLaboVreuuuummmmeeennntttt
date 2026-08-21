namespace UnLaboVreuuuummmmeeennntttt;

public class MazeKey : IMazeObject
{
    public char Symbol => 'f';
    public void Visite(Personage personage)
    {
        personage.Bag.Add(this);
    }
}