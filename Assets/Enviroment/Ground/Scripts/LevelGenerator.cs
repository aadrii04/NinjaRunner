using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    const float playerDistanceForSpawnLevelPart = 20f;
    [SerializeField] Transform levelPartStart;
    [SerializeField] List<Transform> levelPartList;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject allPlatforms;

    Vector3 lastEndPosition;
    Transform lastLevelPartTransform;


    private void Awake()
    {
        lastEndPosition = levelPartStart.Find("EndPosition").position;
        lastLevelPartTransform = levelPartStart;
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < playerDistanceForSpawnLevelPart)
        {
            Destroy(lastLevelPartTransform.gameObject, 13f);
            SpawnLevelPart();
        }
    }

    void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        levelPartTransform.transform.parent = allPlatforms.transform;
        return levelPartTransform;
    }

    public void DestroyAllPlatforms()
    {
        Destroy(allPlatforms.gameObject);
    }
}
