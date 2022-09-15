using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Rigidbody2D rig;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float xInput = Input.GetAxisRaw("Horizontal");

        rig.velocity = new Vector2(xInput * moveSpeed, rig.velocity.y);

        if (xInput > 0) sr.flipX = false; else if (xInput < 0) sr.flipX = true;

        if (transform.position.y <= -6f) GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded()) rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -.1f, 0), Vector2.down, .2f);

        return hit.collider != null;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
