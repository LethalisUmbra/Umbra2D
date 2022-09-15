using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 startPosition;
    public float moveSpeed;
    private bool movingToTargetPos;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        movingToTargetPos = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movingToTargetPos ? targetPosition : startPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition) movingToTargetPos = false; else if (transform.position == startPosition) movingToTargetPos = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerController>().GameOver();
    }
}
