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
using GeneticAlgorithms;
namespace AssemblyCSharp
{
    public static class SimulationConstants
    {
        public static int StartingPopulationSize
        {
            get
            {
                return 200;
            }
        }

		public static int StartingResourcePopulationSize
		{
			get
			{
				return 100;
			}
		}

		public static int MaximumResourcePopulation
		{
			get
			{
				return 600;
			}
		}

        public static float squareSpaceMinPoint
        {
            get
            {
                return 500.0f;
            }
        }

        public static float squareSpaceMaxPoint
        {
            get
            {
                return 1700.0f;
            }
        }

        public static float ResourceSpawnTime
        {
            get
            {
                return .5f;
            }
        }

        public static float AgentYPosition
        {
            get
            {
                return 8f;
            }
        }

        public static SimulationSpace SimSpace
        {
            get
            {
                return new SimulationSpace(SimulationConstants.squareSpaceMinPoint, SimulationConstants.squareSpaceMaxPoint);
            }
        }

        public static int baseGenomeSize
        {
            get
            {
                return 8;
            }
        }

        public static LifeAgentIndividualFactory LifeAgentFactory
        {
            get
            {
                return new LifeAgentIndividualFactory(SimulationConstants.GenomeFactory, 
                                                      SimulationConstants.GeneFactory, 
                                                      SimulationConstants.GeneTraitMap, 
                                                      SimulationConstants.baseGenomeSize);
            }
        }

        public static IGenomeFactory GenomeFactory
        {
            get
            {
                return new SingleIntegerGenomeFactory();
            }
        }

        public static IGeneFactory GeneFactory
        {
            get
            {
                return new SingleIntegerGeneFactory();
            }
        }

        public static IGeneToTraitMap GeneTraitMap
        {
            get
            {
                return new SingleIntegerGeneToTraitMap();
            }
        }

        public static bool AgentsCanDie
        {
            get
            {
                return true;
            }
        }

		public static float ResourceEnergyHandicap
		{
			get
			{
				return 1f;
			}
		}

		public static float PhotosynthesisHandicap
		{
			get
			{
				return 2f;
			}
		}

    }
}

