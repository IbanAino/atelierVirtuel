using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSelection : MonoBehaviour {

    public Material appleOutlineMaterial;
    public Material appleMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("handler"))
        {
            this.GetComponentInChildren<Renderer>().material = appleOutlineMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("handler"))
        {
            this.GetComponentInChildren<Renderer>().material = appleMaterial;
        }
    }
}
