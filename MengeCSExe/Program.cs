using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MengeCS;
using System.Runtime.InteropServices;

namespace MengeCSExe
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator sim = new Simulator();
            String behaveXml = @"E:\work\projects\menge_fork\examples\core\cross\crossB.xml";
            String sceneXml = @"E:\work\projects\menge_fork\examples\core\cross\crossS.xml";
            if (sim.Initialize(behaveXml, sceneXml, "orca"))
            {
                System.Console.WriteLine("New simulator created.");
                System.Console.WriteLine("\t{0} agents", sim.AgentCount);
                for (int i = 0; i < sim.AgentCount; ++i)
                {
                    System.Console.WriteLine(sim.GetAgent(i).ToString());
                }
                for (int i = 0; i < 20; ++i)
                {
                    System.Console.WriteLine("Step {0}", i + 1);
                    if (!sim.DoStep())
                    {
                        System.Console.WriteLine("Simulation done...quitting");
                        break;
                    }
                    for (int a = 0; a < sim.AgentCount; ++a)
                    {
                        Agent agt = sim.GetAgent(a);
                        Vector3 p = agt.Position;
                        System.Console.WriteLine("\tAgent {0} at ({1}, {2})", a, p.X, p.Z);
                    }
                }

            }
            else
            {
                System.Console.WriteLine("Error initializing simulation");
            }
        }
    }
}
