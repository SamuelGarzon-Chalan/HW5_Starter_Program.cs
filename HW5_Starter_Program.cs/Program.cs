
using System;
public class Program
{
    public static void Main(string[] args)
    {
        // ======================= TESTS (do not change) =======================
        var empty = new BinarySearchTree();
        var one = new BinarySearchTree();
        one.Insert(7);
        var t1 = new BinarySearchTree();
        foreach (int v in new[] { 50, 30, 70, 20, 40, 80, 35, 45 }) t1.Insert(v);
        var line = new BinarySearchTree();
        foreach (int v in new[] { 10, 20, 30, 40, 50 }) line.Insert(v);
        Console.WriteLine("== Min ==");
        Console.WriteLine(t1.Min());
        Console.WriteLine(line.Min());
        Console.WriteLine(one.Min());
        Console.WriteLine();
        Console.WriteLine("== Max ==");
        Console.WriteLine(t1.Max());
        Console.WriteLine(line.Max());
        Console.WriteLine(one.Max());
        Console.WriteLine();
        Console.WriteLine("== Depth ==");
        Console.WriteLine(t1.Depth(50));
        Console.WriteLine(t1.Depth(70));
        Console.WriteLine(t1.Depth(35));
        Console.WriteLine(t1.Depth(99));
        Console.WriteLine(line.Depth(50));
        Console.WriteLine(empty.Depth(5));
        Console.WriteLine();
    }
}
// ======================= CLASSES =======================
public class Node
{
    public int Value;
    public Node? Left;
    public Node? Right;
    public Node(int value) { Value = value; }
}
public class BinarySearchTree
{
    private Node? root;
    public Node? Root => root;
    public bool Insert(int value)
    {
        Node newNode = new Node(value);
        if (root == null) { root = newNode; return true; }
        Node temp = root;
        while (true)
        {
            if (newNode.Value == temp.Value) return false;
            if (newNode.Value < temp.Value)
            {
                if (temp.Left == null) { temp.Left = newNode; return true; }
                temp = temp.Left;
            }
            else
            {
                if (temp.Right == null) { temp.Right = newNode; return true; }
                temp = temp.Right;
            }
        }
    }
    public bool Contains(int value)
    {
        Node? temp = root;
        while (temp != null)
        {
            if (value < temp.Value) temp = temp.Left;
            else if (value > temp.Value) temp = temp.Right;
            else return true;
        }
        return false;
    }
   
    
public int Min()
    {
        Node? temp = root;
        while (temp.Left != null)
        {
            temp = temp.Left;
        }
        return temp.Value;
    }
  
    
public int Max()
    {
        Node? temp = root;
        while (temp.Right != null)
        {
            temp = temp.Right;
        }
        return temp.Value;
    }
    public int Depth(int value)
    {
        Node? temp = root;
        int depth = 0;

        while (temp != null)
        {
            if (value == temp.Value)
            {
                return depth;
            }

            if (value < temp.Value)
            {
                temp = temp.Left;
            }
            else
            {
                temp = temp.Right;
            }

          
            depth++;
        }

        return -1;
    }
}


// TODO: return the depth of the node that holds "value".
// The root has depth 0. If the value is not in the tree, return -1.
// Hint: it works like Contains, but count the steps as you go down.

/* ======================= WRITTEN ANSWERS (Questions 1 to 5)
=======================
Type your answers here. Draw trees with spaces and slashes, like the trees on
the
assignment page.
---- Question 1 ----
a) root:
50

b) leaves:
20, 35, 45, 80

c) internal nodes:
50, 30, 40, 70

d) parent of 35:
40

sibling of 20:
40

e) depth of 35:
3

height of node 30:
2

f) height of tree:
3

size:
8 nodes

g) degree of 70:
1, for one child.

h) valid BST? why:
Yes. At node 30 it's left subtree is 20, which is less
than 30. It's right subtree is 40, 35 and 45,
All are larger than 30. The other nodes follow suit also.
BST rule.

---- Question 2 ---- (Yes / No)
Tree A Tree B Tree C
Full? a Yes b yes and c yes
Perfect?a no b yesd and c no
Complete?a yes b yes and c noi
Reasons for each No:
Tree A is not perfect as its leaves aren't all at the same time Tree A is not perfect because its leaves are at different
The numbers under depths are 12 at depth 1, 2 and 6 at depth 2.

Tree C is not ideal as its leaves are not all the same size
depths: 4 is at depth 1, while 10 and 14 are at depth 2.

Tree C is incomplete as the lowest level has nodes
while the positions under 4 are empty, the following under 12 should be filled:
last level is not filled from left to right.
---- Question 3 ----
a) tree:
41
/\
20 65
/\ /\
11 29 50 91
    \   /\
   32 72 99
b) height: 3
c) Contains(32) visits:41,20 ,29 ,32eturns: tru
Contains(60) visits: 41 65 50 returns: false
---- Question 4 ----
a) tree:
10
  \
    20
       \
         30
            \
              40
                 \
                   50

height:4
b) nodes visited by Contains(50):5 Big O:worstr case acts like:
A singly linked list since every node has only one right child.
---- Question 5 ----
a) tree:
        90
        /\
      70   85
     / \   / \
    40 65 80 30
    /\
   10 35

b) children of 70 (show math):index 1 why because left 2*1 +1 =3  index 3 is 40
and right 2*1 +2 = 4
index 4 is 65
The children of 70 are 40 and 65.

c) parent of 35 (show math):index 8
(8 - 1) / 2 = 7 / 2 = 3
ikndex 3 is 40 so the partent is 40
d) why 65 is a leaf (show math):
left 2*4 +1 = 9 index 9 is null
right 2*4 +2 = 10 index 10 is null
*/