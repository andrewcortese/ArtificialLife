using UnityEngine;
using System.Collections;
using GeneticAlgorithms;
using AssemblyCSharp;
using UnityObjectFinders;
public class ReproductionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Reproduce(int id1, int id2, Vector3 position)
    {
        PopulationManager pm = MonoBehaviorFinder.Find<PopulationManager>("PopulationManager");
        IIndexedPopulation population = pm.Population;

        ICrossover crossover = new RandomCrossover();
        IIndividual p1 = population.find(id1);
        IIndividual p2 = population.find(id2);

        IGenome[] parents = {p1.getGenome(), p2.getGenome()};

        IGenome child = crossover.crossover(parents, SimulationConstants.GenomeFactory);

        IIndividualFactory factory = SimulationConstants.LifeAgentFactory;

        IIndividual i = factory.construct(child);
        pm.Add(i);

        Instantiator instantiator = new Instantiator();
        Prefabs prefabs = MonoBehaviorFinder.Find<Prefabs>("Prefabs");
        instantiator.InstantiateLifeAgent(prefabs.LifeAgentPrefab, position, i);


        Debug.Log("Reproduction: " + id1 + " with " + id2);
//        string message = string.Empty;
//
//        message+= "----REPRODUCTION----";
//      
//        message+= "\nParent 1: ";
//        message+= "\n\tID: " + id1;
//        message+= "\n\tGenome: " + p1.getGenome().ToString();
//      
//        message+= "\n\nParent 2: ";
//        message+= "\n\tID: " + id2;
//        message+= "\n\tGenome: " + p2.getGenome().ToString();
//      
//        message+= "\n\n-------------------";

       // Debug.Log(message);

    }

}
