using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is for generating Locations to place asset currently just trees
 * Trees are currently just placed in a preset location that is out of water and below mountains
 */
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

    //This function determinds where trees can be placed and places them at the start of game
    void PlaceTrees()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            if (vertices[i].y > 2.3 && vertices[i].y < 2.35)
            {
                float yAxisOffset = Random.Range(-3.0f, -1f);
                Vector3 placementVertex = vertices[i];
                placementVertex.y += yAxisOffset;
                GameObject spawnedObject = Instantiate(OriginalTree, placementVertex, Quaternion.identity);
                Trees.Add(spawnedObject);
                TreePosition.Add(spawnedObject.transform.position);
            }
        }
    }
}