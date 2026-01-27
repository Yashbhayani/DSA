using LeetCodes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodes.Controller
{
    internal class addTwoNumbersClass
    {

        public ListNode addTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode l3 = new ListNode();
            ListNode res = l3;
            int car = 0;

            while(l1 != null || l2 != null || car != 0)
            {
                int x = l1 != null ? l1.value : 0;
                int y = l2 != null ? l2.value : 0;
                
                int sum = x + y + car;
                car = sum / 10;

                res.next = new ListNode(sum % 10);
                res = res.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            } 

                return l3.next;
        }

    }
}
