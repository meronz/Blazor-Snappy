namespace Snappy;

public struct Size(int width, int height)
{
    public int Width = width;
    public int Height = height;

    public Size(double width, double height) : this((int)Math.Truncate(width), (int)Math.Truncate(height)) { }

    public static bool operator ==(Size a, Size b) => a.Width == b.Width && a.Height == b.Height;
    public static bool operator !=(Size a, Size b) => a.Width != b.Width || a.Height != b.Height;
    public override bool Equals(object? obj) => obj is Size other && Equals(other);
    public bool Equals(Size other) => Width == other.Width && Height == other.Height;
    public override int GetHashCode() => HashCode.Combine(Width, Height);
    public override string ToString() => $"{Width}x{Height}";

    internal void SnapToGrid(int gridSize)
    {
        Width = (int)Math.Round((double)Width / gridSize) * gridSize;
        Height = (int)Math.Round((double)Height / gridSize) * gridSize;

        Width = Math.Max(gridSize, Width);
        Height = Math.Max(gridSize, Height);
    }

    internal void Clamp(Size canvasSize, Position position)
    {
        if (Width < 1) Width = 1;
        if (Height < 1) Height = 1;

        if (position.X + Width > canvasSize.Width) Width = canvasSize.Width - position.X;
        if (position.Y + Height > canvasSize.Height) Height = canvasSize.Height - position.Y;
    }
}