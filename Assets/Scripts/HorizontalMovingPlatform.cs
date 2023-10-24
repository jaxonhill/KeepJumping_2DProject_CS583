using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingPlatform : MonoBehaviour
{
    public float speed;
    public float timeBetweenSwitch;
    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Flip directions
        if (timeElapsed > timeBetweenSwitch)
        {
            // Change direction
            speed = speed * -1;

            // Reset time
            timeElapsed = 0f;
        }

        // Move platform
        float horizontalMovement = speed * Time.deltaTime;
        transform.position += new Vector3(horizontalMovement, 0, 0);

        // Increment timeElapsed
        timeElapsed += Time.deltaTime;
    }
}
