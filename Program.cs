using System;
using DataStructureCore;

namespace Cheat_Sheet
{
    class Program
    {
        #region Stack
        /////////////
        ////Stack////
        ///////////// 
        public static Stack<T> Clone<T>(Stack<T> s)
        {
            Stack<T> temp = new Stack<T>();
            Stack<T> copy = new Stack<T>();
            while (!s.IsEmpty())
                temp.Push(s.Pop());
            while (!temp.IsEmpty())
            {
                s.Push(temp.Top());
                copy.Push(temp.Pop());
            }
            return copy;
        } // מעתיקה את המחסנית

        public static T Max<T>(Stack<T> s)
            where T : IComparable
        {
            if (s.IsEmpty())
                return default(T);
            T max = s.Top();
            Stack<T> temp = new Stack<T>();
            while (!s.IsEmpty())
            {
                if (s.Top().CompareTo(max) > 0)
                    max = s.Top();
                temp.Push(s.Pop());
            }
            while (!temp.IsEmpty())
                s.Push(temp.Pop());
            return max;
        } // מחזירה את הערך המקסימלי

        public static T Min<T>(Stack<T> s)
    where T : IComparable
        {
            if (s.IsEmpty())
                return default(T);
            T min = s.Top();
            Stack<T> temp = new Stack<T>();
            while (!s.IsEmpty())
            {
                if (s.Top().CompareTo(min) < 0)
                    min = s.Top();
                temp.Push(s.Pop());
            }
            while (!temp.IsEmpty())
                s.Push(temp.Pop());
            return min;
        } // מחזירה את הערך המינימלי

        public static bool Exist<T>(Stack<T> s, T val)
        {
            bool found = false;
            Stack<T> temp = new Stack<T>();
            while (!s.IsEmpty() && !found)
            {
                if (s.Top().Equals(val))
                    found = true;
                temp.Push(s.Pop());
            }
            while (!temp.IsEmpty())
                s.Push(temp.Pop());
            return found;
        } // מחזירה אמת אם הערך נמצאה במחסנית או שקר אחרת

        public static int Length<T>(Stack<T> s)
        {
            int length = 0;
            Stack<T> temp = new Stack<T>();
            while (!s.IsEmpty())
            {
                length++;
                temp.Push(s.Pop());
            }
            while (!temp.IsEmpty())
                s.Push(temp.Pop());
            return length;
        } // מחזירה את אורך המחסנית

        public static void InsertSorted(Stack<int> st, int val)
        {
            bool found = false;
            Stack<int> temp = new Stack<int>();
            while (!st.IsEmpty() && !found)
            {
                if (val <= st.Top())
                {
                    st.Push(val);
                    found = true;
                }
                else
                    temp.Push(st.Pop());
            }
            if (st.IsEmpty())
                st.Push(val);
            while (!temp.IsEmpty())
                st.Push(temp.Pop());
        } // מכניסה את האיבר למקמותו המתאים במחסנית

