using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleAvatar01 : MonoBehaviour {

    public Animator anim;
    public bool avatarMovment;
    public GameObject avatar;

    //variables for the avatar movment
    public Vector3 startPosition;
    public Vector3 endPosition;
    private float startTime;
    public float speed;
    private float journeyLength;
    public bool direction;

    void Start()
    {
        //anim = GameObject.FindWithTag("Avatar01").GetComponent<Animator>();
        anim = avatar.GetComponent<Animator>();

        //for the avatar movment
        speed = 0.5F;
        startPosition = this.transform.position;
        endPosition = this.transform.position + new Vector3(-10, 0, 0);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    void Update()
    {
        if(avatarMovment == true)
        {
            //GameObject.FindWithTag("Avatar01").transform.Translate(Vector3.forward * Time.deltaTime);
            float distCovered = Time.time - startTime;
            float fracJourney = (distCovered / journeyLength) * speed;
            avatar.transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);
        }
    }

    void OnTriggerEnter(Collider other)
    {      
        if (other.gameObject.tag == "Player")
        {
            //launch the animation
            anim.SetBool("idle2ToWalk", true);
            //move the avatar
            avatarMovment = true;

            Debug.Log("Bubble tuched");
        }
    }
}
