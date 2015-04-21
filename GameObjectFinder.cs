using UnityEngine;
using System.Collections;



/// <summary>
/// This class encapsulates the behavior for locating a GameObject in the scene by name.
/// 
/// By delegating that logic to this class, error handling need not be repeated everywhere, and the
/// details of how to find an object in a particular scene are not coupled to client classes.
/// 
/// This implementation provides a static method
/// </summary>
public class GameObjectFinder {

	/// <summary>
	/// Wrapper method for the static GameObject.Find method.
	/// Includes error handling for that method.
	/// </summary>
	/// <param name="name">Name.</param>
	public static GameObject Find(string name)
    {
        GameObject go = GameObject.Find(name);
        if(go == null)
        {
            throw new UnityException("Game Object not found: " + name);
        }
        return go;
    }

}




