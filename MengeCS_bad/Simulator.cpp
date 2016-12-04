#include "Stdafx.h"
#include <windows.h>
#include "Simulator.h"

#include "PluginEngine.h"
#include "SimSystem.h"
#include "SimulatorBase.h"
#include "SimulatorDB.h"
#include "SimulatorDBEntry.h"

#include <cassert>
#include <msclr/marshal_cppstd.h>

namespace MengeCS {
		
	Simulator::Simulator() : _simulator(0x0), _fsm(0x0) {
	}

	// ---------------------------------------------------

	bool Simulator::Initialize( String^ behaviorXml, String^ sceneXml, String^ model ) {
		const bool VERBOSE = false;
		Menge::SimulatorDB simDB;
		// TODO: Plugin engine is *not* public.  I can't get plugins.
		Menge::PluginEngine engine( &simDB );
		std::string modelName = msclr::interop::marshal_as<std::string>( model );
		//std::string modelName = convert( model );
		Menge::SimulatorDBEntry * simDBEntry = simDB.getDBEntry( modelName );
		if ( simDBEntry == 0x0 ) return false;

		std::string sceneFile = msclr::interop::marshal_as<std::string>( sceneXml );
		//std::string sceneFile = convert( sceneXml );
		_simulator = simDBEntry->initSimulator( sceneFile, VERBOSE );
		if ( _simulator == 0x0 ) return false;

		std::string behaveFile = msclr::interop::marshal_as<std::string>( behaviorXml );
		//std::string behaveFile = convert( behaviorXml );
		_fsm = simDBEntry->initFSM( behaveFile, _simulator, VERBOSE );
		if ( _fsm == 0x0 ) return false;

		if ( !simDBEntry->finalize( _simulator, _fsm ) ) return false;
		return true;
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

	bool Simulator::DoStep() {
		assert( _simulator != 0x0 );
		for ( size_t i = 0; i <= _simulator->getSubSteps(); ++i ) {
			try {
				_fsm->doStep();
			} catch ( Menge::BFSM::FSMFatalException ) {
				return false;
			}

			_simulator->doStep();
			try {
				_fsm->doTasks();
			} catch ( Menge::BFSM::FSMFatalException ) {
				return false;
			}
		}
		return true;
	}
}	// namespace MengeCS