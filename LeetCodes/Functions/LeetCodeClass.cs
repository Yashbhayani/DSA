using LeetCodes.Controller;
using LeetCodes.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        private static void ExpandFromCenter(string s, int left, int right,
                                     ref int start, ref int maxLen)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                int len = right - left + 1;
                if (len > maxLen)
                {
                    maxLen = len;
                    start = left;
                }
                left--;
                right++;
            }
        }

        public static string LongestPalindromicSubstring(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2)
                return s;

            int start = 0, maxLen = 1;

            for (int i = 0; i < s.Length; i++)
            {
                // Odd length palindrome
                ExpandFromCenter(s, i, i, ref start, ref maxLen);

                // Even length palindrome
                ExpandFromCenter(s, i, i + 1, ref start, ref maxLen);
            }

            return s.Substring(start, maxLen);
        }

        public static string LongestPalindromicSubstring2(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2)
                return s;

            string maxString = s[0].ToString();   // important for cases like "a"

            for (int i = 0; i < s.Length - 1; i++)
            {
                string ss = s[i].ToString();
                for (int j = i + 1; j < s.Length; j++)
                {
                    ss += s[j].ToString();

                    if (s[i] == s[j] && IsPalindrome(ss))   // ONLY real fix
                    {
                        maxString = maxString.Length >= ss.Length ? maxString : ss;
                    }
                }
            }
            return maxString;
        }

        private static bool IsPalindrome(string str)
        {
            int l = 0, r = str.Length - 1;
            while (l < r)
            {
                if (str[l] != str[r]) return false;
                l++;
                r--;
            }
            return true;
        }


        public static string LongestPalindromicSubstring3(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2)
                return s;

            int first = 0;
            int last = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                    {
                        if ((last - first) < (j - i))
                        {
                            first = i;
                            last = j;
                        }
                        break;
                    }
                }
            }
            if (last == 0) return s[0].ToString();
            return s.Substring(first, last - first + 1);
        }

        public static string ZigzagConversion(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s) || numRows <= 0)
            {
                return "";
            }

            if (numRows == 1)
            {
                return s;
            }

            StringBuilder result = new StringBuilder();

            int step = 2 * numRows - 2;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = i; j < s.Length; j += step)
                {
                    result.Append(s[j]);

                    if (i != 0 && i != numRows - 1 && (j + step - 2 * i) < s.Length)
                    {
                        result.Append(s[j + step - 2 * i]);
                    }
                }
            }

            return result.ToString();

        }

        public static string ZigzagConversion2(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s) || numRows <= 0)
            {
                return "";
            }

            if (numRows == 1) return s;

            string[] newarr = new string[numRows];

            for (int i = 0; i < numRows; i++)
            {
                newarr[i] = "";
            }

            int n = 0;
            bool isReverse = false;

            for (int i = 0; i < s.Length; i++)
            {
                newarr[n] += s[i].ToString();

                if (!isReverse)
                {
                    n++;
                    if (n == numRows)
                    {
                        n -= 2;
                        isReverse = true;
                    }
                }
                else
                {
                    n--;
                    if (n < 0)
                    {
                        n += 2;
                        isReverse = false;
                    }
                }
            }

            return string.Join("", newarr);
        }

        public static int reverse(int x)
        {
            bool isNegative = false;
            if (x < 0)
            {
                isNegative = true;
                x = -x;
            }
            long reverse = 0;
            while (x > 0)
            {
                reverse = reverse * 10 + x % 10;
                x /= 10;
            }
            if (reverse > int.MaxValue)
            {
                return 0;
            }
            return (int)(isNegative ? -reverse : reverse);
        }

        public static int reverse2(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int digit = x % 10;
                x /= 10;

                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > 7)) return 0;
                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && digit < -8)) return 0;

                result = result * 10 + digit;
            }
            return result;
        }

        public static int reverse3(int x)
        {
            bool isNegative = false;

            if (x == int.MinValue)
                return 0;

            if (x < 0)
            {
                isNegative = true;
                x = -x;
            }

            string s = new string(x.ToString().Reverse().ToArray());

            long val = long.Parse(s);

            if (val > int.MaxValue)
                return 0;

            return (int)(isNegative ? -val : val);
        }


        public static int MyAtoi(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            const int INT_MAX = 2147483647;
            const int INT_MIN = -2147483648;

            s = System.Text.RegularExpressions.Regex.Replace(s, @"^\s+", "");

            int i = 0;
            bool isNegative = s.StartsWith("-");
            bool isPositive = s.StartsWith("+");

            if (isNegative)
            {
                i++;
            }
            else if (isPositive)
            {
                i++;
            }

            double number = 0;

            while (i < s.Length && s[i] >= '0' && s[i] <= '9')
            {
                number = number * 10 + (s[i] - '0');
                i++;
            }

            number = isNegative ? -number : number;

            if (number < INT_MIN)
            {
                return INT_MIN;
            }

            if (number > INT_MAX)
            {
                return INT_MAX;
            }

            return (int)number;
        }



        public static int MyAtoi2(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var match = Regex.Match(s.Trim(), @"^-?\d+");

            try
            {
                if (!match.Success || int.Parse(match.Value) > int.MaxValue || int.Parse(match.Value) < int.MinValue)
                    return 0;

                return int.Parse(match.Value);
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public static int MyAtoi3(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int i = 0, n = s.Length;


            while (i < n && s[i] == ' ')
                i++;

            int sign = 1;
            if (i < n && (s[i] == '+' || s[i] == '-'))
            {
                if (s[i] == '-') sign = -1;
                i++;
            }

            int result = 0;
            while (i < n && char.IsDigit(s[i]))
            {
                int digit = s[i] - '0';

                if (result > (int.MaxValue - digit) / 10)
                {
                    return sign == 1 ? int.MaxValue : int.MinValue;
                }

                result = result * 10 + digit;
                i++;
            }

            return result * sign;
        }

        public static int MyAtoi4(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            s = s.Trim();

            var match = Regex.Match(s, @"^[+-]?\d+");

            if (!match.Success)
                return 0;

            if (long.TryParse(match.Value, out long num))
            {
                if (num > int.MaxValue) return int.MaxValue;
                if (num < int.MinValue) return int.MinValue;
                return (int)num;
            }

            return 0;

        }

        public static int MyAtoi5(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            s = s.Trim();

            int i = 0;
            if (s[0] == '-' || s[0] == '+') i++;

            while (i < s.Length && char.IsDigit(s[i]))
                i++;

            s = s.Substring(0, i);
            if (long.TryParse(s, out long num))
            {
                if (num > int.MaxValue) return int.MaxValue;
                if (num < int.MinValue) return int.MinValue;
            }
            return int.Parse(s);
        }

        public static bool IsPalindrome(int x)
        {
            if(x < 0) return false;
            int s = int.Parse(new string(x.ToString().Reverse().ToArray()));
            return s == x;
        }

    }
}
