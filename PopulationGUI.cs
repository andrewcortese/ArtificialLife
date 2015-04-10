using UnityEngine;
using System.Collections;
using GeneticAlgorithms;
using AssemblyCSharp;
using UnityObjectFinders;
public class PopulationGUI : MonoBehaviour {

    private IIndexedPopulation population;
	private IIndexedPopulation resourcePop;
	private ResourceManager rm;

	// Use this for initialization
	void Start () {
        this.population = null;
	}
	
	// Update is called once per frame
	void Update () {
	    if(this.population == null)
        {
            PopulationManager pm = MonoBehaviorFinder.Find<PopulationManager>("PopulationManager");
            this.population = pm.Population;

			rm = MonoBehaviorFinder.Find<ResourceManager>("ResourceManager");
			this.resourcePop = rm.ResourcePopulation;
        }
	}


    void OnGUI()
    {
        if(this.population != null)
        {
            Rect rect = new Rect(50, 50, 200, 50);
            string text = "Agent population: " + this.population.count().ToString() + "\n" +
				"Resource population: " + this.rm.Count;
            GUI.Box(rect, text);
        }
    }
}
