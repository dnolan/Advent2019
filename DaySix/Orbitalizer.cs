using System;
using System.Collections.Generic;
using System.Linq;

namespace DaySix
{
    class Orbitalizer
    {
        private readonly string m_Input;

        private class Satellite
        {
            public Satellite()
            {
                Satelites = new List<Satellite>();
            }

            public int Direct { get; set; }
            public string Id { get; set; }
            public string ParentId { get; set; }

            public Satellite Parent { get; set; }

            public List<Satellite> Satelites { get; set; }
            public int Level { get; internal set; }

            public void AddSatellite(Satellite sat)
            {
                Satelites.Add(sat);
            }

            public override string ToString()
            {
                return $"{Id}:{ParentId}";
            }

            internal int Indirect(int level = 0)
            {
                if (Parent != null)
                {
                    level++;
                    return Parent.Indirect(level);
                }
                else
                {
                    return level;
                }
            }
        }

        public Orbitalizer(string input)
        {
            m_Input = input;
        }

        public void Analyse()
        {
            var objectList = new List<Satellite>();

            var instructions = m_Input.Split(Environment.NewLine);

            var com = new Satellite { Id = "COM" };
            objectList.Add(com);

            foreach (var instruction in instructions)
            {
                var split = instruction.Split(')');
                var parentId = split[0];
                var satelliteId = split[1];

                var satellite = new Satellite
                {
                    Id = satelliteId,
                    ParentId = parentId
                };

                objectList.Add(satellite);
            }

            foreach (var obj in objectList)
            {
                if (obj.ParentId == null) continue;

                obj.Parent = objectList.SingleOrDefault(o => o.Id == obj.ParentId);

                if (obj.Parent != null)
                {
                    obj.Parent.AddSatellite(obj);
                    obj.Parent.Direct += 1;
                }
            }

            SetLevels(com);

            OutputOrbit(com);
            var orbits = objectList.Sum(o => o.Level);

            Console.WriteLine(orbits);
        }

        private void SetLevels(Satellite sat, int level = 0)
        {
            sat.Level = level;
            foreach (var child in sat.Satelites)
            {
                SetLevels(child, level + 1);
            }
        }

        private void OutputOrbit(Satellite sat)
        {
            Console.WriteLine($"{RepeatPadLeft("-", sat.Level)} {sat.Id}");
            
            foreach (var child in sat.Satelites)
            {
                OutputOrbit(child);
            }
        }

        static string RepeatPadLeft(string s, int n)
        {
            return "".PadLeft(n, 'X').Replace("X", s);
        }
    }
}
