using UnityEngine;
// dont forget this line
using UnityEngine.UI;
using TMPro;

public class BallScript : MonoBehaviour
{
    Rigidbody rb;
    public Rigidbody rbCamera;
    public Transform camera;
    public TMP_Text scoreText;
    // public RectTransform powerBar;
    // public float powerBarWidth;
    public float score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get rigid body 
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        score = 0;
    }

    // Update is called once per frame

    bool holdingBall = true;

    Vector3 hoopPos = new Vector3(2.07f, 3f, 0.78f);
    Vector3 vToHoop;
    float distanceToHoop;
    Vector3 playerVelocity;
    Vector3 lastPlayerPos;
    void Update()
    {
        playerVelocity = (camera.position - lastPlayerPos) / Time.deltaTime;
        if (Input.GetMouseButtonDown(0)) {
            if (holdingBall) {
                rb.useGravity = true;
                // get distance to hoop to adjust strength of shot
                vToHoop = transform.position - hoopPos;
                distanceToHoop = vToHoop.magnitude;
                // add force based on distance, and add player momentum
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.AddForce((camera.forward * 2f + Vector3.up * 3f) * (distanceToHoop * 0.092f + 0.5f), ForceMode.Impulse);
                // add backspin
                rb.AddTorque(camera.right * -0.1f, ForceMode.Impulse);
                holdingBall = false;
            } else {
                holdingBall = true;
                rb.useGravity = false;
            }
        } else if (holdingBall) {   
            transform.position = camera.position + camera.forward;
            // transform.rotation = camera.rotation;
            transform.rotation = Quaternion.Euler(camera.rotation.eulerAngles.x, camera.rotation.eulerAngles.y, camera.rotation.eulerAngles.z + 90);
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        } 
        scoreText.text = score.ToString();
        lastPlayerPos = camera.position;
        Debug.Log(playerVelocity);
    }
    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider collider) {
        Debug.Log("Scored!");
        score += 1;
    }
}
