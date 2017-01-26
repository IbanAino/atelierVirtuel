using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGameObjects : MonoBehaviour {


    public GameObject tuchedGameObject = null;

    public GameObject controller;

    public bool triggerPressed;

    private bool doOnce;

    public GameObject target;

    public GameObject[] selectionnablesGamesObjects;
    //public string[] tags;

    void Start()
    {
        controller = GameObject.FindWithTag("rightController");

        //Make an array with all the selectionnables GameObjects
        //Find the GameObject's tags to use them into the script
        //tags = new string[selectionnablesGamesObjects.Length];

        /*for (int i = 0; i < selectionnablesGamesObjects.Length; i++)
        {
            if (selectionnablesGamesObjects[i] != null)
                tags[i] = selectionnablesGamesObjects[i].tag;
        }*/
    }

    private void Update()
    {
        triggerPressed = controller.GetComponent<SteamVR_TrackedController>().triggerPressed;

        //saisir l'objet
        if (triggerPressed)
        {
            if (tuchedGameObject != null)
            {
                if (doOnce == true)
                {
                    target.transform.position = tuchedGameObject.transform.position;
                    target.transform.rotation = tuchedGameObject.transform.rotation;
                    doOnce = false;
                }
                else
                {
                    tuchedGameObject.transform.position = target.transform.position;
                    tuchedGameObject.transform.rotation = target.transform.rotation;
                }
            }
        }
        else
        {
            if (doOnce == false)
                if (tuchedGameObject != null)
                    tuchedGameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            doOnce = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (!triggerPressed)
        {
            for (int i = 0; i < selectionnablesGamesObjects.Length; i++)
            {
                if (selectionnablesGamesObjects[i] != null)
                    if (selectionnablesGamesObjects[i] == other.gameObject)
                        tuchedGameObject = other.gameObject;

            }
        }

        if (other.gameObject == selectionnablesGamesObjects[1])
            Debug.Log("Charlotte");

        Debug.Log(tuchedGameObject);
        Debug.Log(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (!triggerPressed)
        {
            if (tuchedGameObject == other.gameObject)
            {
                tuchedGameObject = null;
            }
        }
    }
}
