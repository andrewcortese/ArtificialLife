using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GeneticAlgorithms;
using AssemblyCSharp;
using UnityObjectFinders;
public class Resource : MonoBehaviour {

	private bool initialized = false;
    private SingleIntegerGenome genome;
    private float energy;
    private ITimer photosynthesisTimer;
	private float energyNeeded;
	private float seedRadius;
	private int id;
	private IIndividual individual;
	System.Random gen;
	private ITimer lifespanTimer;
	private float age;
	private float lifespan;

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
		private set {
			this.energy = value;
		}
	}

	public float EnergyNeeded {
		get {
			return energyNeeded;
		}
	}

	public float Age {
		get {
			return age;
		}
	}

	public float Lifespan {
		get {
			return lifespan;
		}
	}

    private void Initialize(SingleIntegerGenome genome)
    {
		if(genome != null)
		{
			int[] values = this.genome.getGeneIntegerValues();
			if(values.Length >= 3)
			{
				this.photosynthesisTimer = new Timer((values[0] + 1) * SimulationConstants.PhotosynthesisHandicap);
				this.energyNeeded = (float)((values[1]+ 1)* SimulationConstants.ResourceEnergyHandicap);
				this.seedRadius = (float) (values[2] + 1) * 100f;
				this.lifespan = (values[3] + 1)*TraitConstants.BaseLifeSpan;
				this.lifespanTimer = new Timer(lifespan);
				this.age = 0;
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
			if(photosynthesisTimer.Tick(Time.deltaTime))
			{
				energy++;
			}

			if(energy >= energyNeeded)
			{
				this.Reproduce();
				energy = 0;
			}

			if(lifespanTimer.Tick(Time.deltaTime))
			{
				this.Die();
			}
			else
			{
				this.age = lifespanTimer.CurrentTime;
			}
        }
	}


	/// <summary>
	/// Method called by a predator to eat this Resource
	/// </summary>
	/// <param name="killedBy">Killed by.</param>
	public void Eat(string killedBy)
	{
		ResourceManager pm = MonoBehaviorFinder.Find<ResourceManager>("ResourceManager");
		pm.ResourcePopulation.Remove(this.Id);
		pm.Count --;
		Debug.Log("Resource: " + this.Id +  "was eaten by " + killedBy);
		GameObject.Destroy(this.gameObject);
	}

	public void Die()
	{
		ResourceManager pm = MonoBehaviorFinder.Find<ResourceManager>("ResourceManager");
		pm.ResourcePopulation.Remove(this.Id);
		pm.Count --;
		Debug.Log("Resource: " + this.Id +  "died of old age");
		GameObject.Destroy(this.gameObject);
	}


	/// <summary>
	/// Reproduction logic.
	/// Search for potential mates within the seed radius.
	/// If there are any, mate with the closest.
	/// Otherwise, undergo asexual reproduction.
	/// </summary>
	private void Reproduce()
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

		GameObject closest = null;
		foreach(GameObject f in inRange)
		{
			if(closest == null)
			{
				closest = f;
			}

			else if (LifeFinder.Distance(f, this.gameObject) < LifeFinder.Distance(closest, this.gameObject))
			{
				closest = f;
			}

		}

		Resource mate = null;
		if(closest != null)
		{
			mate = closest.GetComponent<Resource>();
		}
		else
		{
			mate = this;
		}
		SimulationSpace s = SimulationConstants.SimSpace;
		Vector3 position = Vector3.zero;
		while((position.Equals(Vector3.zero)) || (s.IsInside(position) == false))
		{
			position = new Vector3(this.transform.position.x + gen.Next((int)seedRadius), this.transform.position.y, this.transform.position.z + gen.Next((int)seedRadius));
		}
		ReproductionManager reproductionManager = MonoBehaviorFinder.Find<ReproductionManager>("ReproductionManager");
		reproductionManager.ResourceReproduction(this.Id, mate.Id, position);

		ResourceManager rm = MonoBehaviorFinder.Find<ResourceManager>("ResourceManager");


	}

}
