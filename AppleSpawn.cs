using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawn : MonoBehaviour {

    public GameObject apple;
    public float appleRate;
    private float nextApple;

    // Update is called once per frame
    void Update () {
        if (Time.time > nextApple)
        {
            nextApple = Time.time + appleRate;

            Vector3 position = new Vector3(1, 0, 1);
            position *= Random.value * 0.1f;

            Instantiate(apple, this.transform.position + position, this.transform.rotation);
        }
    }
}
