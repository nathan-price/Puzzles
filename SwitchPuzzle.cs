using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int lights = 9, switches = 8;
            Solve(lights, switches);
            Console.ReadKey();
        }
        public static void Solve(int lights, int numswitches)
        {
            bool[] field = new bool[lights], test = new bool[lights], best = new bool[lights];
            for (int i = 0; i < lights; i++) field[i] = true;
            List<int>[] switches = new List<int>[numswitches];
            Random random = new Random();
            int wire, score = lights, prev = -1;

            field.CopyTo(test, 0);
            field.CopyTo(best, 0);
            for (int i = 0; i < numswitches; i++)
            {
                Console.Write("Switch {0}: ", i + 1);
                switches[i] = new List<int>();
                int size = random.Next(lights / 3, 2 * lights / 3);
                for (int j = 0; j < size; j++)
                {
                    do wire = random.Next(0, lights); while (switches[i].Contains(wire));
                    switches[i].Add(wire);
                    Console.Write("{0} ", wire + 1);
                }
                Console.WriteLine("");
            }
            Print(test);
            for (int i = 0; i < 100 * lights; i++)
            {
                do wire = random.Next(0, numswitches); while (wire == prev);
                prev = wire;
                Console.Write("{0} ", wire + 1);
                foreach (int bulb in switches[wire]) test[bulb] = !test[bulb];
                int s = Score(test);
                if (s < score)
                {
                    test.CopyTo(best, 0);
                    score = s;
                    if (score == 0) break;
                }
                //Print(field);
            }
            Console.Write("\nScore {0}: ", score);
            Print(best);
        }
        public static void Print(bool[] bools)
        {
            foreach (bool b in bools) Console.Write((b) ? "1 " : "0 ");
            Console.WriteLine("");
        }
        public static int Score(bool[] bools)
        {
            int score = 0;
            foreach (bool b in bools)
            {
                if (b) score++;
            }
            return score;
        }
    }
}
