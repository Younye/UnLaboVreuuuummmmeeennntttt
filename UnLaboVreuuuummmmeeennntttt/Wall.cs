namespace UnLaboVreuuuummmmeeennntttt
{
    public class Wall : IMazeElement
    {
        public char Symbol => '*';

        public IMazeObject Content
        {
            get => null;
            set
            {
                if (value != null) throw new MazeException("Impossible d'ajouter un objet : un mur ne peut pas contenir d'objet.");
            }
        }

        public void Visite(Personage personage)
        {
            throw new MazeException("Les personnages ne traversent pas les murs");
        }
    }
}
