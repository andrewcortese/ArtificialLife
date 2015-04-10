// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
namespace AssemblyCSharp
{
	public class Instantiator 
	{
		public Instantiator ()
		{
		}

		
		public GameObject InstantiateLifeAgent (GameObject prefab, Vector3 position, GeneticAlgorithms.IIndividual individual)
		{
			GameObject lifeAgentGO = this.Instantiate(prefab, position);
            int id = ((LifeAgentIndividual)individual).Id;
			lifeAgentGO.tag = Tags.Life;
			lifeAgentGO.name = "LifeAgent - ID:"+id;
			LifeAgent lifeAgent = (LifeAgent) lifeAgentGO.AddComponent<LifeAgent>();
			lifeAgent.AgentIndividual = (LifeAgentIndividual) individual;

            fixHeight(lifeAgentGO);
            GeneShapeMap g = new GeneShapeMap();
            lifeAgentGO = g.GetModelFromGenes(individual.getGenome(), lifeAgentGO);
			LifeData data = lifeAgentGO.AddComponent<LifeData>();
			data.Domain = LifeDomain.LifeAgent;
          

         /*   label.transform.localPosition = new Vector3(0,0,0);
           */

            Debug.Log("Created Agent -- ID: " + id + " -- Genome: " + individual.getGenome().GenesToString());
			return lifeAgentGO;
		}

		public GameObject InstantiateResource (GameObject prefab, Vector3 position)
		{
			GameObject resourceGO = this.Instantiate(prefab, position);
            resourceGO.name = "Resource " + position.ToString();
            fixHeight(resourceGO);
			return resourceGO;

		}

		public GameObject InstantiateResource(GameObject prefab, Vector3 position, GeneticAlgorithms.IIndividual individual)
		{
			GeneticAlgorithms.IGenome genome = individual.getGenome();
			GameObject resourceGO = this.InstantiateResource(prefab, position);
			LifeData data = resourceGO.AddComponent<LifeData>();
			data.Domain = LifeDomain.Resource;
			resourceGO.tag = Tags.Life;
			Resource resource = resourceGO.AddComponent<Resource>();
			resource.Genome = genome;
			resource.Id = individual.Id;
			resource.Individual = individual;
			return resourceGO;
		}

		public GameObject Instantiate (GameObject prefab, Vector3 position)
		{
			GameObject go = (GameObject)GameObject.Instantiate(prefab, position, Quaternion.identity);
			if(go == null)
			{
				throw new Exception("instantiation failed");
			}

			return go;

		}

        public GameObject fixHeight(GameObject go)
        {
            Vector3 pos = go.transform.position;
            pos = new Vector3(pos.x, SimulationConstants.AgentYPosition, pos.z);
            go.transform.position = pos;
            return go;
        }

	}
}
