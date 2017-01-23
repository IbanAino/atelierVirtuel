using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleLightControl : MonoBehaviour {

    public int count = 0;

    public GameObject button;

    void Start () {
        this.GetComponent<Light>().enabled = false;
    }

    private void Update()
    {
        if(button.GetComponent<ButtonOnTheConsole>().buttonPushed == true)
        {
            this.GetComponent<Light>().enabled = true;
        }
        else
        {
            this.GetComponent<Light>().enabled = false;
        }
    }
}
