using System;
using System.IO;

namespace Assignment {
  class Program {
    static void Main(string[] args) {
      var arrayTask       = new TestArray("./numbers.txt"); //Runs array's task
      var LinkedListTask  = new TaskLinkedList(3, 10);
      Console.WriteLine($"Middle value: {LinkedListTask.getMiddle()}");
      LinkedListTask.displayPrimes();

      // //Binary Search Tree Task :

      // //Writes random numbers to a file
      // String text = "";
      // Random rand = new Random();
      // //Loops three times for three files
      // for (int i = 0; i < 3; i++) {
      //   //Loops 20 times to make 20 random numbers for each file
      //   for (int j = 0; j < 20; j++) { 
      //     text = text + rand.Next(1, 21) + "\n";
      //   }
      //   File.WriteAllText("./numbers" + (i + 1) + ".txt", text); //Creates a file with 20 random numbers inside
      //   text = "";
      // }
      // //Reads all the numbers from each file into a binary search tree
      // int[] numbers;
      // int index = 0;
      // String[] file;
      // for (int i = 0; i < 3; i++) { //Loops for each file
      //   file = File.ReadAllLines("./numbers" + (i + 1) + ".txt"); //Reads the files lines
      //   //Makes a integer array from the file's content
      //   numbers = new int[file.Length];
      //   foreach (String j in file) {
      //     if (j.Length == 0) continue; //Continue if string is empty
      //     try {
      //       numbers[index] = int.Parse(j); //Add to the array
      //     } catch {
      //       Console.WriteLine("Character was not a number: \"{0}\"", j);
      //       continue;
      //     }
      //     index++;
      //   }
      //   index = 0;
      //   BinarySearchTree tree = new BinarySearchTree(numbers);
      //   Console.WriteLine("Displaying tree {0}", i + 1);
      //   tree.displayTree();
      //   tree.displayPrimes();
      // }
      // HashTableTask.run();
    }
    public static Boolean isPrime(int n) {
      Boolean b = true;
      if (n < 2)
        return false;
      int max = (int)Math.Sqrt((double)n);
      //Loops through 2 - Square root of given number
      for (int i = 2; i <= max; i++) {
        if (n % i == 0) { //If divisible by i equals 2. Return false
          b = false;
          break;
        }
      }
      return b;
    }
  }
}
