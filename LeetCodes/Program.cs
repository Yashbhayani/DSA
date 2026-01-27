using LeetCodes.Controller;
using LeetCodes.Functions;
using LeetCodes.Model;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;


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


//LeetCode Problem :1
/*int[] num = { 2, 7, 11, 15 };
int[] result = LeetCodeFunctionsClass.TwoSum(num, 9);

if (result != null){
    Console.WriteLine($"[{result[0]}, {result[1]}]");
}else{
    Console.WriteLine("No solution found");
}

int[] num2 = { 3,2,4};
result = LeetCodeFunctionsClass.TwoSum2(num2, 6);

if (result != null){
    Console.WriteLine($"[{result[0]}, {result[1]}]");
}else{
    Console.WriteLine("No solution found");
}*/


//LeetCode Problem :2
/*ListNode result = LeetCodeFunctionsClass.AddTwoNumbersfun();
while (result != null)
{
    Console.Write(result.value + " ");
    result = result.next;
}*/


//LetCode Problem :3
/*string val = "abcabcbb";
int res = LeetCodeFunctionsClass.LengthOfLongestSubstring3(val);
Console.WriteLine(res);*/





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



int[] num = { 1, 2, 3, 4, 5 };
Node head = LeetCodeFunctionsClass.createList(num);

//LEVEL 3: Two-pointer logic

//7️⃣ Remove Nth Node from End
//Node? result  = LeetCodeFunctionsClass.RemoveNthNodeFromEnd(head, 2);
//Node? result  = LeetCodeFunctionsClass.RemoveNthNodeFromEnd2(head, 2);
//LeetCodeFunctionsClass.printList(result);