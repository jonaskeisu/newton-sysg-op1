namespace GameLib
{
    public struct Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public static implicit operator Position((int row, int column) position) =>
            new Position() { Row = position.row, Column = position.column };

        public static Position operator +(Position a, Position b) =>
            new Position() { Row = a.Row + b.Row, Column = a.Column + b.Column };
    }
}