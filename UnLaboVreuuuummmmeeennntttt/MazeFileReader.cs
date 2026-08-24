using System;
using System.Collections.Generic;
using System.IO;

namespace UnLaboVreuuuummmmeeennntttt;

public class MazeFileReader(IMazeBuilder builder)
{
    private delegate void ElementRead(int row, int column);
    private readonly Dictionary<char, ElementRead> _elementsReader = new()
    {
        { '*', builder.AddWall },
        { '.', builder.AddRoom },
        { '|', builder.AddDoor },
        { 'f', builder.AddKey }
    };

    public void Read(string mazeName)
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
                    if (_elementsReader.TryGetValue(c, out var value))
                    {
                        value(ligne, colonne);
                    }
                    
                    if (char.IsUpper(c))
                    {
                        Console.WriteLine("67"); 
                        builder.AddPersonage(ligne,colonne,c);
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