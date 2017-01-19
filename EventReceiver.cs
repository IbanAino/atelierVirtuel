using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour {

	void Start () {
        EventEnvoyeur.OnClicked += this.voidMethod;
	}

    public void voidMethod(object sender, ClickedEventArgs e)
    {

    }
}
