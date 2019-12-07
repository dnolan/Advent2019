using System;
using System.Collections.Generic;
using System.Text;

namespace DayFive
{
    class IntCodeComputer
    {
        private int[] m_Memory;
        private string m_Input;

        //public void GetNounVerb()
        //{
        //    m_Memory = LoadMemory(m_Input);

        //    for (var noun = 0; noun < 100; noun++)
        //    {
        //        for (var verb = 0; verb < 100; verb++)
        //        {
        //            m_Memory[1] = noun;
        //            m_Memory[2] = verb;

        //            var result = GetOutput(m_Memory);

        //            if (result == 19690720)
        //            {
        //                Console.WriteLine(noun);
        //                Console.WriteLine(verb);
        //            }

        //            m_Memory = LoadMemory(m_Input);
        //        }
        //    }
        //}

        internal void Input(string input)
        {
            m_Input = input;
        }

        public int[] LoadMemory()
        {
            var inputArray = m_Input.Split(',');
            var memory = new int[inputArray.Length];
            for (var i = 0; i < inputArray.Length; i++)
            {
                memory[i] = int.Parse(inputArray[i]);
            }

            return m_Memory = memory;
        }

        public int GetOutput()
        {
            var memory = m_Memory;
            var address = 0;
            while (true)
            {
                var opCodeFull = memory[address];
                var opCode = opCodeFull % 100;
                var opParams = ParseParams(opCodeFull);

                if (opCode == 99)
                {
                    return memory[0];
                }

                if (opCode == 3)
                {
                    Console.WriteLine("Input:");
                    var input = Convert.ToInt32(Console.ReadLine());

                    if (opParams[0] == 0)
                    {
                        memory[memory[address + 1]] = input;
                    }
                    else
                    {
                        memory[address + 1] = input;
                    }

                    address += 2;

                    continue;
                }

                if (opCode == 4)
                {
                    if (opParams[0] == 0)
                    {
                        Console.WriteLine(memory[memory[address + 1]]);
                    }
                    else
                    {
                        Console.WriteLine(memory[address + 1]);
                    }

                    address += 2;
                    continue;
                }


                var numLeft = opParams[0] == 0 ? memory[memory[address + 1]] : memory[address + 1];
                var numRight = opParams[1] == 0 ? memory[memory[address + 2]] : memory[address + 2];

                if (opCode == 5)
                {
                    if (numLeft != 0)
                    {
                        address = numRight;
                        continue;
                    }

                    address += 3;
                    continue;
                }

                if (opCode == 6)
                {
                    if (numLeft == 0)
                    {
                        address = numRight;
                        continue;
                    }

                    address += 3;
                    continue;
                }

                var outputAddress = opParams[2] == 0 ? memory[address + 3] : address + 3;

                if (opCode == 7)
                {
                    memory[outputAddress] = numLeft < numRight ? 1 : 0;
                    address += 4;
                    continue;
                }

                if (opCode == 8)
                {
                    memory[outputAddress] = numLeft == numRight ? 1 : 0;
                    address += 4;
                    continue;
                }

                int result = 0;

                if (opCode == 1)
                {
                    result = numLeft + numRight;
                }
                else if (opCode == 2)
                {
                    result = numLeft * numRight;
                }
                
                memory[outputAddress] = result;

                address += 4;
            }

            return 0;
        }

        private static int[] ParseParams(int opCodeFull)
        {
            var param = new int[3];
            opCodeFull = opCodeFull / 100;
            for (int i = 0; i < 3; i++)
            {
                param[i] = opCodeFull % 10;
                opCodeFull = opCodeFull / 10;

                if (opCodeFull <= 0)
                {
                    continue;
                }
            }

            return param;
        }
    }
}
