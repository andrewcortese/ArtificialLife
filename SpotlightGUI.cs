using UnityEngine;
using System.Collections;
using GeneticAlgorithms;
using AssemblyCSharp;
public class SpotlightGUI : MonoBehaviour {

    GameObject target;
 
    bool show;
    string text;

    public GameObject Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        this.HandleMouseClicks();
	}


    private void HandleMouseClicks()
    {
        if(this.target != null)
        {
			if(this.target.tag == Tags.Life)
			{
				LifeDomain domain = this.target.GetComponent<LifeData>().Domain;

	            if(domain == LifeDomain.LifeAgent)
	            {
	                LifeAgent agent = (LifeAgent)target.GetComponent<LifeAgent>();
	                int id = agent.ID;
	                float age = (int)agent.Age;
	                Vector3 agentPos = target.transform.position;
	                ITraits traits = agent.Traits;
	                SingleIntegerGenome sig = (SingleIntegerGenome)agent.AgentIndividual.getGenome();
	                GameObject targetOfTarget = agent.Target;

	                this.text = "Agent\n" +
	                			"ID: " + id + "\n" +
	                            "Location:" + agentPos.ToString() + "\n" +
	                            "Genome: " + sig.GenesToString() + "\n" +
	                            "Age: " + age + " seconds. \n" +
	                            "Lifespan: " + traits.MaxLifespan + " seconds \n" +
	                            "Speed: " + traits.Speed + " units/second\n " +
	                            "Perception Radius: " + traits.PerceptionRadius + " units.\n" +
	                            "Resources: " + agent.currentResources + " / " + traits.ResourcesNeeded + "\n" +
	                            "Intelligence: " + traits.Intelligence + "\n" +
	                            "Diet: " + traits.Diet + "\n" + 
	                            "Target: " + targetOfTarget.name;
	                        


	                this.show = true;

	            }

	            else if(domain == LifeDomain.Resource)
	            {
					Resource resource = this.target.GetComponent<Resource>();
					Timer pst = resource.PhotosynthTimer;
	                this.text = "Resource \n" +
	                			"Location: " + this.target.transform.position.ToString() + "\n" +
								"Genome: " + resource.Genome.GenesToString() + "\n" +
							"Photosynthesis Timer: " + pst.ToString() + "\n" +
							"Energy: " + resource.Energy + " / " + resource.EnergyNeeded;

								
	                show = true;
	            }
			}
      	}
    }

    void OnGUI()
    {
        if(show)
        {
            Rect rect = new Rect(50, 200, 300, 200);

            GUI.Box(rect, this.text);
        }
    }

    void OnDrawGizmos()
    {
        if(target != null && target.tag.Equals("LifeAgent"))
        {
            LifeAgent agent = (LifeAgent)target.GetComponent<LifeAgent>();
            Gizmos.DrawWireSphere(target.transform.position, agent.Traits.PerceptionRadius);
        }
    }
}
