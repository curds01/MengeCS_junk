Menge's C-Sharp Bindings
========================

This project produces a dll (MengeCS.dll) which can be included in C-Sharp
projects to provide access to the Menge simulation core.

In this version:

   - No real functionality; only the skeleton of the dll is in place.

Still to do:
   - Extend `Simulator` interface to include advancing simulation time step
     and setting time step size.
   - Implement interface to `Simulator` so that it can be initialized by
     specifying behavior and scene specification files.
   - Provide interface for saving out trajectories into an scb file.
   - More testing of the above functionality.
   - Add Unity project showing Menge simulation moving Unity elements.

Unity Issues
------------
	- Although the intent of this was to create a dll that could be exercised
	by Unity to execerise Menge functionality, my homework was *not* sufficient.
	Unity currently only supports .NET 2 functionality.
