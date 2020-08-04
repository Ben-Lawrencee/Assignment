
using System;
using System.IO;
using System.Collections.Generic;

namespace Assignment {
  public class LinkedList {
    public static void run() {
      Console.WriteLine("Doubly Linked List");
      //Creates 20 random numbers for 3 files
      String text = "";
      Random rand = new Random();
      for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 20; j++) {
          text = text + rand.Next(1, 21) + "\n";
        }
        File.WriteAllText("./numbers" + (i + 1) + ".txt", text);
      }
      //Reads numbers from files and adds to linked list
      LinkedList<int> linkedNumbers = new LinkedList<int>();
      linkedNumbers = addToLinkedListInt(linkedNumbers, File.ReadAllLines("./numbers1.txt"));
      linkedNumbers = addToLinkedListInt(linkedNumbers, File.ReadAllLines("./numbers2.txt"));
      linkedNumbers = addToLinkedListInt(linkedNumbers, File.ReadAllLines("./numbers3.txt"));
      //Gets middles index and logs it
      int middle = (int)Math.Floor((decimal)linkedNumbers.Count / 2);
      try {
        Console.WriteLine("Middle node: {0}", get(linkedNumbers, middle));
      } catch (Exception ex) {
        Console.WriteLine("Error getting middle node : {0}", ex);
      }
      //Loops through all values in linked list, checking each if its a prime and logging it
      LinkedListNode<int> node = linkedNumbers.First;
      Console.WriteLine("Displaying prime numbers in Linked List:");
      int counter = 0;
      for (int i = 0; i < linkedNumbers.Count; i++) {
        if (Program.isPrime(node.Value)) {
          Console.Write("[{0},{1}]", i, node.Value);
          counter++;
          if (counter == 5) {
            Console.Write("\n");
            counter = 0;
          } 
        } 
        node = node.Next;
      }
      Console.Write("\n");
    }
    public static int get(LinkedList<int> linkedNumbers, int index) {
      //Loops through a linked list looking for an index
      LinkedListNode<int> node = linkedNumbers.First;
      for (int i = 0; i < linkedNumbers.Count; i++) {
        if (i == index) return node.Value; //Returns value once index is found
        node = node.Next;
      }
      //Throws an error if index is not found
      throw new System.IndexOutOfRangeException("Index out of range");
    }
    public static LinkedList<int> addToLinkedListInt(LinkedList<int> list, String[] input) {
      //Loops through a given String array
      foreach (String content in input) {
        if (content.Length == 0) continue;
        //Adds string to linked list
        if (list.Count == 0) list.AddFirst(int.Parse(content));
        else list.AddAfter(list.Last, int.Parse(content));
      }
      //Returns linked list
      return list;
    }
  }
}