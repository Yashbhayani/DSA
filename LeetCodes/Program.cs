using LeetCodes.Controller;
using LeetCodes.Functions;
using LeetCodes.Model;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;


//LeetCodeCodeFunctionsClass.LoopCode();


//Maximum subarray sum
/*int[] num = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
int[] num = { 2, 3, -8, 7, -1, 2, 3};
Console.WriteLine(LeetCodeFunctionsClass.Maximumsubarraysum2(num));*/


//Product except self
/*int[] num = { 1, 2, 3, 4 };
int[]? val = LeetCodeFunctionsClass.Productexceptself(num);
foreach(int k in val)
{
    Console.WriteLine(k);
}*/

//---------------------------------------------------------------------------------------------------------

//Valid palindrome

/*Console.WriteLine(LeetCodeFunctionsClass.Validpalindrome("Abc 012..##  10cbA"));*/

//Two Pointers
/*int[] num = { 1, 2, 4, 6, 10 };
Console.WriteLine(LeetCodeFunctionsClass.Pairwithtargetsum(num, 15));*/

//Reverse string
/*Console.WriteLine(LeetCodeFunctionsClass.Reversestring("hello"));*/

//---------------------------------------------------------------------------------------------------------


//LEVEL 4: Sliding Window
/*int[] num = { 2, 1, 5, 1, 3, 2 };
int k = 3;*/
/*int[] num = { 100, 200, 300, 400 };
int k = 2;*/
/*int[] num = { 1, 4, 2, 10, 23, 3, 1, 0, 20 };
int k = 4;*/
/*int[] num = { 1, 3 };
int k = 1;*/
//Console.WriteLine(LeetCodeFunctionsClass.MaximumSumOfSubarrayOfSizeK2(num, k));


//Longest substring with at most 2 distinct characters


/*string s = "eceba";
s = "geeksforgeeks";
s = "ccaabbb";
s = "abac";
s = "abcba";
s = "aabacbebebe";
s = "eceba";
s = "abccbadd";*/
//Console.WriteLine(LeetCodeFunctionsClass.LongestSubstringWithAtMost2DistinctCharacters3(s));


//---------------------------------------------------------------------------------------------------------

//LEVEL 5: Hashing
/*string s = "leetcode";
s = "loveleetcode";
s = "aabb";
s = "swiss";
Console.WriteLine(LeetCodeFunctionsClass.FirstNonRepeatingCharacter2(s));*/


//---------------------------------------------------------------------------------------------------------

//LEVEL 6: Stack

//Example 1: Valid parentheses

/*string s = "()[]{}";
s = "()";
s = "{[]}";
s = "([])";
s = "((()))";
s = "{[()]}";
s = "[({})]";
s = "(]";
s = "([)]";
s = "{(})";
s = "(";
s = ")";
s = "(()";
s = "())";
s = "()[]{}{";
s = "()[{}]";
Console.WriteLine(LeetCodeFunctionsClass.Validparentheses3(s));*/


//Example 2: Next greater element


/*int[] arr = [4, 5, 2, 10];
arr = [1, 2, 3, 4];
arr = [4, 3, 2, 1];
arr = [6, 8, 0, 1, 3];
arr = [2, 2, 2];
arr = [5, 7, 1, 2, 6, 0];
arr = [9];
arr = [10, 3, 5, 4, 12];
int[] res = LeetCodeFunctionsClass.NextGreaterElement2(arr);
foreach (var item in res)
{
    Console.Write(item+", ");
}*/

//---------------------------------------------------------------------------------------------------------

//LEVEL 7: Queue / BFS

//Example 1: Level order traversal (tree)

/*NodeClass root = new NodeClass(5);

root.left = new NodeClass(12);
root.right = new NodeClass(13);

root.left.left = new NodeClass(7);
root.left.right = new NodeClass(14);

root.right.right = new NodeClass(2);

root.left.left.left = new NodeClass(17);
root.left.left.right = new NodeClass(23);

root.left.right.left = new NodeClass(27);
root.left.right.right = new NodeClass(3);

root.right.right.left = new NodeClass(8);
root.right.right.right = new NodeClass(11);*/


/*List<List<int>> res = LeetCodeFunctionsClass.levelOrder(root);

// Print level by level
foreach (var level in res)
{
    foreach (int val in level)
    {
        Console.Write(val + " ");
    }
    Console.WriteLine();
}*/

//List<int> nodes = LeetCodeFunctionsClass.levelOrder3(root);
//Console.WriteLine(string.Join(" ", nodes));


