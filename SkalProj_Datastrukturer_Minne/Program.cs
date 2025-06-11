using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. ReverseText"
                    + "\n6. RecursionMenu"
                    + "\n7. IterationMenu"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        ReverseText();
                        break;
                    case '6':
                        RecursionMenu();
                        break;
                    case '7':
                        IterationMenu();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }


        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            List<string> theList = new();
            bool running = true;
            while (running)
            {
                Console.WriteLine
                (
                      "E. Exit to the main menu"
                    + "\n+. Add following input after '+' to the list"
                    + "\n-. Remove following input after '+' to the list"
                );

                string input = Console.ReadLine() ?? string.Empty;
                char nav = input[0];
                string restOfString = input.Substring(1);


                switch (nav) 
                {
                    case 'E':
                        running = false;
                        break;
                    case '+':
                        theList.Add(restOfString);
                        Console.WriteLine($"Count: {theList.Count} Capacity: {theList.Capacity}");
                        break;
                    case '-':
                        theList.Remove(restOfString);
                        Console.WriteLine($"Count: {theList.Count} Capacity: {theList.Capacity}");
                        break;
                    default:
                        Console.WriteLine("Type either + or - first");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Console.WriteLine
            (
                "E. Exit to the main menu"
                + "\nR. Remove from queue"
                + "\n<anything>. Add to queue"
            );
            Queue<string> queue = new();
            bool running = true;
            while (running)
            {
                string input = Console.ReadLine() ?? string.Empty;
                switch (input)
                {
                    case "E":
                        running = false;
                        break;
                    case "R":
                        if (queue.Count > 0) 
                            Console.WriteLine(queue.Dequeue() + " has been removed from the queue");
                        break;
                    default:
                        queue.Enqueue(input);
                        Console.WriteLine($"{input} has been added to the queue"); 
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            
            Stack<string> stack = new();

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine
                (
                    "E. Exit to the main menu"
                    + "\nR. Pop from stack"
                    + "\n<anything>. Add to stack"
                );

                string input = Console.ReadLine()!;


                switch (input)
                {
                    case "E":
                        running = false;
                        break;
                    case "R":
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Pop() + " has been removed from the stack");
                        break;
                    default:
                        stack.Push(input);
                        Console.WriteLine($"{input} has been added to the stack");
                        break;
                }
            }
        }

        static void ReverseText()
        {
            Console.WriteLine("Type some text to reverse");

            string input = Console.ReadLine() ?? string.Empty;

            Stack<char> stack = new();

            foreach (char character in input)
                stack.Push(character);

            while (stack.Count > 0)
                Console.Write(stack.Pop());
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("Write a well shaped string meaning brackets are opened and closed in right order"
                + "\n[](){}[()]");


            string input = Console.ReadLine() ?? string.Empty;
            string onlyBrackets = Regex.Replace(input, @"[^\[\]{}()]", "");

            Dictionary<char, char> bracketPairs = new();

            bracketPairs.Add('(', ')');
            bracketPairs.Add('[', ']');
            bracketPairs.Add('{', '}');

            Stack<char> openingBrackets = new();
            bool wellShaped = true;

            foreach (char bracket in onlyBrackets)
            {
                if (bracketPairs.ContainsKey(bracket)) // Is an opening bracket
                {
                    openingBrackets.Push(bracket);
                }
                else if (openingBrackets.Count > 0 && bracketPairs[openingBrackets.Peek()] == bracket) //Is a matching closing bracket
                {
                    openingBrackets.Pop();
                }
                else
                {
                    wellShaped = false;
                    break;
                }
            }

            if (openingBrackets.Count != 0) // Don't want to leave any opening bracket left unchecked
            {
                wellShaped = false;
            }

            if (wellShaped)
            {
                Console.WriteLine("String is well shaped");
            }
            else
            {
                Console.WriteLine("String is not well shaped");
            }

        }

        static int RecursiveEven(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            return RecursiveEven(n - 1) + 2;
        }
        static int RecursiveFibonacci(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            return (RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2));
        }
        private static void RecursionMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine
                (
                    "E. Exit to the main menu"
                    + "\nR. RecursiveEven ex 5"
                    + "\nF. RecursiveFibonacci ex 10"
                );

                string input = Console.ReadLine()!;


                switch (input)
                {
                    case "E":
                        running = false;
                        break;
                    case "R":
                        Console.WriteLine(RecursiveEven(5));
                        break;
                    case "F":
                        Console.WriteLine(RecursiveFibonacci(10));
                        break;
                    default:
                        break;
                }
            }
        }
        static int IterativeEven(int n)
        {
            int result = 0;

            for(int i = 0; i < n; i++)
            {
                result += 2;
            }
            return result;
        }
        static int IterativeFibonacci(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            int result = 0;

            int fib1 = 0;
            int fib2 = 1;
            
            for (int i = 2; i <= n; i++)
            {
                int newFib = fib1 + fib2;
                fib1 = fib2;
                fib2 = newFib;
            }

            return result;
        }



        private static void IterationMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine
                (
                    "E. Exit to the main menu"
                    + "\nR. IterativeEven ex 5"
                    + "\nF. IterativeFibonacci ex 10"
                );

                string input = Console.ReadLine()!;


                switch (input)
                {
                    case "E":
                        running = false;
                        break;
                    case "R":
                        Console.WriteLine(IterativeEven(5));
                        break;
                    case "F":
                        Console.WriteLine(IterativeFibonacci(10));
                        break;
                    default:
                        break;
                }
            }
        }

    }
}

