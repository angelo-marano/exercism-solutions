using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class SimpleLinkedList<T> : IEnumerable<T>
{
    public SimpleLinkedList(T value)
    {
        Value = value;
    }

    public SimpleLinkedList(IEnumerable<T> values) : this(values.First())
    {
        foreach (var v in values.Skip(1))
        {
            Add(v);
        }
    }

    public T Value { get; }

    public SimpleLinkedList<T> Next { get; private set; }

    public SimpleLinkedList<T> Add(T value)
    {
        var current = this;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = new SimpleLinkedList<T>(value);
        return current;
    }

    public IEnumerator<T> GetEnumerator() => new SimpleLinkedListEnumerator(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    private class SimpleLinkedListEnumerator : IEnumerator<T>
    {
        private SimpleLinkedList<T> _current;
        private readonly SimpleLinkedList<T> _start;
        public SimpleLinkedListEnumerator(SimpleLinkedList<T> list)
        {
            _start = list;
            _current = list;
        }

        public bool MoveNext()
        {
            if (_current.Next == null)
            {
                return false;
            }

            _current = _current.Next;
            return true;

        }

        public void Reset() => _current = _start;

        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }
    }

}