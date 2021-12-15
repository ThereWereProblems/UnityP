using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        if (pos.x > 40 || pos.x < -40 || pos.y > 20 || pos.y < -20)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.up * 70f * Time.deltaTime);

    }
}
