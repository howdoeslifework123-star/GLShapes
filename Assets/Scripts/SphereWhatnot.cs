using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SphereGenerator : MonoBehaviour
{
    [Header("Sphere Settings")]
    public float radius = 1f;

    [Tooltip("Number of horizontal segments (longitude). Must be > 5.")]
    [Min(6)] public int segments = 12;

    [Tooltip("Number of vertical rings (latitude). Must be > 5.")]
    [Min(6)] public int rings = 12;

    void Start()
    {
        GenerateSphere();
    }

    public void GenerateSphere()
    {

        segments = Mathf.Max(segments, 6);
        rings = Mathf.Max(rings, 6);

        Mesh mesh = new Mesh();
        mesh.name = "ProceduralSphere";

        int vertCount = (rings + 1) * (segments + 1);
        Vector3[] vertices = new Vector3[vertCount];
        Vector3[] normals = new Vector3[vertCount];
        Vector2[] uv = new Vector2[vertCount];

        int index = 0;
        for (int lat = 0; lat <= rings; lat++)
        {

            float theta = lat * Mathf.PI / rings;
            float sinTheta = Mathf.Sin(theta);
            float cosTheta = Mathf.Cos(theta);

            for (int lon = 0; lon <= segments; lon++)
            {

                float phi = lon * 2f * Mathf.PI / segments;
                float sinPhi = Mathf.Sin(phi);
                float cosPhi = Mathf.Cos(phi);

                Vector3 dir = new Vector3(sinTheta * cosPhi, cosTheta, sinTheta * sinPhi);

                vertices[index] = dir * radius;
                normals[index] = dir;
                uv[index] = new Vector2((float)lon / segments, 1f - (float)lat / rings);
                index++;
            }
        }

        int[] triangles = new int[rings * segments * 6];
        int t = 0;
        for (int lat = 0; lat < rings; lat++)
        {
            for (int lon = 0; lon < segments; lon++)
            {
                int current = lat * (segments + 1) + lon;
                int next = current + segments + 1;

                triangles[t++] = current;
                triangles[t++] = next;
                triangles[t++] = current + 1;

                triangles[t++] = current + 1;
                triangles[t++] = next;
                triangles[t++] = next + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
