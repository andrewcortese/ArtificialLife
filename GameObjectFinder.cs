using UnityEngine;
using System.Collections;


namespace UnityObjectFinders
{

    public static class GameObjectFinder {

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

}


