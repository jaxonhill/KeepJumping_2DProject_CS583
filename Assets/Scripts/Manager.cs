using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject starBackground;
    public float secondsBetweenStarSpawns = 6.5f;
    void Start()
    {
        // Spawn player
        Instantiate<GameObject>(player);
        player.transform.position = Vector3.zero;

        // Star spawning stars
        SpawnStars();
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
}
