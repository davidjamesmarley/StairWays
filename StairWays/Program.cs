using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace StairWays
{
    class Program
    {
        static int GetSteps()
        {
            Console.Write("Total Steps: ");
            string stepString = Console.ReadLine();
            int i;
            if (int.TryParse(stepString, out i))
            {
                return i;
            }
            throw new Exception("Could not parse the total steps.");
        }

        static int[] GetIncrements()
        {
            Console.Write("Increments: ");
            string[] incStrings = Console.ReadLine().Split(',');
            List<int> ints = new List<int>();
            foreach (string incString in incStrings)
            {
                int i;
                if (int.TryParse(incString, out i))
                {
                    ints.Add(i);
                }
                else
                {
                    throw new Exception("Could not parse the increments.");
                }
            }
            return ints.ToArray();
        }

        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter an array of allowable step increments, for example 2,3,4 or \"2, 3, 4\". \nThen the total number of steps, for example 5. \nTo exit enter Ctrl + C.\n");

                    //int[] inc = new int[] {2,3};
                    //int tot = 6;
                    int[] inc = GetIncrements();
                    int tot = GetSteps();

                    int val = numWays(inc, tot);

                    Console.Write(String.Format("\nThere is {0} way to climb {1} steps using increments of [", val, tot));
                    for (int i = 0; i < inc.Length; i++)
                    {
                        Console.Write("{0}", inc[i]);
                        if (i != inc.Length - 1) Console.Write(",");
                    }
                    Console.WriteLine("].\n");

                    Console.Write("Press enter to continue . . . ");
                    Console.ReadLine();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.Write("\nError: " + ex.Message + "\n");
                    Console.Write("Press enter to try again . . . ");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        static int numWays(int[] incSteps, int totSteps)
        {
            int ret = 0;

            if (totSteps < incSteps.Min()) return 0;

            foreach (int incStep in incSteps)
            {
                if (totSteps == incStep)
                {
                    ret += 1;
                }
                else
                {
                    ret += numWays(incSteps, totSteps - incStep);
                }
            }

            return ret;
        }
    }
}
