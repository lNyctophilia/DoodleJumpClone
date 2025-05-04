using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    public GameObject[] platforms;
    public float spawnRate = 0.5f;
    public float leftPos = -0.4f, rightPos = 0.4f;
    public float currentY = 0.5f;
    public float distance = 1;
    public float space = 0.3f;
    private Transform player;
    private List<GameObject> spawnedPlatforms = new List<GameObject>();

    void Awake()
    {
        Instance = this;
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (!PlayerJump.Instance.falling && currentY - player.position.y < distance && LevelManager.Instance.isStart)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        GameObject platformPrefab = platforms[SpawnChance()];
        GameObject newPlatform = Instantiate(platformPrefab);

        newPlatform.transform.position = new Vector2(Random.Range(leftPos, rightPos), currentY);

        currentY += space;

        spawnedPlatforms.Add(newPlatform);
    }

    public void DestroyPlatforms()
    {
        spawnedPlatforms.RemoveAll(platform => platform == null);
        for (int i = 0; i < spawnedPlatforms.Count; i++)
        {
            Destroy(spawnedPlatforms[i]);
        }
        spawnedPlatforms.Clear();
        currentY = 0.5f;
    }
    int SpawnChance()
    {
        int i = Random.Range(1, 101);
        if(i <= 70 && i >= 1)
        {
            return 0;
        }
        if (i > 70 && i <= 90)
        {
            return 1;
        }
        if (i > 90 && i <= 100)
        {
            return 2;
        }
        else return 0;
    }
}