using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private int currentLevel = 3;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentLevel++;
            SceneManager.LoadScene(currentLevel);
            Debug.Log("LevelSwitch");
        }
    }
}
