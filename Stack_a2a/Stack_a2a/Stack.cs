using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/************************************************
 * References Used: 
 * https://www.geeksforgeeks.org/implement-a-stack-using-singly-linked-list/?ref=gcse
 * https://www.geeksforgeeks.org/nested-classes-in-c-sharp/
 * 
 ************************************************/

namespace Stack_a2a
{
    public class Stack
    {
        // nested class
        private class Node
        {
            public string data;
            public Node link;   // reference variable to next node
        }

        // variables
        private Node top;

        // constructor
        public Stack()
        {
            this.top = null;
        }

        public void push(string s)
        {
            Node temp = new Node(); // create new node

            // set up new node
            temp.data = s;
            temp.link = top;

            // update "top"
            top = temp;
        }
        
        public bool pop()
        {
            // if the stack is empty
            if (top == null)
            {
                Console.WriteLine("Stack Underflow");
                return false;
            }

            // update the top to the node underneath
            top = top.link;
            return true;
        }

        public bool isEmpty()
        {
            return top == null;
        }

        // we don't actually need this method
        //public string peek()
        //{
        //    if (!isEmpty())
        //    {
        //        return top.data;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Stack is empty");
        //        return "";
        //    }
        //}
    }
}
