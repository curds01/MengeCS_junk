using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MengeCS;

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
                System.Console.WriteLine("\t{0} agents", sim.GetAgentCount());
                for (uint i = 0; i < sim.GetAgentCount(); ++i)
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
                    for (uint a = 0; a < sim.GetAgentCount(); ++a)
                    {
                        Agent agt = sim.GetAgent(a);
                        Vector2 p = agt.GetPosition();
                        System.Console.WriteLine("\tAgent {0} at ({1}, {2})", a, p.X(), p.Y());
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
