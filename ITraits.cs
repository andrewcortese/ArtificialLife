
using System;
namespace GeneticAlgorithms
{
    public interface ITraits
    {
        float Speed{ get; set; }

        float PerceptionRadius{ get; set; }

        float MaxLifespan{ get; set; }

        int ResourcesNeeded{ get; set; }

        int Intelligence{get; set;}

		AgentDietType Diet{get; set;}
            
    }
}

