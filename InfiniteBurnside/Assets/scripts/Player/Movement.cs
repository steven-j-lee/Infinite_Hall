using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    CharacterController characterController;

    public float speed;
    public float sprintSpeed;
    private float tempSpeed;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    //array of footsteps
    [SerializeField] private AudioClip[] footSteps;
    private AudioSource source;

    //Coroutine for steps
    private Coroutine footStepSound;
    
    //variable to check whether player is moving
    private Vector3 lastPosUpdate = new Vector3(0, 0, 0);

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
        tempSpeed = speed;
    }


    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;
        //increase speed if sprinting
        if ((Input.GetKeyDown(KeyCode.LeftShift)))
        {
            speed = sprintSpeed;
        }
        else if ((Input.GetKeyUp(KeyCode.LeftShift)))
        {
            speed = tempSpeed;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice, as its an acceleration
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = this.transform.TransformDirection(moveDirection);
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        
    }
    
    
    //functions for foot steps

    private AudioClip getRandom(AudioClip[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];

    }

    private void PlayStep()
    {
        AudioClip foot = getRandom(footSteps);
        source.PlayOneShot(foot);
    }

    private IEnumerator Delay()
    {
        while (true)
        {
            PlayStep();
            yield return new WaitForSeconds(0.8f);
        }
    }


}