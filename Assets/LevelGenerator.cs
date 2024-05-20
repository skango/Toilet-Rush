using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

	public GameObject platformPrefab;

	public int numberOfPlatforms = 200;
	public float levelWidth = 3f;
	public float minY = .2f;
	public float maxY = 1.5f;
    Vector3 spawnPosition;

    // Use this for initialization
    public void Start()
	{

		if (!Application.isMobilePlatform)
		{
			levelWidth = 6;
			
		}else
		{
            minY = 2;
            maxY = 2.5f;
        }
		

		for (int i = 0; i < numberOfPlatforms; i++)
		{

			spawnPosition.y += Random.Range(minY, maxY);
			if (i == 0 && spawnPosition.y < 10)
			{
				spawnPosition.y = 1f;
			}
			spawnPosition.x = Random.Range(-levelWidth, levelWidth);
			Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
		}
	}
}

	
