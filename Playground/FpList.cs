using System.Collections;

namespace Playground;


public class FpList<T> : IEnumerable<T>
{
    private T Head { get; init; }
    public FpList<T>? Tail { get; init; }

    public static FpList<T> Create(T item)
    {
        return new FpList<T> { Head = item, Tail = null };
    }

    public void Deconstruct(out T head, out FpList<T>? tail)
    {
        head = Head;
        tail = Tail;
    }

    public static FpList<T> operator +(FpList<T> list, T item)
    {
        return new FpList<T> { Head = item, Tail = list };
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(this);
    }

    private class Enumerator : IEnumerator<T>
    {
        private readonly FpList<T> _start;
        private FpList<T> _current;

        public Enumerator(FpList<T> value)
        {
            _start = value;
        }

        public T Current => _current.Head;

        object IEnumerator.Current => _current.Head;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                _current = _start;
            }
            else
            {
                _current = _current?.Tail;
            }
            return _current != null;
        }

        public void Reset()
        {
            _current = _start;
        }
    }

    public class Builder : IEnumerable<T>
    {
        private FpList<T>? list;

        public FpList<T> Build()
        {
            return list;
        }

        public void Add(T item)
        {
            this.list = list + item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new FpList<T>.Enumerator(list);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new FpList<T>.Enumerator(list);
        }
    }
}
