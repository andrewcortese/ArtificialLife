﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GeneticAlgorithms;
using AssemblyCSharp;
public class ResourceManager : MonoBehaviour {

	public GameObject resourcePrefab;


	private ITimer resourceSpawnTimer;

	private IIndexedPopulation resourcePopulation;

	private int count;
	
	// Use this for initialization
	void Start () {
		this.resourceSpawnTimer = new Timer(SimulationConstants.ResourceSpawnTime);
        Prefabs prefabs = UnityObjectFinders.MonoBehaviorFinder.Find<Prefabs>("Prefabs");
        this.resourcePrefab = prefabs.ResourcePrefab;
		this.resourcePopulation = new IndexedPopulation(SimulationConstants.StartingPopulationSize, SimulationConstants.LifeAgentFactory, new ALGUIDGenerator());
		count = 0;
		List<IIndividual> list = this.resourcePopulation.getIterator();
		foreach(IIndividual i in list)
		{
			InstantiateResource(i);
			count++;

		}
	}

	public IIndexedPopulation ResourcePopulation {
		get {
			return resourcePopulation;
		}
	}

	public int Count {
		get {
			return count;
		}
		set {
			this.count = value;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(resourceSpawnTimer.tick(Time.deltaTime))
		{
			Vector3 pos = this.randomPosition();
			this.InstantiateResource(pos);
			count++;
		}
	}


	private GameObject InstantiateResource(Vector3 position, IIndividual i)
	{

		Instantiator instantiator = new Instantiator();
		return instantiator.InstantiateResource(resourcePrefab, position, i);
	}

	private GameObject InstantiateResource(IIndividual i)
	{

		return InstantiateResource(randomPosition(), i);
	}

	private GameObject InstantiateResource(Vector3 position)
	{

		Instantiator instantiator = new Instantiator();
		return instantiator.InstantiateResource(resourcePrefab, position);
	}

	private Vector3 randomPosition()
	{
		SimulationSpace space = SimulationConstants.SimSpace;
		return space.RandomPosition();
	}
}
