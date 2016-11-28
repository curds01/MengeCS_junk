Menge's C-Sharp Bindings
========================

This project produces a dll (MengeCS.dll) which can be included in C-Sharp
projects to provide access to the Menge simulation core.

In this version:

   - Three full classes:
      - ``Vector2`` - a simple wrapper of the `Menge::Math::Vector2` class for reporting agent properties.
      - ``Agent`` - a simple wrapper of the `Menge::Agents::BaseAgent` class.  Reports agent position, orientation, velocity, and preferred velocity.
      - ``Simulator`` - a wrapper for the Menge simulation system.  Allows initialization on scene, behavior, and model specifications.  Allows for setting the time step and advancing the state of the simulation.  Also grants access to the wrapped agents to query the agent state.
   - Includes a C# executable that tests the functionality; loads `cross.xml` and runs 20 simulation steps, printing the output.
   
It turns out this isn't compatible with Unity.
   - Unity runs an old version of .NET (well, quasi-.NET) akin to .NET 2.0.  This builds a dll that has .NET 4 dependencies.
   - This means the dll *can* be used by the Mono editor shipped with Unity but *not* by Unity itself.
   - The best hope for addressing this is building this dll in VS2008 (which *should* produce a compatible dll.)  However, this is not feasible either; it would require the Menge dlls to be built in 2008 as well.  And this isn't currently supported.

Still to do:
   - Provide interface for saving out trajectories into an scb file.
   - ... This is put on hold in the light of the recent discoveries ...
   
New plan
   - Write another dll called ``CMenge``.
      - it is a simple C-style interface to the Menge API.
   - Write C# assembly (in 3.5) which uses DllImport to bring the methods into the assembly and then wrap them with C# constructs.
