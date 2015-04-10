using UnityEngine;
using System.Collections;

public class AgentIDGUI : MonoBehaviour {

    GameObject[] agents;
    Camera camera;
    bool show;
    GameObject target;

    public GameObject Target
    {
        get
        {
            return this.target;
        }
        set
        {
            target = value;
        }
    }


	// Use this for initialization
	void Start () {
	
        this.camera = Camera.main;
        agents = new GameObject[1];
	}
	
	// Update is called once per frame
	void Update () {
	
        agents = GameObject.FindGameObjectsWithTag("LifeAgent");
      

	}


    void OnGUI ()
    {
//        Rect position;
//        string text;
//
//        foreach(GameObject o in agents)
//        {
//            Vector3 loc = this.camera.WorldToViewportPoint(o.transform.position);
//            LifeAgent agent = (LifeAgent)o.GetComponent<LifeAgent>();
//            int id = agent.id;
//            position = new Rect(loc.x, loc.y, 50, 50);
//            text = "ID: " + id;
//            GUI.Label(position, text);
//        }
    }
}
