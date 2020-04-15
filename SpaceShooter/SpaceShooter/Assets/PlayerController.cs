using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float ShipSpeed = 8f;
    public float ShipRotationOffset = 145f;

    public Rigidbody2D Projectile;
    public float ProjectileSpeed = 12f;

    private bool left = false;
    private bool right = false;
    private bool up = false;
    private bool down = false;

    private float angle;

    // Update is called once per frame
    void Update() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 shipPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - shipPos.x;
        mousePos.y = mousePos.y - shipPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (Input.GetKeyDown(KeyCode.A)) {
            left = true;
        } else if (Input.GetKeyUp(KeyCode.A)) {
            left = false;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            right = true;
        } else if (Input.GetKeyUp(KeyCode.D)) {
            right = false;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            up = true;
        } else if (Input.GetKeyUp(KeyCode.W)) {
            up = false;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            down = true;
        } else if (Input.GetKeyUp(KeyCode.S)) {
            down = false;
        }

        if (Input.GetMouseButtonDown(0)) {
            Rigidbody2D inst = Instantiate(Projectile, transform.position,
                    Quaternion.identity);
            Vector2 direction = new Vector2(mousePos.x, mousePos.y);
            direction.Normalize();
            inst.velocity = direction * ProjectileSpeed;
        }
    }

    void FixedUpdate() {
        if (left) {
            transform.Translate(Vector2.left * ShipSpeed * Time.deltaTime, 
                    Space.World);
        }

        if (right) {
            transform.Translate(Vector2.right * ShipSpeed * Time.deltaTime, 
                    Space.World);
        }

        if (up) {
            transform.Translate(Vector2.up * ShipSpeed * Time.deltaTime, 
                    Space.World);
        }

        if (down) {
            transform.Translate(Vector2.down * ShipSpeed * Time.deltaTime, 
                    Space.World);
        }
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 
                    ShipRotationOffset));

    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Asteroid") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
