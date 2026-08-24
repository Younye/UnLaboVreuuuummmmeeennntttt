using System;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeControler
    {
        public MazeVue? Vue { get; init; }
        public MazeModel? Model { get; init; }

        public void Start()
        {
            if (Vue == null || Model == null) return;
            
            bool isPlaying = true;
            string message = "Début du jeu - Flèches: Bouger | TAB: Joueur suivant | Lettre (A-Z): Choisir joueur | (CTRL+MAJ+Q pour quitter)";
            
            while (isPlaying && Model.Personage.Position != null)
            {
                Console.Clear();
                Vue.Display(Model, message);
                message = "Flèches: Bouger | TAB: Joueur suivant | Lettre (A-Z): Choisir joueur | (CTRL+MAJ+Q pour quitter)";

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Q && 
                    keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control) && 
                    keyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift))
                {
                    isPlaying = false;
                    continue;
                }

                if (keyInfo.Key == ConsoleKey.Tab)
                {
                    Model.ActivePersonage();
                    continue;
                }
                
                if (char.IsLetter(keyInfo.KeyChar))
                {
                    char symbol = char.ToUpper(keyInfo.KeyChar);
                    Model.ActivatePersonage(symbol);
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
                    if (Model.Personage == null)
                    {
                        isPlaying = false;
                        Console.Clear();
                        Vue.Display(Model, message);
                        Console.WriteLine("\nBravo, vous avez trouvé la sortie !");
                    }
                }
                catch (MazeException e)
                {
                    message = e.Message;
                }
            }
        }
    }
}