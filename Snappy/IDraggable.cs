namespace Snappy;

public interface IDraggable
{
    public Position Position { get; }
    public Size Size { get; }

    internal bool OverlapsWith(Position otherPosition, Size otherSize) =>
        Position.X < otherPosition.X + otherSize.Width &&
        Position.X + Size.Width > otherPosition.X &&
        Position.Y < otherPosition.Y + otherSize.Height &&
        Position.Y + Size.Height > otherPosition.Y;
}