        public static Stack<T> OrderSmallToBig<T>(Stack<T> s)
            where T : IComparable
        {
            Stack<T> temp = new Stack<T>();
            Stack<T> copy = Clone(s);
            while (!copy.IsEmpty())
            {
                temp.Push(MaxAndOut(copy));
            }
            return temp;
        } // ממיינת את המחסנית מהקטן לגדול הערך הגדול ביותר נמצא בתחתית המחסנית
        private static T MaxAndOut<T>(Stack<T> s)
            where T : IComparable
        {
            if (s.IsEmpty())
                return default;
            T max = s.Top();
            Stack<T> temp = new Stack<T>();
            while (!s.IsEmpty())
            {
                if (s.Top().CompareTo(max) > 0)
                    max = s.Top();
                temp.Push(s.Pop());
            }
            bool found = false;
            while (!temp.IsEmpty())
            {
                T val = temp.Pop();
                if (val.Equals(max) && !found)
                    found = true;
                else
                    s.Push(val);
            }
            return max;
        } // הפעולה מוציאה את הערך הגדול ביותר במחסנית
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
        } // מעתיקה את התור

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
        } // מחזירה את הערך המקסימלי בתור

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
        } // מחזירה את הערך המינימלי בתור

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
        } // מחזירה אמת אם הערך נמצא בתור או שקר אחרת

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
        } // מחזירה את אורך התור

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
        } //מכינה מספר באיברי התור 1-1-1 -> 111

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
        } // מחיקת ערך מתור

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
        } //מוציאה את האיבר האחרון בתור ומחזירה את ההפנייה אליו

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
        } //מכניס ערך במקום המתאים

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
        } // ממיינת את התור מהקטן לגדול הערך הגדול ביותר נמצא בתחתית התור

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
        } // הפעולה מוציאה את הערך הגדול ביותר בתור

        #endregion

        #region BinNode
        ///////////////
        ////BinNode////
        ///////////////

        public static BinNode<string> CreateTree()
        {
            Console.WriteLine("Please enter root value:");
            string shoresh = Console.ReadLine();
            if (shoresh == "")
                return null;
            BinNode<string> root = new BinNode<string>(shoresh);
            Console.WriteLine($"Please enter left sub tree of {shoresh}:");
            BinNode<string> left = CreateTree();
            Console.WriteLine($"Please enter right sub tree of {shoresh}:");
            BinNode<string> right = CreateTree();
            root.SetLeft(left);
            root.SetRight(right);
            return root;
        } //מכינה עץ ע"י הכנסת נתונים מהמשתמש

        public static BinNode<int> CreateRandomTree(int height, Random r, int min, int max)
        {
            if (height < 0)
                return null;
            int shoresh = r.Next(min, max + 1);
            BinNode<int> root = new BinNode<int>(shoresh);
            BinNode<int> left = CreateRandomTree(height - 1, r, min, max);
            BinNode<int> right = CreateRandomTree(height - 1, r, min, max);
            root.SetLeft(left);
            root.SetRight(right);
            return root;
        } //יוצר עץ עם מספרים אקראיים

        public static void PrintInorder(BinNode<int> t)
        {
            //תנאי עצירה
            if (t == null)
                return;
            //הדפס תת עץ שמאלי
            PrintInorder(t.GetLeft());
            //טיפול בשורש
            Console.WriteLine(t.GetValue());
            //הדפס תת עץ ימני
            PrintInorder(t.GetRight());
        } //מדפיס באופן תוכי

        public static void PrintPreOrder(BinNode<int> t)
        {
            //תנאי עצירה
            if (t == null)
                return;
            //טיפול בשורש
            Console.WriteLine(t.GetValue());
            //הדפס תת עץ שמאלי
            PrintPreOrder(t.GetLeft());
            //הדפס תת עץ ימני
            PrintPreOrder(t.GetRight());
        } //מדפיס באופן סופי

        public static void PrintPostOrder(BinNode<int> t)
        {
            //תנאי עצירה
            if (t == null)
                return;
            //הדפס תת עץ שמאלי
            PrintPostOrder(t.GetLeft());
            //הדפס תת עץ ימני
            PrintPostOrder(t.GetRight());
            //טיפול בשורש
            Console.WriteLine(t.GetValue());

        } //מדפיס באופן תחילי

        public static int CountNodes<T>(BinNode<T> t)
        {
            //תנאי עצירה
            if (t == null)
                return 0;

            //טיפול
            int numNodes = 1;

            //ספירת הצמתים בתת עץ השמאלי
            numNodes += CountNodes<T>(t.GetLeft());

            //ספירת הצמתים בתת עץ הימני
            numNodes += CountNodes<T>(t.GetRight());

            return numNodes;
        } //מחזיר את מספר הצמתים בעץ

        public static bool Search<T>(BinNode<T> t, T val)
        {
            if (t == null)
                return false;

            return (t.GetValue().Equals(val) ||
                Search<T>(t.GetLeft(), val) ||
                Search<T>(t.GetRight(), val));
        } //בודק אם ערך מסויים נמצא בעץ

        public static int Height<T>(BinNode<T> t)
        {
            //עץ ריק בגובה 0
            //וגם עץ בעל צומת אחד
            if (t == null)
                return 0;

            if (!t.HasLeft() && !t.HasRight())
                return 0;
            int left = Height<T>(t.GetLeft());
            int right = Height<T>(t.GetRight());
            return 1 + Math.Max(left, right);
        } //מחזיר את גובה העץ

        public static int CountNodesPerLevel<T>(BinNode<T> t, int level, int currentLevel)
        {
            if (t == null)
                return 0;
            if (level == currentLevel)
            {
                return 1;
            }
            return CountNodesPerLevel<T>(t.GetLeft(), level, currentLevel + 1) +
                CountNodesPerLevel<T>(t.GetRight(), level, currentLevel + 1);
        } 
        public static int CountNodesPerLevel<T>(BinNode<T> t, int level)
        {
            return CountNodesPerLevel<T>(t, level, 0);
        } // סופר את מספר הצמתים ברמה מסויימת

        public static bool IsFull<T>(BinNode<T> t)
        {
            //עץ ריק הוא עץ מלא
            if (t == null)
                return true;

            //בדיקה האם לא מלא
            if (t.HasLeft() && !t.HasRight() ||
                !t.HasLeft() && t.HasRight())
                return false;

            return IsFull<T>(t.GetLeft()) && IsFull<T>(t.GetRight());
        } //בודק עם העץ הוא עץ מלא

        public static int CountLeafs<T>(BinNode<T> t)
        {
            if (!t.HasLeft() && !t.HasRight())
                return 1;

            return CountLeafs(t.GetLeft()) + CountLeafs(t.GetRight());
        } //סופר את מספר העלים בעץ


        #endregion
        static void Main(string[] args)
        {
           
        }
    }
}
