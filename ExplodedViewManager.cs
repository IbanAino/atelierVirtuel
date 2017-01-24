using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedViewManager : MonoBehaviour {

    public GameObject[] engineParts;
    public GameObject handler;
    public GameObject explosionOrigin;

    public Vector3[] initialPartsPositions;
    public Vector3 initialHandlerPosition;

    public float facteurDeDeplacementMere;
    public float[] facteurDeDeplacementX;
    public float[] facteurDeDeplacementY;
    public float[] facteurDeDeplacementZ;

    public bool[] xMovment;
    public bool[] yMovment;
    public bool[] zMovment;

    void Start () {
        initialPartsPositions = new Vector3[engineParts.Length];
        initialHandlerPosition = handler.transform.position;

        facteurDeDeplacementX = new float[engineParts.Length];
        facteurDeDeplacementY = new float[engineParts.Length];
        facteurDeDeplacementZ = new float[engineParts.Length];

        xMovment = new bool[engineParts.Length];
        yMovment = new bool[engineParts.Length];
        zMovment = new bool[engineParts.Length];

        facteurDeDeplacementMere = 1 / (handler.transform.position.z - explosionOrigin.transform.position.z);

        for(int i = 0; i < engineParts.Length; i++)
        {
            if(engineParts[i] != null)
            {
                initialPartsPositions[i] = engineParts[i].transform.position;

                facteurDeDeplacementX[i] = (initialPartsPositions[i].x - explosionOrigin.transform.position.x) * facteurDeDeplacementMere;
                facteurDeDeplacementY[i] = (initialPartsPositions[i].y - explosionOrigin.transform.position.y) * facteurDeDeplacementMere;
                facteurDeDeplacementZ[i] = (initialPartsPositions[i].z - explosionOrigin.transform.position.z) * facteurDeDeplacementMere;

                xMovment[i] = true;
                yMovment[i] = true;
                zMovment[i] = true;
            }
        }
    }
	
	void Update () {
		for(int i = 0; i < engineParts.Length; i++)
        {
            if(engineParts[i] != null)
            {

                if (xMovment[i] == true)
                    engineParts[i].transform.position = new Vector3((handler.transform.position.z - initialHandlerPosition.z) * facteurDeDeplacementX[i] + initialPartsPositions[i].x, engineParts[i].transform.position.y, engineParts[i].transform.position.z);

                if (yMovment[i] == true)
                    engineParts[i].transform.position = new Vector3(engineParts[i].transform.position.x, (handler.transform.position.z - initialHandlerPosition.z) * facteurDeDeplacementY[i] + initialPartsPositions[i].y, engineParts[i].transform.position.z);

                if (zMovment[i] == true)
                    engineParts[i].transform.position = new Vector3(engineParts[i].transform.position.x, engineParts[i].transform.position.y, (handler.transform.position.z - initialHandlerPosition.z) * facteurDeDeplacementZ[i] + initialPartsPositions[i].z);
            }
        }
	}
}
