﻿using System;

namespace DayOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[]
            {
                147077,
                148686,
                71851,
                98056,
                65024,
                87254,
                146003,
                128542,
                136657,
                91885,
                91904,
                78806,
                58210,
                67520,
                118393,
                68344,
                69593,
                135370,
                111892,
                84153,
                105683,
                76166,
                112780,
                145179,
                83811,
                61481,
                118277,
                59732,
                72222,
                64606,
                55645,
                82168,
                97590,
                122479,
                120365,
                103057,
                76225,
                148099,
                100610,
                75592,
                148678,
                132756,
                55335,
                77094,
                73992,
                95097,
                92382,
                78885,
                93657,
                121709,
                114261,
                90565,
                110043,
                145497,
                92066,
                109833,
                76107,
                143941,
                67084,
                139407,
                56730,
                131457,
                110026,
                85632,
                74239,
                116964,
                129806,
                75030,
                76317,
                99523,
                78069,
                75685,
                81279,
                58287,
                148135,
                89313,
                139141,
                136066,
                94046,
                50430,
                55242,
                123494,
                68410,
                83716,
                122608,
                79343,
                88826,
                95968,
                98603,
                104895,
                128814,
                120473,
                97504,
                60990,
                98132,
                58895,
                92987,
                136301,
                131747,
                137498
            };
            
            var total = 0;
            foreach (var module in input)
            {
                int fuel = 0;
                CalculateFuel(module, ref fuel);

                total += fuel;
            }

            Console.WriteLine(total);
        }

        public static int CalculateFuel(int input, ref int output)
        {
            var fuel = (int)Math.Floor((decimal)(input / 3)) - 2;                      

        //    Console.WriteLine($"{fuel} / {output}");

            if (fuel > 0)
            {
                output += fuel;
                CalculateFuel(fuel, ref output);
            }

            return output;
        }
    }
}
