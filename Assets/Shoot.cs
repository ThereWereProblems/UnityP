using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gun;
    public GameObject bone;
    public GameObject flash;
    private bool allowfire = true;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
        transform.position = mousePos;
        if (Input.GetMouseButtonDown(0) && allowfire)
        {
            StartCoroutine(Fire());
            StartCoroutine(Flash());
        }
    }

    IEnumerator Fire()
    {
        allowfire = false;
        source.Play();
        Vector3 pos = transform.position;
        pos.z = 0;
        var lookPos = bone.transform.rotation;
        lookPos *= Quaternion.Euler(0, 0, -90); // this adds a 90 degrees Y rotation
        Instantiate(bullet, gun.transform.position, lookPos);

        yield return new WaitForSeconds(1.6f - (Mathf.Sqrt(Mathf.Sqrt((float)ScoreScript.scoreValue))) / 3);
        allowfire = true;
        StopCoroutine(Fire());
    }
    IEnumerator Flash()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        flash.SetActive(false);
        StopCoroutine(Flash());
    }
}
