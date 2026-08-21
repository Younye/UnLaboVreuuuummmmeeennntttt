using System;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeControler
    {
        public MazeVue Vue { get; set; }
        public MazeModel Model { get; set; }

        public void start()
        {
            if (Vue == null || Model == null) return;
            
            bool isPlaying = true;
            string message = "Début du jeu - Flèches pour bouger. (CTRL+MAJ+Q pour quitter)";

            // Boucle principale
            while (isPlaying && Model.Personage != null && Model.Personage.Position != null)
            {
                Console.Clear();
                Vue.Display(Model, message);
                message = "";

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Check du CTRL+MAJ+Q (en console c'est Q + Modifiers)
                if (keyInfo.Key == ConsoleKey.Q && 
                    keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control) && 
                    keyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift))
                {
                    isPlaying = false;
                    continue;
                }

                try
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Model.Move(Direction.NORD);
                            break;
                        case ConsoleKey.DownArrow:
                            Model.Move(Direction.SUD);
                            break;
                        case ConsoleKey.RightArrow:
                            Model.Move(Direction.EST);
                            break;
                        case ConsoleKey.LeftArrow:
                            Model.Move(Direction.OUEST);
                            break;
                    }
                }
                catch (OutOfMazeException e)
                {
                    message = e.Message;
                    isPlaying = false;
                    Console.Clear();
                    Vue.Display(Model, message);
                    Console.WriteLine("\nBravo, vous avez trouvé la sortie !");
                }
                catch (MazeException e)
                {
                    message = e.Message;
                }
            }
        }
    }
}