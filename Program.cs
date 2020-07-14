using System;
using System.Collections.Generic;


namespace Assignment {
  class Program {
    static void Main(string[] args) {
      Console.Clear();
      ArrayTask.run();
      LinkedList.run();
      BinaryTree tree = new BinaryTree();
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
