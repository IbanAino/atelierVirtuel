using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTest : MonoBehaviour {

    public Material outline;

    // Use this for initialization
    void Start () {
        this.GetComponentInChildren<Renderer>().material = outline;
    }
}
