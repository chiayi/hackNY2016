using UnityEngine;

class Main : MonoBehaviour
{
    public static bool running = false;
    static GameObject sphere=null;

    public static void Go() {
        Debug.Log("WENT");
        if (sphere != null) return;
        GameObject.Find("Cube").active=false;
        running = true;
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.Translate(100,100,100);
        sphere.AddComponent<Main>();
    }

    void Update()
    {
        if (Random.Range(0, 150) == 1) BadCode.Create();
    }
}