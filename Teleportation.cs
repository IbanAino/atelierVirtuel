using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {

    private LineRenderer lineRenderer;

    private Vector3 newPlayerPosition;
    private bool teleportationAllowed;
    public GameObject target;

    void Start () {
        lineRenderer = GetComponent<LineRenderer>();

        //listen the eevnt from SteamVR_TrackedController
        var trackedController = GetComponent<SteamVR_TrackedController>();
        trackedController.TriggerUnclicked += new ClickedEventHandler(OnTriggerReleased);
    }

    void Update() {

        if (GetComponent<SteamVR_TrackedController>().triggerPressed == true)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Debug.Log(hit.collider.gameObject.name);

                    if (hit.collider.gameObject.CompareTag("Floor") == true)
                    {
                        teleportationAllowed = true;
                    }
                    else
                    {
                        teleportationAllowed = false;
                    }
                    newPlayerPosition = hit.point;
                }
            }

            //Show ray from the controller to the target
            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, newPlayerPosition);
            lineRenderer.startWidth = 0.01f;
            lineRenderer.endWidth = 0.01f;

            lineRenderer.enabled = true;

            if (teleportationAllowed == true)// Show the enabled target
            {
                target.GetComponentInChildren<SpriteRenderer>().enabled = true;
                target.transform.position = newPlayerPosition + new Vector3(0, 0.01f, 0);
                target.transform.rotation = Quaternion.Euler(90, 0, 0);

                lineRenderer.startColor = new Color(0, 1, 0);
            }
            else// Show the not enabled target
            {
                lineRenderer.startColor = new Color(1, 0, 0);
                target.GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            target.GetComponentInChildren<SpriteRenderer>().enabled = false;;

            lineRenderer.enabled = false;
        }
    }

    public void OnTriggerReleased(object sender, ClickedEventArgs e)
    {
        if (teleportationAllowed == true)
            GameObject.FindWithTag("Player").transform.position = newPlayerPosition;
    }
}
