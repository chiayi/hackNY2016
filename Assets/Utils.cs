using UnityEngine;
using System.Collections;

public class Utils {
    public static Vector3 Subtract(Vector3 vec1, Vector3 vec2) {
       return new Vector3(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z -vec2.z);
    }

    public static Vector3 getDirection(Vector3 vec1, Vector3 vec2)
    {
        Vector3 velocityVector = Utils.Subtract(vec2, vec1);
        velocityVector.Normalize();
        return velocityVector;
    }

    public static float getDistance(Vector3 vec1, Vector3 vec2) {
        float x = Mathf.Pow((vec2.x - vec1.x),2);
        float y = Mathf.Pow((vec2.y - vec1.y),2);
        float z = Mathf.Pow((vec2.z - vec1.z),2);
        return Mathf.Sqrt(x + y + z);   
    }
}
