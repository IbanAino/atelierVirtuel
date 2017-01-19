using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeScene01 : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
         if(collision.gameObject.CompareTag("MainCamera"))
            SceneManager.LoadScene("Scene 02", LoadSceneMode.Additive);

        Debug.Log(collision.gameObject.name);
    }
}
