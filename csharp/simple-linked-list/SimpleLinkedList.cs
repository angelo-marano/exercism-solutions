using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

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
        while (current.Next == null)
        {
            current = current.Next;
        }

        current.Next = new SimpleLinkedList(value);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new SimpleLinkedListEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    public class SimpleLinkedListEnumerator<T> : IEnumerator<T>
    {
        private SimpleLinkedList<T> _current;
        public SimpleLinkedListEnumerator(SimpleLinkedList<T> list)
        {
            _current = list;
        }
    }

}