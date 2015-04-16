using UnityEngine;
using System.Collections;
/**
 *  Block class
 */
public enum Block_Type{
	DIRT
}


public class Block{
	// block type 
	protected Block_Type type;

	// block coordinates
	public int x; 
	public int y;
	public int z; 

	// block size
	public int block_size; 
	

	// chunk 
	protected Chunk chunk;

	//protected MeshCollider coll;

	// meshdata
	public MeshData meshdata;

	// constructor
	public Block(Block_Type type, int x, int y, int z, Chunk chunk){
		// init properties
		this.type = type;
		this.x = x; 
		this.y = y;
		this.z = z; 
		this.chunk = chunk;
		this.block_size = chunk.world.block_size;
	}

	// generate mesh 
	public void generateMesh(MeshData meshdata){
		meshdata.FaceDataXNegative (this);
		meshdata.FaceDataXPositive (this);
		meshdata.FaceDataYNegative (this);
		meshdata.FaceDataYPositive (this);
		meshdata.FaceDataZNegative (this);
		meshdata.FaceDataZPositive (this);

	}
}
