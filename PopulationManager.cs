using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using GeneticAlgorithms;
using AssemblyCSharp;
public class PopulationManager : MonoBehaviour {

	private GameObject lifeAgentPrefab;
	private GameObject resourcePrefab;

    private IIndexedPopulation population;

    public IIndexedPopulation Population
    {
        get
        {
            return this.population;
        }
    }

    /// <summary>
    /// Adds the specified individual to the population
    /// </summary>
    /// <param name="individual">Individual.</param>
    public void Add(IIndividual individual)
    {

        int id = individual.Id;
        this.population.add(id, individual);
        //Debug.Log(id + " added to the population");
    }

    public void Remove(int key)
    {
        this.population.Remove(key);
    }

	
	// Use this for initialization
	void Start () 
    {
        Prefabs prefabs = UnityObjectFinders.MonoBehaviorFinder.Find<Prefabs>("Prefabs");
        this.lifeAgentPrefab = prefabs.LifeAgentPrefab;
        this.GeneratePopulation();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

	private void GeneratePopulation()
	{
		IIndividualFactory individualFactory = SimulationConstants.LifeAgentFactory;
		IGUIDGenerator guidGenerator = new ALGUIDGenerator();
	    population = new IndexedPopulation(SimulationConstants.StartingPopulationSize, individualFactory, guidGenerator);


        List<IIndividual> list = population.getIterator();
        foreach(IIndividual i in list)
        {
            Vector3 position = this.randomPosition();
            this.InstantiateLifeAgent(i, position);
        }
	}

	private GameObject InstantiateLifeAgent(IIndividual i, Vector3 position)
	{
		Instantiator instantiator = new Instantiator();
		return instantiator.InstantiateLifeAgent(this.lifeAgentPrefab, position, i);
	}
	

	private Vector3 randomPosition()
	{
		SimulationSpace space = SimulationConstants.SimSpace;
		return space.RandomPosition();
	}
}
