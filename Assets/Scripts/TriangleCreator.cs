using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TriangleCreator : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();

        // 5 vertices: 4 for base, 1 apex
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-1, 0, -1), // 0: Bottom left
            new Vector3(1, 0, -1),  // 1: Bottom right
            new Vector3(1, 0, 1),   // 2: Top right
            new Vector3(-1, 0, 1),  // 3: Top left
            new Vector3(0, 1.5f, 0) // 4: Apex (top center)
        };

        // Define triangles using vertex indices
        int[] triangles = new int[]
        {
            // Base (2 triangles)
            0, 1, 2,
            0, 2, 3,

            // Sides (4 triangles)
            0, 1, 4,
            1, 2, 4,
            2, 3, 4,
            3, 0, 4
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}