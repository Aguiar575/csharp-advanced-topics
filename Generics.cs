using System;

namespace Generics;

public class Utilities<T> where T : IComparable
{
    public T Max(T a, T b)
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}

public class Nullable<T> where T : struct
{
    private object _value;

    public Nullable()
    {
    }

    public Nullable(T value) =>
        _value = value;

    public bool HasValue
    {
        get => _value != null;
    }

    public T GetValueOrDefault() =>
        HasValue ? (T)_value : default(T);

    public void SetValue(T value) =>
        _value = value;
}
