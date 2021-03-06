// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;


	/// <summary>
	/// This class is responsible for obtaining a GUID for a lifeagent.
	/// 
	/// This implementation depends on the existence of a static class in the solution from which
	/// the next GUID will be obtained.
	///
	/// Client classes should call THIS class to generate GUIDs. This prevents dependency on the use of the static class. 
	/// 
	/// </summary>
	public class ALGUIDGenerator : IGUIDGenerator
	{
		public ALGUIDGenerator()
		{
		}

		public int generateGUID()
		{
			return ALGUID.Next();
		}
	}


