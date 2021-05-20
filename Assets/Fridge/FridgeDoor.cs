using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeDoor : MonoBehaviour
{

    float rotationAngle = 0f;

    
    float rotateSpeed = 1;

    bool doorOpen;
    bool closeDoor;

    public Transform fridgeDoor;
    public Transform hinges;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "NPC")
        {
            doorOpen = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "NPC")
        {
            closeDoor = true;
            
        }
    }
    private void Update()
    {
        if (doorOpen)
        {
            rotationAngle += rotateSpeed * Time.deltaTime;
            fridgeDoor.transform.Rotate(0, rotationAngle, 0);
            
            if (rotationAngle >= 1.5f)
            {
                doorOpen = false;
                
            }

        }
        
        if (closeDoor)
        {
            rotationAngle -= rotateSpeed * Time.deltaTime;
            fridgeDoor.transform.Rotate(0, -rotationAngle, 0);
            
            if (rotationAngle <= 0f)
            {
                closeDoor = false;
                
            }

        }

    }
}
