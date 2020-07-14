using System;
using System.IO;
using System.Collections.Generic;
namespace Assignment {
  public class BinaryTree {
    private BinaryTreeNode topNode;
    public BinaryTree() {
      String text = "";
      Random rand = new Random();
      for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 20; j++) {
          text = text + rand.Next(1, 21) + "\n";
        }
        File.WriteAllText("./numbers" + (i + 1) + ".txt", text);
      }
      List<int> numbers = new List<int>();
      for (int i = 0; i < 3; i++) {
        foreach (String j in File.ReadAllLines("./numbers" + (i + 1) + ".txt")) {
          try {
            if (j.Length == 0) continue;
            numbers.Add(int.Parse(j));
          } catch {
            Console.WriteLine("Found NaN: \"{0}\"", j);
            continue;
          }
        }
      }
      topNode = new BinaryTreeNode(numbers[(int)Math.Floor(Math.Round((decimal)numbers.Count / 2))], null, null);
      foreach (int i in numbers) {
        add(i, topNode);
      }
      Console.WriteLine("Binary Tree Created");
      List<BinaryTreeNode> List = new List<BinaryTreeNode>();
      List.Add(topNode);
      displayTree(List);
    }
    public void displayTree(List<BinaryTreeNode> list) {
      int count = list.Count;
      if (count == 0) return;
      Console.Write("[");
      BinaryTreeNode node;
      for( int i = 0; i < count; i++) {
        node = list[i];
        Console.WriteLine("Index: {0}\nList.Count: {1}\nCount: {2}", i, list.Count, count);
        list.RemoveAt(i);
        Console.Write("{0}", node.getValue());
        if (i != count - 1) Console.Write(",");
        if (node.getLeft() != null) list.Add(node.getLeft());
        if (node.getRight() != null) list.Add(node.getRight());
      }
      Console.Write("]");
      displayTree(list);
    }
    public void add(int num, BinaryTreeNode node) {
      if (num < node.getValue()) {
        if (node.getLeft() == null) {
          node.setLeft(new BinaryTreeNode(num, null, null));
        } else {
          add(num, node.getLeft());
        }
      } else {
        if (node.getRight() == null) {
          node.setRight(new BinaryTreeNode(num, null, null));
        } else {
          add(num, node.getRight());
        }
      }
    }
  }

  public class BinaryTreeNode {
    private int value;
    private BinaryTreeNode left;
    private BinaryTreeNode right;

    public BinaryTreeNode(int newValue, BinaryTreeNode newLeft, BinaryTreeNode newRight) {
      value = newValue;
      if (newLeft != null) left = newLeft;
      if (newRight != null) right = newRight;
    }
    public int getValue() {
      return value;
    }
    public BinaryTreeNode getLeft() {
      return left;
    }
    public BinaryTreeNode getRight() {
      return right;
    }
    public void setLeft(BinaryTreeNode newNode) {
      left = newNode;
    }
    public void setRight(BinaryTreeNode newNode) {
      right = newNode;
    }
  }
}