using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector3 initMousePos;
    float pitch = 0;
    float yaw = 0;
    float sensitivity = 0.5f;
    Rigidbody rb;
    // does being private matter?
    void Start()
    {
        initMousePos = Input.mousePosition;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * Mathf.Cos(transform.eulerAngles.x * Mathf.Deg2Rad) * 5f * Time.deltaTime);
            transform.Translate(Vector3.up * Mathf.Sin(transform.eulerAngles.x * Mathf.Deg2Rad) * 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * Mathf.Cos(transform.eulerAngles.x * Mathf.Deg2Rad) * 5f * Time.deltaTime);
            transform.Translate(Vector3.down * Mathf.Sin(transform.eulerAngles.x * Mathf.Deg2Rad) * 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            // transform.Translate(Vector3.up * Mathf.Cos(transform.eulerAngles.x * Mathf.Deg2Rad) * 5f * Time.deltaTime);
            // transform.Translate(Vector3.back * Mathf.Sin(transform.eulerAngles.x * Mathf.Deg2Rad) * 5f * Time.deltaTime);
            rb.AddForce(Vector3.up * 25f, ForceMode.Impulse);
            // rb.AddForce(Vector3.back * Mathf.Sin(transform.eulerAngles.x * Mathf.Deg2Rad) * 25f, ForceMode.Impulse);
        }
        // if (Input.GetKey(KeyCode.LeftShift)) {
        //     transform.Translate(Vector3.down * Mathf.Cos(transform.eulerAngles.x * Mathf.Deg2Rad) * 5f * Time.deltaTime);
        //     transform.Translate(Vector3.forward * Mathf.Sin(transform.eulerAngles.x * Mathf.Deg2Rad) * 5f * Time.deltaTime);
        // }
        
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);

        pitch = (-1f) * sensitivity * (Input.mousePosition.y - Screen.height / 2f);

        if (pitch > 90) {
            pitch = 90;
        } else if (pitch < -90) {
            pitch = -90;
        }
        yaw = sensitivity * (Input.mousePosition.x - Screen.width / 2f) + 90f;
        transform.rotation = Quaternion.Euler(new Vector3(pitch, yaw, 0));

        // Debug.Log(new Vector3(pitch, yaw, 0));
    }
}
