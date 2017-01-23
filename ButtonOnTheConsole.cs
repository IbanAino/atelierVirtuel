using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonOnTheConsole : MonoBehaviour {

    private Vector3 initialButtonTransform;

    public Material redMaterial;
    public Material greenMaterial;

    public bool buttonPushed;

    void Start () {
        initialButtonTransform = this.transform.position;
        this.GetComponent<Renderer>().material = redMaterial;
        buttonPushed = false;
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("handler"))
        {
            this.transform.localPosition += new Vector3(0, -0.2F, 0);
            this.GetComponent<Renderer>().material = greenMaterial;
            buttonPushed = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("handler"))
        {
            this.transform.position = initialButtonTransform;
            this.GetComponent<Renderer>().material = redMaterial;
            buttonPushed = false;
        }
    }
}
