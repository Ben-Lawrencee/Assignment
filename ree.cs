// using System;
// using System.IO;
// using System.Collections.Generic;
// namespace Assignment {
//   class Program {
//     static void Main(string[] args) {
//       Console.Clear();
//       //Array
//       Console.Write("Displaying numbers: \n[");
//       String[] content = File.ReadAllText("./numbers.txt").Split("\n");
//       int[] numbers = new int[content.Length];
//       for (int i = 0; i < content.Length; i++) {
//         try {
//           numbers[i] = int.Parse(content[i]);
//           if (i == numbers.Length - 1) Console.Write("{0}", numbers[i]);
//           else Console.Write("{0},", numbers[i]);
//         } catch {
//           Console.WriteLine("Error converting to number: {0}", content[i]);
//           return;
//         }
//       }
//       Console.Write("]\nDisplaying primes: \n[");
//       for (int i = 0; i < numbers.Length; i++) {
//         if (isPrime(i)) {
//           if (i == numbers.Length - 1) Console.Write("{0}", i);
//           else Console.Write("{0},", i);
//         }
//       }
//       //Doubly linked list:
//       Console.Write("]\nDoubly Linked List\n");
//       LinkedList<int> linkedNumbers = new LinkedList<int>();
//       linkedNumbers = addToLinkedListInt(linkedNumbers, File.ReadAllText("./linkedNumbers1.txt").Split("\n"));
//       linkedNumbers = addToLinkedListInt(linkedNumbers, File.ReadAllText("./linkedNumbers2.txt").Split("\n"));
//       linkedNumbers = addToLinkedListInt(linkedNumbers, File.ReadAllText("./linkedNumbers3.txt").Split("\n"));
//       int middle = (int)Math.Floor((decimal)linkedNumbers.Count / 2);
//       LinkedListNode<int> node = linkedNumbers.First;
//       for (int i = 0; i < linkedNumbers.Count; i++) {
//         if (i == middle) Console.WriteLine("Middle node: {0}", node.Value);
//         node = node.Next;
//       }
//       node = linkedNumbers.First;
//       Console.WriteLine("Displaying prime numbers in Linked List\n");
//       for (int i = 0; i < linkedNumbers.Count; i++) {
//         if (isPrime(node.Value)) Console.Write("[{0},{1}]", i, node.Value);
//         node = node.Next;
//       }
//       Console.WriteLine("\nBinary Search Trees");
      
//     }
//     static LinkedList<int> addToLinkedListInt(LinkedList<int> list, String[] input) {
//       foreach (String content in input) {
//         if (list.Count == 0) list.AddFirst(int.Parse(content));
//         else list.AddAfter(list.Last, int.Parse(content));
//       }
//       return list;
//     }
//     static int[] createNumberArray(String[] content) {
//       int[] numbers = new int[content.Length];
//       for (int i = 0; i < content.Length; i++) {
//         try {
//           numbers[i] = int.Parse(content[i]);
//         }
//         catch {
//           Console.WriteLine("Error converting to number: {0}", content[i]);
//           return null;
//         }
//       }
//       return numbers;
//     }
//     private static Boolean isPrime(int n) {
//       Boolean b = true;
//       int max = (int)Math.Sqrt((double)n);
//       for (int i = 2; i <= max; i++) {
//         if ((n % i) == 0) {
//           b = false;
//           break;
//         }
//       }
//       return (b);
//     }
//   }
// }
