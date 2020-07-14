
using System;
using System.IO;
using System.Collections.Generic;

namespace Assignment {
  public class LinkedList {
    public static void run() {
      Console.WriteLine("Doubly Linked List");
      String text = "";
      Random rand = new Random();
      for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 20; j++) {
          text = text + rand.Next(1, 21) + "\n";
        }
        File.WriteAllText("./numbers" + (i + 1) + ".txt", text);
      }
      LinkedList<int> linkedNumbers = new LinkedList<int>();
      linkedNumbers = addToLinkedListInt(linkedNumbers, File.ReadAllText("./numbers1.txt").Split("\n"));
      linkedNumbers = addToLinkedListInt(linkedNumbers, File.ReadAllText("./numbers2.txt").Split("\n"));
      linkedNumbers = addToLinkedListInt(linkedNumbers, File.ReadAllText("./numbers3.txt").Split("\n"));
      int middle = (int)Math.Floor((decimal)linkedNumbers.Count / 2);
      LinkedListNode<int> node = linkedNumbers.First;
      for (int i = 0; i < linkedNumbers.Count; i++) {
        if (i == middle) Console.WriteLine("Middle node: {0}", node.Value);
        node = node.Next;
      }
      node = linkedNumbers.First;
      Console.WriteLine("Displaying prime numbers in Linked List:");
      for (int i = 0; i < linkedNumbers.Count; i++) {
        if (Program.isPrime(node.Value)) Console.Write("[{0},{1}]", i, node.Value);
        node = node.Next;
      }
      Console.Write("\n");
    }
    public static LinkedList<int> addToLinkedListInt(LinkedList<int> list, String[] input) {
      foreach (String content in input) {
        if (content.Length == 0) continue;
        if (list.Count == 0) list.AddFirst(int.Parse(content));
        else list.AddAfter(list.Last, int.Parse(content));
      }
      return list;
    }
  }
}