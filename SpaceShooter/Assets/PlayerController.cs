using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour {

    public float ShipThrust = 250f;
    public float ShipRotationOffset = -90f;
    public float MaxSpeed = 20f;
    private bool left = false;
    private bool right = false;
    private bool up = false;
    private bool down = false;

    public Rigidbody2D Projectile;
    public float ProjectileSpeed = 24f;

    private float angle;

    private Animator animator;
    private Rigidbody2D rb2d;

    public Light2D leftLight;
    public Light2D rightLight;
    public Light2D headLight;
    private bool isMoving = false;

    public HealthBar healthBar;
    public float health = 100f;
    private bool isFlashing = false;
    private bool canMove = true;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(health);
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
            isMoving = true;
        } else {
            animator.SetBool("IsMoving", false);
            isMoving = false;
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

        healthBar.SetHealth(health);
    }

    void FixedUpdate() {
        Vector2 vel = rb2d.velocity;
        if (canMove && vel.magnitude <= MaxSpeed) {
            if (left) {
                rb2d.AddForce(Vector2.left * ShipThrust * Time.deltaTime);
            }

            if (right) {
                rb2d.AddForce(Vector2.right * ShipThrust * Time.deltaTime);
            }

            if (up) {
                rb2d.AddForce(Vector2.up * ShipThrust * Time.deltaTime);
            }

            if (down) {
                rb2d.AddForce(Vector2.down * ShipThrust * Time.deltaTime);
            }
        } else if (rb2d.velocity.magnitude > MaxSpeed) {
            rb2d.velocity = vel.normalized * MaxSpeed;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 
                    ShipRotationOffset));

        if (isMoving) {
            leftLight.pointLightOuterRadius = .85f;
            rightLight.pointLightOuterRadius = .85f;
        } else {
            leftLight.pointLightOuterRadius = .45f;
            rightLight.pointLightOuterRadius = .45f;
        }
    }

    IEnumerator FlashLights() {
        isFlashing = true;
        
        for (int i = 0; i < Random.Range(2,4); i++) {
            leftLight.enabled = false;
            rightLight.enabled = false;
            headLight.enabled = false;

            yield return new WaitForSeconds(Random.Range(.01f,.15f));

            leftLight.enabled = true;
            rightLight.enabled = true;
            headLight.enabled = true;

            yield return new WaitForSeconds(Random.Range(.01f,.10f));
        }

        isFlashing = false;
    }

    IEnumerator DisableMovement(float magnitude) {
        float delay = magnitude / 30f;

        canMove = false;
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        float magnitude = collision.relativeVelocity.magnitude;
        if (magnitude > 7) {
            health -= magnitude;
            StartCoroutine(DisableMovement(magnitude));
            if (!isFlashing) {
                StartCoroutine(FlashLights());
            }
        }
        if (health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // void OnTriggerEnter2D(Collider2D collision) {
    //     if (collision.tag == "Asteroid") {
    //         if (){
    //             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //         }
    //     }
    // }
}
