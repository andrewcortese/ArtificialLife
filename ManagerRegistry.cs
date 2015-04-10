using UnityEngine;
using System.Collections;
using UnityObjectFinders;
public class ManagerRegistry : MonoBehaviour {


    private PopulationManager populationManager;
    private ResourceManager resourceManager;
    private ReproductionManager reproductionManager;


	// Use this for initialization
	void Start () {
	
        populationManager = MonoBehaviorFinder.Find<PopulationManager>("PopulationManager");
        resourceManager = MonoBehaviorFinder.Find<ResourceManager>("ResourceManager");
        reproductionManager = MonoBehaviorFinder.Find<ReproductionManager>("ReproductionManager");


	}
	
	// Update is called once per frame
	void Update () {
	
	}


    PopulationManager Population
    {
        get
        {
            return this.populationManager;
        }
    }

    ResourceManager Resource
    {
        get
        {
            return this.resourceManager;
        }
    }

    ReproductionManager Reproduction
    {
        get
        {
            return this.reproductionManager;
        }
    }
}
