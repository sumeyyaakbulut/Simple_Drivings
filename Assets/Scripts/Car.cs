using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;

    private int steerValue;
    public AudioClip crash;
    public float roundscore = 130f;
    // Start is called before the first frame update
    void Start()
    {
       // float score = gameObject.GetComponent<ScoreSystem>().score;
    }

    // Update is called once per frame
    void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;

        transform.Rotate(0f,steerValue * turnSpeed *Time.deltaTime,0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

       /* ScoreSystem scoreSystem = gameObject.GetComponent<ScoreSystem>();

        if (scoreSystem.score>roundscore)
        {
            speed += 5f;
        }*/
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GetComponent<AudioSource>().PlayOneShot(crash, 1f);
            StartCoroutine("WaitForSceneLoad");//new
           

        }
    }

    private IEnumerator WaitForSceneLoad()

    {

        yield return new WaitForSeconds(0.8f);

          SceneManager.LoadScene(0);

    }


    public void Steer(int value)
    {
        steerValue = value;
    }
}
