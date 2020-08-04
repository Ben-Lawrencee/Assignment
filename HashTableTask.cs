using System;
using System.IO;
using System.Collections;
namespace Assignment {
  public class HashTableTask {
    public static void run() {
      // String[] tableContent = File.ReadAllLines("E:/fileCharacter.txt");
      String[] tableContent = {"Banana", "Banana", "Orange", "Apple", "Strawberry"};
      Hashtable hashtable = new Hashtable();
      for (int i = 0; i < tableContent.Length; i++) {
        if (tableContent[i].Length == 0) continue;
        hashtable.Add(i, tableContent[i]);
      }
      Console.WriteLine("Most common string is : {0}", getStringFrequency(hashtable));
      Console.WriteLine("Most common character is : {0}", getCharFrequency(hashtable));
      //Best case scenario
      Console.WriteLine("Best case scenario :");
      hashtable = new Hashtable();
      Random rand = new Random();
      int value = 0;
      Console.WriteLine("Table: ");
      for (int i = 0; i < 10; i++) {
        value = rand.Next(1, 11);
        hashtable.Add(i, value);
        Console.WriteLine("'" + i + "': " + value);
      }
      Console.WriteLine("Worst case scenario");
      for (int i = 0; i < 10; i++) {
        value = rand.Next(1,11);
        hashtable.Add(0, value);
        Console.WriteLine("'" + 0 + "': " + value);
      }
    }
    public static String getStringFrequency(Hashtable hashtable) { //Loops through table and finds the most reoccuring string
      int score;
      int highest = 0;
      String highestString = "";
      int i = 0;
      int j;
      foreach (DictionaryEntry a in hashtable) { //Loops through table.Count - 1
        j = 0;
        score = 1;
        foreach (DictionaryEntry b in hashtable) { //loops through all strings after first loop's index
          if (i == j) continue;
          if (a.Value.ToString().ToLower() == b.Value.ToString().ToLower()) score++; //If found a duplicate. Increment score
          j++;
        }
        i++;
        //Updates the highest score if there is one
        if (score > highest) {
          highest = score;
          highestString = a.Value.ToString().ToLower();
        }
        score = 0;
      }
      return highestString; //Returns the most reoccured string
    }
    public static String getCharFrequency(Hashtable hashtable) { //Loops through table and finds the most reoccuring character
      int[] charScores = new int[255]; //Creates an array to store characters scores. Index = characters ascii code
      String toLower;
      int highest = 0;
      int highestIndex = 0;
      int value;
      //Counts each character in each string in the table
      foreach (DictionaryEntry i in hashtable) { //Loops through each string in the table
        toLower = i.Value.ToString().ToLower();
        foreach (char j in toLower) { //Loops through each character in a string
          charScores[j]++; //Increments that characters score
        }
      }
      //Loops through the characters scores
      for (int i = 0; i < charScores.Length; i++) {
        value = charScores[i];
        if (value != 0 && value > highest) { //Updates highest score if there is one
          highest = value;
          highestIndex = i;
        } 
      }
      return ((char)highestIndex).ToString(); //Returns the character with the highest occurance
    }
  }
}