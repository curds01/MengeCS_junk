#pragma once
#include "Agent.h"
#include "SimulatorInterface.h"

namespace MengeCS {
	public ref class Simulator {
	public:
		/*! Constuctor. */
		// TODO: Initialize with files and arguments.
		Simulator();

		/*! Reports the number of agents in the simulator. */
		size_t GetAgentCount();

		/*! Retrieves the ith agent; null if i is outside the valid range of indices. */
		Agent^ GetAgent( size_t i );

		/*! Sets the time duration of subsequent simulation steps (see DoStep()). */
		void SetTimeStep( float timeStep );

		/*! Advance the simulation by one time step. */
		void DoStep();

	private:
		Menge::Agents::SimulatorInterface * _simulator;
	};
}