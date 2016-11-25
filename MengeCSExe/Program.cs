using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MengeCS;

namespace MengeCSExe
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator sim = new Simulator();
            System.Console.WriteLine("New simulator created.");
            System.Console.WriteLine("\t{0} agents", sim.GetAgentCount());
            for (uint i = 0; i < sim.GetAgentCount(); ++i)
            {
                System.Console.WriteLine(sim.GetAgent(i).ToString());
            }
        }
    }
}
