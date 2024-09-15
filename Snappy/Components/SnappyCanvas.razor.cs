using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Snappy.Components;


[SupportedOSPlatform("browser")]
public partial class SnappyCanvas<TItem> where TItem : IDraggable
{
    [JSImport("getElementPosition", "SnappyCanvas")]
    internal static partial string GetElementPosition(string elementId);

    (Position, Size) ElementPositionFromString(string positionString)
    {
        var positionArray = positionString.Split('|');
        return
            (new Position(double.Parse(positionArray[0]), double.Parse(positionArray[1])),
             new Size(double.Parse(positionArray[2]), double.Parse(positionArray[3])));
    }
}