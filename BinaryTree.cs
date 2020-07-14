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
      displayTree(List, 0);
    }
    public void displayTree(List<BinaryTreeNode> list, int depth) {
      int count = list.Count;
      if (count == 0) return;
      Console.Write("Layer: {0} [", depth);
      BinaryTreeNode node;
      for(int i = 0; i < count; i++) {
        node = list[0];
        list.RemoveAt(0);
        Console.Write("{0}", node.value);
        if (i != count - 1) Console.Write(", ");
        if (node.left != null) list.Add(node.left);
        if (node.right != null) list.Add(node.right);
      }
      Console.Write("]\n");
      displayTree(list, depth + 1);
    }
    public void add(int num, BinaryTreeNode node) {
      if (num == node.value) return; //If number already exists. Return
      int temp = 0;
      if (num > node.value) {
        if (num > node.right.value) { //If number is greater than right. Make new right and connect that right with prevs rights right.
          temp = node.right.value;
          node.right.value = num;
          if (node.right.right == null) node.right.setRight(new BinaryTreeNode(temp, node.right.left, node.right.right));
          else {

          }
        } else {
          
        }
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