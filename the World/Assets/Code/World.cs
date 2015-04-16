using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
	public int block_size;
	public GameObject chunk_object;
	public float perlin_noise_seed;

	public Tile dirt_tile;

	public int chunk_size_x;
	public int chunk_size_y;
	public int chunk_size_z;
	// Use this for initialization
	void Start () {
		Debug.Log ("Start World");

		this.chunk_size_x = 16;
		this.chunk_size_y = 64;
		this.chunk_size_z = 16;


		perlin_noise_seed = Random.Range (-1.0f, 1.0f);

		Debug.Log (perlin_noise_seed);


		// initialize tile texture
		/*dirt_tile = new Tile (3, 15,
		                      3, 15,
		                      14, 15,
		                      2, 15,
		                      3, 15,
		                      3, 15);
		                      */
		dirt_tile = new Tile (0, 14,
		                      0, 14,
		                      0, 14,
		                      0, 14,
		                      0, 14,
		                      0, 14);


		// begin to generate terrain
		StartCoroutine (SimpleGenerator ()); 	

	}
	
	// Update is called once per frame
	void Update () {
		// left mouse button is pressed
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log("Left click!");
			
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit, 100)){
				Debug.Log(hit.point.x);
				Debug.Log(hit.point.y);
				Debug.Log(hit.point.z);
			}
			
			
			// Destory the parent of the face we clicked
			//Destroy(this.transform.parent.gameObject);
		}
		
		// right mouse button is pressed
		if (Input.GetMouseButtonDown (1)) {
			Debug.Log("Right click!");
			
			// call method from WorldGenerator class
			// http://in2gpu.com/2014/08/09/build-minecraft-unity-part-3/
			//WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta,  // N = C + delta
			//                            this.transform.parent.gameObject);    // The parent GameObject. we clone it
		}
	}

	public static void CloneAndPlace(int x, int z, GameObject originalGameobject, World world){
		//clone
		GameObject clone_chunk_object = (GameObject)Instantiate (originalGameobject, 
		                                                         new Vector3((x * world.chunk_size_x * world.block_size)
		                                                                     , 0
		                                                                     , (z * world.chunk_size_z * world.block_size)), 
		                                                         Quaternion.identity);

		// create chunk
		Chunk chunk = new Chunk(x, z, clone_chunk_object, world);


		clone_chunk_object.name = "Chunk@" + x + "_" + z;
	}

	IEnumerator SimpleGenerator(){
		uint instancePerFrame = 30;
		uint instanceNum = 0;
		for (int i = 0; i < 10; i++) {
			for(int j = 0; j < 10; j++){
				// create new chunk
				CloneAndPlace (i, j, this.chunk_object, this);


				instanceNum += 1;
				if (instanceNum == instancePerFrame){
					// reset num
					instanceNum = 0;
					// Wait for next frame
					yield return new WaitForEndOfFrame();
				}
			}
		}
	}
}


