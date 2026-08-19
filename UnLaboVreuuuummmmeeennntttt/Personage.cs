namespace UnLaboVreuuuummmmeeennntttt
{
    public class Personage : IMazeObject
    {
        public char Symbol => 'O';
        
        // Si null, le personnage est hors du labyrinthe
        public MazePosition Position { get; set; } 
    }
}
