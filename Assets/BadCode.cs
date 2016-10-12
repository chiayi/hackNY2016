using UnityEngine;
using System.Collections;

public class BadCode : MonoBehaviour
{

    public static void Create()
    {
        if (!Main.running) return;
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Vector3 ray = new Vector3(Camera.main.transform.forward.x, Camera.main.transform.forward.y, Camera.main.transform.forward.z);
        
        sphere.transform.position = Camera.main.transform.position+ray;

        sphere.transform.localScale = new Vector3(.1f, .1f, .1f);
        sphere.AddComponent<BadCode>();
        sphere.AddComponent<Rigidbody>();
        sphere.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        float speed = .01f;
        Vector3 direc = Utils.getDirection(transform.position, Camera.main.transform.position);
        transform.Translate(speed * direc.x, speed * direc.y, speed * direc.z);

        if (Utils.getDistance(transform.position, Camera.main.transform.position) > 3.625f)
        {
            Object.Destroy(gameObject, 0f);
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.GetComponent<Shot>() != null) { 
           Destroy(gameObject);
           Destroy(col.gameObject);
        }
    }
}