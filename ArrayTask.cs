using System;
using System.IO;
using System.Text;

namespace Assignment {
  public class ArrayTask {
    public static void run() { //Creates a file of numbers and runs run(generatedFile)
      // Creating numbers
      StringBuilder text = new StringBuilder();
      Random rand = new Random();
      for (int i = 0; i < 20; i++) {
        text.Append(rand.Next(1, 21));
        if (i != 20 - 1)
          text.Append("\n"); 
      }
      //Stores numbers in a file
      File.WriteAllText("./numbers.txt", text.ToString());
      run("./numbers.txt");
    }
    public static void run(String file) {
      Console.WriteLine("Displaying numbers:");
      if (!File.Exists(file)) { //If file doesn't exist. Display error
        Console.WriteLine("Error: File does not exist");
        return;
      }
      //Gets numbers from file
      String[] content = File.ReadAllLines(file);
      int numOfPrimes = 0;
      int num;
      Console.Write("[");
      //Limits number of lines to a preset constant
      const int iterations = 20;
      if (content.Length != iterations) {
        Console.WriteLine("Error: File content must have 20 lines"); 
        return;
      }
      int[] numbers = new int[iterations];
      //Adds numbers to an array and logs said numbers
      for (int i = 0; i < iterations; i++) {
        //Error handling
        if (content[i].Length == 0) { //Throw error if there is an empty line
          Console.WriteLine("Error: File must not contain empty lines");
          return;
        }
        if (int.TryParse(content[i], out num)) { //Throws error if unable to convert to int
          Console.WriteLine("Error: converting number");
          return;
        }
        numbers[i] = num;
        //Counts primes
        if (Program.isPrime(num))
          numOfPrimes++;
        //Display numbers
        if (i == 0)
          Console.Write("{0}", numbers[i]);
        else
          Console.Write(",{0}", numbers[i]);
      }
      Console.Write("]\n");
      Console.WriteLine("Number of primes: {0}", numOfPrimes);
    }
  }
}