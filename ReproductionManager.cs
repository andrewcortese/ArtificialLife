using UnityEngine;
using System.Collections;
using GeneticAlgorithms;
using AssemblyCSharp;
using UnityObjectFinders;
public class ReproductionManager : MonoBehaviour {

	Instantiator instantiator;
	Prefabs prefabs;
	private int numTimesLimitReached;
	Timer alertTimer;

	// Use this for initialization
	void Start () {
	
		instantiator = new Instantiator();
		prefabs = MonoBehaviorFinder.Find<Prefabs>("Prefabs");
		numTimesLimitReached = 0;
		alertTimer = new Timer(5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Reproduction two Agent lifeforms to create one child
	/// </summary>
	/// <param name="id1">The id of the first parent</param>
	/// <param name="id2">The id of the second parent</param>
	/// <param name="position">Where to put the child</param>
	public void AgentReproduction(int id1, int id2, Vector3 position)
    {
        PopulationManager pm = MonoBehaviorFinder.Find<PopulationManager>("PopulationManager");
        IIndexedPopulation population = pm.Population;

		IIndividual i = this.DoCrossover(id1, id2, population);
        
        pm.Add(i);
        this.instantiator.InstantiateLifeAgent(prefabs.LifeAgentPrefab, position, i);


        Debug.Log("Agent Reproduction: " + id1 + " with " + id2);

    }

	/// <summary>
	/// Reproduction of two Resource lifeforms to create one child.
	/// </summary>
	/// <param name="id1">The id of the first parent</param>
	/// <param name="id2">The id of the second parent</param>
	/// <param name="position">Position.</param>
	public void ResourceReproduction(int id1, int id2, Vector3 position)
	{

		ResourceManager rm = MonoBehaviorFinder.Find<ResourceManager>("ResourceManager");

		if(rm.Count < SimulationConstants.MaximumResourcePopulation)
		{
			IIndexedPopulation resources = rm.ResourcePopulation;

			IIndividual i = this.DoCrossover(id1, id2, resources);
			rm.Add(i);

			this.instantiator.InstantiateResource(prefabs.ResourcePrefab, position, i);
			rm.Count++;

		}
		else
		{
			if(alertTimer.Tick(Time.deltaTime))
			{
				Debug.Log("Resource population limit reached");

			}
			this.numTimesLimitReached++;
		}
	}

	/// <summary>
	/// A general crossover prodedure for any Domain of life. 
	/// Given two id's and the Population collection, crossover and return the child
	/// </summary>
	/// <returns>The child as an IIndividual</returns>
	/// <param name="id1">Id1.</param>
	/// <param name="id2">Id2.</param>
	/// <param name="population">Population.</param>
	private IIndividual DoCrossover(int id1, int id2, IIndexedPopulation population)
	{
		ICrossover crossover = new RandomCrossover();
		IIndividual p1 = population.find(id1);
		IIndividual p2 = population.find(id2);
		
		IGenome[] parents = {p1.getGenome(), p2.getGenome()};
		
		IGenome child = crossover.crossover(parents, SimulationConstants.GenomeFactory);
		
		IIndividualFactory factory = SimulationConstants.LifeAgentFactory;
		
		IIndividual i = factory.construct(child);
		
		return i;
	}

}
