using System;
using DataStructureCore;

namespace Cheat_Sheet
{
    class Program
    {
        #region Node
        /////////////
        ////Node////
        ///////////
        public static int CountNodes<T>(Node<T> lst)
        {
            Node<T> pos = lst;
            int counter = 0;
            while (pos != null)
            {
                counter++;
                pos = pos.GetNext();
            }
            return counter;
        } //Counts the number of nodes in the list (not including the last null)

        public static int MaxNode(Node<int> lst)
        {
            int max = int.MinValue;
            while(lst != null)
            {
                int num = lst.GetValue();
                max = Math.Max(max, num);
                lst = lst.GetNext();
            }
            return max;
        } //Returns the largest number in the list

        public static int MinNode(Node<int> lst)
        {
            int min = int.MaxValue;
            while (lst != null)
            {
                int num = lst.GetValue();
                min = Math.Min(min, num);
                lst = lst.GetNext();
            }
            return min;
        } //Returns the smalles number in the list

        public static bool Exists<T>(Node<T> lst, T val)
        {
            while(lst != null)
            {
                T currentVal = lst.GetValue();
                if (currentVal.Equals(val))
                    return true;
                lst = lst.GetNext();
            }
            return false;
        } //Returns true if val exists in the list

        public static Node<int> InsertedSorted(Node<int> lst, int val)
        {
            Node<int> dummy = new Node<int>(-1, lst);
            Node<int> temp = dummy;
            bool found = false;
            while (temp.HasNext())
            {
                Node<int> next = temp.GetNext();
                if (!found && next.GetValue() < val)
                {
                    temp.SetNext(new Node<int> (val, next));
                    found = true;
                }
                temp = temp.GetNext();
            }
            if (!found)
                temp.SetNext(new Node<int> (val));
            return dummy.GetNext();
        } //Inserts val into the a sorted list (from small to big)

        public static Node<int> DeleteItem(Node<int> lst, int val)
        {
            Node<int> pos = lst, prev = null;
            while (pos != null && pos.GetValue() != val)
            {
                prev = pos;
                pos = pos.GetNext();
            }
            if (pos.GetValue() == val)
            {
                if (pos == lst)
                    lst = lst.GetNext();
                else
                    prev.SetNext(pos.GetNext());
            }
            return lst;

        } //Deletes all the nodes containing val using dummy

        public static void Sort(Node<int> lst)
        {
            Node<int> pos = lst;
            while (pos != null)
            {
                Node<int> temp = lst;
                while (temp.HasNext())
                {
                    if (temp.GetValue() > temp.GetNext().GetValue())
                    {
                        int value = temp.GetValue();
                        temp.SetValue(temp.GetNext().GetValue());
                        temp.GetNext().SetValue(value);
                    }
                    temp = temp.GetNext();
                }
                pos = pos.GetNext();
            }
        } //Sorts a list from small to big
        #endregion

        #region Array
        /////////////
        ////Array////
        /////////////
        public static void BubbleSortAscending(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        } //Sorts an array (using Bubble Sort) in ascending order

        public static void BubbleSortDescending(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        } //Sorts an array (using Bubble Sort) in descending order

        public static int[] MergeArrays(int[] arr1, int[] arr2)
        {
            int[] newArr = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length; i++)
                newArr[i] = arr1[i];
            for (int i = arr1.Length; i < newArr.Length; i++)
                newArr[i] = arr2[i - arr2.Length];
            return newArr;
        } //Merges to arrays

        public static int[] MergeSortArrays(int[] arr1, int[] arr2)
        {
            int[] merged = MergeArrays(arr1, arr2);
            BubbleSortAscending(merged);
            return merged;
        } //Merges two arrays and sorts the new array

