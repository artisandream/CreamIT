using System.Collections;

public static class Extensions
{
    public static bool InBounds(this IList list, int index)
    {
        return list != null && (index > 0 || index < list.Count);
    }
}
