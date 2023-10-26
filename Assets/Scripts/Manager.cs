using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject starBackground;
    public float secondsBetweenStarSpawns = 6.5f;
    public float timeBetweenObstacleSpawns;
    public AudioListener audioListener;

    // Possible obstacles
    public List<GameObject> obstacles;

    void Start()
    {
        // Spawn player
        Instantiate<GameObject>(player);
        player.transform.position = Vector3.zero;

        // Get audio listener for mute button
        audioListener = GetComponent<AudioListener>();

        // Star spawning stars
        SpawnStars();

        // Start spawning obstacles after 2 minutes (after the "tutorial" 6 obstacles are done passing)
        Invoke("SpawnRandomObstacle", 120f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnStars()
    {
        // Spawn star background
        Instantiate<GameObject>(starBackground);
        starBackground.transform.position = new Vector3(75, 1, 0);
        // Invoke again infinitely every 6 seconds
        Invoke("SpawnStars", secondsBetweenStarSpawns);
    }

    void SpawnRandomObstacle()
    {
        // 6 possible obstacles, so get a random index from 
        int obstacle_index = Random.Range(0, obstacles.Count);

        // Instantiate the random obstacle
        Instantiate<GameObject>(obstacles[obstacle_index]);
        
        // Call same function to create recursive loop of spawning based on time interval
        Invoke("SpawnRandomObstacle", timeBetweenObstacleSpawns);
    }

    public void ToggleSound()
    {
        if (audioListener.enabled)
        {
            audioListener.enabled = false;
        }
        else
        {
            audioListener.enabled = true;
        }
    }
}
