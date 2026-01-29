using LeetCodes.Controller;
using LeetCodes.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodes.Functions
{
    internal class LeetCodeClass
    {

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

        public static double MedianofTwoSortedArrays(int[] nums1, int[] nums2)
        {
            int[] arr = nums1.Concat(nums2).OrderBy(x => x).ToArray();
            int n = arr.Length;
            if (n % 2 == 1)
            {
                return arr[n / 2];
            }
            else
            {
                return (arr[n / 2 - 1] + arr[n / 2]) / 2.0;
            }
        }

        public static double MedianofTwoSortedArrays2(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;
            int n = n1 + n2;

            int i = 0, j = 0;
            int prev = 0, curr = 0;

            for (int count = 0; count <= n / 2; count++)
            {
                prev = curr;

                if (i < n1 && (j >= n2 || nums1[i] <= nums2[j]))
                {
                    curr = nums1[i];
                    i++;
                }
                else
                {
                    curr = nums2[j];
                    j++;
                }
            }

            if (n % 2 == 1)
                return curr;

            return (prev + curr) / 2.0;
        }

        public static string LongestPalindromicSubstring(string s)
        {
            string maxString = null;
            for(int i = 0; i < s.Length; i++)
            {

            }
            return null;
        }


    }
}
