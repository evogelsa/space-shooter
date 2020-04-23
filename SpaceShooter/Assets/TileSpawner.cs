using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

    public GameObject tile;

    private GameObject player;

    private float width = 112.4f;
    private float height = 60.6f;

    public List<Vector2> spawns;

    void Start() {
        player = GameObject.FindWithTag("Player");
        spawns = new List<Vector2>();
    }

    void Update() {
        float px = player.transform.position.x;
        float py = player.transform.position.y;

        float x = ((int) (px / width)) * width;
        float y = ((int) (py / height)) * height;

        float dx = px - x;
        float dy = py - y;

        Vector2 posRight = new Vector2(x + width, y);
        Vector2 posLeft = new Vector2(x - width, y);
        Vector2 posUp = new Vector2(x, y + height);
        Vector2 posDown = new Vector2(x, y - height);

        if (dx > (width / 4) && !spawns.Contains(posRight)) {
            spawns.Add(posRight);
            GameObject spawn = Instantiate(tile, posRight, Quaternion.identity);
        } else if (dx < (-width / 4) && !spawns.Contains(posLeft)) {
            spawns.Add(posLeft);
            GameObject spawn = Instantiate(tile, posLeft, Quaternion.identity);
        } else if (dy > (height / 4) && !spawns.Contains(posUp)) {
            spawns.Add(posUp);
            GameObject spawn = Instantiate(tile, posUp, Quaternion.identity);
        } else if (dy < (-height / 4) && !spawns.Contains(posDown)) {
            spawns.Add(posDown);
            GameObject spawn = Instantiate(tile, posDown, Quaternion.identity);
        }
    }

}
