using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    public List<GameObject> Tiles = new List<GameObject>();
    public GameObject nextTile;

    private float zDistanceNextTile = 0f;
    private float tileLength = 2.1625f;
    private int numberOfTiles = 40;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float totalLengthOfTiles = numberOfTiles * tileLength;
        if (playerTransform.position.z - (4*tileLength)> zDistanceNextTile - totalLengthOfTiles)
        {
            SpawnTile();
            DeleteTile();
        }
    }

    public void SpawnTile()
    {
        int index = Random.Range(0, Tiles.Count);
        nextTile = Tiles[index];
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
