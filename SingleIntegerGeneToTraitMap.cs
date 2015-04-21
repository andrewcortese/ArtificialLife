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
using AssemblyCSharp;
namespace GeneticAlgorithms
{
		public class SingleIntegerGeneToTraitMap : IGeneToTraitMap
		{
				public SingleIntegerGeneToTraitMap ()
				{
				}

		public ITraits generateTraits(IGenome genome){

			/*
			if(false == genome.GetType().Equals((new SingleIntegerGenome().GetType())))
			{
				throw new Exception("wrong gene type for map");
			}*/

			Traits traits = new Traits();
			int[] genesVals = ((SingleIntegerGenome)genome).getGeneIntegerValues();

			//get the gene integer values
			int speedGene = genesVals[(int)TraitIndex.Speed];
			int perceptionGene = genesVals[(int)TraitIndex.PerceptionRadius];
			int resourceGene = genesVals[(int)TraitIndex.RequiredResources];
			int lifespanGene = genesVals[(int)TraitIndex.MaxLifespan];
			int matePreferenceGene = genesVals[(int)TraitIndex.PreferencePitch];
			int pathfindingGene = genesVals[(int)TraitIndex.PathfindingStrategy];

			//pass to mapping methods
			traits.Speed = speed(speedGene);					
			traits.PerceptionRadius = perception(perceptionGene);
			traits.ResourcesNeeded = resources(resourceGene);
			traits.MaxLifespan = lifespan(lifespanGene);
			traits.MatePreferenceValue = preference(matePreferenceGene);
			traits.PathfindingStrategy = pathfinding(pathfindingGene);
            traits.Intelligence = intelligence(pathfindingGene);

			if(genesVals.Length >= 7)
			{
				traits.Diet = this.diet(genesVals[6]);
			}
			else
			{
				traits.Diet = AgentDietType.Herbivore;
			}

			if(genesVals.Length >= 8)
			{
				traits.Strength = genesVals[7];
			}
			else
			{
				traits.Strength = 5;
			}

			return traits;
					
		}

		/// <summary>
		/// Speed is base speed + X% of base speed, where X = gene*10.
		/// i.e. 1 + (gene/10) * baseSpeed = speed
		/// </summary>
		/// <param name="gene">Gene.</param>
		private float speed(int gene)
		{
			return (1 + ((float)gene/10))*TraitConstants.BaseSpeed;
		}


		private float perception(int gene)
		{
			return 1 + (gene*TraitConstants.BasePerceptionRadius);
		}


		private int resources(int gene)
		{
			return TraitConstants.BaseResourcesNeeded + (TraitConstants.MaxGeneValue - gene);
		}

		private float lifespan(int gene)
		{
			return ((gene+1)*TraitConstants.BaseLifeSpan);
		}

		private int preference(int gene)
		{
			return gene;
		}

		private StrategyType pathfinding(int gene)
		{
			if(gene <= 4)
			{
				return StrategyType.Naive;
			}
			else if(5<= gene && gene <= 9)
			{
				return StrategyType.AvoidRepitition;
			}
			else
			{
				return StrategyType.Naive;
			}
		}

        private int intelligence(int gene)
        {
            return gene;
        }

		private AgentDietType diet(int gene)
		{
			if(gene < 3)
			{
				return AgentDietType.Herbivore;
			}
			else if(gene < 6)
			{
				return AgentDietType.Carnivore;
			}
			else
			{
				return AgentDietType.Omnivore;
			}
		}

}
}

