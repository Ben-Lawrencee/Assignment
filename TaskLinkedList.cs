using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Assignment {
  public class TaskLinkedList {
    private LinkedList<int> linkedNumbers = new LinkedList<int>();
    public TaskLinkedList(int amount, int numAmount = 20) {
      string fileName;
      for (int i = 0; i < amount; i++) {
        fileName = $"./numbers{i + 1}.txt";
        generateFile(fileName, numAmount);
        addFromFile(fileName);
      }
    }
    public TaskLinkedList(string[] givenFiles) {
      foreach (string file in givenFiles) {
        addFromFile(file);
      }
    }
    public TaskLinkedList(string file) {
      addFromFile(file);
    }
    public TaskLinkedList() {}
    public LinkedList<int> addFromFile(string file) {
      if (!File.Exists(file)) {
        Console.WriteLine($"Error: File does not exist: '{file}'");
        return null;
      }
      String[] content = File.ReadAllLines(file);
      int num;
      foreach (string i in content) {
        if (content.Length == 0) continue;
        //Converts all strings from given file to int
        if (!int.TryParse(i, out num)) {
          Console.WriteLine($"Error: Failed to convert to int: '{i}'");
        }        
        //Adds int to linked list
        if (linkedNumbers.Count == 0) 
          linkedNumbers.AddFirst(num);
        else
          linkedNumbers.AddAfter(linkedNumbers.Last, num);
      }
      return linkedNumbers;
    }
    private static bool generateFile(string file, int numAmount = 20) {
      StringBuilder text = new StringBuilder();
      Random rand = new Random();
      //Creates 20 random numbers for amount number of files
      for (int j = 0; j < numAmount; j++) {
        text.Append($"{rand.Next(1, 21)}\n");
      }
      if (!file.EndsWith(".txt")) {
        file += ".txt";
      }
      try {
        File.WriteAllText(file, text.ToString());
        return true;
      } catch {
        return false;
      }
    }
    public int getMiddle() {
      if (linkedNumbers.Count == 0) {
        Console.WriteLine("Error: LinkedList is empty");
        return -1;
      }
      int middle = (int)Math.Floor((decimal)linkedNumbers.Count / 2);
      try {
        return get(middle);
      } catch (Exception ex) {
        Console.WriteLine($"Error: Could not get middle node : {ex}");
        return -1;
      }
    }
    public void display(bool displayPrimes = false) {
      int count = linkedNumbers.Count;
      if (count == 0) {
        Console.WriteLine("LinkedList is empty");
        return;
      }
      LinkedListNode<int> node = linkedNumbers.First;
      StringBuilder values = new StringBuilder();
      StringBuilder primes = new StringBuilder();
      int counter = 0;
      for (int i = 0; i < count; i++) {
        if (displayPrimes && Program.isPrime(node.Value)) {
          if (counter != 0)
            primes.Append(",");
          counter++;
          primes.Append($"[{node.Value}]");
          if (counter == 5) {
            primes.Append("\n");
            counter = 0;
          } 
        }
        values.Append($"[{node.Value}]");
        if (i != count - 1)
          values.Append(",");
        node = node.Next;
      }
      Console.WriteLine($"Values: \n{values.ToString()}");
      Console.WriteLine($"Primes: \n{primes.ToString()}");
    }
    public void displayPrimes() {
      LinkedListNode<int> node = linkedNumbers.First;
      int counter = 0;
      StringBuilder primes = new StringBuilder();
      for (int i = 0; i < linkedNumbers.Count; i++) {
        if (Program.isPrime(node.Value)) {
          if (counter != 0)
            primes.Append(",");
          counter++;
          primes.Append($"[{node.Value}]");
          if (counter == 5) {
            primes.Append("\n");
            counter = 0;
          } 
        }
        node = node.Next;
      }
      Console.WriteLine($"Primes: \n{primes.ToString()}");
    }
    public int get(int index) {
      //Loops through a linked list looking for an index
      LinkedListNode<int> node = linkedNumbers.First;
      for (int i = 0; i < linkedNumbers.Count; i++) {
        if (i == index) return node.Value; //Returns value once index is found
        node = node.Next;
      }
      //Throws an error if index is not found
      throw new System.IndexOutOfRangeException("Index out of range");
    }
  }
}