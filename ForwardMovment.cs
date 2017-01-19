using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovment : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
            other.transform.Translate(-1f * Time.deltaTime, 0, 0, Space.World);
    }
}
