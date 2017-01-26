using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBottleManager : MonoBehaviour {

    public GameObject juice;
    private float juiceMaxSize;
    public float juiceMaxPosition;


	void Start () {
        juiceMaxSize = juice.transform.localScale.y;
        juiceMaxPosition = juice.transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(juice.transform.localScale.y > juiceMaxSize)
        {
            juice.transform.localScale = new Vector3(juice.transform.localScale.x, 0, juice.transform.localScale.z);
        }
        else
        {
            juice.transform.localScale = new Vector3(juice.transform.localScale.x, juice.transform.localScale.y + 0.1F * Time.deltaTime, juice.transform.localScale.z);
            juice.transform.localPosition = new Vector3(juice.transform.localPosition.x, juice.transform.localScale.y + 0.1F * Time.deltaTime, juice.transform.localPosition.z);
        }

	}
}
