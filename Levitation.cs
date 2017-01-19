using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitation : MonoBehaviour {

    public Vector3 startPosition;
    public Vector3 endPosition;
    private float startTime;
    public float speed;
    private float journeyLength;

    public bool direction;

    private void Start()
    {
        speed = 0.05F;

        startPosition = this.transform.position;
        endPosition = this.transform.position + new Vector3(0, 0.05f, 0);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    void Update () {

        if(direction == true)
        {
            float distCovered = Time.time - startTime;
            float fracJourney = (distCovered / journeyLength) * speed;
            transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
        }else
        {
            float distCovered = Time.time - startTime;
            float fracJourney = (distCovered / journeyLength) * speed;
            transform.position = Vector3.Lerp(endPosition, startPosition, fracJourney);
        }

        if (this.transform.position == endPosition)
        {
            direction = false;
            startTime = Time.time;
        }

        if (this.transform.position == startPosition)
        {
            direction = true;
            startTime = Time.time;
        }

    }
}
