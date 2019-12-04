using System;
using System.ComponentModel.DataAnnotations;

namespace DayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            var lower = 178416;
            var upper = 676461;


            var count = 0;
            for (var i = lower; i <= upper; i++)
            {
                var num = i.ToString();

                var increases = true;
                var duplicate = false;
                var last = -1;
                var lastLast = -2;
                var matchCount = 0;

                foreach (var s in num)
                {
                    var now = (int)char.GetNumericValue(s);
                    if (now == last)
                    {
                        matchCount += 1;
                    }
                    else
                    {
                        if (matchCount == 1)
                        {
                            duplicate = true;
                        }

                        matchCount = 0;
                    }

                    if (now < last)
                    {
                        increases = false;
                    }

                    lastLast = last;
                    last = now;
                }

                if (matchCount == 1)
                {
                    duplicate = true;
                }

                //if (duplicate)
                //{
                //    Console.WriteLine($"{i} contains dupe");
                //}

                //if (increases)
                //{
                //    Console.WriteLine($"{i} increases");
                //}

                if (duplicate && increases)
                {
                    Console.WriteLine($"{i} is a combo");
                    count++;
                }
            }

            Console.WriteLine($"{count} combinations found");
        }
    }
}
