using System;
using System.Collections.Generic;
using System.IO;

namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazeFileReader
    {
        private readonly IMazeBuilder _builder;
        public delegate void ElementRead(int row, int column);
        private readonly Dictionary<char, ElementRead> _elementsReader;

        public MazeFileReader(IMazeBuilder builder)
        {
            _builder = builder;
            _elementsReader = new Dictionary<char, ElementRead>
            {
                { '*', builder.AddWall },
                { '.', builder.AddRoom },
                { '|', builder.AddDoor },
                { 'f', builder.AddKey },
                { 'M', builder.AddMonster }
            };
        }

        public void Read(string mazeName)
        {
            string fileName = mazeName + ".maze";

            if (File.Exists(fileName))
            {
                _builder.start(mazeName);
                string[] lines = File.ReadAllLines(fileName);

                int lineIndex = 0;
                while (lineIndex < lines.Length && lines[lineIndex].Contains(':'))
                {
                    string def = lines[lineIndex].Trim();
                    if (!string.IsNullOrEmpty(def))
                    {
                        var parts = def.Split(':');
                        if (parts.Length == 2 && parts[0].Length == 1)
                        {
                            char symbol = parts[0][0];
                            var stats = parts[1].Split(',');
                            if (stats.Length == 3 &&
                                int.TryParse(stats[0], out int life) &&
                                int.TryParse(stats[1], out int strength) &&
                                int.TryParse(stats[2], out int defensive))
                            {
                                _builder.DefinePersonnage(symbol, life, strength, defensive);
                            }
                        }
                    }
                    lineIndex++;
                }

                int mazeRow = 0;
                for (int ligne = lineIndex; ligne < lines.Length; ligne++)
                {
                    string currentLine = lines[ligne];
                    for (int colonne = 0; colonne < currentLine.Length; colonne++)
                    {
                        char c = currentLine[colonne];
                        if (c != 'M' && char.IsUpper(c))
                        {
                            _builder.AddPersonage(mazeRow, colonne, c);
                        }
                        else if (_elementsReader.ContainsKey(c))
                        {
                            _elementsReader[c](mazeRow, colonne);
                        }
                    }
                    mazeRow++;
                }
                _builder.finish();
            }
            else
            {
                Console.WriteLine($"Erreur : Le fichier {fileName} n'existe pas.");
            }
        }
    }
}