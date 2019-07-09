using UnityEngine;

public class MoveScript : MonoBehaviour {
    private Rigidbody rigidbody;
    private const float distanceFromGnd = 0.5f;
    private float speed = 10f;
    private float jmpSpeed = 10f;
    
    // Start is called before the first frame update
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        // Getting values from the arrows (keyboard)
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.Space)) {
            rigidbody.AddForce(0, 1f * jmpSpeed, 0);
        }

        Vector3 vector = rigidbody.velocity;
        vector.x = h * speed;
        vector.z = v * speed;

        if (rigidbody.position.y < -1f) {
            Vector3 pos = rigidbody.position;
            pos.x = -3.11f;
            pos.z = 2.297224f;
            pos.y = 0.5f;

            // Stopping its speed
            vector.x = 0;
            vector.z = 0;

            rigidbody.position = pos;
        }

        rigidbody.velocity = vector; // Updates the postion of the obj
    }
}
