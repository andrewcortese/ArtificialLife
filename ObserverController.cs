using UnityEngine;
using System.Collections;

public class ObserverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetInputsAndMove();
		
	}
	
	void GetInputsAndMove()
	{
        //get inputs
		float leftRightRotation = Input.GetAxis ("Horizontal");
        float verticalRotation = Input.mouseScrollDelta.y;
		float forwardTranslation = Input.GetAxis ("Vertical");
		
		float positiveYAxisInput = Input.GetAxis("Jump");
		float negativeYAxisInput = Input.GetAxis("Fire1");
		
		float verticalTranslation = positiveYAxisInput - negativeYAxisInput;
		
        //rotate
        this.transform.Rotate(0,leftRightRotation,0);
        this.transform.Rotate(verticalRotation, 0,0);

        this.transform.Translate(Vector3.forward * forwardTranslation);
        this.transform.Translate(Vector3.up * verticalTranslation, Space.World);
		
	}

}
