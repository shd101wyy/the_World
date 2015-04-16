using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshData{

	// mesh properties
	public List<Vector3> vertices; //Vector3[] vertices;
	public List<Vector3> normals;  //Vector3[] normals;
	public List<Vector2> uvs;      //Vector2[] uvs;
	public List<int> triangles;    //int[] triangles;




	// constructor
	public MeshData(){
		this.vertices = new List<Vector3> ();
		this.normals = new List<Vector3>();
		this.uvs = new List<Vector2>();
		this.triangles = new List<int>();
	}

	public void FaceDataYPositive(Block block){
		float half_block_size = block.block_size / 2.0f;
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y + half_block_size, block.z + half_block_size));
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y + half_block_size, block.z + half_block_size));
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y + half_block_size, block.z - half_block_size));
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y + half_block_size, block.z - half_block_size));

		// add normals
		Vector3 up = Vector3.up;
		this.normals.Add (up);
		this.normals.Add (up);
		this.normals.Add (up);
		this.normals.Add (up);


		// add triangles
		this.AddQuadTriangles();


		// add textures
		Vector2 _00 = new Vector2( 0f, 480/512f );
		Vector2 _10 = new Vector2( 32/512f, 480/512f );
		Vector2 _01 = new Vector2( 0f, 1.0f );
		Vector2 _11 = new Vector2( 32/512.0f, 1.0f );
		this.uvs.Add (_11);
		this.uvs.Add (_01);
		this.uvs.Add (_00);
		this.uvs.Add (_10);
	}

	public void FaceDataYNegative(Block block){
		float half_block_size = block.block_size / 2.0f;
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y - half_block_size, block.z - half_block_size));
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y - half_block_size, block.z - half_block_size));
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y - half_block_size, block.z + half_block_size));
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y - half_block_size, block.z + half_block_size));

		// add normals
		Vector3 down = Vector3.down;
		this.normals.Add (down);
		this.normals.Add (down);
		this.normals.Add (down);
		this.normals.Add (down);

		// add triangles
		this.AddQuadTriangles();

		// add textures
		Vector2 _00 = new Vector2( 0f, 480/512f );
		Vector2 _10 = new Vector2( 32/512f, 480/512f );
		Vector2 _01 = new Vector2( 0f, 1.0f );
		Vector2 _11 = new Vector2( 32/512.0f, 1.0f );
		this.uvs.Add (_11);
		this.uvs.Add (_01);
		this.uvs.Add (_00);
		this.uvs.Add (_10);
	}

	public void FaceDataXPositive(Block block){
		float half_block_size = block.block_size / 2.0f;
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y - half_block_size, block.z - half_block_size));
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y + half_block_size, block.z - half_block_size));
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y + half_block_size, block.z + half_block_size));
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y - half_block_size, block.z + half_block_size));
		
		// add normals
		Vector3 right = Vector3.right;
		this.normals.Add (right);
		this.normals.Add (right);
		this.normals.Add (right);
		this.normals.Add (right);
		
		// add triangles
		this.AddQuadTriangles();

		// add textures
		Vector2 _00 = new Vector2( 0f, 480/512f );
		Vector2 _10 = new Vector2( 32/512f, 480/512f );
		Vector2 _01 = new Vector2( 0f, 1.0f );
		Vector2 _11 = new Vector2( 32/512.0f, 1.0f );
		this.uvs.Add (_11);
		this.uvs.Add (_01);
		this.uvs.Add (_00);
		this.uvs.Add (_10);
	}

	public void FaceDataXNegative(Block block){
		float half_block_size = block.block_size / 2.0f;
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y - half_block_size, block.z + half_block_size));
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y + half_block_size, block.z + half_block_size));
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y + half_block_size, block.z - half_block_size));
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y - half_block_size, block.z - half_block_size));


		// add normals
		Vector3 left = Vector3.left;
		this.normals.Add (left);
		this.normals.Add (left);
		this.normals.Add (left);
		this.normals.Add (left);

		// add triangles
		this.AddQuadTriangles();

		// add textures
		Vector2 _00 = new Vector2( 0f, 480/512f );
		Vector2 _10 = new Vector2( 32/512f, 480/512f );
		Vector2 _01 = new Vector2( 0f, 1.0f );
		Vector2 _11 = new Vector2( 32/512.0f, 1.0f );
		this.uvs.Add (_11);
		this.uvs.Add (_01);
		this.uvs.Add (_00);
		this.uvs.Add (_10);
	}

	public void FaceDataZPositive(Block block){
		float half_block_size = block.block_size / 2.0f;
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y - half_block_size, block.z - half_block_size));
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y + half_block_size, block.z - half_block_size));
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y + half_block_size, block.z - half_block_size));
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y - half_block_size, block.z - half_block_size));
		
		// add normals
		Vector3 front = Vector3.forward;
		this.normals.Add (front);
		this.normals.Add (front);
		this.normals.Add (front);
		this.normals.Add (front);
		
		// add triangles
		this.AddQuadTriangles();

		// add textures
		Vector2 _00 = new Vector2( 0f, 480/512f );
		Vector2 _10 = new Vector2( 32/512f, 480/512f );
		Vector2 _01 = new Vector2( 0f, 1.0f );
		Vector2 _11 = new Vector2( 32/512.0f, 1.0f );
		this.uvs.Add (_11);
		this.uvs.Add (_01);
		this.uvs.Add (_00);
		this.uvs.Add (_10);
	}

	public void FaceDataZNegative(Block block){
		float half_block_size = block.block_size / 2.0f;
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y - half_block_size, block.z + half_block_size));
		this.vertices.Add(new Vector3(block.x + half_block_size, block.y + half_block_size, block.z + half_block_size));
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y + half_block_size, block.z + half_block_size));
		this.vertices.Add(new Vector3(block.x - half_block_size, block.y - half_block_size, block.z + half_block_size));
		
		// add normals
		Vector3 back = Vector3.back;
		this.normals.Add (back);
		this.normals.Add (back);
		this.normals.Add (back);
		this.normals.Add (back);
		
		// add triangles
		this.AddQuadTriangles();

		// add textures
		Vector2 _00 = new Vector2( 0f, 480/512f );
		Vector2 _10 = new Vector2( 32/512f, 480/512f );
		Vector2 _01 = new Vector2( 0f, 1.0f );
		Vector2 _11 = new Vector2( 32/512.0f, 1.0f );
		this.uvs.Add (_11);
		this.uvs.Add (_01);
		this.uvs.Add (_00);
		this.uvs.Add (_10);
	}


	// add triangles
	public void AddQuadTriangles(){
		triangles.Add(vertices.Count - 4);
		triangles.Add(vertices.Count - 3);
		triangles.Add(vertices.Count - 2);
		
		triangles.Add(vertices.Count - 4);
		triangles.Add(vertices.Count - 2);
		triangles.Add(vertices.Count - 1);
	}
	/**
	 *  return vertices coordinate for cube
	 */
	/*
	public Vector3[] getVertices(){
		float length = this.block_size;
		float width = this.block_size;
		float height = this.block_size;

		#region Vertices
		Vector3 p0 = new Vector3( -length * .5f + this.x,	-width * .5f + this.y, height * .5f + this.z );
		Vector3 p1 = new Vector3( length * .5f + this.x, 	-width * .5f + this.y, height * .5f + this.z );
		Vector3 p2 = new Vector3( length * .5f + this.x, 	-width * .5f + this.y, -height * .5f + this.z );
		Vector3 p3 = new Vector3( -length * .5f + this.x,	-width * .5f + this.y, -height * .5f + this.z );	
		
		Vector3 p4 = new Vector3( -length * .5f + this.x,	width * .5f + this.y,  height * .5f + this.z );
		Vector3 p5 = new Vector3( length * .5f + this.x, 	width * .5f + this.y,  height * .5f + this.z );
		Vector3 p6 = new Vector3( length * .5f + this.x, 	width * .5f + this.y,  -height * .5f + this.z );
		Vector3 p7 = new Vector3( -length * .5f + this.x,	width * .5f + this.y,  -height * .5f + this.z );
		
		Vector3[] vertices = new Vector3[]
		{
			// Bottom
			p0, p1, p2, p3,
			
			// Left
			p7, p4, p0, p3,
			
			// Front
			p4, p5, p1, p0,
			
			// Back
			p6, p7, p3, p2,
			
			// Right
			p5, p6, p2, p1,
			
			// Top
			p7, p6, p5, p4
		};
		#endregion
		return vertices;
	}*/

	/**
	 *  return cube normals
	 */
	/*
	public Vector3[] getNormals(){
		#region Normales
		Vector3 up 	= Vector3.up;
		Vector3 down 	= Vector3.down;
		Vector3 front 	= Vector3.forward;
		Vector3 back 	= Vector3.back;
		Vector3 left 	= Vector3.left;
		Vector3 right 	= Vector3.right;
		
		Vector3[] normales = new Vector3[]
		{
			// Bottom
			down, down, down, down,
			
			// Left
			left, left, left, left,
			
			// Front
			front, front, front, front,
			
			// Back
			back, back, back, back,
			
			// Right
			right, right, right, right,
			
			// Top
			up, up, up, up
		};
		#endregion
		return normales;
	}
*/
	/**
	 * return cube uvs 
	 */

	//public Vector2[] getUVs(){
	//	#region UVs
		/**
		Vector2 _00 = new Vector2( 0f, 0f );
		Vector2 _10 = new Vector2( 1f, 1f );
		Vector2 _01 = new Vector2( 0f, 1f );
		Vector2 _11 = new Vector2( 1f, 1f );
		**/
		
		/**
		 * 01    11
		 * 
		 * 
		 * 00    10
		 * 
		 * Attention: UV coordinate starts from left bottom corner instead of left top corner!!
		 */
	/*
		Vector2 _00 = new Vector2( 0f, 480/512f );
		Vector2 _10 = new Vector2( 32/512f, 480/512f );
		Vector2 _01 = new Vector2( 0f, 1.0f );
		Vector2 _11 = new Vector2( 32/512.0f, 1.0f );
		Vector2[] uvs = new Vector2[]
		{
			// Bottom
			_11, _01, _00, _10,
			
			// Left
			_11, _01, _00, _10,
			
			// Front
			_11, _01, _00, _10,
			
			// Back
			_11, _01, _00, _10,
			
			// Right
			_11, _01, _00, _10,
			
			// Top
			_11, _01, _00, _10,
		};
		#endregion
		return uvs;
	}*/

	/*
	public int[] getTriangles(){
		
		#region Triangles
		int[] triangles = new int[]
		{
			// Bottom
			3, 1, 0,
			3, 2, 1,			
			
			// Left
			3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
			3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
			
			// Front
			3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
			3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
			
			// Back
			3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
			3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
			
			// Right
			3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
			3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
			
			// Top
			3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
			3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
			
		};
		#endregion
		return triangles;
	}
*/
}
