using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    
    public Transform player;
    private Vector3 pos;
    private float cameraDepth = -10;

    void Start() {
        cameraDepth = transform.position.z;
    }

    // Update is called once per frame
    void Update() {
        pos = new Vector3(player.position.x, player.position.y, cameraDepth);
        transform.position = pos;
    }
}
