
using LeetCodes.Controller;
using LeetCodes.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Xml.Linq;


namespace LeetCodes.Functions
{
    public class LeetCodeCodeFunctionsClass
    {
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

        public static void LoopCode()
        {
            int n = 6;
            for (int i = 1; i <= n; i++)
            {
                int k = n - 1;
                string s = "";
                int val = 0;
                for (int j = i; j >= 1; j--)
                {
                    if (j == i)
                    {
                        val = i;
                        s = i.ToString();
                    }
                    else
                    {
                        val += k;
                        s = val.ToString() + " " + s;
                        k--;
                    }
                }
                Console.WriteLine(s);
            }
        }
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;

            int length = 1;
            ListNode tail = head;

            // Find length and tail
            while (tail.next != null)
            {
                tail = tail.next;
                length++;
            }

            // Make circular
            tail.next = head;

            int t = length - (k % length);

            // Move to new tail
            for (int i = 0; i < t; i++)
            {
                tail = tail.next;
            }

            // Set new head and break circle
            ListNode newHead = tail.next;
            tail.next = null;

            return newHead;
        }

        public static NodeClass createTreeList(int[] num)
        {

            if (num.Length == 0 || num.Length == -1)
                return null;

            NodeClass root = new NodeClass(num[0]);
            Queue<NodeClass> queue = new Queue<NodeClass>();
            queue.Enqueue(root);

            int i = 1;
            while (i < num.Length)
            {
                NodeClass curr = queue.Dequeue();
                if (i < num.Length && num[i] != -1)
                {
                    curr.left = new NodeClass(num[i]);
                    queue.Enqueue(curr.left);
                }
                i++;

                if (i < num.Length && num[i] != -1)
                {
                    curr.right = new NodeClass(num[i]);
                    queue.Enqueue(curr.right);
                }
                i++;
            }


            return root;
        }

        public static int[]? printTreeList(NodeClass res)
        {
            ArrayList data = new ArrayList();

            if (res == null)
                return null;

            Queue<NodeClass> queue = new Queue<NodeClass>();
            queue.Enqueue(res);


            while (queue.Count > 0)
            {
                NodeClass curr = queue.Dequeue();
                data.Add(curr.data);
                if (curr.left != null)
                    queue.Enqueue(curr.left);
                else
                    data.Add(-1);
                if (curr.right != null)
                    queue.Enqueue(curr.right);
                else
                    data.Add(-1);
            }
            return data.ToArray(typeof(int)) as int[];
        }


