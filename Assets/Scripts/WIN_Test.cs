using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIN_Test : MonoBehaviour
{
    [SerializeField] private int levelUnlocker;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Win Scene Load");
            PlayerPrefs.SetInt("ReachedLevel", levelUnlocker);
            SceneManager.LoadScene(7);
        }
    }
}
