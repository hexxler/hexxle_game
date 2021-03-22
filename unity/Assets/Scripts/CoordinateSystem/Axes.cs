using System;
using System.Collections.Generic;
using System.Linq;


namespace Hexxle.CoordinateSystem
{
    public class Axes<T> where T : class, new()
    {
        private T _zero;
        private List<T> _negative, _positive;


        public Axes()
        {
            _zero = new T();
            _negative = new List<T>();
            _positive = new List<T>();
        }


        private void RearageCheck(ref List<T> list, int size)
        {
            if (size > list.Count)
                list.AddRange(Enumerable.Repeat(false, size - list.Count).Select(x => new T()));
        }

        private T CheckedGetValue(ref List<T> list, int index)
        {
            RearageCheck(ref list, index);
            return list[index - 1];
        }

        private void CheckedSetValue(ref List<T> list, int index, T value)
        {
            RearageCheck(ref list, index);
            list[index - 1] = value;
        }


        private T GetValue(int index)
        {
            if (index < 0)
                return CheckedGetValue(ref _negative, Math.Abs(index));
            if (index > 0)
                return CheckedGetValue(ref _positive, index);
            return _zero;
        }

        private void SetValue(int index, T value)
        {
            if (index < 0)
                CheckedSetValue(ref _negative, Math.Abs(index), value);
            else if (index > 0)
                CheckedSetValue(ref _positive, index, value);
            else
                _zero = value;
        }


        public T this[int index]
        {
            get => GetValue(index);
            set => SetValue(index, value);
        }
    }
}