        public static int MDheight(NodeClass nodeClass)
        {
            if (nodeClass == null)
                return 0;

            int leftHeight = MDheight(nodeClass.left);
            int rightHeight = MDheight(nodeClass.right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public static bool IsSameTree(NodeClass p, NodeClass q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            if (p.data != q.data)
                return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }


        public static bool IsSameTree2(NodeClass p, NodeClass q)
        {

            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            if (p.data != q.data)
                return false;


            bool leftHeight = IsSameTree2(p.left, q.left);
            bool rightHeight = IsSameTree2(p.right, q.right);
            return leftHeight && rightHeight;
        }

        public static NodeClass? InvertTree(NodeClass root)
        {
            if (root == null)
                return root;

            NodeClass nodeClass = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(nodeClass);

            return root;
        }
        public static NodeClass? InvertTree2(NodeClass root)
        {
            if (root == null || (root.right == null && root.left == null)) return root;

            NodeClass temp = root.left;
            root.left = root.right;
            root.right = temp;

            root.left = InvertTree(root.left);
            root.right = InvertTree(root.right);

            return root;
        }
        public static NodeClass? InvertTree3(NodeClass root)
        {
            if (root == null) return null;

            var queue = new Queue<NodeClass>();
            queue.Enqueue(root);

            while (queue.Count() != 0)
            {
                var count = queue.Count();

                for (var i = 0; i < count; i++)
                {
                    var curr = queue.Dequeue();
                    var tmp = curr.left;
                    curr.left = curr.right;
                    curr.right = tmp;

                    if (curr.left != null) queue.Enqueue(curr.left);
                    if (curr.right != null) queue.Enqueue(curr.right);
                }
            }

            return root;

        }

        public static bool IsSymmetric(NodeClass root)
        {
            if (root == null)
                return true;

            return IsSymm(root.left, root.right);
        }

        public static bool IsSymm(NodeClass left, NodeClass right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;
            if (left.data != right.data) return false;

            return IsSymm(left.left, right.right) && IsSymm(left.right, right.left);
        }


        public static bool IsSymmetric2(NodeClass root)
        {
            if (root == null) return true;
            return IsMirror(root.left, root.right);
        }

        private static bool IsMirror(NodeClass t1, NodeClass t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;

            return (t1.data == t2.data)
                && IsMirror(t1.left, t2.right)
                && IsMirror(t1.right, t2.left);
        }

        public static bool IsSymmetric3(NodeClass root)
        {
            if (root == null) return true;
            Queue<NodeClass> queue = new Queue<NodeClass>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);
            while (queue.Count > 0)
            {
                NodeClass left = queue.Dequeue();
                NodeClass right = queue.Dequeue();
                if (left == null && right == null) continue;
                if (left == null || right == null) return false;
                if (left.data != right.data) return false;
                queue.Enqueue(left.left);
                queue.Enqueue(right.right);
                queue.Enqueue(left.right);
                queue.Enqueue(right.left);
            }
            return true;
        }

        public static bool IsBalanced(NodeClass root)
        {
            if (root == null)
                return true;

            return Height3(root) != -1 ? true : false;
        }

        private static int Height(NodeClass node)
        {
            if (node == null)
                return 0;
            int leftHeight = Height(node.left);
            if (leftHeight == -1) return -1;
            int rightHeight = Height(node.right);
            if (rightHeight == -1) return -1;
            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        private static int Height2(NodeClass node)
        {
            if (node == null)
                return 0;
            int leftHeight = Height2(node.left);
            int rightHeight = Height2(node.right);
            if (leftHeight == -1 || rightHeight == -1 || Math.Abs(leftHeight - rightHeight) > 1)
                return -1;
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        private static int Height3(NodeClass node)
        {
            if (node == null)
                return 0;
            int leftHeight = Height3(node.left);
            int rightHeight = Height3(node.right);

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1;
            }

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public static int MinDepth(NodeClass root)
        {
            if (root == null)
                return 0;

            int leftdepth = MinDepth(root.left);
            int rightdepth = MinDepth(root.right);

            if (root.left == null || root.right == null)
                return leftdepth + rightdepth + 1;

            return Math.Min(leftdepth, rightdepth) + 1;
        }

        public static int MinDepth2(NodeClass root)
        {
            if (root == null) return 0;

            Queue<NodeClass> q = new();
            root.data = 1;

            q.Enqueue(root);

            while (true)
            {
                NodeClass node = q.Dequeue();
                if (node.left == null && node.right == null) return node.data;

                if (node.left != null)
                {
                    node.left.data = node.data + 1;
                    q.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    node.right.data = node.data + 1;
                    q.Enqueue(node.right);
                }
            }
        }

        public static int MinDepth3(NodeClass root)
        {
            if (root == null) return 0;

            var queue = new Queue<NodeClass>();
            queue.Enqueue(root);
            int depth = 0;

            while (queue.Count > 0)
            {

                depth++;
                int levelSize = queue.Count;

                for (int i = 0; i < levelSize; i++)
                {

                    NodeClass node = queue.Dequeue();

                    if (node.left == null && node.right == null)
                    {

                        return depth;


                    }
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }

                }
            }

            return depth;

        }

        public static IList<int> PreorderTraversal(NodeClass root)
        {
            if (root == null)
                return new List<int>();

            IList<int> result = new List<int>();
            LeetCodeCodeFunctionsClass.PreorderHelper(root, result);
            return result;
        }

        private static void PreorderHelper(NodeClass node, IList<int> result)
        {
            if (node == null)
                return;
            result.Add(node.data);
            PreorderHelper(node.left, result);
            PreorderHelper(node.right, result);
        }

        public static IList<int> PreorderTraversal2(NodeClass root)
        {
            if (root == null)
                return new List<int>();

            var stack = new Stack<NodeClass>();
            IList<int> result = new List<int>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.data);
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }


            return result;
        }

