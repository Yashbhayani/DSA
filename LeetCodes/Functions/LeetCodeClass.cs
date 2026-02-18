using LeetCodes.Controller;
using LeetCodes.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
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
                ExpandFromCenter(s, i, i, ref start, ref maxLen);

                ExpandFromCenter(s, i, i + 1, ref start, ref maxLen);
            }

            return s.Substring(start, maxLen);
        }

        public static string LongestPalindromicSubstring2(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 2)
                return s;

            string maxString = s[0].ToString();

            for (int i = 0; i < s.Length - 1; i++)
            {
                string ss = s[i].ToString();
                for (int j = i + 1; j < s.Length; j++)
                {
                    ss += s[j].ToString();

                    if (s[i] == s[j] && IsPalindrome(ss))
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
            if (x < 0 || (x != 0 && x % 10 == 0)) return false;

            string rev = new string(x.ToString().Reverse().ToArray());

            if (!long.TryParse(rev, out long s)) return false;
            if (s > int.MaxValue) return false;
            return s == x;
        }

        public static bool IsPalindrome2(int x)
        {
            if (x < 0 || (x != 0 && x % 10 == 0)) return false;


            int result = 0;
            int temp = x;
            while (temp > 0)
            {
                int digit = temp % 10;

                if (result > (int.MaxValue - digit) / 10)
                    return false;

                result = (result * 10) + digit;
                temp /= 10;
            }
            return result == x;
        }

        public static bool IsPalindrome3(int x)
        {
            if (x < 0 || (x != 0 && x % 10 == 0)) return false;

            string result = "";
            int temp = x;
            while (temp > 0)
            {
                result += (temp % 10).ToString();
                temp = temp / 10;
            }

            if (!long.TryParse(result, out long val)) return false;
            if (val > int.MaxValue) return false;

            return int.Parse(result) == x;
        }

        public static bool RegularExpressionMatching(string s, string p)
        {

            int rows = s.Length;
            int columns = p.Length;

            if (rows == 0 && columns == 0)
            {
                return true;
            }
            if (columns == 0)
            {
                return false;
            }

            bool[,] dp = new bool[rows + 1, columns + 1];
            dp[0, 0] = true;

            for (int i = 2; i <= columns; i++)
            {
                if (p[i - 1] == '*')
                {
                    dp[0, i] = dp[0, i - 2];
                }
            }

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (j > 1 && p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 2];
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                        {
                            dp[i, j] = dp[i, j] || dp[i - 1, j];
                        }
                    }
                }
            }

            return dp[rows, columns];

        }
        public static bool RegularExpressionMatching2(string s, string p)
        {
            var regex = new Regex(p);
            var match = regex.Match(s, 0, s.Length);
            if (match.Success)
            {
                return match.Value == s;
            }
            return false;
        }


        public static int maxArea(int[] height)
        {
            int ANS = 0;
            int B = height.Length - 1;

            for (int i = 0; i < height.Length;)
            {
                int DD = Math.Min(height[i], height[B]);
                ANS = Math.Max(ANS, DD * (B - i));
                if (height[i] < height[B])
                {
                    i++;
                }
                else
                {
                    B--;
                }
                if (i > B)
                {
                    break;
                }
            }
            return ANS;
        }

        public static string intToRoman(int num)
        {
            string HH = "";
            int[] M = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] C = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            int k = M.Length - 1;
            for (int i = k; i >= 0; i--)
            {
                if (num >= M[i])
                {
                    int Do = num / M[i];
                    for (int j = 1; j <= Do; j++)
                    {
                        HH += C[i];
                    }
                    num %= M[i];

                }
            }
            return HH;
        }
        public static string intToRoman2(int num)
        {
            string HH = "";
            while (num != 0)
            {
                if (num >= 1000)
                {
                    num -= 1000;
                    HH += "M";
                }
                else if (num >= 500)
                {
                    num -= 500;
                    HH += "D";
                }
                else if (num >= 100)
                {
                    num -= 100;
                    HH += "C";
                }
                else if (num >= 50)
                {
                    num -= 50;
                    HH += "L";
                }
                else if (num >= 40)
                {
                    num -= 40;
                    HH += "XL";
                }

                else if (num >= 10)
                {
                    num -= 10;
                    HH += "X";
                }

                else if (num >= 9)
                {
                    num -= 9;
                    HH += "IX";
                }

                else if (num >= 5)
                {
                    num -= 5;
                    HH += "V";
                }

                else if (num >= 4)
                {
                    num -= 4;
                    HH += "IV";
                }

                else if (num >= 1)
                {
                    num -= 1;
                    HH += "I";
                }

                else
                {
                    num = 0;
                }
            }
            return HH;
        }

        public static int RomanToInt(string s)
        {
            Dictionary<char, int> romanMap = new Dictionary<char, int> {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
            int n = s.Length;
            int num = romanMap[s[n - 1]];

            for (int i = n - 2; i >= 0; i--)
            {
                if (romanMap[s[i]] >= romanMap[s[i + 1]])
                {
                    num += romanMap[s[i]];
                }
                else
                {
                    num -= romanMap[s[i]];
                }
            }
            return num;
        }
        public static int fromRomanToInt(char c)
        {
            if (c == 'I')
            {
                return 1;
            }
            else if (c == 'V')
            {
                return 5;
            }
            else if (c == 'X')
            {
                return 10;
            }
            else if (c == 'L')
            {
                return 50;
            }
            else if (c == 'C')
            {
                return 100;
            }
            else if (c == 'D')
            {
                return 500;
            }
            else if (c == 'M')
            {
                return 1000;
            }
            else
            {
                return 0;
            }
        }

        public static int RomanToInt2(string s)
        {
            int numero = 0;
            int current;
            int next;

            for (int i = 0; i < s.Length; i++)
            {

                current = fromRomanToInt(s[i]);

                if (i + 1 < s.Length)
                {
                    next = fromRomanToInt(s[i + 1]);

                    if (current >= next)
                    {
                        numero += current;
                    }
                    else
                    {
                        numero -= current;
                    }

                }
                else
                {
                    numero += current;
                }

            }

            return numero;
        }

        public static int RomanToInt3(string s)
        {
            int num = 0;
            int current;
            int next;

            for (int i = 1; i <= s.Length; i++)
            {
                current = fromRomanToInt(s[i - 1]);
                if (i == s.Length)
                {
                    num += current;
                    break;
                }
                next = fromRomanToInt(s[i]);

                if (current >= next)
                {
                    num += current;
                }
                else
                {
                    num -= current;
                }

            }

            return num;
        }


        public static string LongestCommonPrefix(string[] strs)
        {
            StringBuilder longestCommonPrefix = new StringBuilder();

            if (strs == null || strs.Length == 0)
            {
                return longestCommonPrefix.ToString();
            }

            int minimumLength = strs[0].Length;

            for (int i = 1; i < strs.Length; i++)
            {
                minimumLength = Math.Min(minimumLength, strs[i].Length);
            }

            for (int i = 0; i < minimumLength; i++)
            {
                char current = strs[0][i];

                foreach (string str in strs)
                {
                    if (str[i] != current)
                    {
                        return longestCommonPrefix.ToString();
                    }
                }

                longestCommonPrefix.Append(current);
            }

            return longestCommonPrefix.ToString();
        }

        public static string LongestCommonPrefix2(string[] strs)
        {
            string prefix = strs[0];

            for (int i = 1; i < strs.Length; i++)
            {
                while (!strs[i].StartsWith(prefix))
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (prefix == "")
                        return "";
                }
            }

            return prefix;
        }

        public static string LongestCommonPrefix3(string[] strs)
        {
            int ML = strs[0].Length;
            string MLs = strs[0];
            foreach (string str in strs)
            {
                if (str.Length < ML)
                {
                    MLs = str;
                }
                ML = Math.Min(ML, str.Length);

            }


            string prefix = "";
            bool sd = true;
            for (int i = 0; i < ML; i++)
            {
                foreach (string str in strs)
                {
                    if (str[i] != MLs[i])
                    {
                        sd = false;
                    }
                }

                if (sd)
                {
                    prefix += MLs[i];
                }
                else
                {
                    break;
                }
            }

            return prefix;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            IList<IList<int>> triplets = new List<IList<int>>();

            for (int i = 0; i < n; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int j = i + 1;
                int k = n - 1;

                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];

                    if (sum == 0)
                    {
                        triplets.Add(new List<int> { nums[i], nums[j], nums[k] });

                        j++;
                        k--;

                        while (j < k && nums[j] == nums[j - 1]) j++;
                        while (j < k && nums[k] == nums[k + 1]) k--;
                    }
                    else if (sum < 0)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return triplets;
        }

        public static IList<IList<int>> ThreeSum2(int[] nums)
        {
            Array.Sort(nums);

            IList<IList<int>> triplets = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 1; i++)
            {
                int newval = nums[i] + nums[i + 1];

                if (newval < 0 && newval != 0)
                {
                    newval = -newval;
                }

                int val = Array.IndexOf(nums, newval);

                if (val > 0 && val != i && val != (i + 1))
                {
                    triplets.Add(new List<int> { nums[i], nums[i + 1], newval });
                }
            }

            return triplets;
        }

        public static int threeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int closest = nums[0] + nums[1] + nums[n - 1];
            for (int i = 0; i < n - 2; i++)
            {
                int j = i + 1;
                int k = n - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum <= target)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                    if (Math.Abs(closest - target) > Math.Abs(sum - target))
                    {
                        closest = sum;
                    }
                }
            }
            return closest;
        }

        public static int threeSumClosest2(int[] nums, int target)
        {
            int n = nums.Length;
            int closest = nums[0] + nums[1] + nums[2];
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        int sum = nums[i] + nums[k] + nums[j];
                        if (Math.Abs(closest - target) > Math.Abs(sum - target))
                        {
                            closest = sum;
                        }
                    }
                }
            }
            return closest;
        }

        public static IList<string> LetterCombinations(string digits)
        {
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(digits)) return result;

            string[] map = new string[] {
            "", "", "abc", "def", "ghi", "jkl",
            "mno", "pqrs", "tuv", "wxyz"
        };

            Backtracking(digits, new StringBuilder(), map, 0, result);
            return result;
        }

        public static void Backtracking(string digits, StringBuilder temp, string[] map, int index, List<string> result)
        {
            if (index == digits.Length)
            {
                result.Add(temp.ToString());
                return;
            }

            string cur = map[digits[index] - '0'];

            foreach (char c in cur)
            {
                temp.Append(c);
                Backtracking(digits, temp, map, index + 1, result);
                temp.Remove(temp.Length - 1, 1);
            }


        }

        public static IList<string> LetterCombinations2(string digits)
        {
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(digits)) return result;

            Dictionary<char, string> contactString = new Dictionary<char, string> {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"},
    };

            Queue<string> q = new Queue<string>();
            q.Enqueue("");

            foreach (char c in digits)
            {
                string letters = contactString[c];
                int size = q.Count;

                for (int i = 0; i < size; i++)
                {
                    string cur = q.Dequeue();

                    foreach (char la in letters)
                    {
                        q.Enqueue(cur + la);
                    }
                }
            }

            return q.ToList();
        }

        public static IList<string> LetterCombinations3(string digits)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(digits)) return result;

            string[] map = {
            "", "", "abc", "def", "ghi",
            "jkl", "mno", "pqrs", "tuv", "wxyz"
        };


            result.Add("");

            foreach (char d in digits)
            {
                var temp = new List<string>();
                string letters = map[d - '0'];

                foreach (var item in result)
                {
                    foreach (var item1 in letters)
                    {
                        temp.Add(item + item1);
                    }
                }
                result = temp;
            }

            return result;
        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            var ans = new List<IList<int>>();
            NSum(nums, 4, target, 0, nums.Length - 1, new List<int>(), ans);
            return ans;
        }

        private static void NSum(int[] nums, int n, long target, int l, int r,
                          List<int> path, List<IList<int>> ans)
        {
            if (r - l + 1 < n || target < (long)nums[l] * n || target > (long)nums[r] * n)
                return;

            if (n == 2)
            {
                while (l < r)
                {
                    int sum = nums[l] + nums[r];

                    if (sum == target)
                    {
                        path.Add(nums[l]);
                        path.Add(nums[r]);
                        ans.Add(new List<int>(path));

                        path.RemoveAt(path.Count - 1);
                        path.RemoveAt(path.Count - 1);

                        l++;
                        r--;

                        while (l < r && nums[l] == nums[l - 1]) l++;
                        while (l < r && nums[r] == nums[r + 1]) r--;
                    }
                    else if (sum < target)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
                return;
            }

            for (int i = l; i <= r; i++)
            {
                if (i > l && nums[i] == nums[i - 1])
                    continue;

                path.Add(nums[i]);
                NSum(nums, n - 1, target - nums[i], i + 1, r, path, ans);
                path.RemoveAt(path.Count - 1);
            }
        }

        public static IList<IList<int>> FourSum2(int[] nums, int target)
        {
            var ans = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 3; i++)
            {
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    for (int k = j + 1; k < nums.Length - 1; k++)
                    {
                        for (int l = k + 1; l < nums.Length; l++)
                        {
                            if (nums[i] + nums[j] + nums[k] + nums[l] == target)
                            {
                                ans.Add(new List<int> { nums[i], nums[j], nums[k], nums[k] });
                            }
                        }
                    }
                }
            }
            return ans;
        }


        public static Node RemoveNthFromEnd(Node head, int n)
        {
            Node slow = head;
            Node fast = head;

            while (n-- > 0)
                fast = fast.next;

            if (fast == null)
                return head.next;

            while (fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }

            slow.next = slow.next.next;

            return head;
        }

        public static Node? RemoveNthFromEnd2(Node head, int target)
        {
            if (head == null || target == 0) return head;
            int? count = LeetCodeCodeFunctionsClass.ListCount(head);
            int c = 0;
            Node dummy = new Node(0);
            Node cdu = dummy;

            while (head != null)
            {
                if (c == (count - target))
                {
                    head = head.next;
                }

                cdu.next = head;
                cdu = head;
                head = head.next;
                c++;
            }
            return dummy.next;
        }

        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '(')
                    stack.Push(')');
                else if (c == '{')
                    stack.Push('}');
                else if (c == '[')
                    stack.Push(']');
                else if (stack.Count == 0 || stack.Pop() != c)
                    return false;
            }

            return stack.Count == 0;
        }

        public static bool IsValid2(string s)
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

        public static bool IsValid3(string s)
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

        public static bool IsValid4(string s)
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

        public static Node MergeTwoLists(Node list1, Node list2)
        {
            if (list1 == null || list2 == null)
                return list1 == null ? list2 : list1;

            if (list1.value > list2.value)
            {
                Node temp = list1;
                list1 = list2;
                list2 = temp;
            }

            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        }

        public static Node? MergeTwoLists2(Node list1, Node list2)
        {

            Node nNode = new Node(0);
            Node dum = nNode;

            while (list1 != null && list2 != null)
            {
                if (list1.value >= list2.value)
                {
                    Node tempNnode2 = list2.next;
                    list2.next = null;
                    dum.next = list2;
                    list2 = tempNnode2;
                }
                else
                {

                    Node tempNnode1 = list1.next;
                    list1.next = null;
                    dum.next = list1;
                    list1 = tempNnode1;
                }
                dum = dum.next;
            }

            dum.next = list1 ?? list2;
            return nNode.next;
        }

        public static IList<string> GenerateParenthesis(int n)
        {
            var ans = new List<string>();
            Dfs(n, n, new StringBuilder(), ans);
            return ans;
        }

        private static void Dfs(int l, int r, StringBuilder sb, IList<string> ans)
        {
            if (l == 0 && r == 0)
            {
                ans.Add(sb.ToString());
                return;
            }

            if (l > 0)
            {
                sb.Append("(");
                Dfs(l - 1, r, sb, ans);
                sb.Length--;
            }

            if (l < r)
            {
                sb.Append(")");
                Dfs(l, r - 1, sb, ans);
                sb.Length--;
            }
        }

        public static IList<string> GenerateParenthesis2(int n)
        {
            var result = new List<string>();
            var queue = new Queue<(string str, int open, int close)>();

            queue.Enqueue(("", 0, 0));

            while (queue.Count > 0)
            {
                var (str, open, close) = queue.Dequeue();

                if (str.Length == 2 * n)
                {
                    result.Add(str);
                    continue;
                }

                if (open < n)
                    queue.Enqueue((str + "(", open + 1, close));

                if (close < open)
                    queue.Enqueue((str + ")", open, close + 1));
            }

            return result;
        }

        public static IList<string> GenerateParenthesis3(int n)
        {
            List<string> result = new List<string>();
            Build(result, "", 0, 0, n);
            return result;
        }

        private static void Build(List<string> result, string current, int open, int close, int n)
        {
            if (current.Length == 2 * n)
            {
                result.Add(current);
                return;
            }

            if (open < n)
                Build(result, current + "(", open + 1, close, n);

            if (close < open)
                Build(result, current + ")", open, close + 1, n);
        }

        public static IList<string> GenerateParenthesis4(int n)
        {
            var result = new List<string>();
            var st = new Stack<(string str, int open, int close)>();

            st.Push(("", 0, 0));

            while (st.Count > 0)
            {
                var (str, open, close) = st.Pop();

                if (str.Length == 2 * n)
                {
                    result.Add(str);
                    continue;
                }

                if (open < n)
                    st.Push((str + "(", open + 1, close));

                if (close < open)
                    st.Push((str + ")", open, close + 1));
            }

            return result;
        }

        public static Node MergeKLists(Node[] head)
        {
            if (head == null || head.Length == 0)
                return null;

            List<int> li = new List<int>();

            foreach (var list in head)
            {
                Node node = list;
                while (node != null)
                {
                    li.Add(node.value);
                    node = node.next;
                }
            }

            li.Sort();

            if (li.Count == 0)
                return null;

            Node headd = new Node(li[0]);
            Node current = headd;

            for (int i = 1; i < li.Count; i++)
            {
                current.next = new Node(li[i]);
                current = current.next;
            }

            return headd;
        }

        public static Node MergeKLists2(Node[] head)
        {
            if (head == null || head.Length == 0)
                return null;

            LinkedList<int> linkedList = new LinkedList<int>();

            AddAllValues(head, linkedList);

            if (linkedList.Count == 0)
                return null;

            SortLinkedList(linkedList);

            return BuildNodeList(linkedList);
        }
        static void AddAllValues(Node[] heads, LinkedList<int> list)
        {
            foreach (var node in heads)
            {
                Node cur = node;
                while (cur != null)
                {
                    list.AddLast(cur.value);
                    cur = cur.next;
                }
            }
        }
        static void SortLinkedList(LinkedList<int> list)
        {
            int[] arr = list.ToArray();
            Array.Sort(arr);

            list.Clear();
            foreach (var v in arr)
                list.AddLast(v);
        }

        static Node BuildNodeList(LinkedList<int> list)
        {
            Node dummy = new Node(0);
            Node tail = dummy;

            foreach (int v in list)
            {
                tail.next = new Node(v);
                tail = tail.next;
            }

            return dummy.next;
        }

        public static Node MergeKLists3(Node[] head)
        {
            Node nd = new Node(0);
            Node dummy = nd;

            Node NewTemp = new Node(0);
            Node d = NewTemp;

            foreach (var item in head)
            {
                Node i = item;
                while (i != null)
                {
                    d.next = new Node(i.value);
                    i = i.next;
                    d = d.next;
                }
            }

            NewTemp = NewTemp.next;
            while (NewTemp != null)
            {
                Node i = NewTemp.next;

                while (i != null)
                {
                    if (i.value < NewTemp.value)
                    {
                        int tV = NewTemp.value;
                        NewTemp.value = i.value;
                        i.value = tV;
                    }

                    i = i.next;
                }
                dummy.next = NewTemp;
                NewTemp = NewTemp.next;
                dummy = dummy.next;
            }

            return nd.next;
        }

        public static Node SwapPairs(Node head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            Node newHead = head.next;
            Node prev = null;

            while (head != null && head.next != null)
            {
                Node first = head;
                Node second = head.next;

                first.next = second.next;
                second.next = first;

                if (prev != null)
                {
                    prev.next = second;
                }

                prev = first;
                head = first.next;
            }

            return newHead;
        }

        public static Node SwapPairs2(Node head)
        {
            if (head != null && head.next != null)
            {
                int fi = head.value;
                head.value = head.next.value;
                head.next.value = fi;
                SwapPairs2(head.next.next);
            }
            return head;
        }

        public static Node SwapPairs3(Node head)
        {
            Node newHead = new Node(0);
            Node ntemp = newHead;

            while(head != null && head.next != null)
            {
                Node first = head;
                Node second = head.next;

                first.next = second.next;
                second.next = first;

                ntemp.next = second;

                ntemp = first;

                head = first.next;
            }
            if (head != null)
                ntemp.next = head;

            return newHead.next;
        }


        public static Node ReverseKGroup(Node head, int k)
        {
            if (head == null)
                return null;

            Node tail = head;

            for (int i = 0; i < k; i++)
            {
                if (tail == null)
                    return head;
                tail = tail.next;
            }

            Node newHead = Reverse(head, tail);
            head.next = ReverseKGroup(tail, k);
            return newHead;
        }

        private static Node Reverse(Node head, Node tail)
        {
            Node prev = null;
            Node curr = head;

            while (curr != tail)
            {
                Node next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

    }
}
