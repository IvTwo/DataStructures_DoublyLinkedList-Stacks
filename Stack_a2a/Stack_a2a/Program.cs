namespace Stack_a2a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        // accept user input as a string
        public void userInput()
        {
            bool keepGoing = true;
            
            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome Bracket Balance Checker----!");
                Console.WriteLine();
                Console.WriteLine("\t1. Input String\n" + "\t2. Quit\n");
                
                switch (UserInput())    // handle user input
                {
                    case "1":
                        CheckBracketBalance();
                        break;

                    case "2":
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid Input!");
                        break;
                }

            }
        }

        // return the user input
        public static string UserInput()
        {
            Console.Write("\t * Your Input: ");
            return Console.ReadLine();
        }

        public static void CheckBracketBalance()
        {
            Console.WriteLine("---");
            Console.WriteLine("Input your string");
            string uInput = UserInput();

            // check the string character by character
            for(int i = 0; i < uInput.Length; i++)
            {
                if (uInput[i].Equals("{"))
                {
                    // push
                }
                else if (uInput[i].Equals("}"))
                {
                    //pop
                }
            }
        }
    }
}