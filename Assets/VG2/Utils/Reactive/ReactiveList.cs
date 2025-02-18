using System;
using System.Collections;
using System.Collections.Generic;
using R3;

namespace VG2
{
    public class ReactiveList<T> : IEnumerable<T>
    {
        public Observable<Unit> OnChanged => _onChanged; private Subject<Unit> _onChanged = new();
        private List<T> _list;


        public ReactiveList() => _list = new List<T>();

        public ReactiveList(int capacity) => _list = new List<T>(capacity);

        public ReactiveList(List<T> list) => _list = list;



        public int Count => _list.Count;

        public T Find(Predicate<T> predicate) => _list.Find(predicate);

        public bool Exists(Predicate<T> predicate) => _list.Exists(predicate);


        public void Add(T item)
        {
            _list.Add(item);
            _onChanged?.OnNext(Unit.Default);
        }

        public void Remove(T item)
        {
            if (!_list.Contains(item)) return;

            _list.Remove(item);
            _onChanged?.OnNext(Unit.Default);
        }

        public T Get(int index) => _list[index];

        public void Set(int index, T value)
        {
            _list[index] = value;
            _onChanged?.OnNext(Unit.Default);
        }

        public void Clear()
        {
            _list.Clear();
            _onChanged?.OnNext(Unit.Default);
        }

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_list).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_list).GetEnumerator();


        public void ReplaceList(List<T> list)
        {
            _list = list;
            _onChanged?.OnNext(Unit.Default);
        }

    }
}



