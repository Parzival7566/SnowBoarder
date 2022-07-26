using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float respawnTime = 1f;
    [SerializeField] ParticleSystem deathEffect;
    [SerializeField] AudioClip crashSFX;
    bool crashed = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Respawn" && !crashed)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            deathEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", respawnTime);
            crashed=true;
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
