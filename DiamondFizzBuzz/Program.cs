using System;

namespace Assessments
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDiamond(9);

            WriteFizzBuzz();
        }


        public static string RepeatNumber(int number, int maxNumber)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("");
            if(number <= maxNumber && number > 0)
            {
                string maxNum = maxNumber.ToString();
                string num = number.ToString();

                int repeatCount = (number * 2) - 1;
                for (int y = number; y < maxNumber; y++)
                {
                    for(int p=0; p<maxNum.Length; p++)
                        sb.Append(" ");
                }
                for (int x=1; x<=repeatCount; x++)
                {
                    for (int p = num.Length; p < maxNum.Length; p++)
                        sb.Append(" ");

                   sb.Append(number);
                }
            }

            return sb.ToString();
        }

        private static void CreateDiamond(int endNumber)
        {
            bool upDirection = true;
            System.Text.StringBuilder diamond = new System.Text.StringBuilder("");
            int number = 0;
            while(number >= 0)
            {
                if (number > 0) diamond.AppendLine(RepeatNumber(number,endNumber));
                

                if (number == endNumber) upDirection = false;
                

                if (upDirection) number++; else number--;
                
            }

            System.Console.WriteLine(diamond.ToString());

        }

        private static void WriteFizzBuzz()
        {
             int testCases = int.Parse(Console.ReadLine());

             string[] data = Console.ReadLine().Split(' ');

             for (int x= 0; x < testCases; x++)
             {
                 int number = int.Parse(data[x]);
                 for (int i = 1; i <= number; i++)
                 {
                     if (i % 3 == 0) Console.Write("Fizz");
                     
                     if (i % 5 == 0) Console.Write("Buzz");
                     
                     if (i % 3 != 0 && i % 5 != 0) Console.Write(i);
                     
                     Console.WriteLine("");
                 }
             }
        }
    }
}
