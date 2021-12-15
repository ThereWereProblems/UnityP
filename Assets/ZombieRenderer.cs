using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieRenderer : MonoBehaviour
{
    public List<GameObject> zomies;
    public static GameObject button;
    private float timeRender = 4f;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("BackButton");
        button.SetActive(false);
        Time.timeScale = 1;
        ScoreScript.scoreValue = 0;
        StartCoroutine(Render());
    }

    // Update is called once per frame
    void Update()
    {
        timeRender = 4f - Mathf.Sqrt((float)ScoreScript.scoreValue) / 3; 
    }
    IEnumerator Render()
    {
        System.Random rand = new System.Random();
        while (true)
        {
            int number = rand.Next(zomies.Count);
            switch (number)
            {
                case 0:
                    float a = (float)((rand.NextDouble() * 4.2));
                    Instantiate(zomies[0], new Vector3(51f, (a + 6.2f) * -1f, 0f), Quaternion.identity);
                    break;
                case 1:
                    float b = (float)((rand.NextDouble() * 4.2));
                    Instantiate(zomies[1], new Vector3(35f, (b + 6.8f) * -1f, 0f), zomies[1].transform.rotation);
                    break;
                case 2:
                    float c = (float)((rand.NextDouble() * 4.2));
                    Instantiate(zomies[2], new Vector3(35f, (c + 6f) * -1f, 0f), zomies[2].transform.rotation);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(timeRender);
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
