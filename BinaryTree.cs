using System;
using System.Collections.Generic;
namespace Assignment {
  public class BinaryTree {
    private BinaryTreeNode topNode;
    public BinaryTree(int[] numbers) {
      topNode = new BinaryTreeNode(numbers[(int)Math.Floor(Math.Round((decimal)numbers.Length / 2))], null, null);
      foreach (int i in numbers) {
        add(i, topNode);
      }
      Console.WriteLine("Binary Tree Created");
    }
    public void displayTree() {
      List<BinaryTreeNode> List = new List<BinaryTreeNode>();
      List.Add(topNode);
      recurseDisplayTree(List, 0);
    }
    public void displayPrimes() {
      List<BinaryTreeNode> List = new List<BinaryTreeNode>();
      List.Add(topNode);
      recurseDisplayPrimes(List, 0);
    }
    private void recurseDisplayPrimes(List<BinaryTreeNode> list, int depth) {
      int count = list.Count;
      BinaryTreeNode node;
      if (count == 0) return;
      if (depth == 0) Console.WriteLine("Displaying primes by layer: ");
      int primeCount = 0;
      for (int i = 0; i < count; i++) {
        node = list[0];
        list.RemoveAt(0);
        if (node.value >= 2 && isPrime(node.value)) {
          if (primeCount == 0) Console.Write("[");
          else Console.Write(",");
          Console.Write("{0}", node.value);
          primeCount++;
        }
        if (node.left != null) list.Add(node.left);
        if (node.right != null) list.Add(node.right);
      }
      if (primeCount > 0) Console.Write("]");
      recurseDisplayPrimes(list, depth + 1);
    }
    private Boolean isPrime(int n) {
      Boolean b = true;
      int max = (int)Math.Sqrt((double)n);
      for (int i = 2; i <= max; i++) {
        if (n % i == 0) {
          b = false;
          break;
        }
      }
      return b;
    }
    private void recurseDisplayTree(List<BinaryTreeNode> list, int depth) {
      int count = list.Count;
      if (count == 0) return;
      if (depth == 0) Console.Write("Root: ");
      else Console.Write("Layer: {0} [", depth);
      BinaryTreeNode node;
      for(int i = 0; i < count; i++) {
        node = list[0];
        list.RemoveAt(0);
        Console.Write("{0}", node.value);
        if (i != count - 1) Console.Write(",");
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
        if (node.right == null) node.setRight(new BinaryTreeNode(num, null, null));
        else add(num, node.right);
      } else {
        if (node.left == null) node.setLeft(new BinaryTreeNode(num, null, null));
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