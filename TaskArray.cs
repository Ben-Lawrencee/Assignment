using System;
using System.Text;
using System.IO;
namespace Assignment {
  public class TestArray {
    private const int setLength = 20;
    private int[] numbers;
    public TestArray() { //Generate file if none is given
      //Generate file
      if (!generateFile(out string fileName)) {
        Console.WriteLine("Error: Failed to write file");
        return;
      }
      Console.WriteLine($"File created: {fileName}");
      if (!createArray(fileName, true))
        return;
      Console.WriteLine($"Number of primes: {countPrimes()}");
    }
    public TestArray(string fileName) {
      if (!File.Exists(fileName)) {
        Console.WriteLine("Error: File not found");
        return;
      }
      Console.WriteLine($"File found: {fileName}");
      if (!createArray(fileName, true))
        return;
      Console.WriteLine($"Number of primes: {countPrimes()}");
    }
    public int countPrimes() {
      int count = 0;
      for (int i = 0; i < setLength; i++)
        if (Program.isPrime(numbers[i]))
          count++;
      return count;
    }
    public void displayNumbers() {
      for (int i = 0; i < setLength; i++)
        if (i == 0)
          Console.WriteLine($"{numbers[i]}");
        else
          Console.WriteLine($",{numbers[i]}");
    }
    public bool createArray(string fileName, bool display = false) {
      String[] content = File.ReadAllLines(fileName);
      //Limits number of lines to a preset constant
      this.numbers = new int[setLength];
      if (content.Length != setLength) {
        Console.WriteLine("Error: File content must have 20 lines"); 
        return false;
      }
      int num;
      this.numbers = new int[setLength];
      StringBuilder log = new StringBuilder();
      if (display)
        log.Append("[");
      //Adds numbers to an array and logs said numbers
      for (int i = 0; i < setLength; i++) {
        //Error handling
        if (content[i].Length == 0) { //Throw error if there is an empty line
          Console.WriteLine("Error: File must not contain empty lines");
          return false;
        }
        if (!int.TryParse(content[i], out num)) { //Throws error if unable to convert to int
          Console.WriteLine($"Error: Couldn't convert number '{content[i]}'");
          return false;
        }
        this.numbers[i] = num;
        //Display numbers
        if (display)
          if (i == 0)
            log.Append(numbers[i]);
          else
            log.Append($",{numbers[i]}");
      }
      Console.WriteLine(log.Append("]").ToString());
      return true;
    }
    public bool generateFile(out string fileName, string name = "numbers") {
      StringBuilder text = new StringBuilder();
      Random rand = new Random();
      //Creates numbers
      for (int i = 0; i < setLength; i++) {
        text.Append(rand.Next(1, 21));
        if (i != setLength - 1)
          text.Append("\n"); 
      }
      // Tries to write to a file
      if (name.EndsWith(".txt"))
        fileName = $"./{name}";
      else
        fileName = $"./{name}.txt";
      try {
        File.WriteAllText(fileName, text.ToString());
        return true;
      } catch {
        fileName = null;
        return false;
      }
    }
  }
}