using UnityEngine;
using System.Collections;


public class Shot : MonoBehaviour
{
    Vector3 velocity;

    public static GameObject Create(Vector3 pos3, Vector3 velocityVector)
    {
        if (!Main.running) return null;
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Vector3 loc = new Vector3(sphere.transform.position.x, sphere.transform.position.y, sphere.transform.position.z);
        sphere.transform.position = pos3;
        sphere.transform.localScale = new Vector3(.1f, .1f, .1f);
        sphere.AddComponent<Shot>().velocity = velocityVector;
        sphere.AddComponent<Rigidbody>();
        Rigidbody rig = sphere.GetComponent<Rigidbody>();
        rig.useGravity = false;
        rig.maxAngularVelocity = 0;
        Debug.Log("Bullet Spawned");
        return sphere;
    }

    void Update()
    {
        Debug.Log("Bullet Location Updated");
        float speed = .01f;
        transform.Translate(speed * velocity.x, speed * velocity.y, speed * velocity.z);

        if (Utils.getDistance(transform.position, Camera.main.transform.position) > 3.625f)
        {
            Object.Destroy(gameObject,0f);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.GetType().Name);
        //Destroy(gameObject);
    }
}