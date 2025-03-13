using UnityEngine;

public class BoxScript : MonoBehaviour
{
    float i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i > 0.5) {
            transform.Rotate(0, 90, 0);
            i = 0;
        } else {
            transform.Translate(Vector3.forward * 5f * Time.deltaTime);
        }
        i += Time.deltaTime;
    
    }
}
