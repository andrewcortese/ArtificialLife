using UnityEngine;
using System.Collections;

public class MouseClickHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        SpotlightGUI gui = UnityObjectFinders.MonoBehaviorFinder.Find<SpotlightGUI>("SpotlightGUI");
        gui.Target = this.gameObject;
    }
}
