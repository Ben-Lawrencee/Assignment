using System;
using System.IO;

namespace Assignment {
  class Program {
    static void Main(string[] args) {
      Console.Clear();
      ArrayTask.run();
      LinkedList.run();

      String text = "";
      Random rand = new Random();
      for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 20; j++) {
          text = text + rand.Next(1, 21) + "\n";
        }
        File.WriteAllText("./numbers" + (i + 1) + ".txt", text);
      }
      int[] numbers;
      int index = 0;
      String[] file;
      for (int i = 0; i < 3; i++) {
        file = File.ReadAllLines("./numbers" + (i + 1) + ".txt");
        numbers = new int[file.Length];
        foreach (String j in file) {
          try {
            if (j.Length == 0) continue;
            numbers[index] = int.Parse(j);
          } catch {
            Console.WriteLine("Character was not a number: \"{0}\"", j);
            continue;
          }
          index++;
        }
        index = 0;
        BinaryTree tree = new BinaryTree(numbers);
        tree.displayTree();
        tree.displayPrimes();
      }
    }
    public static Boolean isPrime(int n) {
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
  }
}
