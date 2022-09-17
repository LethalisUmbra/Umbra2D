using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlagController : MonoBehaviour
{
    public bool isFinalLevel;
    public string nextSceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isFinalLevel) SceneManager.LoadScene(0); else SceneManager.LoadScene(nextSceneName);
        }
    }
}
