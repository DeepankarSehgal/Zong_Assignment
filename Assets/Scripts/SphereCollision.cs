using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereCollision : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip SourceClip;
    public GameObject[] particals;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Box 1"))
        {
            particals[0].SetActive(true);
            particals[2].SetActive(true);
            StartCoroutine(ParticalOff());
            Source.PlayOneShot(SourceClip);
        }
        if (collision.collider.CompareTag("Box 2"))
        {
            particals[1].SetActive(true);
            particals[3].SetActive(true);
            StartCoroutine(ParticalOff());
            Source.PlayOneShot(SourceClip);
        }
        if (collision.collider.CompareTag("Box 3"))
        {
            SceneManager.LoadScene(1);
            Source.PlayOneShot(SourceClip);
        }
    }


    public IEnumerator ParticalOff()
    {
        yield return new WaitForSeconds(2);
        particals[0].SetActive(false);
        particals[1].SetActive(false);
        particals[2].SetActive(false);
        particals[3].SetActive(false);
    }
}
