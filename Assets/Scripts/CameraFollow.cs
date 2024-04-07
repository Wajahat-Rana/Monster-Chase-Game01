using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 cameraPosition;

[SerializeField]
    private float maxX = 90f;
[SerializeField]
    private float minX = -90f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!playerTransform){
        return;
        }

        cameraPosition = transform.position;
        cameraPosition.x = playerTransform.position.x;
        if(cameraPosition.x>maxX){
        cameraPosition.x = maxX;
        }
        if(cameraPosition.x<minX){
        cameraPosition.x = minX;
        }

        transform.position = cameraPosition;
    }
}
