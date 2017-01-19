using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForwardMovment : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(1f*Time.deltaTime, 0f, 0f);
        //transform.position += transform.forward * Time.deltaTime;

        //transform.Translate(Vector3.forward * Time.deltaTime);
        //transform.Translate(Vector3.up * Time.deltaTime, Space.World);


    }
}
