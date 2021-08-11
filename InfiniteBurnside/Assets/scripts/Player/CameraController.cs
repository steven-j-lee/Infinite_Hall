using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;

    private float yaw = 270.0f;
    private float pitch = 0.0f;

    private Vector3 randomPos;
    private Vector3 lastPos;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yaw = 270;
    }

    void Update()
    {
            yaw += horizontalSpeed * Input.GetAxis("Mouse X");
            pitch -= verticalSpeed * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

            transform.parent.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }

    public void ScreenShake(float rad, float intensity, float duration)
    {
        lastPos = gameObject.transform.position;
        StartCoroutine(Shake(rad, intensity, duration));

    }

    private IEnumerator Shake(float rad, float intensity, float duration)
    {
        var t = 0f;
        while (t <= duration)
        {
            
            randomPos = Random.insideUnitSphere * rad + gameObject.transform.position;
            gameObject.transform.position = new Vector3(randomPos.x, randomPos.y, gameObject.transform.position.z);
            t += Time.deltaTime + (1/intensity);
            yield return new WaitForSeconds(1/intensity);
        }
        gameObject.transform.position = lastPos;
        yield return null;
    }
}