/*NodeClass root = new NodeClass(3);

root.left = new NodeClass(9);
root.right = new NodeClass(20);

root.right.left = new NodeClass(15);
root.right.right = new NodeClass(7);

List<List<int>> nodes = LeetCodeFunctionsClass.levelOrder4(root);
// Output the result
foreach (var list in nodes)
{
    Console.WriteLine("["+string.Join(", ", list)+"]");
}*/

//Sliding window maximum

/*int[] arr = [1, 3, -1, -3, 5, 3, 6, 7];
arr = [4, 2, 12, 3, 8, 7];
arr = [9, 1, 3, 4, 6, 2];
int k = 2;
int[] result = LeetCodeFunctionsClass.SlidingWindoMaximum2(arr, k);
foreach (var item in result)
{
    Console.Write(item + ", ");
}
*/


//---------------------------------------------------------------------------------------------------------
//LEVEL 8: Linked List
/*Node head = new Node(1);
head.next = new Node(2);
head.next.next = new Node(3);
head.next.next.next = new Node(4);
head.next.next.next.next = new Node(5);
head = LeetCodeFunctionsClass.ReverseList(head);
LeetCodeFunctionsClass.printList(head);*/



/*int[] values = { 1, 2, 3, 4, 5, 6, 7, 8 };
int k = 4;
Node head = LeetCodeFunctionsClass.createList(values);
Node newhead =  LeetCodeFunctionsClass.reversKnode2(head, k);
LeetCodeFunctionsClass.printList(newhead);
*/
//---------------------------------------------------------------------------------------------------------


//LinkedList Levels


//int[] num = { 2, 7, 11, 15 };
//Node head = LeetCodeFunctionsClass.createList(num);

// Traverse a Linked List
//LeetCodeFunctionsClass.TraverseaLinkedList(head);
//LeetCodeFunctionsClass.TraverseaLinkedList2(head);


//Find Length of Linked List
//int count = LeetCodeFunctionsClass.FindLengthofLinkedList(head);
//int count = LeetCodeFunctionsClass.FindLengthofLinkedList2(head, 0);
//Console.WriteLine(count);

//Search an Element
//Console.WriteLine(LeetCodeFunctionsClass.SearchAnElement(head, 33));
//Console.WriteLine(LeetCodeFunctionsClass.SearchAnElement2(head, 33));

//Reverse a Linked List
//Node? result = LeetCodeFunctionsClass.ReverseALinkedList(head);
//Node? result = LeetCodeFunctionsClass.ReverseALinkedList2(head);
//LeetCodeFunctionsClass.printList(result);


//Find Middle of Linked List
//Console.WriteLine(LeetCodeFunctionsClass.FindMiddleOfLinkedList(head));
//Console.WriteLine(LeetCodeFunctionsClass.FindMiddleOfLinkedList2(head));



/*int[] num = { 1, 2, 3, 4, 5 };
Node head = LeetCodeCodeFunctionsClass.createList(num);*/

//LEVEL 3: Two-pointer logic

//7️⃣ Remove Nth Node from End
//Node? result  = LeetCodeFunctionsClass.RemoveNthNodeFromEnd(head, 2);
//Node? result  = LeetCodeFunctionsClass.RemoveNthNodeFromEnd2(head, 2);
//LeetCodeFunctionsClass.printList(result);


//------------------------------------------------LeetCode---------------------------------------------------------


//LeetCode Problem :1
/*int[] num = { 2, 7, 11, 15 };
int[] result = LeetCodeClass.TwoSum(num, 9);

if (result != null){
    Console.WriteLine($"[{result[0]}, {result[1]}]");
}else{
    Console.WriteLine("No solution found");
}

int[] num2 = { 3,2,4};
result = LeetCodeClass.TwoSum2(num2, 6);

if (result != null){
    Console.WriteLine($"[{result[0]}, {result[1]}]");
}else{
    Console.WriteLine("No solution found");
}*/


//LeetCode Problem :2
/*ListNode result = LeetCodeClass.AddTwoNumbersfun();
while (result != null)
{
    Console.Write(result.value + " ");
    result = result.next;
}*/


//LetCode Problem :3
/*string val = "abcabcbb";
int res = LeetCodeClass.LengthOfLongestSubstring3(val);
Console.WriteLine(res);*/


//4. Median of Two Sorted Arrays
/*int[] nums1 = [1,2];
int[] nums2 = [3,4];
double res = LeetCodeClass.MedianofTwoSortedArrays2(nums1, nums2);
Console.WriteLine(res);
*/


