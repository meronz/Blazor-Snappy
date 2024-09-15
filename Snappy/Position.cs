namespace Snappy;

public struct Position(int x, int y)
{
    public int X = x;
    public int Y = y;

    public Position(double x, double y) : this((int)Math.Truncate(x), (int)Math.Truncate(y)) { }

    public static Position operator +(Position a, Position b) => new(a.X + b.X, a.Y + b.Y);
    public static Position operator -(Position a, Position b) => new(a.X - b.X, a.Y - b.Y);
    public static Position operator /(Position a, int n) => new(a.X / n, a.Y / n);

    public static bool operator ==(Position a, Position b) => a.X == b.X && a.Y == b.Y;
    public static bool operator !=(Position a, Position b) => a.X != b.X || a.Y != b.Y;

    public override bool Equals(object? obj) => obj is Position other && Equals(other);

    public bool Equals(Position other) => X == other.X && Y == other.Y;

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public override string ToString() => $"{X}:{Y}";

    internal void Clamp(Size canvasSize, Size itemSize)
    {
        if (X < 0) X = 0;
        if (Y < 0) Y = 0;

        if (X + itemSize.Width > canvasSize.Width) X = canvasSize.Width - itemSize.Width;
        if (Y + itemSize.Height > canvasSize.Height) Y = canvasSize.Height - itemSize.Height;
    }

    internal void SnapToGrid(int gridSize)
    {
        X = (int)Math.Round((double)X / gridSize) * gridSize;
        Y = (int)Math.Round((double)Y / gridSize) * gridSize;
    }
}