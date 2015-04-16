using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
	public int block_size;
	public GameObject chunk_object;
	// Use this for initialization
	void Start () {
		Debug.Log ("Start World");
		CloneAndPlace (0, 0, this.chunk_object, this);
		CloneAndPlace (0, 1, this.chunk_object, this);
		CloneAndPlace (1, 1, this.chunk_object, this);
		CloneAndPlace (1, 0, this.chunk_object, this);

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void CloneAndPlace(int x, int z, GameObject originalGameobject, World world){
		//clone
		GameObject clone_chunk_object = (GameObject)Instantiate (originalGameobject, new Vector3(0, 0, 0), Quaternion.identity);

		// create chunk
		Chunk chunk = new Chunk(x, z, clone_chunk_object, world);


		clone_chunk_object.name = "Chunk@" + x + "_" + z;
	}
}


