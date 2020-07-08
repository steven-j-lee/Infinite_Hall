using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 3f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
   
    private Vector3 moveDirection = Vector3.zero;

    //array of footsteps
    [SerializeField] private AudioClip[] footSteps;
    private AudioSource source;

    //Coroutine for steps
    private Coroutine footStepSound;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        //increase speed if sprinting
        if ((Input.GetKeyDown(KeyCode.LeftShift)))
        {
            speed = 4f;
        }
        else if ((Input.GetKeyUp(KeyCode.LeftShift)))
        {
            speed = 3f;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice, as its an acceleration
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = this.transform.TransformDirection(moveDirection);
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        //play foot step sound
        if ((Input.GetKeyDown(KeyCode.W)))
        {
            footStepSound = StartCoroutine(Delay());
        }
        else if ((Input.GetKeyUp(KeyCode.W)))
        {
            StopCoroutine(footStepSound);
        }

    }

    private AudioClip getRandom(AudioClip[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];

    }

    private void playStep()
    {
        AudioClip foot = getRandom(footSteps);
        source.PlayOneShot(foot);
    }

    private IEnumerator Delay()
    {
        while (true)
        {
            playStep();
            yield return new WaitForSeconds(0.8f);
        }
    }


}