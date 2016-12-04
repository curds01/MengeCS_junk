using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MengeCS
{
    /// <summary>
    /// Wrapper for Menge::SimulatorBase
    /// </summary>
    public class Simulator
    {   
        /// <summary>
        /// Constructor.
        /// </summary>
        public Simulator() {
            _agents = new List<Agent>();
        }

        public bool Initialize(String behaviorXml, String sceneXml, String model)
        {
            // TODO: Initialize from scene, behavior, and model.
            const float RADIUS = 5;
            const int COUNT = 20;
            const float dTheta = 2.0f * (float)Math.PI / COUNT;
            for (int i = 0; i < COUNT; ++i)
            {
                float theta = dTheta * i;
                float c = (float)Math.Cos(theta);
                float s = (float)Math.Sin(theta);
                Agent agt = new Agent();
                agt._pos = new Vector2(c * RADIUS, s * RADIUS);
                _agents.Add(agt);
            }
            return true;
        }

        /// <summary>
        /// The number of agents in the simulation.
        /// </summary>
        public int AgentCount { get { return _agents.Count;} }

        /// <summary>
        /// Returns the ith agent.
        /// </summary>
        /// <param name="i">Index of the agent to retrieve.</param>
        /// <returns>The ith agent.</returns>
        public Agent GetAgent( int i ) {
            return _agents[i];
        }

        /// <summary>
        /// The simulation time step.
        /// </summary>
        public float TimeStep { get { return _timeStep;} set { _timeStep = value;}}
        private float _timeStep = 0.1f;

        /// <summary>
        /// Advances the simulation by the current time step.
        /// </summary>
        /// <returns>True if evaluation is successful and the simulation can proceed.</returns>
        public bool DoStep() {
            const float THETA = (float)Math.PI / 100;
            float c = (float)Math.Cos(THETA);
            float s = (float)Math.Sin(THETA);
            Vector2 newPos = new Vector2();
            foreach (Agent agt in _agents)
            {
                newPos.X = agt.Position.X * c + agt.Position.Y * s;
                newPos.Y = -agt.Position.X * s + agt.Position.Y * c;
                agt._pos.Set(newPos);
            }
            return true;
        }

        /// <summary>
        /// The agents in the simulation.
        /// </summary>
        private List<Agent> _agents;
    }
}
