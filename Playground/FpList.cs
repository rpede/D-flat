using System.Collections;

namespace Playground;


public record FpList<T>(T head, FpList<T>? tail) : IEnumerable<T>
{
    public static FpList<T> operator +(FpList<T> list, T item) => new FpList<T>(item, list);
    public IEnumerator<T> GetEnumerator() => new Enumerator(this);
    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);
    private class Enumerator : IEnumerator<T>
    {
        private readonly FpList<T> _start;
        private FpList<T> _current;
        public Enumerator(FpList<T> value) => _start = value;
        public T Current => _current.head;
        object IEnumerator.Current => _current.head;
        public void Dispose() { }
        public bool MoveNext() => (_current = _current == null ? _start : _current?.tail) != null;
        public void Reset() => _current = _start;
    }

    public class Builder : IEnumerable<T>
    {
        private FpList<T>? list;
        public FpList<T> Build() => list ?? throw new InvalidOperationException($"Can not build empty {typeof(FpList<>).Name} !");
        public void Add(T item) => list = list + item;
        public IEnumerator<T> GetEnumerator() => new FpList<T>.Enumerator(list);
        IEnumerator IEnumerable.GetEnumerator() => new FpList<T>.Enumerator(list);
    }
}
