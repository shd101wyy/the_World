using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
	public int block_size;
	public GameObject chunk_object;
	public float perlin_noise_seed;
	// Use this for initialization
	void Start () {
		Debug.Log ("Start World");

		perlin_noise_seed = Random.Range (-1.0f, 1.0f);

		StartCoroutine (SimpleGenerator ()); 	

		Debug.Log (perlin_noise_seed);
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

	IEnumerator SimpleGenerator(){
		uint instancePerFrame = 30;
		uint instanceNum = 0;
		for (int i = -10; i < 10; i++) {
			for(int j = -10; j < 10; j++){
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


