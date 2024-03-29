﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DDManagerSolution.ViewModel
{
    public static class ObservableUtil
    {
        public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable<T>, IEquatable<T>
        {
            List<T> sorted = collection.OrderBy(x => x).ToList();

            int ptr = 0;
            while (ptr < sorted.Count - 1)
            {
                if (!collection[ptr].Equals(sorted[ptr]))
                {
                    int idx = search(collection, ptr + 1, sorted[ptr]);
                    collection.Move(idx, ptr);
                }

                ptr++;
            }
        }

        public static int search<T>(ObservableCollection<T> collection, int startIndex, T other)
        {
            for (int i = startIndex; i < collection.Count; i++)
            {
                if (other.Equals(collection[i]))
                    return i;
            }

            return -1; // decide how to handle error case
        }
    }
}
