using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ClickAction(object sender, ClickedEventArgs e);

public class EventEnvoyeur : MonoBehaviour {

    public static event ClickAction OnClicked;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void clicked(ClickedEventArgs e)
    {
        if (OnClicked != null)
            OnClicked(this, e);
    }
}
