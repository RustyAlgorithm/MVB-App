using System;
using CurrencyCalculator;

namespace CurrencyCalculator
{
    
	public class TypeOut
	{
        ConsoleSpiner s = new ConsoleSpiner();
        public void TypeLine(string line)
        {
            Console.Write("++ ");
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(75); // Sleep for 75 milliseconds
            }
            Console.Write(" ++");
            Thread.Sleep(100);
            Console.WriteLine();
        }
        public void TypeFast(string line)
        {
            Console.Write("++ ");
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(25); // Sleep for 55 milliseconds
            }
            Console.Write(" ++");
            Thread.Sleep(100);
            Console.WriteLine();
        }
        public void WaitLine(string line)
        {
            Console.Write("++ ");
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(1000); // Sleep for 1000 milliseconds
            }
            Console.Write(" ++");
            Thread.Sleep(100);
            Console.WriteLine();
        }
        public void WaitLine()
        {

            Console.CursorVisible = false;
            int i = 0;
            while (i < 5)
            {
                s.Turn();
                Thread.Sleep(250);
                s.Turn();
                Thread.Sleep(250);
                s.Turn();
                Thread.Sleep(250);
                s.Turn();
                Thread.Sleep(250);
                
                i++;
            }
            Console.CursorVisible = true;
            ClearCurrentConsoleLine();
            Console.WriteLine("...");
        }
        public void PauseLine(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(50); // Sleep for 1000 milliseconds
            }
            Thread.Sleep(100);
            Console.WriteLine("");
            Console.ReadLine();
        }
        public void TypeWait(String line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                Thread.Sleep(75); // Sleep for 1000 milliseconds
            }
            Thread.Sleep(1750);
        }
        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

    }
}

