using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
	public int block_size;
	// Use this for initialization
	void Start () {
		Debug.Log ("Start World");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void CloneAndPlace(Vector3 newPosition, GameObject originalGameobject){
		//clone
		GameObject clone = (GameObject)Instantiate (originalGameobject, newPosition, Quaternion.identity);
		
		// place 
		clone.transform.position = newPosition; 
		
		//rename 
		clone.name = "Chunk@" + clone.transform.position;
	}
}