        public static void DeleteByValue(int[] arr, int val)
        {
            if (arr[arr.Length - 1] == val)
            {
                arr[arr.Length - 1] = 0;
                return;
            }
            bool found = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == val)
                    found = true;
                if (found)
                {
                    arr[i] = arr[i + 1];
                }
            }
            arr[arr.Length - 1] = 0;
        } //Deletes a value from an array (only the first appearance of that value)

        public static void DeleteByIndex(int[] arr, int index)
        {
            for (int i = index; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = 0; // 0 represents the default value of the array
        } //Deletes the value in the desired index and moves all cells back (fills in the hole)

        #endregion

        #region Queue
        /////////////
        ////Queue////
        /////////////

        public static Queue<T> Clone<T>(Queue<T> q)
        {
            Queue<T> temp = new Queue<T>();
            Queue<T> copy = new Queue<T>();
            while (!q.IsEmpty())
                temp.Insert(q.Remove());
            while (!temp.IsEmpty())
            {
                copy.Insert(temp.Head());
                q.Insert(temp.Remove());
            }
            return copy;
        } //Clones the desired Queue

        public static void MergeQueues(Queue<int> q1, Queue<int> q2) //Merges q2 into q1 (sorted)
        {
            while (!q2.IsEmpty())
                InsertIntoQueueAscending(q1, q2.Remove());
        }

        public static void InsertIntoQueueAscending(Queue<int> q, int val)
        {
            if (q.IsEmpty())
            {
                q.Insert(val);
                return;
            }
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                int v = q.Remove();
                if (val <= v)
                {
                    temp.Insert(val);
                    temp.Insert(v);
                    break;
                }
                if (q.IsEmpty())
                {
                    temp.Insert(v);
                    temp.Insert(val);
                    break;
                }
                temp.Insert(v);
            }
            while (!q.IsEmpty())
                temp.Insert(q.Remove());
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
        } //Inserts val into q (in ascending order)

        public static T Max<T>(Queue<T> q)
            where T : IComparable
        {
            if (q.IsEmpty())
                return default(T);
            Queue<T> temp = new Queue<T>();
            T max = q.Head();
            while (!q.IsEmpty())
            {
                if (q.Head().CompareTo(max) > 0)
                    max = q.Head();
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return max;
        } // Returns the biggest value in q (only for types that inherits from IComparable)

        public static T Min<T>(Queue<T> q)
            where T : IComparable
        {
            if (q.IsEmpty())
                return default(T);
            Queue<T> temp = new Queue<T>();
            T min = q.Head();
            while (!q.IsEmpty())
            {
                if (q.Head().CompareTo(min) < 0)
                    min = q.Head();
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return min;
        } // Returns the smallest value in q (only for types that inherits from IComparable)

        public static bool Exist<T>(Queue<T> q, T val)
        {
            Queue<T> temp = new Queue<T>();
            bool found = false;
            while (!q.IsEmpty())
            {
                if (q.Head().Equals(val))
                    found = true;
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return found;
        } // Returns true if val exists in q or false if not

        public static int Length<T>(Queue<T> q)
        {
            Queue<T> temp = new Queue<T>();
            int length = 0;
            while (!q.IsEmpty())
            {
                length++;
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return length;
        } // Returns the length q

        public static int GetNum(Queue<int> q)
        {
            int counter = 0;
            int num = 0;
            while (!q.IsEmpty())
            {
                num += (q.Remove() * (int)Math.Pow(10, counter));
                counter++;
            }
            return num;
        } // Creates and int from q (from q --> 1 --> 2 --> 3 to 123)

        public static void Delete(int val, Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                int n = q.Remove();
                if (n != val)
                    temp.Insert(n);
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
        } // Deletes val from q

        public static T RemoveLastItem<T>(Queue<T> q)
        {
            if (q.IsEmpty())
                return default(T);

            Queue<T> temp = new Queue<T>();
            T last = q.Remove();
            while (!q.IsEmpty())
            {
                temp.Insert(last);
                last = q.Remove();
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return last;
        } //Removes the last item from q and returns it

        public static void InsertSorted(Queue<int> q, int val)
        {
            Queue<int> temp = new Queue<int>();
            bool found = false;

            while (!q.IsEmpty())
            {
                int current = q.Remove();
                if (val <= current && !found)
                {
                    temp.Insert(val);
                    found = true;
                }
                temp.Insert(current);
            }

            if (!found)
                temp.Insert(val);

            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
        } //Inserts item in correct place 

        public static void ReverseQueue<T>(Queue<T> q) // Reverses a Queue (Recursive)
        {
            if (!q.IsEmpty())
            {
                T x = q.Remove();
                ReverseQueue(q);
                q.Insert(x);
            }
        }

        public static Queue<T> OrderSmallToBig<T>(Queue<T> q)
            where T : IComparable
        {
            Queue<T> temp = new Queue<T>();
            Queue<T> copy = Clone(q);
            while (!copy.IsEmpty())
            {
                temp.Insert(MinAndOut(copy));
            }
            return temp;
        } // Sorts from small to big (ascending)

        private static T MinAndOut<T>(Queue<T> q)
            where T : IComparable
        {
            if (q.IsEmpty())
                return default;
            T min = q.Head();
            Queue<T> temp = new Queue<T>();
            while (!q.IsEmpty())
            {
                if (q.Head().CompareTo(min) < 0)
                    min = q.Head();
                temp.Insert(q.Remove());
            }
            bool found = false;
            while (!temp.IsEmpty())
            {
                T val = temp.Remove();
                if (val.Equals(min) && !found)
                    found = true;
                else
                    q.Insert(val);
            }
            return min;
        } // finds the smallest value in q and removes it (returns the value)

        public static void RemoveDouble<T>(Queue<T> q)
        {
            Queue<T> temp = new Queue<T>();
            while (!q.IsEmpty())
            {
                RemoveDouble(q, q.Head());
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
        } //Removes all the duplicates in the q

        public static void RemoveDouble<T>(Queue<T> q, T val)
        {
            bool found = false;
            Queue<T> temp = new Queue<T>();
            while (!q.IsEmpty())
            {
                T v = q.Remove();
                if (!found || (found && !v.Equals(val)))
                {
                    temp.Insert(v);
                }
                if (v.Equals(val))
                    found = true;
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
        } //Removes all duplicates from q (gets called by the method before)

        public static int Sum(Queue<int> q) // Returns the sum of the Queue
        {
            Queue<int> temp = new Queue<int>();
            int sum = 0;
            while (!q.IsEmpty())
            {
                sum += q.Head();
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return sum;
        }

        public static Queue<int> QueueByCommon(Queue<int> q)
        {
            Queue<int> common = new Queue<int>();
            Queue<int> copied = Clone<int>(q);
            while (!copied.IsEmpty())
            {
                int val = copied.Remove();
                common.Insert(val);
                common.Insert(CountAndRemove(copied, val) + 1);
            }
            return common;
        } //Sorts the q according to how much the numbers appear (most appearances to least)

        public static int CountAndRemove(Queue<int> q, int num)
        {
            Queue<int> temp = new Queue<int>();
            int counter = 0;
            while (!q.IsEmpty())
            {
                int val = q.Remove();
                if (val == num)
                    counter++;
                else
                    temp.Insert(val);
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return counter;
        } //Counts how many appearances and removes that specific number

        public static Queue<int> NegativeAndPositiveSort(Queue<int> q)
        {
            Queue<int> negatives = new Queue<int>();
            Queue<int> positives = new Queue<int>();
            while (!q.IsEmpty())
            {
                int val = q.Remove();
                if (val < 0)
                    negatives.Insert(val);
                else
                    positives.Insert(val);
            }
            while (!negatives.IsEmpty())
                q.Insert(negatives.Remove());
            while (!positives.IsEmpty())
                q.Insert(positives.Remove());
            return q;
        } //Sorts a q => negatives first then positives
        #endregion

        
        static void Main(string[] args)
        {
        }
    }
}
