namespace Algorithms_DataStruct_Lib
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; } //pointer to another node

        public Node(T value)
        {
            Value = value;
        }
    }
}