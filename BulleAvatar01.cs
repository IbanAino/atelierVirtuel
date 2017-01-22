using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleAvatar01 : MonoBehaviour {

    private Animator anim;
    public bool avatarMovment;
    public GameObject avatar;

    public int programState;

    //variables for the avatar rotation
    public bool rotate = true;
    //public Transform initialRotation;
    //public Transform secondRotation;

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
        speed = 0.7F;

        startPosition = avatar.transform.position;
        endPosition = avatar.transform.position + new Vector3(-5, 0, 0);

        avatar.transform.rotation = Quaternion.Euler(0, 90, 0);

        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    void Update()
    {
        if(programState == 1) //aller
        {

            if (rotate == true)
            {
                //avatar.transform.rotation = Quaternion.Euler(0, -90, 0);

                avatar.transform.rotation = Quaternion.Lerp(avatar.transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * 10);

                if (avatar.transform.rotation == Quaternion.Euler(0, -90, 0))
                {
                    rotate = false;
                    startTime = Time.time;
                }
            }
            else
            {
                float distCovered = Time.time - startTime;
                float fracJourney = (distCovered / journeyLength) * speed;
                avatar.transform.position = Vector3.Lerp(startPosition, endPosition, fracJourney);

                if (avatar.transform.position == endPosition)
                {
                    anim.SetBool("idle2ToWalk", false);
                    anim.SetBool("walkToIdle2", true);
                    programState = 3;
                }
            }
        }
        else if(programState == 2) //retour
        {
            if(rotate == true)
            {
                //avatar.transform.rotation = Quaternion.Euler(0, 90, 0);

                avatar.transform.rotation = Quaternion.Lerp(avatar.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 10);

                if (avatar.transform.rotation == Quaternion.Euler(0, 90, 0))
                {
                    rotate = false;
                    startTime = Time.time;
                }
            }
            else
            {
                float distCovered = Time.time - startTime;
                float fracJourney = (distCovered / journeyLength) * speed;
                avatar.transform.position = Vector3.Lerp(endPosition, startPosition, fracJourney);

                if (avatar.transform.position == startPosition)
                {
                    anim.SetBool("idle2ToWalk", false);
                    anim.SetBool("walkToIdle2", true);
                    programState = 3;
                }
            }
        }
        else //repos
        {

        }
    }

    void OnTriggerEnter(Collider other)
    {      
        if (other.gameObject.tag == "Player")
        {
            programState = 1; //aller

            anim.SetBool("walkToIdle2", false);
            anim.SetBool("idle2ToWalk", true);

            //startTime = Time.time;

            endPosition = startPosition + new Vector3(-5, 0, 0);

            rotate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            programState = 2; //retour

            anim.SetBool("walkToIdle2", false);
            anim.SetBool("idle2ToWalk", true);

            //startTime = Time.time;

            endPosition = avatar.transform.position;

            rotate = true;
        }
    }
}
