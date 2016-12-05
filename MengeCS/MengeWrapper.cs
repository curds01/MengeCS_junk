using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MengeCS
{
    class MengeWrapper
    {
        [DllImport("MengeCore.dll")]
        public static extern bool InitSimulator([MarshalAs(UnmanagedType.LPStr)] String behaveFile,
                                                [MarshalAs(UnmanagedType.LPStr)] String sceneFile,
                                                [MarshalAs(UnmanagedType.LPStr)] String model);

        [DllImport("MengeCore.dll")]
        public static extern uint AgentCount();

        
        [DllImport("MengeCore.dll")]
        public static extern float SetTimeStep(float timestep);

        [DllImport("MengeCore.dll")]
        public static extern bool DoStep();

        [DllImport("MengeCore.dll")]
        public static extern bool GetAgentPosition(uint i, ref float x, ref float y, ref float z);

        [DllImport("MengeCore.dll")]
        public static extern float GetAgentVelocity(uint i, ref float x, ref float y, ref float z);
    }
}