        public static IList<int> PreorderTraversal3(NodeClass root)
        {
            var result = traverse(root);
            return result.ToList();
        }

        private static IEnumerable<int> traverse(NodeClass root)
        {
            if (root is null) yield break;
            yield return root.data;
            foreach (var val in traverse(root.left))
                yield return val;
            foreach (var val in traverse(root.right))
                yield return val;
        }

        public static IList<int> PreorderTraversal4(NodeClass root)
        {
            if (root == null) return new List<int>();

            var res = PreorderTraversal(root.left);
            res.Insert(0, root.data);

            return res.Concat(PreorderTraversal(root.right)).ToList();
        }

        public static IList<int> InorderTraversal(NodeClass root)
        {
            if (root == null)
                return new List<int>();

            IList<int> result = new List<int>();
            LeetCodeCodeFunctionsClass.InorderHelper(root, result);
            return result;
        }

        public static void InorderHelper(NodeClass root, IList<int> res)
        {
            if (root == null)
                return;
            InorderHelper(root.left, res);
            res.Add(root.data);
            InorderHelper(root.right, res);
        }

        public static IList<int> InorderTraversal2(NodeClass root)
        {
            if (root == null)
                return new List<int>();

            IList<int> listL = new List<int>();
            if (root.left != null)
                listL = InorderTraversal(root.left);

            IList<int> listR = new List<int>();
            if (root.right != null)
                listR = InorderTraversal(root.right);

            listL.Add(root.data);
            return listL.Concat(listR).ToList();
        }

        public static IList<int> InorderTraversal3(NodeClass root)
        {
            var ans = new List<int>();
            if (root == null)
                return ans;
            var s = new Stack<NodeClass>();
            NodeClass node = root;
            while (true)
            {
                if (node != null)
                {
                    s.Push(node);
                    node = node.left;
                }
                else
                {
                    if (s.Count == 0)
                        break;
                    node = s.Peek();
                    s.Pop();
                    ans.Add(node.data);
                    node = node.right;
                }
            }
            return ans;
        }

