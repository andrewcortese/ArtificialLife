using UnityEngine;
using System.Collections;

public class GameObjectIdentifier
{
	public bool IsResource (GameObject other)
	{
		if (other != null && other.CompareTag (Tags.Life)) {
			return (GetDomain (other) == LifeDomain.Resource);
		} else
			return false;
	}
	public bool IsLifeAgent (GameObject other)
	{
		if (other != null && other.CompareTag (Tags.Life)) {
			return (GetDomain (other) == LifeDomain.LifeAgent);
		} else
			return false;
	}
	public bool IsWaypoint (GameObject other)
	{
		if (other != null) {
			return other.name.Equals ("WanderTarget");
		} else
			return false;
	}
	
	public LifeDomain GetDomain (GameObject other)
	{
		if (other != null) {
			return other.GetComponent<LifeData> ().Domain;
		} else
			return LifeDomain.None;
	}
}