// 5. Longest Palindromic Substring
/*string s = "ccc";
Console.WriteLine(LeetCodeClass.LongestPalindromicSubstring(s));*/


//6. Zigzag Conversion
/*string s = "AB";
int numRows = 1;
Console.WriteLine(LeetCodeClass.ZigzagConversion2(s, numRows));*/


//7. Reverse Integer
/*int num = -2147483648;
Console.WriteLine(LeetCodeClass.reverse3(num)); */


//8. String to Integer (atoi)
/*string s = "+45";
Console.WriteLine(LeetCodeClass.MyAtoi5(s));
*/

//9. Palindrome Number
/*int x = 10;
Console.WriteLine(LeetCodeClass.IsPalindrome(x));
Console.WriteLine(LeetCodeClass.IsPalindrome2(x));
Console.WriteLine(LeetCodeClass.IsPalindrome3(x));*/


//10. Regular Expression Matching
/*string s = "mississippi";
string p = "mis*is*ip*.";
*/
/*string s = "mississippi";
string p = "mis*is*p*.";*/

/*string s = "aab";
string p = "c*a*b";


Console.WriteLine(LeetCodeClass.RegularExpressionMatching2(s, p));*/

//11. Container With Most Water
/*int[] val = [1, 8, 6, 2, 5, 4, 8, 3, 7];
Console.WriteLine(LeetCodeClass.maxArea(val));
*/


//12. Integer to Roman
/*Console.WriteLine(LeetCodeClass.intToRoman2(3749));*/

//13. Roman to Integer
/*Console.WriteLine(LeetCodeClass.RomanToInt3("MCMXCIV"));*/

//14. Longest Common Prefix
//string[] s = ["flower", "flow", "flight"];
/*string[] s = ["dog", "racecar", "car"];
Console.WriteLine(LeetCodeClass.LongestCommonPrefix3(s));*/

//15. 3Sum
/*int[] nums = [-1, 0, 1, 2, -1, -4];
IList<IList<int>> s = LeetCodeClass.ThreeSum2(nums);
foreach (var item in s)
{
    Console.WriteLine(string.Join(",", item));
}*/

//16. 3Sum Closest
/*int[] nums = [-1, 2, 1, -4]; int target = 1;
Console.WriteLine(LeetCodeClass.threeSumClosest2(nums, target));*/

//17. Letter Combinations of a Phone Number
/*string Input = "23";
IList<string> output = LeetCodeClass.LetterCombinations3(Input);
foreach (string s in output)
{
    Console.WriteLine(s);
}
*/


//18. 4Sum
/*int[] nums = [1, 0, -1, 0, -2, 2];
int target = 0;
IList<IList<int>> res = LeetCodeClass.FourSum2(nums, target);
foreach (var item in res)
{
    foreach (var item1 in item)
    {
        Console.Write(item1 + ",");
    }

    Console.WriteLine("\n");
}*/



//19. Remove Nth Node From End of List
/*int[] num = { 1,2,3,4,5 };
int n = 2;
Node head = LeetCodeCodeFunctionsClass.createList(num);

Node nh = LeetCodeClass.RemoveNthFromEnd2(head, n);
LeetCodeCodeFunctionsClass.printList(nh);
*/


//20. Valid Parentheses
/*string s = "()[]{}";
Console.WriteLine(LeetCodeClass.IsValid(s));*/


//21. Merge Two Sorted Lists
/*int[] num1 = { 1, 2, 4 };
int[] num2 = { 1, 3, 4 };
Node head1 = LeetCodeCodeFunctionsClass.createList(num1);
Node head2 = LeetCodeCodeFunctionsClass.createList(num2);
Node re = LeetCodeClass.MergeTwoLists2(head1, head2);
LeetCodeCodeFunctionsClass.printList(re);*/

//22. Generate Parentheses
/*int n = 3;
IList<string> result = LeetCodeClass.GenerateParenthesis4(n);
foreach (var item in result)
{
    Console.WriteLine(item);
}*/


//23. Merge k Sorted Lists
Node l1 = LeetCodeCodeFunctionsClass.createList([1,4,5]);
Node l2 = LeetCodeCodeFunctionsClass.createList([1,3,4]);
Node l3 = LeetCodeCodeFunctionsClass.createList([2,6]);

Node[] lists = new Node[] { l1, l2, l3 };
Node result = LeetCodeClass.MergeKLists2(lists);
LeetCodeCodeFunctionsClass.printList(result);