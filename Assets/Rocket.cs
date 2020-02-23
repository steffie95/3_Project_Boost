using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource rocketThrust;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rocketThrust = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }


    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!rocketThrust.isPlaying) rocketThrust.Play();

        }

        else rocketThrust.Stop();

        if (Input.GetKey(KeyCode.D) && ! Input.GetKey(KeyCode.A))
        {
            print("Rotating Right");
            transform.Rotate(Vector3.forward);
        }

        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            print("Rotating Left");
            transform.Rotate(-Vector3.forward);
        }
    }

}