using LeetCodes.Controller;
using LeetCodes.Model;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;


namespace LeetCodes.Functions
{
    internal class LeetCodeFunctionsClass
    {
        public static ListNode AddTwoNumbersfun()
        {
            var l1 = new ListNode(2,
                new ListNode(4,
                    new ListNode(3)));

            var l2 = new ListNode(5,
                new ListNode(6,
                    new ListNode(4)));

            addTwoNumbersClass atw = new addTwoNumbersClass();
            ListNode value = atw.addTwoNumbers(l1, l2);

            return value;
        }

        public static int[]? TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }

                map[nums[i]] = i;
            }

            return null;
        }
        public static int[]? TwoSum2(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                int index = Array.BinarySearch(nums, complement);
                if (index > 0)
                {
                    return [i, index];
                }
            }

            return null;
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Equals(""))
            {
                return 0;
            }

            int start = 0, end = 0, maxLength = 0;

            HashSet<char> uc = new HashSet<char>();
            while (end < s.Length)
            {
                if (uc.Add(s[end]))
                {
                    end++;
                    maxLength = Math.Max(maxLength, uc.Count);
                }
                else
                {
                    uc.Remove(s[start]);
                    start++;
                }
            }
            return maxLength;
        }
        public static int LengthOfLongestSubstring2(string s)
        {
            if (s == null || s.Equals(""))
            {
                return 0;
            }
            int start = 0, end = 0, maxLength = 0;
            HashSet<char> uc = new HashSet<char>();
            while (end < s.Length)
            {
                if (uc.Add(s[end]))
                {
                    end++;
                    maxLength = Math.Max(maxLength, uc.Count);
                }
                else
                {
                    while (uc.Contains(s[end]))
                    {
                        uc.Remove(s[start]);
                        start++;
                    }
                }
            }
            return maxLength;
        }

        public static int LengthOfLongestSubstring3(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            HashSet<char> set = new HashSet<char>();
            int left = 0, maxLen = 0;

            for (int right = 0; right < s.Length; right++)
            {
                while (set.Contains(s[right]))
                {
                    set.Remove(s[left]);
                    left++;
                }
                set.Add(s[right]);
                maxLen = Math.Max(maxLen, right - left + 1);
            }
            return maxLen;
        }

        //-2, 1, -3, 4, -1, 2, 1, -5, 4
        public static int Maximumsubarraysum(int[] arr)
        {
            int cS = arr[0];
            int mS = cS;

            for (int i = 1; i < arr.Length; i++)
            {
                cS = Math.Max(arr[i], cS + arr[i]);
                mS = Math.Max(mS, cS);
            }
            return mS;
        }

        // 2, 3, -8, 7, -1, 2, 3
        public static int Maximumsubarraysum2(int[] arr)
        {
            int cS = 0, mS = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0 || (arr[i - 1] < 0 && mS < arr[i]))
                {
                    cS = arr[i];
                    mS = arr[i];
                }
                else
                {
                    cS = arr[i] + cS;
                    mS = Math.Max(mS, cS);
                }
            }
            return mS;
        }

        public static int[]? Productexceptself(int[] arr)
        {
            int[] list = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                int j = 0;
                int total = 1;
                while (arr.Length > j)
                {
                    if (i != j)
                    {
                        total *= arr[j];
                    }
                    j++;
                }

                list[i] = total;
            }
            return list;
        }

        public static bool Validpalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            char[] charArray = s.Trim().ToCharArray(); // Convert string to a character array
            Array.Reverse(charArray);
            return s.Trim() == new string(charArray);
        }

        public static bool Pairwithtargetsum(int[] arr, int taget)
        {
            if (arr.Length == 0 || taget == 0)
            {
                return false;
            }

            int i = 0;
            while (i < arr.Length)
            {
                int k = taget - arr[i];
                if (arr.Contains(k))
                {
                    return true;
                }
                i++;
            }
            return false;
        }

        public static string Reversestring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            char[] charArray = s.Trim().ToCharArray(); // Convert string to a character array
            Array.Reverse(charArray);
            return new string(charArray);
        }

        //2, 1, 5, 1, 3, 2 
        //3
        public static int MaximumSumOfSubarrayOfSizeK(int[] arr, int target)
        {
            if (arr.Length == 0 || target == 0)
            {
                return 0;
            }

            int MaxVal = 0, temptar = target, sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                temptar--;
                if (temptar == 0)
                {
                    MaxVal = Math.Max(MaxVal, sum);
                    sum -= arr[i - (target - 1)];
                    temptar++;
                }
            }
            return MaxVal;
        }

        public static int MaximumSumOfSubarrayOfSizeK2(int[] arr, int target)
        {
            if (arr.Length == 0 || target == 0)
            {
                return 0;
            }

            int MaxVal = 0;
            for (int i = 0; i <= arr.Length - target; i++)
            {
                int sum = 0;
                for (int j = 0; j < target; j++)
                {
                    sum += arr[i + j];
                }
                MaxVal = Math.Max(MaxVal, sum);
            }
            return MaxVal;
        }

        public static int LongestSubstringWithAtMost2DistinctCharacters(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            int n = s.Length;
            int maxLen = 0;

            for (int i = 0; i < n; i++)
            {
                Dictionary<char, int> count = new Dictionary<char, int>();
                for (int j = i; j < n; j++)
                {
                    if (!count.ContainsKey(s[j]))
                    {
                        count[s[j]] = 0;
                    }
                    else
                    {
                        count[s[j]]++;
                    }
                    if (count.Count > 2) break;

                    maxLen = Math.Max(maxLen, j - i + 1);
                }
            }
            return maxLen;
        }

        //eceba
        public static int LongestSubstringWithAtMost2DistinctCharacters2(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int n = s.Length;
            int maxLen = 0;
            int j = 0;

            Dictionary<char, int> count = new Dictionary<char, int>();
            for (int i = 0; i < n; i++)
            {
                if (!count.ContainsKey(s[i]))
                    count[s[i]] = 0;
                count[s[i]]++;

                while (count.Count > 2)
                {
                    count[s[j]]--;
                    if (count[s[j]] == 0)
                        count.Remove(s[j]);
                    j++;
                }

                maxLen = Math.Max(maxLen, i - j + 1);
            }
            return maxLen;
        }

        public static int LongestSubstringWithAtMost2DistinctCharacters3(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int n = s.Length;
            int maxLen = 0;
            int j = 0;

            Dictionary<char, int> count = new Dictionary<char, int>();
            for (int i = 1; i <= n; i++)
            {
                if (!count.ContainsKey(s[i - 1]))
                    count[s[i - 1]] = 0;
                count[s[i - 1]]++;

                if (count.Count > 2)
                {
                    count.Clear();
                    j++;
                    i = j;
                }

                maxLen = Math.Max(maxLen, i - j);
            }
            return maxLen;
        }


        public static char FirstNonRepeatingCharacter(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return '\0';
            }

            char[] charArray = s.Trim().ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                string str = s.Remove(i, 1);

                int index = str.IndexOf(s[i]);
                if (index == -1)
                {
                    return s[i];
                }
            }

            return '\0';
        }

        public static char FirstNonRepeatingCharacter2(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return '\0';
            }

            for (int i = 0; i < s.Length; i++)
            {
                bool sta = false;
                char c = s[i];
                int j = i + 1;
                while (j < s.Length)
                {
                    if (s[i] == s[j])
                    {
                        sta = true;
                        break;
                    }
                    j++;
                }
                if (!sta)
                    return s[i];
            }
            return '\0';

        }

        public static bool Validparentheses(string s)
        {

            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            ArrayList arList1 = new ArrayList();

            char[] charArray = s.Trim().ToCharArray();

            foreach (char item in charArray)
            {
                int i = arList1.Count;
                if (item == '(' || item == '[' || item == '{')
                {
                    arList1.Add(item);
                }

                if (item == ')' || item == ']' || item == '}')
                {
                    if (arList1.Count == 0) return false;

                    if (item == ')' && (char?)arList1[i - 1] == '(' ||
                        item == ']' && (char?)arList1[i - 1] == '[' ||
                        item == '}' && (char?)arList1[i - 1] == '{')
                    {
                        arList1.RemoveAt(i - 1);
                    }
                    else { return false; }
                }
            }

            return arList1.Count == 0;
        }

        public static bool Validparentheses2(string s)
        {

            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            Stack<char> arList1 = new Stack<char>();

            char[] charArray = s.Trim().ToCharArray();

            foreach (char item in charArray)
            {
                int i = arList1.Count;
                if (item == '(' || item == '[' || item == '{')
                {
                    arList1.Push(item);
                }

                if (item == ')' || item == ']' || item == '}')
                {
                    if (arList1.Count == 0) return false;

                    if (item == ')' && arList1.Peek() != '(' ||
                    item == ']' && arList1.Peek() != ']' ||
                    item == '}' && arList1.Peek() != '}')
                    {
                        return false;
                    }

                    arList1.Pop();
                }
            }

            return arList1.Count == 0;
        }

        public static bool Validparentheses3(string s)
        {

            if (string.IsNullOrEmpty(s))
            {
                return true;
            }
            List<char> charList = s.Trim().ToList();
            for (int i = 0; i < charList.Count; i++)
            {
                if (charList[i] == ')' || charList[i] == ']' || charList[i] == '}')
                {
                    if (i == 0)
                    {
                        return false;
                    }
                    if (charList[i] == ')' && charList[i - 1] != '(' ||
                        charList[i] == ']' && charList[i - 1] != '[' ||
                        charList[i] == '}' && charList[i - 1] != '{')
                    {
                        return false;
                    }
                    else
                    {
                        charList.RemoveAt(i);
                        charList.RemoveAt(i - 1);
                        i -= 2;
                    }
                }
            }

            return charList.Count == 0;
        }

        public static int[] NextGreaterElement(int[] arr)
        {
            if (arr.Length == 0)
            {
                return null!;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                bool val = false;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        val = true;
                        arr[i] = arr[j];
                        break;
                    }
                }
                if (!val) { arr[i] = -1; }
            }
            return arr;
        }

        public static int[] NextGreaterElement2(int[] arr)
        {
            int n = arr.Length;
            int[] res = new int[n];
            if (arr.Length == 0)
            {
                return null!;
            }

            for (int i = 0; i < n; i++)
            {
                res[i] = -1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        res[i] = arr[j];
                        break;
                    }
                }
            }
            return res;
        }

        public static void levelOrderRec(NodeClass root, int level, List<List<int>> res)
        {
            if (root == null)
            {
                return;
            }

            if (res.Count <= level)
            {
                res.Add(new List<int>());
            }

            res[level].Add(root.data);
            levelOrderRec(root.left, level + 1, res);
            levelOrderRec(root.right, level + 1, res);

        }
        public static List<List<int>> levelOrder(NodeClass root)
        {
            List<List<int>> res = new List<List<int>>();
            levelOrderRec(root, 0, res);
            return res;
        }


        public static List<int> BFS(NodeClass root)
        {
            List<int> res = new List<int>();

            if (root == null)
                return res;

            Queue<NodeClass> q = new Queue<NodeClass>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                NodeClass n = q.Dequeue();
                res.Add(n.data);

                if (n.left != null)
                {
                    q.Enqueue(n.left);
                }

                if (n.right != null)
                {
                    q.Enqueue(n.right);
                }
            }
            return res;
        }

        public static List<int> BFS2(NodeClass root)
        {
            List<int> res = new List<int>();

            if (root == null)
                return res;

            List<NodeClass> q = new List<NodeClass>();
            q.Add(root);
            while (q.Count > 0)
            {
                NodeClass n = q[0];
                q.RemoveAt(0);
                res.Add(n.data);

                if (n.left != null)
                {
                    q.Add(n.left);
                }

                if (n.right != null)
                {
                    q.Add(n.right);
                }
            }
            return res;
        }
        public static List<List<int>> levelOrder4(NodeClass root)
        {
            List<(int, int)> res = new List<(int, int)>();

            if (root == null)
                return null;

            List<(NodeClass, int)> q = new List<(NodeClass, int)>();
            q.Add((root, 0));
            while (q.Count > 0)
            {
                NodeClass n = q[0].Item1;
                int index = q[0].Item2;
                q.RemoveAt(0);
                res.Add((n.data, index == 0 ? 0 : index));

                if (n.left != null)
                {
                    q.Add((n.left, index + 1));
                }

                if (n.right != null)
                {
                    q.Add((n.right, index + 1));
                }
            }

            List<List<int>> groupedLists = res.GroupBy(x => x.Item2)
                                             .Select(g => g.Select(x => x.Item1).ToList())
                                             .ToList();
            /*            List<List<int>> groupedLists = res
                        .GroupBy(pair => pair.Item2)      
                        .Select(group => group.Select(pair => pair.Item1).ToList()) 
                        .ToList();*/

            return groupedLists;
        }

        public static int[]? SlidingWindoMaximum(int[] arr, int k)
        {
            if (arr.Length == 0)
            {
                return null;
            }

            for (int i = 0; i <= arr.Length - k; i++)
            {
                int Max = arr[i];
                for (int j = i + 1; j < i + k; j++)
                {
                    Max = Math.Max(Max, arr[j]);
                }
                arr[i] = Max;
            }

            return arr.SkipLast(k - 1).ToArray();
        }
        public static int[]? SlidingWindoMaximum2(int[] arr, int k)
        {
            if (arr.Length == 0)
            {
                return null;
            }
            int[] re = new int[arr.Length - (k - 1)];
            for (int i = 0; i <= arr.Length - k; i++)
            {
                int newarr = arr.Skip(i).Take(k).ToArray().Max();
                re[i] = newarr;
            }
            return re;
        }

        public static Node ReverseList(Node head)
        {
            Node curr = head;
            Node prev = null;
            Node next;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }
        public static void printList(Node? node)
        {
            while (node != null)
            {
                Console.Write(node.value);
                if (node.next != null)
                    Console.Write(" -> ");
                node = node.next;
            }
        }
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k == 1)
                return head;

            ListNode dummy = new ListNode(0);
            dummy.next = head;

            ListNode prevGroupEnd = dummy;

            while (true)
            {
                ListNode kthNode = GetKthNode(prevGroupEnd, k);
                if (kthNode == null)
                    break;

                ListNode groupStart = prevGroupEnd.next;
                ListNode nextGroupStart = kthNode.next;

                // Reverse the group
                ListNode prev = nextGroupStart;
                ListNode curr = groupStart;

                while (curr != nextGroupStart)
                {
                    ListNode temp = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = temp;
                }

                // Connect reversed group
                prevGroupEnd.next = kthNode;
                prevGroupEnd = groupStart;
            }

            return dummy.next;
        }

        public static ListNode GetKthNode(ListNode curr, int k)
        {
            while (curr != null && k > 0)
            {
                curr = curr.next;
                k--;
            }
            return curr;
        }

        public static Node createList(int[] values)
        {
            Node head = new Node(values[0]);
            Node current = head;
            for (int i = 1; i < values.Length; i++)
            {
                current.next = new Node(values[i]);
                current = current.next;
            }
            return head;
        }

        public static Node reversKnode2(Node head, int k)
        {
            if (head == null) return head;
            ArrayList ar = new ArrayList();
            Node newHead = head;

            while (newHead != null)
            {
                ar.Add(newHead.value);
                newHead = newHead.next;
            }

            ArrayList newar = new ArrayList();

            for (int i = 0; i < ar.Count / k; i++)
            {
                int j = 0;
                while (j < k)
                {
                    newar.Add(ar[(k * (i + 1)) - (j + 1)]);
                    j++;
                }
            }

            Node rehead = new Node((int)newar[0]);
            Node current = rehead;
            for (int i = 1; i < newar.Count; i++)
            {
                current.next = new Node((int)newar[i]);
                current = current.next;
            }
            return rehead;
        }

        public static void TraverseaLinkedList(Node head)
        {
            if (head == null) return;

            while (head != null)
            {
                Console.Write(head.value + ", ");
                head = head.next;
            }
        }

        public static void TraverseaLinkedList2(Node head)
        {
            if (head == null)
                return;

            Console.Write(head.value + ", ");
            TraverseaLinkedList2(head.next);
        }

        public static int FindLengthofLinkedList(Node head)
        {
            if (head == null) return 0;
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.next;
            }
            return count;
        }
        public static int FindLengthofLinkedList2(Node head, int count)
        {
            if (head == null) return count;
            return FindLengthofLinkedList2(head.next, count + 1);
        }

        public static bool SearchAnElement(Node head, int target)
        {
            if (head == null) return false;
            while (head != null)
            {
                if (head.value == target) return true;
                head = head.next;
            }
            return false;
        }

        public static bool SearchAnElement2(Node head, int target)
        {
            if (head == null) return false;
            return head.value == target ? true : SearchAnElement2(head.next, target);
        }

        public static Node? ReverseALinkedList(Node head)
        {
            if (head == null) return null;

            Node nhead = head;
            Node? prev = null;

            while (nhead != null)
            {
                Node next = nhead.next;
                nhead.next = prev;
                prev = nhead;
                nhead = next;
            }

            return prev;
        }

        public static Node? ReverseALinkedList2(Node? head)
        {

            if (head == null || head.next == null) return head;
            Node? k = ReverseALinkedList2(head.next);
            head.next.next = head;
            head.next = null;
            return k;
        }

        public static int FindMiddleOfLinkedList(Node head)
        {
            if (head == null) return 0;
            int? count = ListCount(head) / 2;
            while (count > 0)
            {
                head = head.next;
                count--;
                if (count == 0)
                    return head.value;

            }
            return 0;
        }

        public static int FindMiddleOfLinkedList2(Node head)
        {
            if (head == null) return 0;
            int? count = ListCount(head) / 2;
            while (count-- > 0)
            {
                head = head.next;
            }
            return head.value;
        }


        public static int? ListCount(Node head)
        {
            if (head == null) return 0;

            int? count = 0;
            while (head != null)
            {
                count++;
                head = head.next;
            }
            return count;
        }

        public static Node? RemoveNthNodeFromEnd(Node head, int target)
        {
            if (head == null || target == 0) return head;
            int? count = ListCount(head);
            int c = 0;
            Node dummy = new Node(0);
            Node current = dummy;
            while (head != null)
            {
                if (c != (count - target))
                {
                    current.next = new Node(head.value);
                    current = current.next;
                }
                head = head.next;
                c++;
            }

            return dummy.next;
        }

        public static Node? RemoveNthNodeFromEnd2(Node head, int target)
        {
            if (head == null || target == 0) return head;
            int? count = ListCount(head);
            int c = 0;
            Node dummy = new Node(0);
            Node current = dummy;
            while (head != null)
            {
                Node node = head.next;
                head.next = null;
                if (c != (count - target))
                {
                    current.next = head;
                    current = current.next;
                }
                head = node;
                c++;
            }

            return dummy.next;
        }

        public static Node? DeleteNodeinaLinkedList(Node head, int target)
        {
            if (head == null || target == 0) return head;

            int count = 0;

            Node dummy = new Node(0);
            Node cdu = dummy;

            while (head != null)
            {
                if (count == target)
                {
                    head = head.next;
                }

                cdu.next = new Node(head.value);
                cdu = cdu.next;
                head = head.next;
                count++;
            }


            return dummy.next;
        }

        public static Node? DeleteNodeinaLinkedList2(Node head, int target)
        {
            if (head == null || target == 0) return head;

            int count = 0;

            Node dummy = new Node(0);
            Node cdu = dummy;

            while (head != null)
            {
                if (count == target)
                {
                    head = head.next;
                }

                Node node = head.next;
                head.next = null;
                cdu.next = head;
                cdu = cdu.next;
                head = node;
                count++;
            }


            return dummy.next;
        }


        public static Node? DeleteNodeinaLinkedList3(Node head, int target)
        {
            if (head == null || target == 0) return head;

            int count = 0;

            Node dummy = new Node(0);
            Node cdu = dummy;

            while (head != null)
            {
                if (count == target)
                {
                    head = head.next;
                }

                cdu.next = head;
                cdu = head;
                head = head.next;
                count++;
            }
            return dummy.next;
        }
    }
}
