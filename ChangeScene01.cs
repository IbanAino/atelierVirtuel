using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeScene01 : MonoBehaviour {

    public GameObject gameController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            ChangeScene();
            //SceneManager.LoadScene("Scene 02", LoadSceneMode.Additive);
        }           
    }

    IEnumerator ChangeScene()
    {
        float fadeTime = gameController.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Scene 02", LoadSceneMode.Additive);
    }
}
