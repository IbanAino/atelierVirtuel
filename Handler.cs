using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    public GameObject tuchedGameObject = null;
    public GameObject apple = null;

    public Material appleOutlineMaterial;
    public Material appleMaterial;

    public bool triggerPressed;

    public int counter = 0;

    void Start()
    {
        // listen the controller's buttons
        var trackedController = GetComponent<SteamVR_TrackedController>();
        if (trackedController == null)
        {
            trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
        }

        trackedController.TriggerClicked += new ClickedEventHandler(OnButtonPressed);
        trackedController.TriggerUnclicked += new ClickedEventHandler(oOnButtonReleased);
    }

    void update()
    {

    } 

    public void TuchedGameObject (GameObject tuchedGameObject)
    {
        counter ++;

        //tuchedGameObject.GetComponentInChildren<Renderer>().material = appleOutlineMaterial;

        /*if (tuchedGameObject == null)
        {
            this.tuchedGameObject = tuchedGameObject;
            tuchedGameObject.GetComponentInChildren<Renderer>().material = appleOutlineMaterial;
        }
        else
        {
            tuchedGameObject.GetComponentInChildren<Renderer>().material = appleMaterial;
            this.tuchedGameObject = tuchedGameObject;
            this.tuchedGameObject.GetComponentInChildren<Renderer>().material = appleOutlineMaterial;
        }*/
    }

    //listen the controller's buttons
    private void OnButtonPressed(object sender, ClickedEventArgs e)
    {
        triggerPressed = true;
    }

    private void oOnButtonReleased(object sender, ClickedEventArgs e)
    {
        triggerPressed = false;
    }
}
 