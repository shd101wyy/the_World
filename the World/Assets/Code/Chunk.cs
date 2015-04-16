﻿using UnityEngine;
using System.Collections;

/**
 * 
 * z
 *
 * |
 * |
 * |
 * |
 *  ------> x
 * 
 */
public class Chunk: MonoBehaviour {
	protected Block[,,] blocks;

	protected int chunk_x;
	protected int chunk_z; 

	protected int size_x;
	protected int size_y;
	protected int size_z; 
	
	public World world;

	// Use this for initialization
	void Start(){
		Debug.Log ("Start Chunk");
		initChunk (0, 0);
	}

	/**
	 *  chunk_x and chunk_z is the position in the World. eg [0, 0], [0, 1] 
	 *  left bottom corner
	 */
	public void initChunk(int chunk_x, int chunk_z){
		this.size_x = 16; 
		this.size_y = 64; 
		this.size_z = 16;

		this.chunk_x = chunk_x;
		this.chunk_z = chunk_z; 
		this.blocks = new Block[this.size_x, this.size_y, this.size_z];

		this.generateBlocks ();
		this.renderBlocks ();
	}

	public Block GetBlock(int x, int y, int z){
		return this.blocks[x, y, z];
	}

	public void SetBlock(Block block, int x, int y, int z){
		int b_x = x - this.chunk_x * this.size_x;
		int b_z = z - this.chunk_z * this.size_z;
		int b_y = y;
		this.blocks [b_x, b_y, b_z] = block;
	}

	/**
	 * use perlin algorithm to generate terrain
	 */
	public void generateBlocks(){
		// In this Coroutine we will instantiate 20 voxels per frame
		//uint numberOfInstances = 0;
		//uint instancesPerFrame = 20;

		int chunk_pos_x = this.chunk_x * this.size_x;
		int chunk_pos_z = this.chunk_z * this.size_z;

		int x, y, z;
		int block_size = this.world.block_size;

		// use perlin noise to generate terrain
		for(x = 0; x < this.size_x; x++){
			for(z = 0; z< this.size_z; z++){
				// Compute a random height
				float height = 10*Mathf.PerlinNoise((x + chunk_pos_x)/12.0f, (z + chunk_pos_z)/12.0f);
				if(height >= this.size_y) // limit
					height = this.size_y - 10; 
				
				for (y = 0; y < height; y++){
					int block_x = (x + chunk_pos_x) * block_size;
					int block_y = y * block_size;
					int block_z = (z + chunk_pos_z) * block_size;
					Block block = new Block(Block_Type.DIRT, 
					                        block_x, // TODO: X block_size
					                        block_y,
					                        block_z, // TODO: X block_size
					                        this);
					this.blocks[x, y, z] = block;
				}
				// set empty.
				for(; y < this.size_y; y++){
					this.blocks[x, y, z] = null;
				}
			}
		}
	}

	public void renderBlocks(){
		Debug.Log ("Render Blocks");
		MeshFilter filter = GetComponent< MeshFilter >();
		Mesh mesh = filter.mesh;
		mesh.Clear();

		MeshData meshdata = new MeshData ();

		int x, y, z;
		for(x = 0; x < this.size_x; x++){
			for(z = 0; z< this.size_z; z++){
				for (y = 0; y < this.size_y; y++){
					if(this.blocks[x, y, z] != null){
						Debug.Log ("generate mesh");
					    this.blocks[x, y, z].generateMesh(meshdata);

						
					}
				}
			}
		}

		mesh.vertices = meshdata.vertices.ToArray();
		mesh.normals = meshdata.normals.ToArray ();
		mesh.uv = meshdata.uvs.ToArray();
		mesh.triangles = meshdata.triangles.ToArray();
		
		
		
		mesh.RecalculateBounds();
		mesh.Optimize();
	
	}
}