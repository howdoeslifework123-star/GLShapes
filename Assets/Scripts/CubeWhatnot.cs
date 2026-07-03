using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CubeGenerator : MonoBehaviour
{
    [Header("Cube Settings")]
    [Tooltip("Length of each side of the cube.")]
    public float size = 1f;

    void Start()
    {
        GenerateCube();
    }

    public void GenerateCube()
    {
        Mesh mesh = new Mesh();
        mesh.name = "ProceduralCube";

        float h = size * 0.5f;

       
        Vector3[] vertices = new Vector3[]
        {

            new Vector3(-h,-h, h), new Vector3( h,-h, h), new Vector3( h, h, h), new Vector3(-h, h, h),
           
            new Vector3( h,-h,-h), new Vector3(-h,-h,-h), new Vector3(-h, h,-h), new Vector3( h, h,-h),
       
            new Vector3(-h,-h,-h), new Vector3(-h,-h, h), new Vector3(-h, h, h), new Vector3(-h, h,-h),
         
            new Vector3( h,-h, h), new Vector3( h,-h,-h), new Vector3( h, h,-h), new Vector3( h, h, h),
        
            new Vector3(-h, h, h), new Vector3( h, h, h), new Vector3( h, h,-h), new Vector3(-h, h,-h),
        
            new Vector3(-h,-h,-h), new Vector3( h,-h,-h), new Vector3( h,-h, h), new Vector3(-h,-h, h),
        };

        Vector3[] normals = new Vector3[]
        {
            Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward,
            Vector3.back, Vector3.back, Vector3.back, Vector3.back,
            Vector3.left, Vector3.left, Vector3.left, Vector3.left,
            Vector3.right, Vector3.right, Vector3.right, Vector3.right,
            Vector3.up, Vector3.up, Vector3.up, Vector3.up,
            Vector3.down, Vector3.down, Vector3.down, Vector3.down,
        };

        Vector2[] uv = new Vector2[24];
        for (int face = 0; face < 6; face++)
        {
            int b = face * 4;
            uv[b + 0] = new Vector2(0, 0);
            uv[b + 1] = new Vector2(1, 0);
            uv[b + 2] = new Vector2(1, 1);
            uv[b + 3] = new Vector2(0, 1);
        }

        int[] triangles = new int[36];
        for (int face = 0; face < 6; face++)
        {
            int vb = face * 4;
            int tb = face * 6;
            triangles[tb + 0] = vb + 0;
            triangles[tb + 1] = vb + 2;
            triangles[tb + 2] = vb + 1;
            triangles[tb + 3] = vb + 0;
            triangles[tb + 4] = vb + 3;
            triangles[tb + 5] = vb + 2;
        }

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
