using UnityEngine;
using System.Collections;


namespace UnityObjectFinders
{

    public static class MonoBehaviorFinder {

        public static T Find<T>(string gameObjectName)
        {
            GameObject parent = GameObjectFinder.Find(gameObjectName);
            T script = (T) parent.GetComponent<T>();

            if(script == null)
            {
                throw new UnityException("script not found " + script.GetType().Name);
            }

            return script;
        }
    	
    }

}
