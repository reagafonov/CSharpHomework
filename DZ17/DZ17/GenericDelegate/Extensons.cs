using System;
using System.Collections;
using System.Linq;

namespace DZ17.GenericDelegate;

public static class Extensons
{
    public static T? GetMax<T>(this IEnumerable e, Func<T, float> getParameter) where T:class
    {
        ILookup<float, T?> elements = e.OfType<T>().ToLookup(getParameter);
        if (!elements.Any()) return default;
        var maxKey = elements.Max(x => x.Key);
        return elements[maxKey].First();
    }
    
    
}