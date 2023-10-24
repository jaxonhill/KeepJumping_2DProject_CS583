using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{
    // NOTE: This is essentially the same code as the horizontal one, just flipped to be vertical
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
        float verticalMovement = speed * Time.deltaTime;
        transform.position += new Vector3(0, verticalMovement, 0);

        // Increment timeElapsed
        timeElapsed += Time.deltaTime;
    }
}
