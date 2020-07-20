using System;
using System.Collections.Generic;
namespace Assignment {
  public class BinarySearchTree {
    private BinaryTreeNode topNode;
    public BinarySearchTree(int[] numbers) {
      //Makes the top node the middle value from inputted numbers array
      topNode = new BinaryTreeNode(numbers[(int)Math.Floor(Math.Round((decimal)numbers.Length / 2))], null, null);
      //Adds numbers to the top node/root node/tree
      foreach (int i in numbers) {
        add(i, topNode);
      }
      Console.WriteLine("Binary Tree Created");
    }
    public void displayTree() {
      //Creates a list for the recursive function to use
      List<BinaryTreeNode> List = new List<BinaryTreeNode>();
      List.Add(topNode);
      recurseDisplayTree(List, 0);
    }
    public void displayPrimes() {
      //Creates a list for the recursive function to use
      List<BinaryTreeNode> List = new List<BinaryTreeNode>();
      List.Add(topNode);
      recurseDisplayPrimes(List, 0);
    }
    private void recurseDisplayPrimes(List<BinaryTreeNode> list, int depth) {
      int count = list.Count; //Count is set so it wont loop through newly added nodes, as new nodes would be the next layer
      BinaryTreeNode node;
      if (count == 0) return;
      if (depth == 0) Console.WriteLine("Displaying primes by layer: ");
      int primeCount = 0;
      //Loops through all nodes in the list
      for (int i = 0; i < count; i++) {
        node = list[0];
        list.RemoveAt(0);
        //Checks if its a prime and logs it
        if (node.value >= 2 && Program.isPrime(node.value)) {
          if (primeCount == 0) Console.Write("[");
          else Console.Write(",");
          Console.Write("{0}", node.value);
          primeCount++;
        }
        //Adds new nodes to the list for next layers recursion
        if (node.left != null) list.Add(node.left);
        if (node.right != null) list.Add(node.right);
      }
      if (primeCount > 0) Console.Write("]");
      recurseDisplayPrimes(list, depth + 1);
    }
    private void recurseDisplayTree(List<BinaryTreeNode> list, int depth) {
      int count = list.Count;
      if (count == 0) return;
      if (depth == 0) Console.Write("Root: ");
      else Console.Write("Layer: {0} [", depth);
      BinaryTreeNode node;
      //Loops through the list
      for(int i = 0; i < count; i++) {
        node = list[0];
        list.RemoveAt(0);
        Console.Write("{0}", node.value);
        if (i != count - 1) Console.Write(",");
        //Add nodes to list for next layers recursion
        if (node.left != null) list.Add(node.left);
        if (node.right != null) list.Add(node.right);
      }
      if (depth > 0) Console.Write("]\n");
      else Console.Write("\n");
      recurseDisplayTree(list, depth + 1);
    }
    public void add(int num, BinaryTreeNode node) {
      if (num == node.value) return; //If number already exists. Return
      if (num > node.value) {
        //If right doesn't exist, make a node valued num
        if (node.right == null) node.setRight(new BinaryTreeNode(num, null, null));
        //else recurse add to nodes right node
        else add(num, node.right);
      } else {
        //If left doesn't exist, make a node valued num
        if (node.left == null) node.setLeft(new BinaryTreeNode(num, null, null));
        //else recurse add to nodes left node
        else add(num, node.left);
      }
    }
  }

  public class BinaryTreeNode {
    public int value;
    public BinaryTreeNode left;
    public BinaryTreeNode right;

    public BinaryTreeNode(int newValue, BinaryTreeNode newLeft, BinaryTreeNode newRight) {
      value = newValue;
      if (newLeft != null) left = newLeft;
      if (newRight != null) right = newRight;
    }
    public void setLeft(BinaryTreeNode newNode) {
      left = newNode;
    }
    public void setRight(BinaryTreeNode newNode) {
      right = newNode;
    }
  }
}