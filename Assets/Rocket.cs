using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource rocketThrust;
   [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 10f;
    enum State { Alive, Dying, Transcending}
    State state = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rocketThrust = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Thrust();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive)  {return;}

        switch (collision.gameObject.tag)
        {
            case "Friendly": break;
            case "Finish":
                {
                    state = State.Transcending;
                    print("Finish");
                    Invoke("LoadNextScene", 1f);
                    break;
                }
            default:
                {
                    print("RIP");
                    state = State.Dying;
                    rocketThrust.Stop();
                    Invoke("ReloadLevel", 1f);
                    break;
                }
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
    
    private void Rotate()
    {
        rigidBody.freezeRotation = true;
        float rotationThisFrame = rcsThrust * Time.deltaTime;


        {
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                transform.Rotate(-Vector3.forward * rotationThisFrame);
            }

            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * rotationThisFrame);
            }
        }
        

        rigidBody.freezeRotation = false;
    }

    private void Thrust()
    {
        if (state == State.Alive)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rigidBody.AddRelativeForce(Vector3.up * mainThrust);
                if (!rocketThrust.isPlaying) rocketThrust.Play();
            }

            else rocketThrust.Stop();
        }
        
    }
}