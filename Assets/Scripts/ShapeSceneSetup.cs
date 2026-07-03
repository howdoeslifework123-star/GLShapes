using UnityEngine;

public class ShapeSceneSetup : MonoBehaviour
{
    void Start()
    {

        GameObject cubeGO = new GameObject("ProceduralCube");
        cubeGO.transform.position = new Vector3(-3f, 1f, 0f);
        cubeGO.AddComponent<MeshFilter>();
        cubeGO.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Standard")) { color = Color.red };
        cubeGO.AddComponent<CubeGenerator>().size = 1.5f;


        GameObject pyramidGO = new GameObject("ProceduralPyramid");
        pyramidGO.transform.position = new Vector3(0f, 0f, 0f);
        pyramidGO.AddComponent<MeshFilter>();
        pyramidGO.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Standard")) { color = Color.green };
        var pyr = pyramidGO.AddComponent<PyramidGenerator>();
        pyr.baseSize = 1.5f;
        pyr.height = 2f;


        GameObject sphereGO = new GameObject("ProceduralSphere");
        sphereGO.transform.position = new Vector3(3f, 1f, 0f);
        sphereGO.AddComponent<MeshFilter>();
        sphereGO.AddComponent<MeshRenderer>().material = new Material(Shader.Find("Standard")) { color = Color.blue };
        var sph = sphereGO.AddComponent<SphereGenerator>();
        sph.radius = 1f;
        sph.segments = 12;
        sph.rings = 12;


        if (Camera.main != null)
        {
            Camera.main.transform.position = new Vector3(0f, 3f, -8f);
            Camera.main.transform.LookAt(new Vector3(0f, 1f, 0f));
        }
    }
}
