using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public bool isActive = false;
    private bool isColliding = false;

    public GameObject leftLever;
    public GameObject rightLever;
    public GameObject bridge;

    private void Awake()
    {
        bridge.SetActive(isActive);
    }

    private void Update()
    {
        if (isColliding && Input.GetButtonDown("Fire1"))
        {
            // Pull lever
            isActive = !isActive;
            bridge.SetActive(isActive);
            rightLever.SetActive(isActive);
            leftLever.SetActive(!isActive);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) isColliding = false;
    }
}
