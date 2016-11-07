using System;
using System.Collections.Generic;
using System.Linq;

namespace philly.numpy
{
    public class NdArray<T>
    {
        private List<ArrayList<T>> _list = new List<ArrayList<T>>();
    }

    internal class ArrayList<T>
    {
        private List<ArrayList<T>> _list;

        protected ArrayList()
        {
            _list = new List<ArrayList<T>>();
        }

        public ArrayList(Array array) : this()
        {
            if(array.Rank >= 1)
            {
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    Array ary = (Array)array.GetValue(i);
                    _list.Add(new ArrayList<T>(array));
                }
            }
            else
            {

            }
        }
    }

    internal class ElementList<T> : ArrayList<T>
    {
        public ElementList(Array array) : base()
        {

        }
    }
}
