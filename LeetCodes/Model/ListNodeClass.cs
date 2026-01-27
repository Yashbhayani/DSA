using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodes.Model
{
    public class ListNode
    {
        public int value;    
        public ListNode next; 

        public ListNode(int value = 0, ListNode next = null)
        {
            this.value = value;
            this.next = next;
        }
    }

}
