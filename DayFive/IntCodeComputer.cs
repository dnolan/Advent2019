using System;
using System.Collections.Generic;
using System.Text;

namespace DayFive
{
    class IntCodeComputer
    {
        private int[] m_Memory;
        private string m_Input;

        public void GetNounVerb()
        {
            m_Memory = LoadMemory(m_Input);

            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    m_Memory[1] = noun;
                    m_Memory[2] = verb;

                    var result = GetOutput(m_Memory);

                    if (result == 19690720)
                    {
                        Console.WriteLine(noun);
                        Console.WriteLine(verb);
                    }

                    m_Memory = LoadMemory(m_Input);
                }
            }
        }

        internal void Input(string input)
        {
            m_Input = input;
        }

        public int[] LoadMemory(string input)
        {
            var inputArray = input.Split(',');
            var memory = new int[inputArray.Length];
            for (var i = 0; i < inputArray.Length; i++)
            {
                memory[i] = int.Parse(inputArray[i]);
            }

            return m_Memory = memory;
        }

        private int GetOutput(int[] memory)
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
