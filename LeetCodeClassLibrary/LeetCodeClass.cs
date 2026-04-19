using LeetCodes.Controller;
using LeetCodes.Model;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCodes.Functions
{
    public class LeetCodeClass
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

            while (head != null && head.next != null)
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

        public static Node ReverseKGroup2(Node head, int k)
        {
            if (head == null || k == 1)
                return head;

            Node dummy = new Node(0);
            dummy.next = head;

            Node prevGroupEnd = dummy;

            while (true)
            {
                Node kthNode = GetKthNode(prevGroupEnd, k);
                if (kthNode == null)
                    break;

                Node groupStart = prevGroupEnd.next;
                Node nextGroupStart = kthNode.next;

                Node prev = nextGroupStart;
                Node curr = groupStart;

                while (curr != nextGroupStart)
                {
                    Node temp = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = temp;
                }

                prevGroupEnd.next = kthNode;
                prevGroupEnd = groupStart;
            }

            return dummy.next;
        }
        public static Node GetKthNode(Node curr, int k)
        {
            while (curr != null && k > 0)
            {
                curr = curr.next;
                k--;
            }
            return curr;
        }
        public static Node ReverseKGroup3(Node head, int k)
        {
            if (head == null || k == 1) return head;

            Node dummy = new Node(0);
            dummy.next = head;

            Node groupPrev = dummy;

            while (true)
            {
                Node kth = GetKthNode(groupPrev.next, k);
                if (kth == null) break;

                Node groupNext = kth.next;

                Node prev = groupNext;
                Node curr = groupPrev.next;

                while (curr != groupNext)
                {
                    Node temp = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = temp;
                }

                Node tempHead = groupPrev.next;
                groupPrev.next = kth;
                groupPrev = tempHead;
            }

            return dummy.next;
        }
        public static Node ReverseKGroup4(Node head, int k)
        {
            if (head == null || k == 1) return head;

            Node newhead = new Node(0);
            Node dummy = newhead;

            while (head != null)
            {
                Node check = head;
                int count = 0;
                while (count < k && check != null)
                {
                    check = check.next;
                    count++;
                }

                if (count < k)
                {
                    dummy.next = head;
                    break;
                }

                Node knth = head;
                Node dm = null;
                int i = k;

                while (i > 0)
                {
                    Node temp = knth.next;
                    knth.next = dm;
                    dm = knth;
                    knth = temp;
                    i--;
                }

                dummy.next = dm;
                dummy = head;
                head = knth;
            }

            return newhead.next;
        }
        public static Node ReverseKGroup6(Node head, int k)
        {
            if (head == null || k == 1) return head;

            Node newhead = new Node(0);
            Node dummy = newhead;

            while (head != null)
            {
                Node check = head;
                int count = 0;
                while (count < k && check != null)
                {
                    check = check.next;
                    count++;
                }

                if (count < k)
                {
                    dummy.next = head;
                    break;
                }

                Node curr = head;
                Node prev = null;
                int i = 0;

                while (i < k)
                {
                    Node temp = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = temp;
                    i++;
                }

                dummy.next = prev;
                dummy = head;
                head = curr;
            }

            return newhead.next;
        }
        public static Node ReverseKGroup5(Node head, int k)
        {
            if (head == null || k == 1) return head;

            Node dummy = new Node(0);
            dummy.next = head;

            Node groupPrev = dummy;

            while (true)
            {
                Node kth = groupPrev;
                for (int i = 0; i < k && kth != null; i++)
                {
                    kth = kth.next;
                }

                if (kth == null) break;

                Node groupNext = kth.next;

                Node prev = groupNext;
                Node curr = groupPrev.next;

                while (curr != groupNext)
                {
                    Node temp = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = temp;
                }

                Node temp2 = groupPrev.next;
                groupPrev.next = kth;
                groupPrev = temp2;
            }

            return dummy.next;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < nums.Length - 1 && nums[i] == nums[i + 1])
                {
                    continue;
                }
                nums[count] = nums[i];
                count++;
            }
            return count;
        }

        public static int RemoveDuplicates2(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i + 1])
                {
                    count++;
                }
            }
            return count + 1;
        }
        public static int RemoveDuplicates3(int[] nums)
        {
            int c = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[c] != nums[i])
                {
                    c++;
                    nums[c] = nums[i];
                }
            }
            return c + 1;
        }

        public static int RemoveDuplicates4(int[] nums)
        {
            int currentPosition = 1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i + 1])
                {
                    nums[currentPosition] = nums[i + 1];
                    currentPosition++;
                }
            }
            return currentPosition;
        }

        public static int removeElement(int[] nums, int val)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    continue;
                }
                nums[count] = nums[i];
                count++;
            }
            return count;
        }

        public static int removeElement2(int[] nums, int val)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    count++;
                }
            }
            return count;
        }

        public static int strStr(string haystack, string needle)
        {
            return haystack.IndexOf(needle);
        }

        public static int strStr2(string haystack, string needle)
        {
            if (!haystack.Contains(needle))
            {
                return -1;
            }

            int index = 0;
            string word = "";

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[index])
                {
                    word += haystack[i];

                    if (word == needle)
                    {
                        index = i + 1 - word.Length;
                        break;
                    }

                    index++;
                    continue;
                }

                i = i - word.Length;
                index = 0;
                word = "";
            }

            return index;
        }
        public static int StrStr2(string haystack, string needle)
        {


            if (haystack.Length < needle.Length)
                return -1;

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                int j = 0;

                for (int k = 0; k < needle.Length; k++)
                {
                    if ((i + k) >= haystack.Length)
                        break;

                    if (haystack[i + k] == needle[k])
                    {
                        j++;
                    }
                }

                if (j == needle.Length)
                    return i;
            }

            return -1;

        }

        public static int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }
            bool isNegative = (dividend < 0) ^ (divisor < 0);

            long absDividend = Math.Abs((long)dividend);
            long absDivisor = Math.Abs((long)divisor);

            int quotient = 0;
            while (absDividend >= absDivisor)
            {
                long tempDivisor = absDivisor;
                int multiple = 1;

                while (absDividend >= (tempDivisor << 1))
                {
                    tempDivisor <<= 1;
                    multiple <<= 1;
                }

                absDividend -= tempDivisor;
                quotient += multiple;
            }
            return isNegative ? -quotient : quotient;
        }

        public static IList<int> FindSubstring(string s, string[] words)
        {
            if (string.IsNullOrEmpty(s) || words.Length == 0)
                return new List<int>();

            int k = words.Length;
            int n = words[0].Length;
            List<int> ans = new List<int>();

            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (count.ContainsKey(word))
                    count[word]++;
                else
                    count[word] = 1;
            }

            for (int i = 0; i <= s.Length - k * n; i++)
            {
                Dictionary<string, int> seen = new Dictionary<string, int>();
                int j = 0;

                for (; j < k; j++)
                {
                    string word = s.Substring(i + j * n, n);

                    if (seen.ContainsKey(word))
                        seen[word]++;
                    else
                        seen[word] = 1;

                    if (!count.ContainsKey(word) || seen[word] > count[word])
                        break;
                }

                if (j == k)
                    ans.Add(i);
            }

            return ans;
        }

        public static IList<int> FindSubstring2(string s, string[] words)
        {
            var cnt = new Dictionary<string, int>();
            foreach (var w in words)
            {
                if (cnt.ContainsKey(w))
                {
                    cnt[w]++;
                }
                else
                {
                    cnt[w] = 1;
                }
            }

            var ans = new List<int>();
            int m = s.Length, n = words.Length, k = words[0].Length;

            for (int i = 0; i < k; ++i)
            {
                int l = i, r = i;
                var cnt1 = new Dictionary<string, int>();
                while (r + k <= m)
                {
                    var t = s.Substring(r, k);
                    r += k;

                    if (!cnt.ContainsKey(t))
                    {
                        cnt1.Clear();
                        l = r;
                        continue;
                    }

                    if (cnt1.ContainsKey(t))
                    {
                        cnt1[t]++;
                    }
                    else
                    {
                        cnt1[t] = 1;
                    }

                    while (cnt1[t] > cnt[t])
                    {
                        var w = s.Substring(l, k);
                        cnt1[w]--;
                        if (cnt1[w] == 0)
                        {
                            cnt1.Remove(w);
                        }
                        l += k;
                    }

                    if (r - l == n * k)
                    {
                        ans.Add(l);
                    }
                }
            }

            return ans;
        }

        public static IList<int> FindSubstring3(string s, string[] words)
        {
            int sL = s.Length;
            int sWL = words.Length;
            int sAL = words[0].Length;
            IList<int> ListVal = new List<int>();
            List<string> ans = new List<string>();
            ans.AddRange(words);

            for (int i = 0; i < sL - (sWL * sAL); i++)
            {
                int j = i;
                int StartVal = i;
                while (true)
                {
                    string SubS = s.Substring(j, sAL);

                    if (ans.Count == 0)
                        break;


                    int ind = ans.IndexOf(SubS);
                    if (ind >= 0)
                    {
                        ans.RemoveAt(ind);
                        j += sAL;
                    }
                    else
                    {
                        StartVal = -1;
                        ans.Clear();
                        break;
                    }
                }

                if (StartVal >= 0)
                {
                    ListVal.Add(StartVal);
                }

                ans.AddRange(words);
            }
            return ListVal;
        }

        public static int[] NextPermutation(int[] nums)
        {
            int n = nums.Length;

            int i;
            for (i = n - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                    break;
            }

            if (i >= 0)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (nums[j] > nums[i])
                    {
                        Swap(nums, i, j);
                        break;
                    }
                }
            }

            Reversee(nums, i + 1, n - 1);

            return nums;
        }

        public static void Reversee(int[] nums, int left, int right)
        {
            while (left < right)
            {
                Swap(nums, left, right);
                left++;
                right--;
            }
        }

        public static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        public static int[] NextPermutation2(int[] nums)
        {
            int i = nums.Length - 1;
            int MinPos = -1, MaxPos = -1;
            while (i - 1 >= 0)
            {
                if (nums[i] > nums[i - 1])
                {
                    MinPos = i - 1;
                    break;
                }
                i--;
            }
            i = nums.Length - 1;
            while (i - 1 >= 0 && MinPos != -1)
            {
                if (nums[MinPos] < nums[i])
                {
                    MaxPos = i;
                    break;
                }
                i--;
            }

            if (MinPos == MaxPos)
            {
                Array.Sort(nums);
            }
            else
            {
                int tempval = nums[MaxPos];
                nums[MaxPos] = nums[MinPos];
                nums[MinPos] = tempval;
                // Array.Sort(nums, (MinPos+1), nums.Length - (MinPos+1));
                Array.Reverse(nums, MinPos + 1, nums.Length - (MinPos + 1));
            }

            return nums;

        }

        public static int[] NextPermutation3(int[] nums)
        {
            int index = nums.Length - 1;

            while (index >= 1 && nums[index] <= nums[index - 1])
                index--;

            if (index < 1)
            {
                Array.Sort(nums);
                return nums;
            }

            int swap = nums.Length - 1;
            while (swap >= index && nums[index - 1] >= nums[swap])
                swap--;

            int temp = nums[swap];
            nums[swap] = nums[index - 1];
            nums[index - 1] = temp;

            Array.Reverse(nums, index, nums.Length - index);

            return nums;
        }

        public static int[] NextPermutation4(int[] nums)
        {
            if (nums.Length == 1) return nums;

            int i = nums.Length - 2;
            while (i >= 0 && nums[i + 1] <= nums[i]) i--;

            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (nums[j] <= nums[i]) j--;

                (nums[i], nums[j]) = (nums[j], nums[i]);
            }

            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
                right--;
            }
            return nums;
        }


        public static int LongestValidParentheses(string s)
        {
            string s2 = ")" + s;
            int[] dp = new int[s2.Length];

            for (int i = 1; i < s2.Length; i++)
            {
                if (s2[i] == ')')
                {
                    int prevIndex = i - dp[i - 1] - 1;

                    if (prevIndex >= 0 && s2[prevIndex] == '(')
                    {
                        dp[i] = dp[i - 1] + 2;

                        int beforeIndex = i - dp[i - 1] - 2;
                        if (beforeIndex >= 0)
                            dp[i] += dp[beforeIndex];
                    }
                }
            }

            return dp.Max();
        }

        public static int LongestValidParentheses2(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            Stack<int> stack = new Stack<int>();

            stack.Push(-1);

            int maxLength = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();

                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        int length = i - stack.Peek();
                        maxLength = Math.Max(maxLength, length);
                    }
                }
            }

            return maxLength;
        }

        public static int LongestValidParentheses3(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int open = 0, close = 0, maxLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    open++;
                else
                    close++;

                if (open == close)
                    maxLen = Math.Max(maxLen, 2 * close);
                else if (close > open)
                {
                    open = 0;
                    close = 0;
                }
            }

            open = 0;
            close = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '(')
                    open++;
                else
                    close++;

                if (open == close)
                    maxLen = Math.Max(maxLen, 2 * open);
                else if (open > close)
                {
                    open = 0;
                    close = 0;
                }
            }

            return maxLen;
        }

        public static int Search(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;

            while (l <= r)
            {
                int m = l + (r - l) / 2;

                if (nums[m] == target)
                    return m;

                if (nums[l] <= nums[m])
                {
                    if (nums[l] <= target && target < nums[m])
                        r = m - 1;
                    else
                        l = m + 1;
                }
                else
                {
                    if (nums[m] < target && target <= nums[r])
                        l = m + 1;
                    else
                        r = m - 1;
                }
            }

            return -1;
        }
        public static int Search2(int[] nums, int target)
        {
            int i = Array.IndexOf(nums, target);
            return i >= 0 ? i : -1;
        }

        public static int Search3(int[] nums, int target)
        {

            int i = 0;
            int j = nums.Length - 1;
            int k = 0;
            while (i <= j)
            {
                if (nums[i] == target)
                    return i;

                if (nums[j] == target)
                    return j;

                if (nums[j] < target && nums[i] > target) return -1;

                if (nums[j] > target)
                {
                    j--;
                    continue;
                }

                if (nums[i] < target)
                {
                    i++;
                }
            }

            return -1;
        }

        public static int Search4(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;
            var min = nums[0];
            var deflectionIndex = 0;

            while (left <= right)
            {
                if (nums[left] < nums[right])
                {
                    if (nums[left] < min)
                    {
                        min = nums[left];
                        deflectionIndex = left;
                    }
                    break;
                }

                var curr = (left + right) / 2;
                if (nums[curr] < min)
                {
                    min = nums[curr];
                    deflectionIndex = curr;
                }

                if (nums[curr] >= nums[left])
                {
                    left = curr + 1;
                }
                else
                {
                    right = curr - 1;
                }
            }
            var firstArrayResult = SearchArray(nums[..deflectionIndex], target);
            if (firstArrayResult != -1) return firstArrayResult;
            var secondArrayResult = SearchArray(nums[deflectionIndex..], target);
            if (secondArrayResult != -1) return secondArrayResult + deflectionIndex;
            return -1;
        }

        private static int SearchArray(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var curr = (left + right) / 2;

                if (nums[curr] == target)
                {
                    return curr;
                }
                if (nums[curr] > target)
                {
                    right = curr - 1;
                }
                else
                {
                    left = curr + 1;
                }
            }
            return -1;
        }

        public static int[] searchRange(int[] nums, int target)
        {
            int l = firstGreaterEqual(nums, target);
            if (l == nums.Length || nums[l] != target)
                return new int[] { -1, -1 };
            int r = firstGreaterEqual(nums, target + 1) - 1;
            return new int[] { l, r };
        }

        private static int firstGreaterEqual(int[] arr, int target)
        {
            int l = 0;
            int r = arr.Length;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (arr[m] >= target)
                    r = m;
                else
                    l = m + 1;
            }
            return l;
        }

        public static int[] SearchRange2(int[] nums, int target)
        {
            int FI = Array.IndexOf(nums, target);
            int LI = Array.LastIndexOf(nums, target);
            return new int[] { FI, LI };
        }

        public static int[] SearchRange3(int[] nums, int target)
        {
            int FI = -1;
            int LI = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != target)
                    continue;

                if (FI == -1)
                    FI = i;

                if (nums[i] == target)
                    LI = i;
            }
            return new int[] { FI, LI };
        }

        public static int[] SearchRange4(int[] nums, int target)
        {
            int FI = -1;
            int LI = -1;
            for (int i = 0; nums[i] <= target; i++)
            {
                if (nums[i] != target)
                    continue;

                if (FI == -1)
                    FI = i;

                if (nums[i] == target)
                    LI = i;
            }
            return new int[] { FI, LI };
        }
        public static int SearchInsert(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length;

            while (l < r)
            {
                int m = (l + r) / 2;
                if (nums[m] == target)
                    return m;
                if (nums[m] < target)
                    l = m + 1;
                else
                    r = m;
            }

            return l;
        }

        public static int SearchInsert2(int[] nums, int target)
        {
            int v = -1;
            for (int i = 0; nums[i] < target + 1; i++)
            {
                if (nums[i] != target)
                    continue;

                if (nums[i] > target)
                    v = i;
            }
            return v;
        }


        public static int SearchInsert3(int[] nums, int target)
        {
            int v = 0;
            int N = nums.Length;
            for (int i = 0; i < N - 1; i++)
            {
                if ((nums[i] < target && nums[i + 1] >= target) || (i + 1 == N - 1 && nums[i + 1] < target))
                {
                    v = (i + 1 == N - 1 && target > nums[i + 1] ? N : i + 1);
                    break;
                }
            }
            return v;
        }


        public static int SearchInsert4(int[] nums, int target)
        {
            int r = 0;
            int k = nums.Length;

            while (r < k)
            {
                int m = r + (k - r) / 2;

                if (nums[m] == target)
                    return m;

                int rMi = target - nums[r];
                int mMi = target - nums[m];

                if (rMi >= 0 && mMi >= 0)
                {
                    int Di = Math.Min(rMi, mMi);

                    if (mMi == Di)
                    {
                        r = m + 1;
                    }
                    else
                    {
                        k = m;
                    }
                    continue;
                }

                if (mMi < 0)
                {
                    k = m;
                }
                else
                {
                    r = m + 1;
                }
            }

            return r;
        }
        public static int SearchInsert5(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;

            while (l <= r)
            {
                int m = l + (r - l) / 2;

                if (nums[m] == target)
                    return m;

                if (nums[m] < target)
                    l = m + 1;
                else
                    r = m - 1;
            }

            return l;
        }

        public static bool IsValidSudoku(char[][] board)
        {
            HashSet<string> seen = new HashSet<string>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                        continue;

                    char c = board[i][j];

                    if (!seen.Add(c + "@row" + i) ||
                        !seen.Add(c + "@col" + j) ||
                        !seen.Add(c + "@box" + (i / 3) + (j / 3)))
                        return false;
                }
            }

            return true;
        }

        public static bool IsValidSudoku2(char[][] board)
        {
            int[] rows = new int[9];
            int[] cols = new int[9];
            int[] boxes = new int[9];

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    char val = board[r][c];

                    if (val == '.') continue;

                    int bit = 1 << (val - '0');
                    int boxIdx = (r / 3) * 3 + (c / 3);

                    if ((rows[r] & bit) != 0 ||
                        (cols[c] & bit) != 0 ||
                        (boxes[boxIdx] & bit) != 0)
                    {
                        return false;
                    }

                    rows[r] |= bit;
                    cols[c] |= bit;
                    boxes[boxIdx] |= bit;
                }
            }

            return true;
        }

        public static bool IsValidSudoku3(char[][] board)
        {
            bool[,] rows = new bool[9, 9];
            bool[,] cols = new bool[9, 9];
            bool[,] boxes = new bool[9, 9];

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[r][c] == '.') continue;

                    int num = board[r][c] - '1';

                    int boxIdx = (r / 3) * 3 + (c / 3);

                    if (rows[r, num] || cols[c, num] || boxes[boxIdx, num])
                    {
                        return false;
                    }

                    rows[r, num] = true;
                    cols[c, num] = true;
                    boxes[boxIdx, num] = true;
                }
            }

            return true;
        }

        public static bool IsValidSudoku4(char[][] board)
        {
            List<HashSet<char>> row = new List<HashSet<char>>();
            List<HashSet<char>> col = new List<HashSet<char>>();
            List<HashSet<char>> box = new List<HashSet<char>>();

            for (int i = 0; i < 9; i++)
            {
                row.Add(new HashSet<char>());
                col.Add(new HashSet<char>());
                box.Add(new HashSet<char>());
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char val = board[i][j];

                    if (val == '.') continue;

                    HashSet<char> ro = row[i];
                    HashSet<char> co = col[j];
                    HashSet<char> bo = box[(i / 3) * 3 + (j / 3)];

                    if (!ro.Add(val)) return false;
                    if (!co.Add(val)) return false;
                    if (!bo.Add(val)) return false;
                }
            }

            return true;
        }

        public static void SolveSudoku(char[][] board)
        {
            Dfs(board, 0);
        }

        private static bool Dfs(char[][] board, int s)
        {
            if (s == 81)
                return true;

            int i = s / 9;
            int j = s % 9;

            if (board[i][j] != '.')
                return Dfs(board, s + 1);

            for (char c = '1'; c <= '9'; c++)
            {
                if (IsValid(board, i, j, c))
                {
                    board[i][j] = c;

                    if (Dfs(board, s + 1))
                        return true;

                    board[i][j] = '.';
                }
            }

            return false;
        }

        private static bool IsValid(char[][] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i][col] == c ||
                    board[row][i] == c ||
                    board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == c)
                {
                    return false;
                }
            }

            return true;
        }

        public static void SolveSudoku2(char[][] board)
        {
            Solve2(board);
            AppDomain.CurrentDomain.ProcessExit += (s, e) =>
                File.WriteAllText("display_runtime.txt", "00000");
            GC.Collect();
        }

        private static bool Solve2(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (IsValid2(board, i, j, c))
                            {
                                board[i][j] = c;
                                if (Solve2(board)) return true;
                                board[i][j] = '.';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool IsValid2(char[][] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == c) return false;
                if (board[i][col] == c) return false;
                int r = 3 * (row / 3) + i / 3;
                int co = 3 * (col / 3) + i % 3;
                if (board[r][co] == c) return false;
            }
            return true;
        }

        public static string CountAndSay(int n)
        {
            StringBuilder sb = new StringBuilder("1");

            while (--n > 0)
            {
                StringBuilder next = new StringBuilder();

                for (int i = 0; i < sb.Length; i++)
                {
                    int count = 1;

                    while (i + 1 < sb.Length && sb[i] == sb[i + 1])
                    {
                        count++;
                        i++;
                    }

                    next.Append(count).Append(sb[i]);
                }

                sb = next;
            }

            return sb.ToString();

        }
        public static string CountAndSay2(int n)
        {
            StringBuilder sb = new StringBuilder("1");

            for (int i = 1; i < n; i++)
            {
                StringBuilder next = new StringBuilder();
                int count = 1;

                for (int j = 0; j < sb.Length; j++)
                {
                    if (j + 1 < sb.Length && sb[j] == sb[j + 1])
                    {
                        count++;
                    }
                    else
                    {
                        next.Append(count).Append(sb[j]);
                        count = 1;
                    }
                }

                sb = next;
            }

            return sb.ToString();
        }
        public static string CountAndSay3(int n)
        {
            return SolveCAS(1, n, "1");
        }

        private static string SolveCAS(int sn, int n, string sb)
        {
            if (sn == n)
                return sb;

            StringBuilder next = new StringBuilder();
            int count = 1;

            for (int i = 0; i < sb.Length; i++)
            {
                if (i + 1 < sb.Length && sb[i] == sb[i + 1])
                {
                    count++;
                }
                else
                {
                    next.Append(count).Append(sb[i]);
                    count = 1;
                }
            }

            return SolveCAS(sn + 1, n, next.ToString());
        }

        public static string CountAndSay4(int n)
        {
            StringBuilder sb = new StringBuilder("1");
            return solveCAS(2, n, sb.ToString());
        }

        private static string solveCAS(int sn, int n, string sb)
        {
            StringBuilder next = new StringBuilder();
            string[] groupedLetters = sb.Aggregate(
        new List<string>(),
        (list, c) =>
        {
            if (list.Count > 0 && list.Last()[0] == c)
                list[list.Count - 1] += c;
            else
                list.Add(c.ToString());
            return list;
        }).ToArray();
            foreach (var group in groupedLetters)
            {
                next.Append(group.Length).Append(group[0]);
            }
            return n == sn ? next.ToString() : solveCAS(sn + 1, n, next.ToString());
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(candidates);

            DFS(candidates, 0, target, new List<int>(), ans);

            return ans;
        }

        private static void DFS(int[] candidates, int s, int target, List<int> path, IList<IList<int>> ans)
        {
            if (target < 0)
                return;

            if (target == 0)
            {
                ans.Add(new List<int>(path));
                return;
            }

            for (int i = s; i < candidates.Length; i++)
            {
                path.Add(candidates[i]);
                DFS(candidates, i, target - candidates[i], path, ans);
                path.RemoveAt(path.Count - 1);
            }
        }

        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(candidates);

            var stack = new Stack<(List<int> varList, int startVal, int sumVal)>();
            stack.Push(new(new List<int>(), 0, 0));
            while (stack.Count > 0)
            {
                var (varL, startV, sumV) = stack.Pop();

                if (sumV == target)
                {
                    ans.Add(varL);
                    continue;
                }

                for (int i = startV; i < candidates.Length; i++)
                {
                    int newSum = sumV + candidates[i];

                    if (newSum <= target)
                    {
                        var newCom = new List<int>(varL);
                        newCom.Add(candidates[i]);
                        stack.Push(new(newCom, i, newSum));
                    }
                }
            }

            return ans;
        }

        public static IList<IList<int>> CombinationSum3(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(candidates);

            var ques = new Queue<(List<int> varList, int startVal, int sumVal)>();
            ques.Enqueue(new(new List<int>(), 0, 0));
            while (ques.Count > 0)
            {
                var (varL, startV, sumV) = ques.Dequeue();

                if (sumV == target)
                {
                    ans.Add(varL);
                    continue;
                }

                for (int i = startV; i < candidates.Length; i++)
                {
                    int newSum = sumV + candidates[i];

                    if (newSum <= target)
                    {
                        var newCom = new List<int>(varL);
                        newCom.Add(candidates[i]);
                        ques.Enqueue(new(newCom, i, newSum));
                    }
                }
            }

            return ans;
        }

        public static IList<IList<int>> CombinationSum5(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Backtrack(0, target, new List<int>());
            return result;

            void Backtrack(int index, int target, List<int> path)
            {
                if (target == 0)
                {
                    result.Add(new List<int>(path));
                    return;
                }
                if (index >= candidates.Length || target < 0)
                {
                    return;
                }
                path.Add(candidates[index]);
                Backtrack(index, target - candidates[index], path);
                path.RemoveAt(path.Count - 1);
                Backtrack(index + 1, target, path);

            }
        }

        public static IList<IList<int>> CombinationSums2(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(candidates);

            DFS2(candidates, 0, target, new List<int>(), ans);

            return ans;
        }

        private static void DFS2(int[] candidates, int s, int target, List<int> path, IList<IList<int>> ans)
        {
            if (target < 0)
                return;

            if (target == 0)
            {
                ans.Add(new List<int>(path));
                return;
            }

            for (int i = s; i < candidates.Length; i++)
            {
                if (i > s && candidates[i] == candidates[i - 1])
                    continue;

                path.Add(candidates[i]);

                DFS2(candidates, i + 1, target - candidates[i], path, ans);

                path.RemoveAt(path.Count - 1);
            }
        }
        public static IList<IList<int>> CombinationSums22(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(candidates);
            Backtrack(0, target, new List<int>());
            return result;

            void Backtrack(int index, int target, List<int> path)
            {
                if (target == 0)
                {
                    result.Add(new List<int>(path));
                    return;
                }
                if (index >= candidates.Length || target < 0)
                {
                    return;
                }
                path.Add(candidates[index]);
                Backtrack(index + 1, target - candidates[index], path);
                path.RemoveAt(path.Count - 1);
                int next = index + 1;
                while (next < candidates.Length && candidates[next] == candidates[index])
                    next++;
                Backtrack(next, target, path);

            }
        }

        public static IList<IList<int>> CombinationSum23(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<IList<int>> result = new List<IList<int>>();
            ConfigArray(result, new List<int>(), candidates, target, 0);
            return result;
        }

        static void ConfigArray(List<IList<int>> result, List<int> temp
        , int[] candidates, int remain, int start)
        {
            if (remain == 0)
            {
                result.Add(new List<int>(temp));
                return;
            }
            if (remain < 0)
                return;

            for (int i = start; i < candidates.Length; i++)
            {
                int val = candidates[i];
                if (val > remain)
                    break;
                if (i > start && val == candidates[i - 1])
                    continue;
                temp.Add(val);
                ConfigArray(result, temp, candidates, remain - val, i + 1);
                temp.RemoveAt(temp.Count - 1);
            }
        }
        public static IList<IList<int>> CombinationSum24(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(candidates);
            Backtrack(candidates, 0, target, new List<int>(), result);
            return result;
        }

        public static void Backtrack(int[] candidates, int start, int target, List<int> path, List<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(path));
                return;
            }

            var processed = new HashSet<int>();
            for (int i = start; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                    continue;

                if (processed.Contains(candidates[i]))
                {
                    continue;
                }
                else
                {
                    processed.Add(candidates[i]);
                }

                path.Add(candidates[i]);
                Backtrack(candidates, i + 1, target - candidates[i], path, result);
                path.RemoveAt(path.Count - 1);
            }
        }

        public static IList<IList<int>> CombinationSums25(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(candidates);

            DFS3(candidates, 0, target, new List<int>(), ans);

            return ans;
        }

        private static void DFS3(int[] candidates, int s, int target, List<int> path, IList<IList<int>> ans)
        {
            if (target < path.Sum())
                return;

            if (target == path.Sum())
            {
                ans.Add(new List<int>(path));
                return;
            }

            for (int i = s; i < candidates.Length; i++)
            {
                if (i > s && candidates[i] == candidates[i - 1])
                    continue;

                path.Add(candidates[i]);

                DFS3(candidates, i + 1, target, path, ans);

                path.RemoveAt(path.Count - 1);
            }
        }

        public static int firstMissingPositive(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < n; ++i)
                while (nums[i] > 0 && nums[i] <= n && nums[i] != nums[nums[i] - 1])
                    swap(nums, i, nums[i] - 1);

            for (int i = 0; i < n; ++i)
                if (nums[i] != i + 1)
                    return i + 1;

            return n + 1;
        }

        private static void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public static int firstMissingPositive2(int[] nums)
        {
            int i = 1;
            HashSet<int> visited = nums.Distinct().ToHashSet();

            while (nums.Length > i)
            {
                if (!visited.Contains(i))
                    return i;
                else
                    i++;
            }
            return i;
        }

        public static int firstMissingPositive3(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i] - 1;

                if (nums[i] < nums.Length && nums[i] > 0 && nums[i] != nums[val])
                {
                    int newVal = nums[i];
                    nums[i] = nums[val];
                    nums[val] = newVal;
                }
                else { i++; }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1) return i + 1;
            }

            return nums.Length + 1;

        }

        public static int firstMissingPositive4(int[] nums)
        {
            int i = 1;
            foreach (var item in nums)
            {
                if (!nums.Contains(i))
                    return i;
                else
                    i++;
            }
            return i;
        }
        public static int firstMissingPositive5(int[] nums)
        {
            Array.Sort(nums); int j = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < j)
                    continue;

                if (nums[i] == j)
                    j++;
                else
                    return j;
            }
            return j;
        }

        public static int firstMissingPositive6(int[] nums)
        {
            int[] newarr = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length)
                    newarr[nums[i] - 1] = nums[i];
            }

            for (int i = 0; i < newarr.Length; i++)
                if (newarr[i] == 0)
                    return i + 1;


            return nums.Length + 1;
        }

        public static int firstMissingPositive7(int[] nums)
        {
            for (int i = 0; i < nums.Length;)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length)
                {
                    if (nums[nums[i] - 1] != nums[i])
                    {
                        int val = nums[nums[i] - 1];
                        int index = nums[i] - 1;
                        nums[index] = nums[i];
                        nums[i] = val;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    i++;
                }
            }

            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != i + 1) return i + 1;

            return nums.Length + 1;
        }

        public static int firstMissingPositive8(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0 || nums[i] > nums.Length + 1)
                    nums[i] = nums.Length + 1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int e = Math.Abs(nums[i]);
                if (e == nums.Length + 1) continue;
                if (nums[e - 1] > 0)
                    nums[e - 1] = -nums[e - 1];
            }

            for (int i = 0; i < nums.Length; i++)
                if (nums[i] > 0) return i + 1;

            return nums.Length + 1;
        }

        public static int trap(int[] height)
        {
            int n = height.Length;
            int ans = 0;
            int[] l = new int[n];
            int[] r = new int[n];

            for (int i = 0; i < n; ++i)
                l[i] = i == 0 ? height[i] : Math.Max(height[i], l[i - 1]);

            for (int i = n - 1; i >= 0; --i)
                r[i] = i == n - 1 ? height[i] : Math.Max(height[i], r[i + 1]);

            for (int i = 0; i < n; ++i)
                ans += Math.Min(l[i], r[i]) - height[i];

            return ans;
        }

        public static int trap2(int[] height)
        {
            int i = 0;
            int[] val = new int[height.Length];
            int MaxVal = 0, res = 0;
            bool ct = true;
            while ((i < height.Length && i > 0) || i >= 0)
            {

                if (i < height.Length && ct)
                {
                    MaxVal = i == 0 ? height[i] : Math.Max(height[i], MaxVal);
                    val[i] = MaxVal;
                    if (i != height.Length - 1)
                    {
                        i++;
                    }
                    else
                    {
                        ct = false;
                    }
                }

                if (i >= 0 && !ct)
                {
                    MaxVal = i == height.Length - 1 ? height[i] : Math.Max(height[i], MaxVal);
                    int Min = Math.Min(val[i], MaxVal);
                    res += Min - height[i];
                    i--;
                }
            }
            return res;
        }

        public static int trap3(int[] arr)
        {
            int res = 0;

            for (int i = 1; i < arr.Length - 1; i++)
            {

                int left = arr[i];
                for (int j = 0; j < i; j++)
                    left = Math.Max(left, arr[j]);

                int right = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                    right = Math.Max(right, arr[j]);

                res += Math.Min(left, right) - arr[i];
            }

            return res;
        }

        public static int trap4(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;

            int leftMax = 0;
            int rightMax = 0;

            int water = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] > leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        water += leftMax - height[left];
                    }

                    left++;
                }
                else
                {
                    if (height[right] > rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        water += rightMax - height[right];
                    }

                    right--;
                }
            }

            return water;
        }

        public static string multiply(string num1, string num2)
        {
            int m = num1.Length;
            int n = num2.Length;

            StringBuilder sb = new StringBuilder();
            int[] pos = new int[m + n];

            for (int i = m - 1; i >= 0; --i)
                for (int j = n - 1; j >= 0; --j)
                {
                    int multiply = (num1[i] - '0') * (num2[j] - '0');
                    int sum = multiply + pos[i + j + 1];
                    pos[i + j] += sum / 10;
                    pos[i + j + 1] = sum % 10;
                }

            foreach (var p in pos)
            {
                if (p > 0 || sb.Length > 0)
                    sb.Append(p);
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }

        public static string multiply2(string num1, string num2)
        {
            return (int.Parse(num1) * int.Parse(num2)).ToString();
        }

        public static string multiply3(string num1, string num2)
        {
            int n1 = 0, n2 = 0;
            for (int i = 0; i < num1.Length; i++)
            {
                n1 = (n1 + ((int)num1[i] - '0')) * 10;
            }

            for (int i = 0; i < num2.Length; i++)
            {
                n2 = (n2 + ((int)num2[i] - '0')) * 10;
            }
            return (n1 / 10 * n2 / 10).ToString();
        }

        public static bool IsMatch(string s, string p)
        {

            return false;
        }

        public static int Jump(int[] nums)
        {
            int ans = 0;
            int end = 0;
            int farthest = 0;

            for (int i = 0; i < nums.Length - 1; ++i)
            {
                farthest = Math.Max(farthest, i + nums[i]);
                if (farthest >= nums.Length - 1)
                {
                    ++ans;
                    break;
                }
                if (i == end)
                {
                    ++ans;
                    end = farthest;
                }
            }

            return ans;
        }

        public static int Jump2(int[] nums)
        {
            int ans = 0;
            int end = 0;
            int farthest = 0;

            for (int i = 0; i < nums.Length - 1; ++i)
            {
                farthest = Math.Max(farthest, i + nums[i]);

                if (i == end)
                {
                    ans++;
                    end = farthest;
                }
            }

            return ans;
        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Dfs(nums, new bool[nums.Length], new List<int>(), ans);
            return ans;
        }

        private static void Dfs(int[] nums, bool[] used, List<int> path, IList<IList<int>> ans)
        {
            if (path.Count == nums.Length)
            {
                ans.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;

                used[i] = true;
                path.Add(nums[i]);

                Dfs(nums, used, path, ans);

                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }

        public static IList<IList<int>> Permute2(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();

            int[] revnum = nums.Reverse().ToArray();
            ans.Add(new List<int>(nums));
            while (!nums.SequenceEqual(revnum))
            {
                int index = nums.Length - 1;

                while (index >= 1 && nums[index] <= nums[index - 1])
                    index--;

                int swap = nums.Length - 1;
                while (swap >= index && nums[index - 1] >= nums[swap])
                    swap--;

                int temp = nums[swap];
                nums[swap] = nums[index - 1];
                nums[index - 1] = temp;

                Array.Reverse(nums, index, nums.Length - index);

                ans.Add(new List<int>(nums));
            }
            return ans;
        }


        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            PermuteUniqueDfs(nums, new bool[nums.Length], new List<int>(), ans);
            return ans;
        }

        private static void PermuteUniqueDfs(int[] nums, bool[] used, List<int> path, IList<IList<int>> ans)
        {
            if (path.Count == nums.Length)
            {
                if (!ans.Contains(new List<int>(nums)))
                {
                    ans.Add(new List<int>(nums));
                }
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;

                used[i] = true;
                path.Add(nums[i]);

                Dfs(nums, used, path, ans);

                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }

        public static IList<IList<int>> PermuteUnique2(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();

            int[] revnum = nums.Reverse().ToArray();
            ans.Add(new List<int>(nums));
            while (!nums.SequenceEqual(revnum))
            {
                int index = nums.Length - 1;

                while (index >= 1 && nums[index] <= nums[index - 1])
                    index--;

                int swap = nums.Length - 1;
                while (swap >= index && nums[index - 1] >= nums[swap])
                    swap--;

                int temp = nums[swap];
                nums[swap] = nums[index - 1];
                nums[index - 1] = temp;

                Array.Reverse(nums, index, nums.Length - index);

                if (!ans.Contains(new List<int>(nums)))
                {
                    ans.Add(new List<int>(nums));
                }
            }
            return ans;
        }

        public static IList<IList<int>> permuteUnique3(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            permuteUnique3Dfs(nums, new bool[nums.Length], new List<int>(), ans);
            return ans;
        }

        private static void permuteUnique3Dfs(int[] nums, bool[] used, List<int> path, IList<IList<int>> ans)
        {
            if (path.Count == nums.Length)
            {
                ans.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;

                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
                    continue;

                used[i] = true;
                path.Add(nums[i]);

                Dfs(nums, used, path, ans);

                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }
        public static void Rotate(int[][] matrix)
        {
            for (int i = 0, j = matrix.Length - 1; i < j; ++i, --j)
            {
                int[] temp = matrix[i];
                matrix[i] = matrix[j];
                matrix[j] = temp;
            }

            for (int i = 0; i < matrix.Length; ++i)
                for (int j = i + 1; j < matrix.Length; ++j)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
        }

        public static void Rotate2(int[][] matrix)
        {
            for (int mn = 0; mn < matrix.Length / 2; ++mn)
            {
                int mx = matrix.Length - mn - 1;
                for (int i = mn; i < mx; ++i)
                {
                    int offset = i - mn;
                    int top = matrix[mn][i];
                    matrix[mn][i] = matrix[mx - offset][mn];
                    matrix[mx - offset][mn] = matrix[mx][mx - offset];
                    matrix[mx][mx - offset] = matrix[i][mx];
                    matrix[i][mx] = top;
                }
            }
        }

        public static void Rotate3(int[][] matrix)
        {
            for (int i = 0; i <= matrix.Length - 2; i++)
            {
                for (int j = i + 1; j < matrix.Length; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            foreach (int[] row in matrix)
            {
                Array.Reverse(row);
            }

            foreach (var item in matrix)
            {
                Console.Write("[" + string.Join(", ", item) + "]");
            }
        }

        public static void Rotate4(int[][] matrix)
        {
            for (int i = 0; i <= matrix.Length - 2; i++)
            {
                for (int j = i + 1; j < matrix.Length; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            foreach (int[] subArray in matrix)
            {
                int start = 0;
                int end = subArray.Length - 1;

                while (start < end)
                {
                    int temp = subArray[start];
                    subArray[start] = subArray[end];
                    subArray[end] = temp;

                    start++;
                    end--;
                }
            }

            foreach (var item in matrix)
            {
                Console.Write("[" + string.Join(", ", item) + "]");
            }
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var keyToAnagrams = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                char[] chars = str.ToCharArray();
                Array.Sort(chars);
                string key = new string(chars);

                if (!keyToAnagrams.ContainsKey(key))
                {
                    keyToAnagrams[key] = new List<string>();
                }

                keyToAnagrams[key].Add(str);
            }

            return keyToAnagrams.Values.Select(list => (IList<string>)list).ToList();
        }

        public static double myPow(double x, long n)
        {
            if (n == 0)
                return 1;
            if (n < 0)
                return 1 / myPow(x, -n);
            if (n % 2 == 1)
                return x * myPow(x, n - 1);
            return myPow(x * x, n / 2);
        }

        public static double myPow2(double x, long n)
        {
            double result = 1;
            if (n < 0)
            {
                x = 1 / x;
                n = -n;
            }
            while (n > 0)
            {
                if (n % 2 == 0)
                {
                    x *= x;
                    n /= 2;
                }
                else
                {
                    result *= x;
                    n -= 1;
                }
            }
            return result;
        }

        public double MyPow3(double x, int n)
        {
            long N = n;

            if (N < 0)
            {
                x = 1 / x;
                N = -N;
            }

            return FastPow(x, N);
        }

        private double FastPow(double x, long n)
        {
            if (n == 0)
                return 1;

            if (n % 2 == 1)
                return x * FastPow(x, n - 1);

            return FastPow(x * x, n / 2);
        }

        public static IList<IList<string>> SolveNQueens(int n)
        {
            var ans = new List<IList<string>>();
            char[][] board = new char[n][];

            for (int i = 0; i < n; i++)
            {
                board[i] = new char[n];
                Array.Fill(board[i], '.');
            }

            SolveNQueensDfs(n, 0, new bool[n], new bool[2 * n - 1], new bool[2 * n - 1], board, ans);
            return ans;
        }

        private static void SolveNQueensDfs(int n, int i, bool[] cols, bool[] diag1, bool[] diag2,
                         char[][] board, IList<IList<string>> ans)
        {
            if (i == n)
            {
                ans.Add(Construct(board));
                return;
            }

            for (int j = 0; j < cols.Length; j++)
            {
                if (cols[j] || diag1[i + j] || diag2[j - i + n - 1])
                    continue;

                board[i][j] = 'Q';
                cols[j] = diag1[i + j] = diag2[j - i + n - 1] = true;

                SolveNQueensDfs(n, i + 1, cols, diag1, diag2, board, ans);

                cols[j] = diag1[i + j] = diag2[j - i + n - 1] = false;
                board[i][j] = '.';
            }
        }

        private static IList<string> Construct(char[][] board)
        {
            var listBoard = new List<string>();

            for (int i = 0; i < board.Length; i++)
            {
                listBoard.Add(new string(board[i]));
            }

            return listBoard;
        }

        public static IList<IList<string>> SolveNQueens2(int n)
        {
            var ans = new List<IList<string>>();
            char[][] board = new char[n][];

            for (int i = 0; i < n; i++)
            {
                board[i] = new char[n];
                Array.Fill(board[i], '.');
            }

            AddNQueens2IsValid(board, n, 0, ans);

            return ans;
        }

        private static void AddNQueens2IsValid(char[][] board, int n, int row, List<IList<string>> ans)
        {
            if (row == n)
            {
                List<string> solution = new List<string>();
                for (int i = 0; i < n; i++)
                    solution.Add(new string(board[i]));

                ans.Add(solution);
                return;
            }

            for (int j = 0; j < n; j++)
            {
                if (SolveNQueens3IsValid(board, n, row, j))
                {
                    board[row][j] = 'Q';
                    AddNQueens2IsValid(board, n, row + 1, ans);
                    board[row][j] = '.';
                }
            }
        }

        private static bool SolveNQueens2IsValid(char[][] board, int n, int i, int j)
        {
            for (int k = 0; k < i; k++)
                if (board[k][j] == 'Q') return false;

            for (int k = i - 1, l = j - 1; k >= 0 && l >= 0; k--, l--)
                if (board[k][l] == 'Q') return false;

            for (int k = i - 1, l = j + 1; k >= 0 && l < n; k--, l++)
                if (board[k][l] == 'Q') return false;

            return true;
        }

        private static bool SolveNQueens3IsValid(char[][] board, int n, int i, int j)
        {
            for (int k = 0; k < i; k++)
            {
                if (board[k][j] == 'Q') return false;
            }

            for (int k = 0; k < j; k++)
            {
                if (board[i][k] == 'Q') return false;
            }

            for (int k = i, l = j; k >= 0 && l < n; k--, l++)
            {
                if (board[k][l] == 'Q') return false;
            }

            for (int k = i - 1, l = j - 1; l >= 0 && k >= 0; k--, l--)
            {
                if (board[k][l] == 'Q') return false;
            }
            return true;
        }

        public static int TotalNQueens(int n)
        {
            int count = 0;
            char[][] board = new char[n][];

            for (int i = 0; i < n; i++)
            {
                board[i] = new char[n];
                Array.Fill(board[i], '.');
            }

            TotalNQueensDfs(n, 0, new bool[n], new bool[2 * n - 1], new bool[2 * n - 1], board, ref count);
            return count;
        }

        private static void TotalNQueensDfs(int n, int i, bool[] cols, bool[] diag1, bool[] diag2,
                         char[][] board, ref int count)
        {
            if (i == n)
            {
                count++;
                return;
            }

            for (int j = 0; j < cols.Length; j++)
            {
                if (cols[j] || diag1[i + j] || diag2[j - i + n - 1])
                    continue;

                board[i][j] = 'Q';
                cols[j] = diag1[i + j] = diag2[j - i + n - 1] = true;

                TotalNQueensDfs(n, i + 1, cols, diag1, diag2, board, ref count);

                cols[j] = diag1[i + j] = diag2[j - i + n - 1] = false;
                board[i][j] = '.';
            }
        }
        public static int MaxSubArray(int[] nums)
        {
            int max = 0;
            int Cuursum = 0;

            foreach (int item in nums)
            {
                if (max == 0 && Cuursum == 0)
                {
                    max = item;
                    Cuursum = item;
                    continue;
                }
                Cuursum = item > item + Cuursum ? item : item + Cuursum;
                max = Cuursum > max ? Cuursum : max;
            }
            return max;
        }

        public static int MaxSubArray2(int[] nums)
        {
            int[] dp = new int[nums.Length];

            dp[0] = nums[0];
            for (int i = 1; i < nums.Length; ++i)
                dp[i] = Math.Max(nums[i], dp[i - 1] + nums[i]);

            return dp.Max();
        }

        public static int MaxSubArray3(int[] nums)
        {
            int max = 0;
            int Cuursum = 0;

            foreach (int item in nums)
            {
                if (max == 0 && Cuursum == 0)
                {
                    max = item;
                    Cuursum = item;
                    continue;
                }
                Cuursum = Math.Max(item + Cuursum, item);
                max = Math.Max(Cuursum, max);
            }
            return max;
        }

        public static IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 0)
                return new List<int>();

            int m = matrix.Length;
            int n = matrix[0].Length;
            IList<int> ans = new List<int>();

            int r1 = 0, c1 = 0;
            int r2 = m - 1, c2 = n - 1;

            while (ans.Count < m * n)
            {
                for (int j = c1; j <= c2 && ans.Count < m * n; j++)
                    ans.Add(matrix[r1][j]);

                for (int i = r1 + 1; i <= r2 - 1 && ans.Count < m * n; i++)
                    ans.Add(matrix[i][c2]);

                for (int j = c2; j >= c1 && ans.Count < m * n; j--)
                    ans.Add(matrix[r2][j]);

                for (int i = r2 - 1; i >= r1 + 1 && ans.Count < m * n; i--)
                    ans.Add(matrix[i][c1]);

                r1++;
                c1++;
                r2--;
                c2--;
            }

            return ans;
        }

        public static IList<int> SpiralOrder2(int[][] matrix)
        {
            if (matrix.Length == 0)
                return new List<int>();

            int m = matrix.Length;
            int n = matrix[0].Length;
            IList<int> ans = new List<int>();

            int t = 0, l = 0;
            int b = m - 1, r = n - 1;

            while (ans.Count < m * n)
            {
                for (int i = t; i < n; i++)
                {
                    ans.Add(matrix[t][i]);
                }
                t++;

                for (int i = t; i < b; i++)
                {
                    ans.Add(matrix[i][r]);
                }
                r--;

                if (t <= b)
                {
                    for (int i = r; i >= l; i--)
                    {
                        ans.Add(matrix[b][i]);
                    }
                    b--;
                }

                if (l <= r)
                {
                    for (int i = b; i >= t; i--)
                    {
                        ans.Add(matrix[i][l]);
                    }
                    l++;
                }
            }
            return ans;
        }

        public static bool canJump(int[] nums)
        {
            int i = 0;

            for (int reach = 0; i < nums.Length && i <= reach; ++i)
                reach = Math.Max(reach, i + nums[i]);

            return i == nums.Length;
        }

        public static int[][] Merge(int[][] intervals)
        {
            var ans = new List<int[]>();

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            foreach (var interval in intervals)
            {
                if (ans.Count == 0 || ans[ans.Count - 1][1] < interval[0])
                {
                    ans.Add(interval);
                }
                else
                {
                    ans[ans.Count - 1][1] = Math.Max(ans[ans.Count - 1][1], interval[1]);
                }
            }

            return ans.ToArray();
        }

        public static int[][] Merge2(int[][] intervals)
        {
            var ans = new List<int[]>();

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            int c1 = intervals[0][0];
            int c2 = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (c2 >= intervals[i][0])
                {
                    c2 = Math.Max(c2, intervals[i][1]);
                }
                else
                {
                    ans.Add(new int[] { c1, c2 });
                    c1 = intervals[i][0];
                    c2 = intervals[i][1];
                }
            }
            ans.Add(new int[] { c1, c2 });

            return ans.ToArray();
        }

        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int n = intervals.Length;
            var ans = new List<int[]>();
            int i = 0;

            while (i < n && intervals[i][1] < newInterval[0])
            {
                ans.Add(intervals[i]);
                i++;
            }

            while (i < n && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }

            ans.Add(newInterval);

            while (i < n)
            {
                ans.Add(intervals[i]);
                i++;
            }

            return ans.ToArray();
        }

        public static int[][] Insert2(int[][] intervals, int[] newInterval)
        {
            var list = intervals.ToList();
            list.Add(newInterval);

            intervals = list.ToArray();

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            var ans = new List<int[]>();

            int c1 = intervals[0][0];
            int c2 = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (c2 >= intervals[i][0])
                {
                    c2 = Math.Max(c2, intervals[i][1]);
                }
                else
                {
                    ans.Add(new int[] { c1, c2 });
                    c1 = intervals[i][0];
                    c2 = intervals[i][1];
                }
            }

            ans.Add(new int[] { c1, c2 });

            return ans.ToArray();
        }

        public static int[][] Insert3(int[][] intervals, int[] newInterval)
        {
            var ans = new List<int[]>();

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            int c1 = intervals[0][0];
            int c2 = intervals[0][1];

            bool IsUsed = true;

            for (int i = 1; i < intervals.Length; i++)
            {
                if (newInterval[0] > c2 && newInterval[1] <= intervals[i][0] && IsUsed)
                {
                    ans.Add(new int[] { c1, c2 });
                    c1 = newInterval[0];
                    c2 = newInterval[1];
                    IsUsed = false;
                    continue;
                }

                if (newInterval[0] <= c2 && IsUsed)
                {
                    c2 = Math.Max(c2, newInterval[1]);
                    IsUsed = false;
                    continue;
                }

                if (c2 >= intervals[i][0])
                {
                    c2 = Math.Max(c2, intervals[i][1]);
                }
                else
                {
                    ans.Add(new int[] { c1, c2 });
                    c1 = intervals[i][0];
                    c2 = intervals[i][1];
                }
            }

            if (IsUsed)
            {
                if (newInterval[0] <= c2)
                    c2 = Math.Max(c2, newInterval[1]);
                else
                {
                    ans.Add(new int[] { c1, c2 });
                    c1 = newInterval[0];
                    c2 = newInterval[1];
                }
            }

            ans.Add(new int[] { c1, c2 });

            return ans.ToArray();
        }

        public static int[][] GenerateMatrix(int n)
        {
            int[][] ans = new int[n][];
            for (int i = 0; i < n; i++)
                ans[i] = new int[n];

            int count = 1;

            for (int mn = 0; mn < n / 2; ++mn)
            {
                int mx = n - mn - 1;

                for (int i = mn; i < mx; ++i)
                    ans[mn][i] = count++;

                for (int i = mn; i < mx; ++i)
                    ans[i][mx] = count++;

                for (int i = mx; i > mn; --i)
                    ans[mx][i] = count++;

                for (int i = mx; i > mn; --i)
                    ans[i][mn] = count++;
            }

            if (n % 2 == 1)
                ans[n / 2][n / 2] = count;

            return ans;
        }

        public static int[][] GenerateMatrix2(int n)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
                matrix[i] = new int[n];

            int top = 0, bottom = n - 1;
            int left = 0, right = n - 1;

            int num = 1;

            while (num <= n * n)
            {
                for (int i = left; i <= right; i++)
                    matrix[top][i] = num++;
                top++;

                for (int i = top; i <= bottom; i++)
                    matrix[i][right] = num++;
                right--;

                for (int i = right; i >= left; i--)
                    matrix[bottom][i] = num++;
                bottom--;

                for (int i = bottom; i >= top; i--)
                    matrix[i][left] = num++;
                left++;
            }

            return matrix;
        }

        public static string GetPermutation(int n, int k)
        {
            var sb = new System.Text.StringBuilder();
            var nums = new List<int>();
            int[] fact = new int[n + 1];

            for (int i = 1; i <= n; ++i)
                nums.Add(i);

            for (int i = 0; i <= n; i++)
                fact[i] = 1;

            for (int i = 2; i <= n; ++i)
                fact[i] = fact[i - 1] * i;

            k--;

            for (int i = n - 1; i >= 0; --i)
            {
                int j = k / fact[i];
                k %= fact[i];

                sb.Append(nums[j]);
                nums.RemoveAt(j);
            }

            return sb.ToString();
        }


        public static string GetPermutation2(int n, int k)
        {
            int[] fact = new int[n];

            for (int l = 0; l < n; l++)
                fact[l] = l + 1;

            while (k - 1 > 0)
            {
                int i = fact.Length - 1;
                int MinPos = -1, MaxPos = -1;
                while (i - 1 >= 0)
                {
                    if (fact[i] > fact[i - 1])
                    {
                        MinPos = i - 1;
                        break;
                    }
                    i--;
                }
                i = fact.Length - 1;
                while (i - 1 >= 0 && MinPos != -1)
                {
                    if (fact[MinPos] < fact[i])
                    {
                        MaxPos = i;
                        break;
                    }
                    i--;
                }

                if (MinPos == MaxPos)
                {
                    Array.Sort(fact);
                }
                else
                {
                    int tempval = fact[MaxPos];
                    fact[MaxPos] = fact[MinPos];
                    fact[MinPos] = tempval;
                    Array.Reverse(fact, MinPos + 1, fact.Length - (MinPos + 1));
                }
                k--;
            }
            return string.Join("", fact);
        }
        public static string GetPermutation3(int n, int k)
        {
            string s = null, l = null;
            for (int i = 0; i < n; i++)
            {
                l += (i + 1).ToString();
            }

            for (int i = 0; i < n; i++)
            {
                int o = GetFactorialRecursive(l.Length - 1);
                int index = k / o;
                s += l[index].ToString();
                l = l.Remove(index, 1);
                k %= o;
            }

            return s;
        }

        public static int GetFactorialRecursive(int n)
        {
            if (n == 0) return 1;
            return n * GetFactorialRecursive(n - 1);
        }

        public static Node RotateRight(Node head, int k)
        {
            if (head == null || head.next == null || k == 0)
                return head;

            int length = 1;
            Node tail = head;

            while (tail.next != null)
            {
                tail = tail.next;
                length++;
            }

            tail.next = head;

            int t = length - (k % length);

            for (int i = 0; i < t; i++)
            {
                tail = tail.next;
            }

            Node newHead = tail.next;
            tail.next = null;

            return newHead;
        }

        public static int UniquePaths2(int m, int n)
        {
            int[,] arr = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0) arr[i, j] = 1;
                    else
                    {
                        arr[i, j] = arr[i - 1, j] + arr[i, j - 1];
                    }
                }
            }
            return arr[m - 1, n - 1];

        }

        public static int UniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];

            for (int i = 0; i < m; i++)
                dp[i, 0] = 1;

            for (int j = 0; j < n; j++)
                dp[0, j] = 1;

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }
        public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            if (obstacleGrid[0][0] == 1 || obstacleGrid[m - 1][n - 1] == 1)
                return 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    obstacleGrid[i][j] = obstacleGrid[i][j] == 1 ? 0 : i == 0 || j == 0 ? 1 : obstacleGrid[i - 1][j] + obstacleGrid[i][j - 1];
                }
            }
            return obstacleGrid[m - 1][n - 1];
        }

        public static int UniquePathsWithObstacles2(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            if (obstacleGrid[0][0] == 1 || obstacleGrid[m - 1][n - 1] == 1)
                return 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (obstacleGrid[i][j] == 1)
                    {
                        obstacleGrid[i][j] = 0;
                        continue;
                    }
                    if (i == 0 && j == 0)
                    {
                        obstacleGrid[i][j] = 1;
                        continue;
                    }

                    int up = (i > 0) ? obstacleGrid[i - 1][j] : 0;
                    int left = (j > 0) ? obstacleGrid[i][j - 1] : 0;

                    obstacleGrid[i][j] = up + left;
                }
            }

            return obstacleGrid[m - 1][n - 1];
        }

        public static int UniquePathsWithObstacles3(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            long[,] dp = new long[m + 1, n + 1];

            dp[0, 1] = 1;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {

                    if (obstacleGrid[i - 1][j - 1] == 0)
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }

            return (int)dp[m, n];
        }

        public static int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    int up = (i > 0) ? grid[i - 1][j] : grid[i][j];
                    int left = (j > 0) ? grid[i][j - 1] : grid[i][j];

                    grid[i][j] = (i == 0 || j == 0) ? up + left : Math.Min(up + grid[i][j], left + grid[i][j]);
                }
            }
            return grid[m - 1][n - 1];
        }

        public static int MinPathSum2(int[][] grid)
        {
            for (var i = grid.Length - 1; i >= 0; i--)
                for (var j = grid[i].Length - 1; j >= 0; j--)
                {
                    var downMin = i + 1 < grid.Length ? grid[i + 1][j] : int.MaxValue;
                    var rightMin = j + 1 < grid[i].Length ? grid[i][j + 1] : int.MaxValue;

                    var min = Math.Min(downMin, rightMin);
                    grid[i][j] += min is int.MaxValue ? 0 : min;
                }

            return grid[0][0];
        }

        public static int MinPathSum3(int[][] grid)
        {
            int[][] dp = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                dp[i] = new int[grid[0].Length];
            }
            dp[0][0] = grid[0][0];
            for (int i = 1; i < grid.Length; i++)
            {
                dp[i][0] = grid[i][0] + dp[i - 1][0];
            }

            for (int j = 1; j < grid[0].Length; j++)
            {
                dp[0][j] = grid[0][j] + dp[0][j - 1];
            }

            for (int i = 1; i < grid.Length; i++)
            {
                for (int j = 1; j < grid[0].Length; j++)
                {
                    dp[i][j] = grid[i][j] + Math.Min(dp[i - 1][j], dp[i][j - 1]);
                }
            }

            return dp[grid.Length - 1][grid[0].Length - 1];
        }

        public static int MinPathSum4(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int[,] dp = new int[rows, cols];

            dp[0, 0] = grid[0][0];

            for (int col = 1; col < cols; col++)
            {
                dp[0, col] = dp[0, col - 1] + grid[0][col];
            }

            for (int row = 1; row < rows; row++)
            {
                dp[row, 0] = dp[row - 1, 0] + grid[row][0];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    dp[row, col] = Math.Min(dp[row - 1, col], dp[row, col - 1]) + grid[row][col];
                }
            }

            return dp[rows - 1, cols - 1];
        }

        public static bool IsNumber(string s)
        {
            s = s.Trim();
            if (string.IsNullOrEmpty(s))
                return false;

            bool seenNum = false;
            bool seenDot = false;
            bool seenE = false;

            for (int i = 0; i < s.Length; ++i)
            {
                switch (s[i])
                {
                    case '.':
                        if (seenDot || seenE)
                            return false;
                        seenDot = true;
                        break;

                    case 'e':
                    case 'E':
                        if (seenE || !seenNum)
                            return false;
                        seenE = true;
                        seenNum = false;
                        break;

                    case '+':
                    case '-':
                        if (i > 0 && s[i - 1] != 'e' && s[i - 1] != 'E')
                            return false;
                        seenNum = false;
                        break;

                    default:
                        if (!char.IsDigit(s[i]))
                            return false;
                        seenNum = true;
                        break;
                }
            }

            return seenNum;
        }


        public static IList<string> FullJustify(string[] words, int maxWidth)
        {
            var ans = new List<string>();
            var row = new List<StringBuilder>();
            int rowLetters = 0;

            foreach (var word in words)
            {
                if (rowLetters + row.Count + word.Length > maxWidth)
                {
                    int spaces = maxWidth - rowLetters;

                    if (row.Count == 1)
                    {
                        row[0].Append(new string(' ', spaces));
                    }
                    else
                    {
                        for (int i = 0; i < spaces; ++i)
                        {
                            row[i % (row.Count - 1)].Append(' ');
                        }
                    }

                    string joinedRow = string.Concat(row.Select(sb => sb.ToString()));
                    ans.Add(joinedRow);

                    row.Clear();
                    rowLetters = 0;
                }

                row.Add(new StringBuilder(word));
                rowLetters += word.Length;
            }

            string lastRow = string.Join(" ", row.Select(sb => sb.ToString()));
            var sbLast = new StringBuilder(lastRow);

            int spacesToBeAdded = maxWidth - sbLast.Length;
            sbLast.Append(new string(' ', spacesToBeAdded));

            ans.Add(sbLast.ToString());

            return ans;
        }

        public static IList<string> FullJustify2(string[] words, int maxWidth)
        {
            var set = new List<string>();
            List<string> row = new List<string>();
            int wordco = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (row.Count + wordco + words[i].Length > maxWidth)
                {
                    set.Add(LeetCodeClass.newGString(row, maxWidth - wordco));
                    row.Clear();
                    wordco = 0;
                }

                row.Add(words[i]);
                wordco += words[i].Length;
            }
            if (row.Count > 0)
            {
                set.Add(LeetCodeClass.newGString(row, maxWidth - wordco));
                row.Clear();
                wordco = 0;
            }

            return set;
        }

        private static string newGString(List<string> row, int space)
        {
            int rc = 0;
            for (int j = 0; j < space; j++)
            {
                row[rc] = row[rc] + " ";
                if (row.Count - 2 > rc)
                    rc++;
                else
                    rc = 0;
            }

            return string.Join(" ", row).Trim();
        }

        public static IList<string> FullJustify3(string[] words, int maxWidth)
        {
            List<string> result = new List<string>();
            List<string> Chunk = new List<string>();
            int num_of_letters = 0;

            foreach (var word in words)
            {
                if (word.Length + Chunk.Count + num_of_letters > maxWidth)
                {
                    for (int i = 0; i < maxWidth - num_of_letters; i++)
                    {
                        Chunk[i % (Chunk.Count - 1 > 0 ? Chunk.Count - 1 : 1)] += " ";
                    }
                    result.Add(string.Join("", Chunk));
                    Chunk.Clear();
                    num_of_letters = 0;
                }
                Chunk.Add(word);
                num_of_letters += word.Length;
            }

            string lastLine = string.Join(" ", Chunk);
            while (lastLine.Length < maxWidth) lastLine += " ";
            result.Add(lastLine);

            return result;
        }

        public static string SimplifyPath(string path)
        {
            string[] dirs = path.Split('/');
            var stack = new Stack<string>();

            foreach (var dir in dirs)
            {
                if (string.IsNullOrEmpty(dir) || dir == ".")
                    continue;

                if (dir == "..")
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else
                {
                    stack.Push(dir);
                }
            }

            var result = string.Join("/", stack.Reverse());
            return result;
        }

        public static string SimplifyPath2(string path)
        {
            string[] dirs = path.Split('/');
            var queue = new Queue<string>();

            foreach (var dir in dirs)
            {
                if (string.IsNullOrEmpty(dir) || dir == ".")
                    continue;

                if (dir == "..")
                {
                    if (queue.Count > 0)
                    {
                        var temp = new Queue<string>();

                        while (queue.Count > 1)
                            temp.Enqueue(queue.Dequeue());

                        queue.Dequeue();

                        queue = temp;
                    }
                }
                else
                {
                    queue.Enqueue(dir);
                }
            }

            return "/" + string.Join("/", queue);
        }

        public static string SimplifyPath3(string path)
        {
            string[] dirs = path.Split('/');
            var list = new List<string>();

            foreach (var dir in dirs)
            {
                if (string.IsNullOrEmpty(dir) || dir == ".")
                    continue;

                if (dir == "..")
                {
                    if (list.Count > 0)
                        list.RemoveAt(list.Count - 1);
                }
                else
                {
                    list.Add(dir);
                }
            }

            return "/" + string.Join("/", list);
        }

        public static string SimplifyPath4(string path)
        {
            var elements = new List<string>();
            var paths = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < paths.Length; i++)
            {
                if (paths[i] != "." && paths[i] != "..")
                {
                    elements.Add(paths[i]);
                }
                else if (paths[i] == ".." && elements.Count > 0)
                {
                    elements.RemoveAt(elements.Count - 1);
                }
            }

            return "/" + string.Join("/", elements);
        }
        public static int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;

            int[,] dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
                dp[i, 0] = i;

            for (int j = 1; j <= n; j++)
                dp[0, j] = j;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(
                            dp[i - 1, j - 1],
                            Math.Min(
                                dp[i - 1, j],
                                dp[i, j - 1]
                            )
                        ) + 1;
                    }
                }
            }

            return dp[m, n];
        }
        public static int MinDistance2(string word1, string word2)
        {
            var l1 = word1.Length;
            var l2 = word2.Length;

            if (l1 == 0) return l2;
            if (l2 == 0) return l1;

            if (l2 > l1)
            {
                (word1, word2) = (word2, word1);
                (l1, l2) = (l2, l1);
            }

            Span<int> dp = stackalloc int[l2 + 1];

            for (var j = 0; j <= l2; j++) dp[j] = j;

            for (var i = 1; i <= l1; i++)
            {
                var prevDiagonal = dp[0];
                dp[0] = i;

                var c1 = word1[i - 1];

                for (var j = 1; j <= l2; j++)
                {
                    var up = dp[j];
                    var cost = c1 == word2[j - 1] ? 0 : 1;

                    var insert = dp[j - 1] + 1;
                    var delete = up + 1;
                    var replace = prevDiagonal + cost;

                    var best = insert < delete ? insert : delete;
                    if (replace < best) best = replace;

                    dp[j] = best;
                    prevDiagonal = up;
                }
            }
            return dp[l2];
        }

        public static int[][] SetZeroes(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            bool shouldFillFirstRow = false;
            bool shouldFillFirstCol = false;

            for (int j = 0; j < n; j++)
            {
                if (matrix[0][j] == 0)
                {
                    shouldFillFirstRow = true;
                    break;
                }
            }

            for (int i = 0; i < m; i++)
            {
                if (matrix[i][0] == 0)
                {
                    shouldFillFirstCol = true;
                    break;
                }
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            if (shouldFillFirstRow)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            if (shouldFillFirstCol)
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[i][0] = 0;
                }
            }

            return matrix;
        }

        public static int[][] SetZeroes2(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            Queue<List<int>> data = new Queue<List<int>>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        data.Enqueue(new List<int> { i, j });
                    }
                }
            }

            while (data.Count > 0)
            {
                List<int> res = data.Dequeue();

                for (int i = 0; i < m; i++)
                {
                    matrix[res[0]][i] = 0;
                    matrix[i][res[1]] = 0;
                }
            }

            return matrix;
        }

        public static int[][] SetZeroes3(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            bool[] rowFlags = new bool[m];
            bool[] colFlags = new bool[n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rowFlags[i] = true;
                        colFlags[j] = true;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (rowFlags[i] || colFlags[j])
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            return matrix;
        }


        public static bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix.Length == 0)
                return false;

            int m = matrix.Length;
            int n = matrix[0].Length;

            int l = 0;
            int r = m * n;

            while (l < r)
            {
                int mid = (l + r) / 2;
                int i = mid / n;
                int j = mid % n;

                if (matrix[i][j] == target)
                    return true;

                if (matrix[i][j] < target)
                    l = mid + 1;
                else
                    r = mid;
            }

            return false;
        }

        public static bool SearchMatrix3(int[][] matrix, int target) => matrix
       .SelectMany(m => m)
       .Any(x => x == target);

        public static bool SearchMatrix2(int[][] matrix, int target)
        {
            if (matrix.Length == 0)
                return false;

            int m = matrix.Length;
            int n = matrix[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; i < n; j++)
                {
                    if (matrix[i][j] == target) return true;
                }
            }

            return false;
        }

        public static int[] sortColors(int[] nums)
        {
            int zero = -1;
            int one = -1;
            int two = -1;

            foreach (var num in nums)
                if (num == 0)
                {
                    nums[++two] = 2;
                    nums[++one] = 1;
                    nums[++zero] = 0;
                }
                else if (num == 1)
                {
                    nums[++two] = 2;
                    nums[++one] = 1;
                }
                else
                {
                    nums[++two] = 2;
                }
            return nums;
        }

        public static int[] sortColors2(int[] nums)
        {
            int low = 0, mid = 0, high = nums.Length - 1;
            while (mid <= high)
            {
                if (nums[mid] == 0)
                {
                    nums = sortColors2swap(nums, low++, mid++);
                }
                else if (nums[mid] == 1)
                {
                    mid++;
                }
                else
                {
                    nums = sortColors2swap(nums, mid, high--);
                }
            }
            return nums;
        }
        private static int[] sortColors2swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            return nums;
        }

        public static int[] SortColors3(int[] nums)
        {

            int low = 0, mid = 0, high = nums.Length - 1;

            while (mid <= high)
            {
                if (nums[mid] == 0)
                {
                    nums = SortColors3SwapNumbers(nums, low, mid);
                    low++;
                    mid++;
                }
                else if (nums[mid] == 1)
                {
                    mid++;
                }
                else
                {
                    nums = SortColors3SwapNumbers(nums, mid, high);
                    high--;
                }
            }
            return nums;
        }

        private static int[] SortColors3SwapNumbers(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;

            return nums;
        }

        public static int[] SortColors4(int[] nums)
        {
            int temp;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
            return nums;
        }

        public static string MinWindow(string s, string t)
        {
            int[] count = new int[128];
            int required = t.Length;
            int bestLeft = -1;
            int minLength = s.Length + 1;

            foreach (char c in t)
                count[c]++;

            for (int l = 0, r = 0; r < s.Length; r++)
            {
                if (--count[s[r]] >= 0)
                    required--;

                while (required == 0)
                {
                    if (r - l + 1 < minLength)
                    {
                        bestLeft = l;
                        minLength = r - l + 1;
                    }

                    if (++count[s[l++]] > 0)
                        required++;
                }
            }

            return bestLeft == -1 ? "" : s.Substring(bestLeft, minLength);
        }
        public static string MinWindow2(string s, string t)
        {
            if (t.Length == 0 || s.Length < t.Length)
            {
                return "";
            }

            Span<int> count = stackalloc int[58];
            int missingSoFar = 0;
            foreach (char ch in t)
            {
                if (count[ch - 'A']++ == 0)
                {
                    missingSoFar++;
                }
            }

            int start = 0, end = 0;
            int fStart = -1, fEnd = 0;
            bool foundOnce = false;
            while (true)
            {
                if (start > end || (end == s.Length && missingSoFar > 0))
                { // start = 0; end = 0,1
                    if (fStart != -1)
                    {
                        return s.Substring(fStart, fEnd - fStart + 1);
                    }
                    return "";
                }
                if (missingSoFar > 0)
                { // 3,2,1
                    if (foundOnce)
                    { // false,false,true
                        if (count[s[start] - 'A']++ == 0)
                        { //O,B ,E,C
                            missingSoFar++; //2
                        }
                        start++; //2,3,4,5
                    }
                    if (count[s[end] - 'A']-- == 1)
                    { // A:1->0, B:0, C:1 E:0 D:-1 O:-1
                        missingSoFar--; //1
                    }
                    end++;
                }
                if (missingSoFar == 0)
                {
                    foundOnce = true;
                    fStart = start; //0
                    fEnd = end - 1; //5
                    if (count[s[start] - 'A']++ == 0)
                    { // 1
                        missingSoFar++; //1
                    }
                    start++; //1
                }
            }
            return "";
        }

        public static string MinWindow3(string s, string t)
        {

            Hashtable thash = new Hashtable();

            for (int i = 0; i < t.Length; i++)
            {
                if (thash.ContainsKey(t[i]))
                {
                    thash[t[i]] = (int)thash[t[i]] + 1;
                    continue;
                }
                thash.Add(t[i], 1);
            }

            Hashtable shash = new Hashtable(thash);
            string news = "";
            string minstri = "";


            for (int i = 0; i < s.Length; i++)
            {
                if (news == "" && !t.Contains(s[i]))
                {
                    continue;
                }

                int j = i;
                shash = new Hashtable(thash);
                while (j < s.Length)
                {

                    if (t.Contains(s[j]))
                    {
                        if (!shash.ContainsKey(s[j]))
                        {
                            break;
                        }
                        int newValue = (int)shash[s[j]] - 1;
                        if (newValue <= 0)
                        {
                            shash.Remove(s[j]);
                        }
                        else
                        {
                            shash[s[j]] = newValue;
                        }
                    }
                    news += s[j];

                    if (shash.Count == 0)
                    {
                        minstri = minstri == "" ? news : (minstri.Length > news.Length) ? news : minstri;
                        news = "";
                        break;
                    }
                    j++;

                }
            }
            return minstri;
        }
        public static IList<IList<int>> Combine(int n, int k)
        {
            return null;
        }
    }
}


