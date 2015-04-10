using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public static class LifeFinder {

	public static List<GameObject> FindAllWithDomain(LifeDomain domain)
	{
		List<GameObject> domainMembers = new List<GameObject>();
		GameObject[] lifeforms = GameObject.FindGameObjectsWithTag(Tags.Life);
		foreach(GameObject go in lifeforms)
		{
			LifeData data = go.GetComponent<LifeData>();
			if(data.Domain == domain)
			{
				domainMembers.Add(go);
			}
		}

		return domainMembers;
	}


	public static GameObject FindClosestWithDomain(LifeDomain domain, GameObject origin)
	{
		List<GameObject> all = FindAllWithDomain(domain);
		List<GameObject> allExceptOrigin = new List<GameObject>();
		foreach(GameObject go in all)
		{
			if(Distance(origin, go) != 0)
			{
				allExceptOrigin.Add(go);
			}

		}

		GameObject closest = null;
		foreach(GameObject go in allExceptOrigin)
		{
			if(Distance(go, origin) < Distance(closest, origin))
			{
				closest = go;
			}
		}

		return closest;
	}

	public static float Distance(GameObject a, GameObject b)
	{
		return Vector3.Distance(a.transform.position, b.transform.position);
	}





}
