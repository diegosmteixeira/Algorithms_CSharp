namespace Algorithms_DataStruct_Lib
{
    public class DoublyLinkedNode<T>
    {
        private T? value;

        public T Value { get; set; }
        public DoublyLinkedNode<T>? Next { get; set; }
        public DoublyLinkedNode<T>? Previous { get; set; }

        public DoublyLinkedNode(T value)
        {
            Value = value;
        }
    }
}
