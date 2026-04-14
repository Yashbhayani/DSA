namespace LeetCodes.Model
{
    public class Node
    {
        public int value;
        public Node next;

        public Node(int value, Node next = null)
        {
            this.value = value;
            this.next = null;
        }
    }
}