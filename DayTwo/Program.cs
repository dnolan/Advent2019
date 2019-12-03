using System;

namespace DayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,6,1,19,1,5,19,23,1,13,23,27,1,6,27,31,2,31,13,35,1,9,35,39,2,39,13,43,1,43,10,47,1,47,13,51,2,13,51,55,1,55,9,59,1,59,5,63,1,6,63,67,1,13,67,71,2,71,10,75,1,6,75,79,1,79,10,83,1,5,83,87,2,10,87,91,1,6,91,95,1,9,95,99,1,99,9,103,2,103,10,107,1,5,107,111,1,9,111,115,2,13,115,119,1,119,10,123,1,123,10,127,2,127,10,131,1,5,131,135,1,10,135,139,1,139,2,143,1,6,143,0,99,2,14,0,0";
                   
            var memory = LoadMemory(input);

            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    memory[1] = noun;
                    memory[2] = verb;

                    var result = GetOutput(memory);

                    if (result == 19690720)
                    {
                        Console.WriteLine(noun);
                        Console.WriteLine(verb);
                        return;
                    }

                    memory = LoadMemory(input);
                }
            }

        }

        private static int[] LoadMemory(string input)
        {
            var inputArray = input.Split(',');
            var memory = new int[inputArray.Length];
            for (var i = 0; i < inputArray.Length; i++)
            {
                memory[i] = int.Parse(inputArray[i]);
            }

            return memory;
        }

        private static int GetOutput(int[] memory)
        {
            for (var address = 0; address < memory.Length; address += 4)
            {
                var numLeft = memory[memory[address + 1]];
                var numRight = memory[memory[address + 2]];
                int result = 0;

                if (memory[address] == 1)
                {
                    result = numLeft + numRight;
                }
                else if (memory[address] == 2)
                {
                    result = numLeft * numRight;
                }
                else if (memory[address] == 99)
                {
                    return memory[0];
                }

                memory[memory[address + 3]] = result;
            }

            return 0;
        }
    }
}
