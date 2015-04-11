using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GeneticAlgorithms;
using AssemblyCSharp;
using UnityObjectFinders;
public class LifeAgent : MonoBehaviour {

	private LifeAgentIndividual agentIndividual;
	public ITraits traits;
	private SimulationSpace space;
	public int currentResources = 0;
	public AgentMode mode = AgentMode.GatherResource;
	public GameObject target;
	private int id;
    private float maxLifespan;
    private float age = 0;
	private AgentDietType diet;

    public int _age = 0;

    private ITimer lifespanTimer;
    private ITimer targetRefreshTimer;

    private float targetRefreshTime;

    public GameObject Target
    {
        get
        {
            return this.target;
        }
    }


    public int ID
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }

    public ITraits Traits
    {
        get
        {
            return this.traits;
        }
        set
        {
            this.traits = value;
        }
    }

    public float Age
    {
        get
        {
            return age;
        }
    }

    public float MaxLifespan
    {
        get
        {
            return maxLifespan;
        }
    }

	public LifeAgentIndividual AgentIndividual {
		get {
			return agentIndividual;
		}
		set {
			agentIndividual = value;
			this.traits = agentIndividual.getTraits();
			this.id = agentIndividual.Id;
            float lifespan = ((Traits)traits).MaxLifespan;
            this.lifespanTimer = new Timer(lifespan);
            this.maxLifespan = lifespan;
            this.targetRefreshTime = 10 - traits.Intelligence;
            this.targetRefreshTimer = new Timer(this.targetRefreshTime);
			this.diet = agentIndividual.getTraits().Diet;
		}

	}

    public bool IsFit
    {
        get
        {
            return (currentResources >= ((Traits)this.traits).ResourcesNeeded);
        }
    }

    void Start()
    {
        this.space = new SimulationSpace(SimulationConstants.squareSpaceMinPoint, SimulationConstants.squareSpaceMaxPoint);

    }

	void Update()
	{
        //make sure we're not still an empty husk 
        //husk-state is expected for the first few updates after creation
        //after the AgentIndividual property is set, we are no longer in husk-state
		if(this.agentIndividual != null)
		{
            //if death is an option and we're old enough to die, then die.
            if(this.isTimeToDie())
            {
                Die();
            }

			HerbivoreBehavior();
		}
	}


	void HerbivoreBehavior()
	{
		//control the state machine's state
		SetMode();
		
		//get the tag for our target
		LifeDomain targetDomain = GetTargetDomain();
		
		//move to (and interact with) the target
		MoveToTargetAndInteract (targetDomain);
	}

	/// <summary>
    /// Determine's whether we are currently dying of old age.
    /// </summary>
    /// <returns><c>true</c>, if of lifespan was ended, <c>false</c> otherwise.</returns>
    bool isTimeToDie()
    {
        //if immortality is active, return false
        if(SimulationConstants.AgentsCanDie == false)
        {
            return false;
        }

        //update age for tracking
        this.age = lifespanTimer.CurrentTime;

        //determine if we're EOL
        if(lifespanTimer.Tick(Time.deltaTime))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Remove this individual from the population list, and destroy its GameObject
    /// </summary>
    private void Die()
    {
        PopulationManager pm = MonoBehaviorFinder.Find<PopulationManager>("PopulationManager");
        pm.Remove(this.ID);
        Debug.Log(this.ID + " died of old age! :'(");
        GameObject.Destroy(this.gameObject);
    }

	public void Kill(string killedBy)
	{
		PopulationManager pm = MonoBehaviorFinder.Find<PopulationManager>("PopulationManager");
		pm.Remove(this.ID);
		Debug.Log(this.ID + " was killed by " + killedBy);
		GameObject.Destroy(this.gameObject);
	}

    /// <summary>
    /// Set the state machine state based on our fitness status
    /// </summary>
    void SetMode()
    {
        if (this.IsFit)
        {
            mode = AgentMode.FindMate;
        }
        else
        {
            mode = AgentMode.GatherResource;
        }
    }

    /// <summary>
    /// Gets the target tag based on the current mode
    /// </summary>
    /// <returns>The target tag.</returns>
    LifeDomain GetTargetDomain()
    {
		LifeDomain targetDomain;
        if (mode == AgentMode.GatherResource)
        {
			targetDomain = LifeDomain.Resource;
        }
        else
            if (mode == AgentMode.FindMate)
            {
				targetDomain = LifeDomain.Resource;
            }
            else
            {
				targetDomain = LifeDomain.Resource;
            }
		return targetDomain;
    }


    /// <summary>
    /// This method does most of the heavy lifting.
    /// Find a target, move to it, and interact.
    /// 
    /// Note: maybe not as cohesive as possible, but allows us to handle all targets similarly (good tradeoff, but not perfect)
    /// </summary>
    /// <param name="targetTagName">the tag for the target</param>
	void MoveToTargetAndInteract(LifeDomain targetDomain)
	{
        //if we currently have no target, or it's time to try again, then try to find a target
		if(target == null || IsTimeToRefreshTarget())
		{
            //get all target candidates
			List<GameObject> candidates1 = LifeFinder.FindAllWithDomain(targetDomain);
            List<GameObject> candidates = null;

            //if we're in FindMate mode, remove ourself as a candidate
            if(mode == AgentMode.FindMate)
            {
                candidates = new List<GameObject>();
                foreach(GameObject g in candidates1)
                {
                    LifeAgent other = (LifeAgent) g.GetComponent<LifeAgent>();
                    if(this.id != other.id)
                    {
                        candidates.Add(g);
                    }
                }
            }

            //otherwise consider all candidates
            else
            {
                candidates = new List<GameObject>(candidates1);
            }

			float closestDistance = 0;
			GameObject closest = null;

            //if there are any...
			if(candidates.Count > 0)
			{
                //determine which target candidate is closest
				closest = candidates[0];
				closestDistance = Vector3.Distance(transform.position, closest.transform.position);

				foreach(GameObject g in candidates)
				{
					float distance = Vector3.Distance(this.transform.position, g.transform.position);
					if(distance < closestDistance)
					{
						closest = g;
						closestDistance = distance;
					}
				}
				
                //is there a potential target within our perception radius?
				if(closest != null && closestDistance <= ((Traits)traits).PerceptionRadius)
				{
					target = closest;
				}
			}

		}

        //if we STILL don't have a target, choose a random position as the target
		if(target == null)
		{
			GameObject wanderTarget = new GameObject("WanderTarget");
		    Vector3 pos = space.RandomPosition();
            pos = new Vector3(pos.x, this.transform.position.y, pos.z);
            wanderTarget.transform.position = pos;
			target = wanderTarget;
		}

        //otherwise (we do have a target) move to the target
		else
		{
            // don't count height in distance...
            Vector3 pos = transform.position;
            Vector3 targetPos = target.transform.position;
            pos = new Vector3(pos.x, 0, pos.z);
            targetPos = new Vector3(targetPos.x, 0, targetPos.z);

			if(Vector3.Distance(pos, targetPos) <= 1)
			{
                if(isResource(target))
                {
    				this.currentResources++;
    				target.GetComponent<Resource>().Eat("Agent: " + this.id);
    				target = null;
                }
                else if(isWaypoint(target))
                {
                    GameObject.Destroy(target);
                    target = null;
                }
                else if(isLifeAgent(target))
                {
                    LifeAgent potentialMate = (LifeAgent)target.GetComponent<LifeAgent>();
                    if(potentialMate != null)
                    {
                        if(potentialMate.IsFit)
                        {
                            ReproductionManager rm = MonoBehaviorFinder.Find<ReproductionManager>("ReproductionManager");
                            rm.AgentReproduction(this.ID, potentialMate.ID, this.transform.position);

                            currentResources = 0;
                            target = null;
                        }
                    }
                }
			}
			else
			{
				this.transform.LookAt(target.transform.position);
				this.transform.Translate(Vector3.forward * Time.deltaTime * ((Traits)this.traits).Speed);
			}
		}
	}

    /// <summary>
    /// Determine if the target refresh timer is done.
    /// Some agents check for a new target more often than others.
    /// </summary>
    /// <returns><c>true</c> if this instance is time to refresh target; otherwise, <c>false</c>.</returns>
    bool IsTimeToRefreshTarget()
    {
        if(targetRefreshTimer.Tick(Time.deltaTime))
        {
            targetRefreshTimer = new Timer(this.targetRefreshTime);
            return true;
        }
        else
        {
            return false;
        }
    }



    bool isResource(GameObject other)
    {
		if(other != null && other.CompareTag(Tags.Life))
        {
			return (getDomain(other) == LifeDomain.Resource);
        }
        else return false;
    }
    bool isLifeAgent(GameObject other)
    {
		if(other != null && other.CompareTag(Tags.Life))
        {
			return (getDomain(other) == LifeDomain.LifeAgent);
        }
        else return false;
    }
    bool isWaypoint(GameObject other)
    {
        if(other != null)
        {
            return other.name.Equals("WanderTarget");
        }
        else return false;
    }

	LifeDomain getDomain(GameObject other)
	{
		if(other != null)
		{
			return other.GetComponent<LifeData>().Domain;
		}
		else return LifeDomain.None;
	}
}


