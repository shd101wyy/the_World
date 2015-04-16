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
	protected int x; 
	protected int y;
	protected int z; 

	// block size
	protected int block_size; 
	

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

	// render 
	public MeshData generateMesh(){
		this.meshdata = new MeshData (this.x, 
		                         this.y,
		                         this.z,
		                         this.block_size);
		return this.meshdata;
	}
}
