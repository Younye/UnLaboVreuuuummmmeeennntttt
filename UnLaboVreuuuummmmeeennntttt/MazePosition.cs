using System;
namespace UnLaboVreuuuummmmeeennntttt
{
    public class MazePosition : IComparable<MazePosition>, IEquatable<MazePosition>
    {
        public int Line { get; }
        public int Column { get; }
        
        public MazePosition(int line, int column) 
        { 
            Line = line; 
            Column = column; 
        }
        
        public MazePosition this[Direction direction]
        {
            get
            {
                switch (direction)
                {
                    case Direction.NORD: return new MazePosition(Line - 1, Column);
                    case Direction.SUD: return new MazePosition(Line + 1, Column);
                    case Direction.EST: return new MazePosition(Line, Column + 1);
                    case Direction.OUEST: return new MazePosition(Line, Column - 1);
                    default: return this;
                }
            }
        }

        public int CompareTo(MazePosition other)
        {
            if (other == null) return 1;
            int lineComparison = Line.CompareTo(other.Line);
            if (lineComparison != 0) return lineComparison;
            return Column.CompareTo(other.Column);
        }

        public bool Equals(MazePosition other)
        {
            if (other == null) return false;
            return Line == other.Line && Column == other.Column;
        }

        public override bool Equals(object obj) => Equals(obj as MazePosition);
        public override int GetHashCode() => HashCode.Combine(Line, Column);
    }
}
