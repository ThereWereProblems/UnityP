using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    public List<GameObject> bloods;
    private Animator anim;
    private Vector3 move;
    private bool isLive = true;
    private bool isWorking = true;
    private bool check = true;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        speed = (float)(1 + ScoreScript.scoreValue / 10);
        if (gameObject.name == "z1 1(Clone)")
            move = Vector3.left;
        else
            move = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWorking)
        {
            speed = 1f + (float)(ScoreScript.scoreValue) / 10;
            if (isLive)
            {
                if (!check)
                {
                    var bone = transform.Find("bone_1");
                    if (bone.transform.position.x < -24.7f)
                    {
                        var button = ZombieRenderer.button;
                        button.SetActive(true);
                        isWorking = false;
                        Time.timeScale = 0;
                    }
                }

                if (check)
                {
                    var bone = transform.Find("bone_1");
                    if (bone.transform.position.x < -20f)
                    {
                        var nVector = new Vector3(-24.8f, -10.2f, 0f) - bone.transform.position;
                        if (Mathf.Abs(nVector.x) > Mathf.Abs(nVector.y))
                            nVector /= Mathf.Abs(nVector.x);
                        else
                            nVector /= Mathf.Abs(nVector.y);
                        move = nVector;
                        if (gameObject.name != "z1 1(Clone)")
                            move.x *= -1f;
                        check = false;
                    }
                }

                transform.Translate(move * speed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject, 5f);
                isWorking = false;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreScript.scoreValue += 1;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        StartCoroutine(Blood(collision.transform));
        Destroy(collision.gameObject);
        isLive = false;
        anim.SetBool("IsWalking", true);
    }
    IEnumerator Blood(Transform tran)
    {
        var pos = tran.position;
        pos.z = 0;
        var rot = tran.rotation;
        var b0 = Instantiate(bloods[0], pos, rot);
        yield return new WaitForSeconds(0.15f);
        Destroy(b0);
        var b1 = Instantiate(bloods[1], pos, rot);
        yield return new WaitForSeconds(0.15f);
        Destroy(b1);
        var b2 = Instantiate(bloods[2], pos, rot);
        yield return new WaitForSeconds(0.15f);
        Destroy(b2);
        StopCoroutine(Blood(tran));
    }
}
