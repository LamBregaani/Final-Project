using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public bool isGreen;

    public GameObject overlay;

    public static bool overlayEnabled = false;

    public Transform levelOneNormal;

    public Transform levelOneFlipped;

    public AudioClip soundClipPortal;

    public AudioSource soundSource;

    private Transform destination;



    void OnTriggerEnter2D(Collider2D other)
    {

        soundSource.clip = soundClipPortal;
        soundSource.Play();

        if(overlayEnabled)
        {
            overlay.SetActive(false);
            overlayEnabled = false;
        }
        else
        {
            overlay.SetActive(true);
            overlayEnabled = true;
        }

        levelOneNormal.position = new Vector2(100, -50);
        levelOneFlipped.position = new Vector2(0, 0);
    }
}
