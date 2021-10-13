using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class Renders 'Chunks' of mesh around the player
 * along with disable them when out of max view distance
 */
public class EndlessTerrain : MonoBehaviour
{
    public const float maxViewDistance = 450;
    public Transform viewer;

    public static Vector2 viewPosition;
    int chunkSize;
    int chunksVisibleInViewDistance;

    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
    List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();

    private void Start()
    {
        chunkSize = MapGenerator.mapChunkSize - 1;
        chunksVisibleInViewDistance = Mathf.RoundToInt(maxViewDistance / chunkSize);
    }
    public void Update()
    {
        viewPosition = new Vector2(viewer.position.x, viewer.position.z);
        updateVisableChunks();
    }

    void updateVisableChunks()
    {
        for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++)
        {
            terrainChunksVisibleLastUpdate[i].SetVisible(false);
        }
        terrainChunksVisibleLastUpdate.Clear();

        int currentChunkCoordX = Mathf.RoundToInt(viewPosition.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(viewPosition.y / chunkSize);

        for (int yOffset = -chunksVisibleInViewDistance; yOffset <= chunksVisibleInViewDistance; yOffset++)
        {
            for (int xOffset = -chunksVisibleInViewDistance; xOffset <= chunksVisibleInViewDistance; xOffset++)
            {
                Vector2 viewChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);
                if (terrainChunkDictionary.ContainsKey(viewChunkCoord))
                {
                    terrainChunkDictionary[viewChunkCoord].UpdateTerrainChunk();
                    if (terrainChunkDictionary[viewChunkCoord].IsVisible())
                    {
                        terrainChunksVisibleLastUpdate.Add(terrainChunkDictionary[viewChunkCoord]);
                    }
                }
                else
                {
                    terrainChunkDictionary.Add(viewChunkCoord, new TerrainChunk(viewChunkCoord, chunkSize, transform));
                }
            }
        }
    }
    public class TerrainChunk
    {
        GameObject meshObject;
        Vector2 position;
        Bounds bounds;

        public TerrainChunk(Vector2 coord, int size, Transform parent)
        {
            position = coord * size;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3 positionV3 = new Vector3(position.x, 0, position.y);
            meshObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
            meshObject.transform.position = positionV3;
            meshObject.transform.localScale = Vector3.one * size / 10f;
            meshObject.transform.parent = parent;
            SetVisible(false);
        }
        public void UpdateTerrainChunk()
        {
            float viewerDistanceFormNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewPosition));
            bool visible = viewerDistanceFormNearestEdge <= maxViewDistance;
            SetVisible(visible);
        }
        public void SetVisible(bool visible)
        {
            meshObject.SetActive(visible);
        }
        public bool IsVisible()
        {
            return meshObject.activeSelf;
        }
    }
}