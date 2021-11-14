using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetGenerator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    public GameObject OriginalTree;
    public List<GameObject> Trees = new List<GameObject>();
    public List<Vector3> TreePosition = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        PlaceTrees();
    }

    // Update is called once per frame
    void PlaceTrees()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            if (vertices[i].y > 5 && vertices[i].y < 8)
            {
                Debug.Log("Placing Tree");
                //vertices[i] += Vector3.up * Time.deltaTime;
                GameObject spawnedObject = Instantiate(OriginalTree, vertices[i], Quaternion.identity);
                Trees.Add(spawnedObject);
                TreePosition.Add(spawnedObject.transform.position);
            }                                                                       
        }       
    }
}