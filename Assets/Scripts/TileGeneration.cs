using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    public GameObject nextTile;

    public float zDistanceNextTile = 0f;
    public float tileLength = 8.65f;
    public int numberOfTiles = 10;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        float totalLengthOfTiles = numberOfTiles * tileLength;
        if (playerTransform.position.z - (2*tileLength)> zDistanceNextTile - totalLengthOfTiles)
        {
            SpawnTile();
            DeleteTile();
        }
    }

    public void SpawnTile()
    {
        GameObject go = Instantiate(nextTile, transform.forward * zDistanceNextTile, transform.rotation);
        activeTiles.Add(go);
        zDistanceNextTile += tileLength;
    }

    private void DeleteTile()
    {
        //delete the first tile in the activeTiles list
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
