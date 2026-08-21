using System;
using System.Collections.Generic;
using System.IO;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeFileReader
    {
        private IMazeBuilder builder;
        public delegate void ElementRead(int row, int column);
        private Dictionary<char, ElementRead> elementsReader;

        public MazeFileReader(IMazeBuilder builder)
        {
            this.builder = builder;
            elementsReader = new Dictionary<char, ElementRead>();
            
            elementsReader.Add('*', builder.AddWall);
            elementsReader.Add('.', builder.AddRoom);
            elementsReader.Add('O', builder.AddPersonage);
            elementsReader.Add('|', builder.AddDoor);
            elementsReader.Add('f', builder.AddKey);
        }

        public void read(string mazeName)
        {
            string fileName = mazeName + ".maze";

            if (File.Exists(fileName))
            {
                builder.start(mazeName);
                string[] lines = File.ReadAllLines(fileName);
                
                for (int ligne = 0; ligne < lines.Length; ligne++)
                {
                    string currentLine = lines[ligne];
                    for (int colonne = 0; colonne < currentLine.Length; colonne++)
                    {
                        char c = currentLine[colonne];
                        if (elementsReader.ContainsKey(c))
                        {
                            elementsReader[c](ligne, colonne);
                        }
                    }
                }
                builder.finish();
            }
            else
            {
                Console.WriteLine($"Erreur : Le fichier {fileName} n'existe pas.");
            }
        }
    }
}