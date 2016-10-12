using UnityEngine;
using System.Collections;

public class ArrowListener : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
    void Update()
    {
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
