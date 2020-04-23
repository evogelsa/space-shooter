using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBorder : MonoBehaviour {

    private float width = 110f;
    private float height = 60f;

    private float startTime;
    private float elapsedTime;

    public GameObject player;

    void Start() {
        startTime = Time.time;
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate() {
        elapsedTime = Time.fixedTime - startTime;
        if (elapsedTime > 4)
            Warp();
        // if (gameObject.name == "Player") {
        //     Warp();
        // } else {
        //     float x = transform.position.x;
        //     float y = transform.position.y;
        //
        //     float px = player.transform.position.x;
        //     float py = player.transform.position.y;
        //
        //     float dx = (x - px);
        //     float dy = (y - py);
        //
        //     float d = dx*dx + dy*dy;
        //
        //     if (d > 25*25)
        //         Warp();
        // }
    }

    void Warp() {
        if (transform.position.x < (-width/2)) {
            transform.position = new Vector2(transform.position.x + width,
                    transform.position.y);
        } else if (transform.position.x > (width/2)) {
            transform.position = new Vector2(transform.position.x - width,
                    transform.position.y);
        }

        if (transform.position.y < (-height/2)) {
            transform.position = new Vector2(transform.position.x,
                    transform.position.y + height);
        } else if (transform.position.y > (height/2)) {
            transform.position = new Vector2(transform.position.x,
                    transform.position.y - height);
        }
    }
}
