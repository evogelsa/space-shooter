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

    private Animator animator;
    private Rigidbody2D rb2d;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        bool paused = PauseMenu.GameIsPaused;

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

        if (left || right || up || down) {
            animator.SetBool("IsMoving", true);
        } else {
            animator.SetBool("IsMoving", false);
        }

        if (Input.GetMouseButtonDown(0) && !paused) {
            Vector2 direction = new Vector2(mousePos.x, mousePos.y);
            direction.Normalize();

            Vector3 spawnOffset = direction * 1f;

            Rigidbody2D inst = Instantiate(Projectile, transform.position + spawnOffset,
                    Quaternion.identity);
            
            inst.rotation = angle - 90;
            inst.velocity = direction * ProjectileSpeed;


        }
    }

    void FixedUpdate() {
        if (left) {
            rb2d.AddForce(Vector2.left * ShipSpeed * Time.deltaTime);
        }

        if (right) {
            rb2d.AddForce(Vector2.right * ShipSpeed * Time.deltaTime);
        }

        if (up) {
            rb2d.AddForce(Vector2.up * ShipSpeed * Time.deltaTime);
        }

        if (down) {
            rb2d.AddForce(Vector2.down * ShipSpeed * Time.deltaTime);
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
