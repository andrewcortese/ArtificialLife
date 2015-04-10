using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GeneticAlgorithms;
using AssemblyCSharp;
using UnityObjectFinders;
public class Resource : MonoBehaviour {

    private bool initialized;
    private SingleIntegerGenome genome;
    private float energy;
    private ITimer photosynthesisTimer;
	private float energyNeeded;
	private float seedRadius;
	private int id;
	private IIndividual individual;
	System.Random gen;


    public IGenome Genome
    {
        get
        {
            return (IGenome)this.genome;
        }
        set
        {
            this.genome = (SingleIntegerGenome)value;
            this.Initialize(this.genome);
        }
    }

	public int Id {
		get {
			return id;
		}
	    set {
			id = value;
		}
	}

	public IIndividual Individual {
		get {
			return individual;
		}
		set {
			individual = value;
		}
	}

	public Timer PhotosynthTimer
	{
		get
		{
			return (Timer)this.photosynthesisTimer;
		}
	}

	public float Energy {
		get {
			return energy;
		}
	}

	public float EnergyNeeded {
		get {
			return energyNeeded;
		}
	}

    private void Initialize(SingleIntegerGenome genome)
    {
		if(genome != null)
		{
			int[] values = this.genome.getGeneIntegerValues();
			if(values.Length >= 3)
			{
				this.photosynthesisTimer = new Timer(values[0] * 2f);
				this.energyNeeded = (float)values[1] * 2f;
				this.seedRadius = (float) values[2];
			}


			initialized = true;
		}
		else
		{
			initialized = false;
		}



    }

	// Use this for initialization
	void Start () {
		energy = 0;
		gen  = new System.Random();

	}
	
	// Update is called once per frame
	void Update () {
	   if(this.initialized)
        {
			if(photosynthesisTimer.tick(Time.deltaTime))
			{
				energy++;
			}

			if(energy >= energyNeeded)
			{
				//this.Reproduce();
				energy = 0;
			}
        }
	}

	public void Eat(string killedBy)
	{
		ResourceManager pm = MonoBehaviorFinder.Find<ResourceManager>("ResourceManager");
		pm.ResourcePopulation.Remove(this.Id);
		pm.Count --;
		Debug.Log("Resource: " + this.Id +  "was eaten by " + killedBy);
		GameObject.Destroy(this.gameObject);
		          }

	void Reproduce()
	{
		ICrossover crossover = new RandomCrossover();

		List<GameObject> others = LifeFinder.FindAllWithDomain(LifeDomain.Resource);

		List<GameObject> inRange = new List<GameObject>();

		foreach(GameObject g in others)
		{
			float distance = LifeFinder.Distance(this.gameObject, g);
			if( distance > 0 && distance < this.seedRadius)
			{
				inRange.Add(g);
			}

		}


		foreach(GameObject g in inRange)
		{

			Resource r = g.GetComponent<Resource>();
			IGenome otherGenome = r.Genome;
			IGenome[] parents = {this.genome, otherGenome};
			IGenome child = crossover.crossover(parents, (new SingleIntegerGenomeFactory()));


			Vector3 here = this.transform.position;
			Vector3 random = new Vector3(gen.Next((int)this.seedRadius), 0, gen.Next((int)this.seedRadius));
			Vector3 newLocation = here + random;

			IIndividualFactory f = SimulationConstants.LifeAgentFactory;
			IIndividual ri = f.construct(child);
			Instantiator i = new Instantiator();
			Prefabs p = MonoBehaviorFinder.Find<Prefabs>("Prefabs");

			int key = ALGUID.Next();
			MonoBehaviorFinder.Find<ResourceManager>("ResourceManager").ResourcePopulation.add(key, ri);

			i.InstantiateResource(p.ResourcePrefab, newLocation, ri);


		}

		if(inRange.Count == 0)
		{




			IGenome[] parents = {this.genome, this.genome};
			IGenome child = this.Genome.Clone();
			
			
			Vector3 here = this.transform.position;
			Vector3 random = new Vector3(gen.Next((int)this.seedRadius), 0, gen.Next((int)this.seedRadius));
			Vector3 newLocation = here + random;
			
			IIndividualFactory f = SimulationConstants.LifeAgentFactory;
			IIndividual ri = f.construct(child);
			Instantiator i = new Instantiator();
			Prefabs p = MonoBehaviorFinder.Find<Prefabs>("Prefabs");

			int key = ALGUID.Next();
			MonoBehaviorFinder.Find<ResourceManager>("ResourceManager").ResourcePopulation.add(key, ri);
			i.InstantiateResource(p.ResourcePrefab, newLocation, ri);
		}



	}

}
