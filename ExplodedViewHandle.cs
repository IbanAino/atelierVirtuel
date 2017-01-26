using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedViewHandle : MonoBehaviour {

    public GameObject target;
    public GameObject controller;
    public bool triggerPressed;
    private GameObject expldedViewHandle = null;
    private bool doOnce = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        triggerPressed = controller.GetComponent<SteamVR_TrackedController>().triggerPressed;

        if (triggerPressed)
        {
            if(expldedViewHandle != null)
            {
                if(doOnce == true)
                {
                    target.transform.position = expldedViewHandle.transform.position;
                    doOnce = false;
                }
                else
                {
                    expldedViewHandle.transform.position = new Vector3(expldedViewHandle.transform.position.x, expldedViewHandle.transform.position.y, target.transform.position.z);
                }
            }
        }
        else
        {
            if (doOnce == false)
                expldedViewHandle = null;

            doOnce = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("explodedViewHandle"))
            expldedViewHandle = other.gameObject;
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (expldedViewHandle == other.gameObject)
            expldedViewHandle = null;
    }*/
}
