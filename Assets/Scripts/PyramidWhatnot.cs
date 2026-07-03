using Unity;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PyramidGenerator : MonoBehaviour
{
    [Header("Pyramid Settings")]
    [Tooltip("Width/depth of the square base.")]
    public float baseSize = 1f;
    [Tooltip("Height from base to apex.")]
    public float height = 1.5f;

    void Start()
    {
        GeneratePyramid();
    }

    public void GeneratePyramid()
    {
        Mesh mesh = new Mesh();
        mesh.name = "ProceduralPyramid";

        float h = baseSize * 0.5f;


        Vector3 bfl = new Vector3(-h, 0, -h); 
        Vector3 bfr = new Vector3( h, 0, -h); 
        Vector3 ffr = new Vector3( h, 0,  h); 
        Vector3 ffl = new Vector3(-h, 0,  h); 
        Vector3 apex = new Vector3(0, height, 0);

    
        Vector3[] vertices = new Vector3[]
        {

            bfl, ffl, ffr,
            bfl, ffr, bfr,

        
            ffl, ffr, apex,


            ffr, bfr, apex,


            bfr, bfl, apex,


            bfl, ffl, apex,
        };

        int[] triangles = new int[vertices.Length];
        for (int i = 0; i < vertices.Length; i++) triangles[i] = i;

        Vector2[] uv = new Vector2[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            uv[i] = new Vector2(vertices[i].x / baseSize + 0.5f, vertices[i].z / baseSize + 0.5f);
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals(); 
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
