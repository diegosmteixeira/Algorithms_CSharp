namespace Algorithms_DataStruct_Lib.Trees
{
    //The fundamental building block of a Tree
    public class TreeNode<T> where T :IComparable<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
        }

        public void Insert(T newValue)
        {
            //compare with parent nodes
            int compare = newValue.CompareTo(Value);

            if (compare == 0)
            {
                return;
            }

            if (compare < 0)
            {
                if (Left == null)
                {
                    Left = new TreeNode<T>(newValue);
                }
                else
                {
                    Left.Insert(newValue); //recursive call to left node
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new TreeNode<T>(newValue);
                }
                else
                {
                    Right.Insert(newValue); //recursive call to right node
                }
            }
        }

        //Search a value and returns a entire node
        public TreeNode<T> Get(T value)
        {
            int compare = value.CompareTo(Value);

            if (compare == 0)
            {
                return this;
            }

            if (compare< 0)
            {
                if (Left != null)
                {
                    return Left.Get(value); //recursive call to left node
                }
            }
            else
            {
                if (Right != null)
                {
                    return Right.Get(value); //recursive call to right node
                }
            }

            return null;
        }

        public IEnumerable<T> TraverseInOrder()
        {
            var list = new List<T>();

            InnerTraverse(list);
            return list;
        }

        private void InnerTraverse(List<T> list)
        {
            if(Left != null)
            {
                Left.InnerTraverse(list);
            }

            list.Add(Value);

            if (Right != null)
            {
                Right.InnerTraverse(list);
            }
        }

        public T Min()
        {
            if (Left != null)
            {
                return Left.Min();
            }
            return Value; //return Value when recursion is exhausted
        }

        public T Max()
        {
            if (Right != null)
            {
                return Right.Max();
            }
            return Value; //return Value when recursion is exhausted
        }
    }
}