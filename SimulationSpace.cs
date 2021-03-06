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
using UnityEngine;

namespace AssemblyCSharp
{
	public class SimulationSpace
	{
		float minX;
		float maxX;
		float minZ;
		float maxZ;

		public SimulationSpace (float minX, float maxX, float minZ, float maxZ)
		{
			this.minX = minX;
			this.maxX = maxX;
			this.minZ = minZ;
			this.maxZ = maxZ;
		}

		public SimulationSpace (float squareMin, float squareMax)
		{
			this.minX = squareMin;
			this.maxX = squareMax;
			this.minZ = squareMin;
			this.maxZ = squareMax;
		}

		float MinX {
			get {
				return this.minX;
			}
			set {
				minX = value;
			}
		}

		float MaxX {
			get {
				return this.maxX;
			}
			set {
				maxX = value;
			}
		}

		float MinZ {
			get {
				return this.minZ;
			}
			set {
				minZ = value;
			}
		}

		float MaxZ {
			get {
				return this.maxZ;
			}
			set {
				maxZ = value;
			}
		}

		public SimulationSpace ()
		{
			this.minX = 0;
			this.maxX = 0;
			this.minZ = 0;
			this.maxZ = 0;
		}

		public Vector3 RandomPosition ()
		{
			return new Vector3 (UnityEngine.Random.Range (minX, maxX), 2, UnityEngine.Random.Range (minZ, maxZ));
		}

		public bool IsInside (Vector3 position)
		{
			float x = position.x; 
			float z = position.z;
			return (IsBetween (x, minX, maxX) && IsBetween (z, minZ, maxZ));
		}

		bool IsBetween (float x, float a, float b)
		{
			return (a <= x && x <= b);
		}
	
	}
}

