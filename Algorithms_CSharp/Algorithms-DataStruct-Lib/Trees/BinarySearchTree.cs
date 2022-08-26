namespace Algorithms_DataStruct_Lib.Trees
{
    /* 
     * [A binary tree is a special case of a general tree]:
     * 
     *      - Each node has 0, 1 or 2 children
     *  
     *      - Left child and right child
     *  
     * [Binary Search Tree]
     *  --------------------------------------------------
     *  - 
     *    Is a tree where the LEFT child contains 
     *    only nodes with values LESS than parent node
     *  - 
     *    and the RIGHT child contains nodes with 
     *    values GREATER than or EQUAL to the parent node
     *  -
     *  [NOTE]: If you project all the nodes down creating a row,
     *          you will see a completely ordered sequence of elements!
     *  --------------------------------------------------
     *  
     *  [Full Binary Tree] = every node other than the leaves has two children
     *  
     *  [Complete Binary Tree] = every level, except possibly the last,
     *                           is completely filled and all of the nodes are as
     *                           far left as possible.
     *  --------------------------------------------------                         
     *  [Time Complexity]:
     *  
     *  - Binary Search gives log2(n) for Insertion, Deletion or Retrieval
     *  
     *  [UNBALANCE TREE]:
     *   Worst case, Linear time, in case of a high vertical tree.
     *  
     *              (need to traverse the whole tree)
     *  --------------------------------------------------
     *  [Traversing a Binary Tree]:
     *  
     *      -[ Level ]: visit all the nodes from the left to right at every level
     *      
     *      -[ In-order ]: visit the leftmost node, then root, then the right 
     *                      (tree root in the middle way)
     *                      
     *      -[ Pre-order ]: visit the root of every subtree, first from left to right
     *      
     *      -[ Post-order ]: visit the root of every subtree last
     *                       (leftmost leaf, right, then root)
     *
     */

    //Represent a Tree
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;

        public TreeNode<T> Get(T value)
        {
            return _root?.Get(value);
        }

        public T Min()
        {
            if(_root == null)
            {
                throw new InvalidOperationException("Empty tree.");
            }

            return _root.Min();
        }

        public T Max()
        {
            if (_root == null)
            {
                throw new InvalidOperationException("Empty tree.");
            }

            return _root.Max();
        }

        public void Insert(T value)
        {
            if (_root == null)
            {
                _root = new TreeNode<T>(value);
            }
            else
            {
                _root.Insert(value);
            }
        }

        public IEnumerable<T> TraverseInOrder()
        {
            if (_root != null)
            {
                return _root.TraverseInOrder();
            }

            //this is the best practice instead of returning null
            //(from the API persperctive)
            return Enumerable.Empty<T>(); 
        }
    }
}