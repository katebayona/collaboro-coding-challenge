using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCCodeBox
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeBox codeBox;
            string input;
            bool isExit = false;

            Console.WriteLine("--- SECRET CODE PART 2 ---");
            Console.WriteLine(Environment.NewLine);

            while (!isExit)
            {
                codeBox = new CodeBox();

                Console.WriteLine("Enter values in the code box in the format <code><value>.\n" +
                    "For example: 1C\n\nEntering a blank line signals the end of input.\nEnter 'X' to exit the application.\n");
                Console.Write("Code Box value : ");

                input = Console.ReadLine();

                if (input.ToUpper() == "X")
                {
                    isExit = true;
                }
                else
                {
                    while (!string.IsNullOrEmpty(input))
                    {
                        if (!codeBox.Add(input.Trim()))
                            Console.WriteLine(codeBox.validationMessage);
                        Console.Write("Code Box value : ");
                        input = Console.ReadLine();
                    }

                    Console.WriteLine("\nCode Box: " + codeBox.codeBoxValues);

                    Console.WriteLine("\nEnter code values in the format <code> separated by a comma.\nFor example: 11,3,7,8");

                    bool isDecode = false;

                    Console.Write("Code values : ");

                    input = Console.ReadLine();

                    while (!isDecode)
                    {
                        if (!codeBox.Decode(input.Trim()))
                        {
                            Console.WriteLine(codeBox.validationMessage);
                            Console.Write("Code values : ");
                            input = Console.ReadLine();
                        }
                        else
                        {
                            isDecode = true;
                            Console.WriteLine("Solution is: " + codeBox.result + Environment.NewLine);
                        }
                    }
                }
            }
            Console.WriteLine("--- EXIT ---");
        }
    }
}
