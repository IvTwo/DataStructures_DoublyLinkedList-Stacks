/****************************************************
 * The time complexity for this algorithm is O(n^2)
 * 
 * See code for breakdown of the time complexity.
 ****************************************************/
namespace Stack_a2a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMenu();
        }

        // accept user input as a string
        public static void MyMenu()
        {
            bool keepGoing = true;
            
            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Welcome Bracket Balance Checker----!");
                Console.WriteLine();
                Console.WriteLine("\t1. Input String\n" + "\t2. Quit\n");
                
                switch (UserInput())    // handle user input O(1)
                {
                    case "1":
                        CheckBracketBalance();  // O(n^2)
                        break;

                    case "2":
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("---");
                        Console.WriteLine("Invalid Input!");
                        break;
                }

            }
        }

        // O(1)
        // return the user input
        public static string UserInput()
        {
            Console.Write("\t * Your Input: ");
            return Console.ReadLine();
        }

        // Worst case scenario is O(n^2)
        public static void CheckBracketBalance()
        {
            Console.WriteLine("---");
            Console.WriteLine("Input your string");
            string uInput = UserInput();
            bool unbalanced = false;

            MyStack stack = new MyStack();  // create a stack object

            // check the string character by character
            for(int i = 0; i < uInput.Length; i++)      // O(n)
            {
                if (uInput[i].Equals('{'))
                {
                    stack.push(i);  // O(1)
                }
                else if (uInput[i].Equals('}'))
                {
                    bool didPop = stack.pop();  // O(1)

                    // brackets are unbalanced, too many }
                    if (!didPop)
                    {
                        Console.WriteLine("---");
                        Console.WriteLine("Brackets are Unbalanced!");
                        unbalanced = true;

                        int pos1 = i - 5;   // start of substring
                        while (pos1 < 0)    // O(1) --> worst case is 5 iteration
                        {
                            pos1++;
                        }

                        int pos2 = 11;      // end of substring
                        while (pos2 + pos1 > uInput.Length)     // O(1) --> worst case is 11 iterations
                        {
                            pos2--;
                        }

                        Console.WriteLine("The first imbalanced bracket is at: " + "-" + uInput.Substring(pos1, pos2) + "-");   // O(1)
                    }
                }
            }

            // this block is equal to O(n)
            if (stack.isEmpty() && !unbalanced)
            {
                Console.WriteLine("---");
                Console.WriteLine("{ The brackets are Balanced :) }");
            }
            else if (!unbalanced)   // brackets are unbalanced, too many {
            {
                Console.WriteLine("---");
                Console.WriteLine("Brackets are Unbalanced!");

                // get the first instance of an unbalanced {
                int temp = -1;
                while (!stack.isEmpty())    // O(n)
                {
                    temp = stack.peek();
                    stack.pop();
                }

                int pos1 = temp - 5;   // start of substring
                while (pos1 < 0)    // O(1)
                {
                    pos1++;
                }

                int pos2 = 11;         // end of substring
                while (pos2 + pos1 > uInput.Length)     // O(1)
                {
                    pos2--;
                }

                Console.WriteLine("The first imbalanced bracket is at: " + "-" + uInput.Substring(pos1, pos2) + "-");   // O(1)
            }
        }
    }
}