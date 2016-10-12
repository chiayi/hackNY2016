using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour {
    private static GameObject lastHit = null;
    private int health =100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<BadCode>() != null)
        {
            if (lastHit != null && lastHit.Equals(col.gameObject)) return;
            health -= 10;
            lastHit = col.gameObject;
            Destroy(col.gameObject);
            Debug.Log("You DED");
            GameObject status =GameObject.Find("Status");
            TextMesh mesh = status.GetComponent<TextMesh>();
            if (health>50)
            {
                mesh.text = "Server Status:\n("+health+"%) Breached";
            }else if (health>0)
            {
                mesh.text = "Server Status:\n(" + health + "%) Critical";
            }
            else {
                mesh.text = "Server Status:\n(" + health + "%) Down";
                Application.Quit();
            }
        }
    }
}
