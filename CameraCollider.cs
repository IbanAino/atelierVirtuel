using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraCollider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ChangeSceneSphere01") == true)
            SceneManager.LoadScene("Scene 02");

        //Debug.Log(collision.gameObject.name);        
    }
}
