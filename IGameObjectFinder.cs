using UnityEngine;
using System.Collections;

/// <summary>
/// This interface provides the abstraction for finding game objects in the active scene.
/// Implementors encapsulate the logic of GameObject location to reduce repetition, hide logical details, and allow for easy changes.
/// </summary>
public interface IGameObjectFinder{

	GameObject Find(string name);

}