        public static IList<int> InorderTraversal4(NodeClass root)
        {
            var result = new List<int>();
            var stack = new Stack<NodeClass>();
            var current = root;
            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                current = stack.Pop();
                result.Add(current.data);
                current = current.right;
            }
            return result;
        }

        public static IList<int> InorderTraversal5(NodeClass root)
        {
            var result = new List<int>();
            var stack = new Stack<NodeClass>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (node.right != null)
                    stack.Push(node.right);

                if (node.left == null)
                {
                    result.Add(node.data);
                }
                else
                {
                    var templeft = node.left;
                    node.left = null;
                    node.right = null;
                    stack.Push(node);
                    stack.Push(templeft);
                }

            }

            return result;
        }

        public static IList<int> PostorderTraversal(NodeClass root)
        {
            IList<int> result = new List<int>();
            LeetCodeCodeFunctionsClass.PostorderHelper(root, result);
            return result;
        }

        private static void PostorderHelper(NodeClass node, IList<int> result)
        {
            if (node == null)
                return;
            PostorderHelper(node.left, result);
            PostorderHelper(node.right, result);
            result.Add(node.data);
        }

        public static IList<int> PostorderTraversal2(NodeClass root)
        {

            IList<int> result = new List<int>();

            if (root == null)
                return result;

            var stack = new Stack<NodeClass>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (current.left != null)
                    stack.Push(current.left);

                if (current.right != null)
                    stack.Push(current.right);

                result.Add(current.data);
            }

            return result.Reverse().ToList();
        }

        public static IList<int> PostorderTraversal3(NodeClass root)
        {
            if (root == null)
                return new List<int>();

            Stack<(NodeClass, List<int>)> stack = new();
            List<int> order = new();

            stack.Push((root.right, new List<int> { root.data }));
            stack.Push((root.left, new List<int>()));
            while (stack.Count > 0)
            {
                (NodeClass node, List<int> pending) = stack.Pop();

                if (node == null)
                {
                    for (int i = pending.Count - 1; i >= 0; i--)
                        order.Add(pending[i]);
                }
                else
                {
                    pending.Add(node.data);
                    stack.Push((node.right, pending));
                    stack.Push((node.left, new List<int>()));
                }
            }

            return order;
        }

        public static IList<int> PostorderTraversal4(NodeClass root)
        {

            List<int> result = [];

            if (root == null)
            {
                return result;
            }

            if (root.left != null)
            {
                result.AddRange(PostorderTraversal(root.left));
            }

            if (root.right != null)
            {
                result.AddRange(PostorderTraversal(root.right));
            }

            result.Add(root.data);

            return result;
        }

        public static IList<int> PostorderTraversal5(NodeClass root)
        {
            var stack = new Stack<NodeClass>();
            var visited = new HashSet<NodeClass>();
            var result = new List<int>();

            if (root is not null)
                stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Peek();

                if ((node.right is null && node.left is null)
                    || visited.Contains(node.left) || visited.Contains(node.right))
                {
                    visited.Add(node);
                    result.Add(node.data);
                    stack.Pop();

                    continue;
                }

                if (node.right is not null)
                    stack.Push(node.right);
                if (node.left is not null)
                    stack.Push(node.left);
            }

            return result;
        }

        public static IList<IList<int>> LevelOrder(NodeClass root)
        {
            IList<IList<int>> res = new List<IList<int>>();

            levelOrderRec(root, 0, res);
            return res;
        }

        private static void levelOrderRec(NodeClass root, int level,
                          IList<IList<int>> res)
        {
            if (root == null)
                return;

            if (res.Count <= level)
                res.Add(new List<int>());

            res[level].Add(root.data);

            levelOrderRec(root.left, level + 1, res);
            levelOrderRec(root.right, level + 1, res);
        }

        int MaxLevel = 0;
        public IList<IList<int>> LevelOrder2(NodeClass root)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            PreOrder(root, dict, 0);

            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            for (int i = 0; i <= MaxLevel; i++)
            {
                result.Add(dict[i]);
            }

            return result;
        }

        public void PreOrder(NodeClass root, Dictionary<int, List<int>> dict, int level)
        {
            if (root == null)
            {
                return;
            }

            MaxLevel = Math.Max(level, MaxLevel);
            if (!dict.ContainsKey(level))
            {
                dict.Add(level, new List<int>());
            }

            dict[level].Add(root.data);
            PreOrder(root.left, dict, level + 1);
            PreOrder(root.right, dict, level + 1);
        }

        public static IList<IList<int>> LevelOrder3(NodeClass root)
        {
            Queue<NodeClass> queue = new Queue<NodeClass>();
            IList<IList<int>> list = new List<IList<int>>();

            if (root != null)
            {
                queue.Enqueue(root);
                levelOrderRec2(queue, list);
            }

            return list;
        }

        public static void levelOrderRec2(Queue<NodeClass> q, IList<IList<int>> l)
        {
            if (q.Count == 0)
                return;

            Queue<NodeClass> tempQ = new Queue<NodeClass>();
            List<int> d = new List<int>();
            while (q.Count > 0)
            {
                NodeClass tempn = q.Dequeue();

                if (tempn != null)
                    d.Add(tempn.data);

                if (tempn?.left != null)
                    tempQ.Enqueue(tempn.left);

                if (tempn?.right != null)
                    tempQ.Enqueue(tempn.right);
            }

            l.Add(d);
            levelOrderRec2(tempQ, l);
        }

        public static IList<IList<int>> ZigzagLevelOrder(NodeClass root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            levelOrderZigzag(root, 0, res);
            return res;
        }

        private static void levelOrderZigzag(NodeClass root, int level,
                          IList<IList<int>> res)
        {
            if (root == null)
                return;

            if (res.Count <= level)
                res.Add(new List<int>());

            if (level % 2 == 0)
                res[level].Add(root.data);
            else
                res[level].Insert(0, root.data);

            levelOrderZigzag(root.left, level + 1, res);
            levelOrderZigzag(root.right, level + 1, res);
        }

        public static IList<IList<int>> ZigzagLevelOrder2(NodeClass root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Stack<NodeClass> currentLevel = new Stack<NodeClass>();
            currentLevel.Push(root);
            levelOrderZigzag2(root, res, currentLevel, 1);
            return res;
        }

        private static void levelOrderZigzag2(NodeClass root, IList<IList<int>> res, Stack<NodeClass> currentLevel, int level)
        {
            if (currentLevel.Count == 0)
                return;

            Stack<NodeClass> nextLevel = new Stack<NodeClass>();

            while (currentLevel.Count > 0)
            {
                NodeClass node = currentLevel.Pop();

                if (res.Count <= level)
                    res.Add(new List<int>());

                res[level - 1].Add(node.data);

                if (level % 2 != 0)
                {
                    if (node.left != null)
                        nextLevel.Push(node.left);
                    if (node.right != null)
                        nextLevel.Push(node.right);
                }
                else
                {
                    if (node.right != null)
                        nextLevel.Push(node.right);
                    if (node.left != null)
                        nextLevel.Push(node.left);
                }
            }

            levelOrderZigzag2(root, res, nextLevel, level + 1);
        }

        public IList<IList<int>> ZigzagLevelOrder3(NodeClass root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            Queue<NodeClass> queue = new Queue<NodeClass>();
            queue.Enqueue(root);
            result.Add(new List<int>() { root.data });
            bool reverse = false;
            while (queue.Count > 0)
            {
                var size = queue.Count;
                reverse = !reverse;
                List<int> values = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    var curr = queue.Dequeue();
                    if (curr.left != null)
                    {
                        values.Add(curr.left.data);
                        queue.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        values.Add(curr.right.data);
                        queue.Enqueue(curr.right);
                    }
                }
                if (values.Count > 0)
                {
                    if (reverse == true)
                        values.Reverse();
                    result.Add(values);
                }
            }
            return result;

        }

        public IList<IList<int>> ZigzagLevelOrder4(NodeClass root)
        {
            var ans = new List<IList<int>>();
            if (root == null) return ans;
            Queue<NodeClass> queue = new Queue<NodeClass>();
            queue.Enqueue(root);
            int height = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                var level = new List<int>();

                for (int i = 0; i < size; i++)
                {

                    NodeClass current = queue.Dequeue();
                    level.Add(current.data);
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);

                }
                if (height % 2 == 0) ans.Add(level);
                else ans.Add(level.AsEnumerable().Reverse().ToList());
                height += 1;
            }

            return ans;
        }

        public IList<IList<int>> ZigzagLevelOrder5(NodeClass root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            var queue = new Queue<NodeClass>();
            queue.Enqueue(root);
            int levels = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                List<int> temp = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    NodeClass curr = queue.Dequeue();

                    temp.Add(curr.data);

                    if (curr.left != null)
                    {
                        queue.Enqueue(curr.left);
                    }

                    if (curr.right != null)
                    {
                        queue.Enqueue(curr.right);
                    }
                }

                if (levels % 2 != 0)
                {
                    temp.Reverse();
                }



                levels++;
                result.Add(temp);
            }

            return result;
        }

        public static IList<double> AverageOfLevels(NodeClass root)
        {
            IList<double> result = new List<double>();
            if (root == null) return result;
            Queue<NodeClass> queue = new Queue<NodeClass>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                double sum = 0;
                for (int i = 0; i < size; i++)
                {
                    NodeClass curr = queue.Dequeue();
                    sum += curr.data;
                    if (curr.left != null) queue.Enqueue(curr.left);
                    if (curr.right != null) queue.Enqueue(curr.right);
                }
                result.Add(sum / size);
            }
            return result;
        }

        public static IList<double> AverageOfLevels2(NodeClass root)
        {
            IList<double> result = new List<double>();
            IList<int> lcount = new List<int>();
            levelOrderAverage(root, result, lcount, 0);
            return result;
        }

        public static void levelOrderAverage(NodeClass root, IList<double> res, IList<int> lc, int level)
        {
            if (root == null) return;

            if (level < res.Count)
            {
                res[level] = (res[level] * lc[level] + root.data) / (lc[level] + 1);
                lc[level]++;
            }
            else
            {
                res.Add(root.data);
                lc.Add(1);
            }

            levelOrderAverage(root.left, res, lc, level + 1);
            levelOrderAverage(root.right, res, lc, level + 1);
        }

        public static bool HasPathSum(NodeClass root, int targetSum)
        {
            if (root == null) return false;
            if (root.left == null && root.right == null) return root.data == targetSum;
            return HasPathSum(root.left, targetSum - root.data) || HasPathSum(root.right, targetSum - root.data);
        }

        public static bool HasPathSum2(NodeClass root, int targetSum)
        {
            if (root == null)
                return false;

            if (root.left == null && root.right == null)
            {
                return targetSum == root.data;
            }
            targetSum -= root.data;
            return HasPathSum2(root.left, targetSum) || HasPathSum2(root.right, targetSum);
        }

        public static IList<IList<int>> PathSum(NodeClass root, int targetSum)
        {
            IList<IList<int>> result = new List<IList<int>>();
            //IList<int> temp = new List<int>();
            PathSumHelper(root, targetSum, result, new List<int>());
            return result;
        }

        private static void PathSumHelper(NodeClass root, int targetSum, IList<IList<int>> result, IList<int> temp)
        {
            if (root == null)
                return;
            temp.Add(root.data);
            targetSum -= root.data;
            if (root.left == null && root.right == null && targetSum == 0)
            {
                result.Add(new List<int>(temp));
            }
            else
            {
                PathSumHelper(root.left, targetSum, result, temp);
                PathSumHelper(root.right, targetSum, result, temp);
            }
            temp.RemoveAt(temp.Count - 1);
        }

        private static void PathSumHelper2(NodeClass root, int targetSum, IList<IList<int>> result, IList<int> temp)
        {
            if (root == null) return;

            temp.Add(root.data);

            if (root.left == null && root.right == null && targetSum == root.data)
            {
                result.Add(new List<int>(temp));
            }
            else
            {
                PathSumHelper2(root.left, targetSum - root.data, result, temp);
                PathSumHelper2(root.right, targetSum - root.data, result, temp);
            }

            temp.RemoveAt(temp.Count - 1);
        }

        public static IList<IList<int>> PathSum2(NodeClass root, int targetSum)
        {
            IList<IList<int>> result = new List<IList<int>>();

            var stack = new Stack<(NodeClass nc, List<int> list, int sum)>();

            stack.Push(new(root, new List<int>(), 0));

            while (stack.Count > 0)
            {
                var (node, list, sum) = stack.Pop();
                var newCom = new List<int>(list);
                newCom.Add(node.data);

                if (node.left == null && node.right == null && node.data + sum == targetSum)
                {
                    result.Add(new List<int>(newCom));
                }

                if (node.right != null && node.data + sum < targetSum)
                {
                    stack.Push(new(node.right, newCom, sum + node.data));
                }

                if (node.left != null && node.data + sum < targetSum)
                {
                    stack.Push(new(node.left, newCom, sum + node.data));
                }
            }


            return result;
        }

        public static IList<string> BinaryTreePaths(NodeClass root)
        {

            IList<string> result = new List<string>();
            BinaryTreePathsHelper2(root, result, new List<int>());
            return result;
        }
        private static void BinaryTreePathsHelper2(NodeClass root, IList<string> result, IList<int> temp)
        {
            if (root == null) return;

            temp.Add(root.data);

            if (root.left == null && root.right == null)
            {
                result.Add(string.Join("->", temp.Select(item => string.Join("", item))));
            }
            else
            {
                BinaryTreePathsHelper2(root.left, result, temp);
                BinaryTreePathsHelper2(root.right, result, temp);
            }

            temp.RemoveAt(temp.Count - 1);
        }

        public static IList<string> BinaryTreePaths2(NodeClass root)
        {
            IList<string> result = new List<string>();

            BinaryTreePathsDFS(root, "", result);

            return result;
        }

        private static void BinaryTreePathsDFS(NodeClass node, string path, IList<string> result)
        {
            if (node == null)
                return;

            path += node.data.ToString();

            // Leaf node
            if (node.left == null && node.right == null)
            {
                result.Add(path);
                return;
            }

            path += "->";

            BinaryTreePathsDFS(node.left, path, result);
            BinaryTreePathsDFS(node.right, path, result);
        }
        public static IList<string> BinaryTreePaths3(NodeClass root)
        {
            var solutions = new List<string>();

            BTPGetPaths(root, solutions, new List<int>());

            return solutions;
        }

        private static void BTPGetPaths(NodeClass root, IList<string> solutions, IList<int> current)
        {
            if (root == null)
            {
                return;
            }

            var newCurrent = new List<int>(current);
            newCurrent.Add(root.data);

            if (root.left != null)
            {
                BTPGetPaths(root.left, solutions, newCurrent);
            }
            if (root.right != null)
            {
                BTPGetPaths(root.right, solutions, newCurrent);
            }

            if (root.left == null && root.right == null)
            {

                var sol = string.Join("->", newCurrent);
                solutions.Add(sol);
            }
        }

        public static IList<string> BinaryTreePaths4(NodeClass root)
        {
            IList<string> result = new List<string>();

            var stack = new Stack<(NodeClass nc, string path)>();

            stack.Push((root, ""));

            while (stack.Count > 0)
            {
                var (node, path) = stack.Pop();
                path += node.data.ToString();

                if (node.left == null && node.right == null)
                {
                    result.Add(path);
                }

                path += "->";
                if (node.right != null)
                {
                    stack.Push(new(node.right, path));
                }

                if (node.left != null)
                {
                    stack.Push(new(node.left, path));
                }
            }


            return result;
        }

        public static int SumNumbers(NodeClass root, int sum = 0)
        {
            if (root == null)
                return 0;

            sum = sum * 10 + root.data;

            if (root.left == null && root.right == null)
                return sum;

            return SumNumbers(root.left, sum) + SumNumbers(root.right, sum);
        }

        public static int SumNumbers2(NodeClass root)
        {
            if (root == null)
                return root.data;

            List<int> tempval = new List<int>();
            SumNumberHelper(root, 0, tempval);
            return tempval.Sum();
        }

        public static void SumNumberHelper(NodeClass root, int s, List<int> tempval)
        {
            if (root == null)
                return;

            s = s * 10 + root.data;
            if (root.left == null && root.right == null)
            {
                tempval.Add(s);
            }
            else
            {
                SumNumberHelper(root.left, s, tempval);
                SumNumberHelper(root.right, s, tempval);
            }
            s = (s - root.data) / 10;
        }

        public static int SumNumbers3(NodeClass root)
        {
            if (root == null)
                return 0;
            IList<int> res = new List<int>();
            HelperSumNumber2(root, res);
            return res.Sum();
        }

        public static void HelperSumNumber2(NodeClass root, IList<int> res)
        {
            if (root.right == null && root.left == null)
            {
                res.Add(root.data);
                return;
            }

            if (root.left != null)
            {
                root.left.data = (root.data * 10) + root.left.data;
                HelperSumNumber2(root.left, res);
            }

            if (root.right != null)
            {
                root.right.data = (root.data * 10) + root.right.data;
                HelperSumNumber2(root.right, res);
            }
        }

        public static int pathSumIII(NodeClass root, int sum)
        {
            if (root == null)
                return 0;
            return pathSumIIIdfs(root, sum) + pathSumIII(root.left, sum) + pathSumIII(root.right, sum);
        }

        private static int pathSumIIIdfs(NodeClass root, long sum)
        {
            if (root == null)
                return 0;
            return (sum == root.data ? 1 : 0) +
                pathSumIIIdfs(root.left, sum - root.data) +
                pathSumIIIdfs(root.right, sum - root.data);
        }

        public static int k = 0;

        public static int PathSumIII2(NodeClass root, int sum)
        {
            if (root == null)
                return k;
            pathSumIIIdfs2(root, sum);
            return k;

        }

        private static void pathSumIIIdfs2(NodeClass root, int sum)
        {
            if (root == null)
                return;
            helperOfSumIII(root, sum);

            if (root.left != null)
                pathSumIIIdfs2(root.left, sum);

            if (root.right != null)
                pathSumIIIdfs2(root.right, sum);
        }
        private static void helperOfSumIII(NodeClass root, int sum)
        {
            if (sum - root.data == 0) k++;

            if (root.left != null)
                helperOfSumIII(root.left, sum - root.data);
            if (root.right != null)
                helperOfSumIII(root.right, sum - root.data);
        }
    }
}
