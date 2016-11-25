#include "Stdafx.h"
#include "Simulator.h"
#include "SimulatorBase.h"

#include <cassert>

namespace MengeCS {
		
	Simulator::Simulator() {
		_simulator = new Menge::Agents::SimulatorBase<Menge::Agents::BaseAgent>();
	}

	// ---------------------------------------------------

	size_t Simulator::GetAgentCount() {
		assert( _simulator != 0x0 );
		return _simulator->getNumAgents();
	}

	// ---------------------------------------------------

	Agent^ Simulator::GetAgent( size_t i ) {
		assert( _simulator != 0x0 );
		Menge::Agents::BaseAgent * agt = _simulator->getAgent( i );
		if ( agt != 0x0 ) {
			return gcnew Agent( agt );
		}
		return nullptr;
	}

	// ---------------------------------------------------

	void Simulator::SetTimeStep( float timestep ) {
		assert( _simulator != 0x0 );
		_simulator->setTimeStep( timestep );
	}

	// ---------------------------------------------------

	void Simulator::DoStep() {
		assert( _simulator != 0x0 );
		_simulator->doStep();
	}
}	// namespace MengeCS