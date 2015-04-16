using UnityEngine;
using System.Collections;

public class ClickOnFaceScript : MonoBehaviour {

	public Vector3 delta; // I add this

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver(){
		// left mouse button is pressed
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log("Left click!");

			// Destory the parent of the face we clicked
			Destroy(this.transform.parent.gameObject);
		}

		// right mouse button is pressed
		if (Input.GetMouseButtonDown (1)) {
			Debug.Log("Right click!");

			// call method from WorldGenerator class
			// http://in2gpu.com/2014/08/09/build-minecraft-unity-part-3/
			WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta,  // N = C + delta
			                             this.transform.parent.gameObject);    // The parent GameObject. we clone it
		}
	}
}
