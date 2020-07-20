using System;
namespace Assignment {
  public class HashTable {
    protected String[] table;
    protected decimal loadFactor;
    protected int occupied;
    public HashTable(int size) {
      //Creates table with given size
      if (size <= 1) { //If size is smaller or equal to 1. Throw exception
        throw new System.ArgumentException("Size must be larger than 1");
      }
      table = new String[size];
    }
    public HashTable(String[] array) {
      //Creates table with given array
      if (array.Length <= 1) { //If array size is smaller or equal to 1. Throw exception
        throw new System.ArgumentException("Size must be larger than 1");
      }
      table = new String[array.Length];
      //Adds content of array to table
      foreach (String i in array) {
        add(i);
      }
    }
    public String[] add(String input) { //Adds a given string to the table
      //Gets given string's hash
      int hash = getHash(input);
      if (loadFactor == 1) {
        Console.WriteLine("Table is full. Item not added");
        return table;
      }
      if (table[hash] != null) { //If index hash is occupied
        //Sets value to next unoccupied index
        int index = findOpen(hash); 
        table[index] = input;
      }
      else table[hash] = input; //Sets value to given hash index
      //Updates tables occupied and load factor properties
      occupied++;
      loadFactor = occupied / table.Length;
      return table;
    }
    public int findOpen() { //Find open with no given start
      return findOpen(0); //Returns next unoccupied index starting from 0
    }
    public int findOpen(int start) {
      int i = 0;
      if (loadFactor == 1) { //If table is full. Log it and return -1
        Console.WriteLine("Table is full");
        return -1;
      }
      //Finds next unoccupied index and returns it
      while (table[start + i] != null) { //While index + i is occupied
        i++;
        if ((start + i) >= table.Length) { //If reached the end of the array. Go to beginning
          i = 0;
          start = 0;
        }
      }
      return start + i;
    }
    public String get(String input) {
      int hash = getHash(input); //Gets hash from given string
      int i = hash;
      while (table[i] != input) { //While index hash + i doesn't equal input
        if (hash + i == table.Length) { //If reached the end of the table. Go to beginning
          i = 0;
        }
        i++;
        if (i == hash) { //If looped around to the hash. Return null
          Console.WriteLine("String not found");
          return null;
        }
      }
      return table[i];
    }
    public String getStringFrequency() { //Loops through table and finds the most reoccuring string
      int score = 0;
      int highest = 0;
      String highestString = "";
      String str1, str2;
      for (int i = 0; i < table.Length - 1; i++) { //Loops through table.length - 1
        str1 = table[i];
        for (int j = i + 1; j < table.Length; j++) { //loops through all strings after first loop's index
          str2 = table[j];
          if (str1.ToLower() == str2.ToLower()) score++; //If found a duplicate. Increment score
        }
        //Updates the highest score if there is one
        if (score > highest) {
          highest = score;
          highestString = str1;
        }
        score = 0;
      }
      Console.WriteLine(highest); //Logs the amount of reoccurance
      return highestString; //Returns the most reoccured string
    }
    public String getCharFrequency() { //Loops through table and finds the most reoccuring character
      int[] charScores = new int[255]; //Creates an array to store characters scores. Index = characters ascii code
      String toLower;
      int highest = 0;
      int highestIndex = 0;
      int value;
      //Counts each character in each string in the table
      foreach (String i in table) { //Loops through each string in the table
        toLower = i.ToLower();
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
    public String get(int index) { //Gets the value from a given index
      return table[index];
    }
    public int getHash(String str) { //Returns the hash from a given string for this table
      if (str.Length == 0) throw new System.ArgumentException("String must not be empty");
      int total = 0;
      //Gets the sum of the ascii characters from given string
      foreach(char i in str) //Loops through each character in the given string
        total = total + (int)i; //Adds up the ascii codes
      return total % table.Length; //Returns calculated index
    }
  }
}