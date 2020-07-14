using System;
using System.IO;

namespace Assignment {
  public class ArrayTask {
    public static void run() {
      Console.WriteLine("Displaying numbers:");
      String text = "";
      Random rand = new Random();
      for (int i = 0; i < 20; i++) {
        text = text + rand.Next(1, 21);
        if (i != 19) text = text + "\n"; 
      }
      File.WriteAllText("./numbers.txt", text);
      String[] content = File.ReadAllLines("./numbers.txt");
      int[] numbers = new int[content.Length];
      Console.Write("[");
      for (int i = 0; i < content.Length; i++) {
        try {
          if (content[i].Length == 0) {
            continue;
          }
          numbers[i] = int.Parse(content[i]);
          if (i == 0) Console.Write("{0}", numbers[i]);
          else Console.Write(",{0}", numbers[i]);
        }
        catch {
          Console.WriteLine("Error converting to number: {0}", content[i]);
          return;
        }
      }
      Console.Write("]\n");
    }
  }
}