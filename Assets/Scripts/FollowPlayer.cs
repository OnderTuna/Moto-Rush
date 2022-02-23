using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 camPosition = new Vector3(0f, 2.2f, -2.11f);
    
    void LateUpdate()
    {
        transform.position = player.transform.position + camPosition;
    }
}
