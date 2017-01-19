using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

    public Material appleOutlineMaterial;
    public Material appleMaterial;

    public GameObject apple = null;

    public bool triggerPressed;

    public GameObject target;
    private bool doOnce = true;

     private RaycastHit hit;

    private void Update()
    {
        if(triggerPressed == true)
        {
            if (doOnce == true)
            {
                target.transform.position = this.transform.parent.position + (apple.transform.position - this.transform.parent.position);
                target.transform.rotation = apple.transform.rotation;
                doOnce = false;
            }
            apple.transform.position = target.transform.position;
            apple.transform.rotation = target.transform.rotation;
        }
        else
        {
            doOnce = true;
        }

        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            if (hit.distance < 0.03f)
            {
                print(hit.collider.gameObject.name);
                hit.collider.gameObject.GetComponentInChildren<Renderer>().material = appleOutlineMaterial;
            }
            else
            {
                print("Aucun objet n'est dans le rayon");
            }
        }
        else
        {
            print("Aucun objet n'est dans le rayon");
        }

        Debug.DrawRay(transform.position, transform.forward, Color.red, 1);
    }


    /*void OnTriggerEnter(Collider other)
    {
        if (apple == null)
        {
            apple = other.gameObject;
        }
        else
        {
            apple.GetComponentInChildren<Renderer>().material = appleMaterial;
            apple = other.gameObject;
        }
        apple.GetComponentInChildren<Renderer>().material = appleOutlineMaterial;
    }

    private void OnTriggerStay(Collider other)
    {
        apple.GetComponentInChildren<Renderer>().material = appleOutlineMaterial;
    }

    void OnTriggerExit(Collider other)
    {
        other.GetComponentInChildren<Renderer>().material = appleMaterial;
    }*/


    //communication between controller and handler
    public void Trigger(bool x)
    {
        triggerPressed = x;
    }

}
