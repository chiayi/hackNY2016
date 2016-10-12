using UnityEngine;
using System.Collections;

public class SpawnBalls : MonoBehaviour {
    float count = 0f;
    GameObject currentBall = null;
    string[] txtmsh = new string[5];

    // Use this for initialization
    void Start () {

        Main.Go();
        

    }

    // Update is called once per frame
    void Update()
    {
        txtmsh[0]= "public static void main";   
        txtmsh[1] = "(String[] args)";
        txtmsh[2] = "int life = 42";
        txtmsh[3] = "ArrayList<Stuff> stuffs = new ArrayList<Stuff>()";
        txtmsh[4] = "I CANT DO THIS ANYTMORE";
        if (!Main.running) return;
        GameObject parent = transform.parent.gameObject;
        GameObject bone1 = parent.transform.FindChild("bone1").gameObject;
        Vector3 pos1 = bone1.transform.position;
        Vector3 pos3 = transform.position;
        float dist = Utils.getDistance(bone1.transform.position, transform.position);
        if (currentBall == null)
        {
            if (dist < .04)
            {
                currentBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                GameObject textChild = new GameObject();
                textChild.transform.parent = currentBall.transform;
                TextMesh words = textChild.AddComponent<TextMesh>();
                
                words.text = txtmsh[Random.Range(0,5)];
                words.transform.localScale = new Vector3(1f, 1f, 1f);
                words.transform.localPosition = new Vector3(0, 0, 0);
               currentBall.GetComponent<Renderer>().enabled = false;
                currentBall.transform.localScale = new Vector3(.05f, .05f, .05f);
                //currentBall.GetComponent<Text>().text = "public static void main()";
            }
        }
        else if (dist > .04875) {
            Destroy(currentBall);
            currentBall = null;
            GameObject sphere = Shot.Create(pos3, Utils.getDirection(pos1,pos3));
            GameObject textChild = new GameObject();
            textChild.transform.parent = sphere.transform;
            TextMesh words = textChild.AddComponent<TextMesh>();
           
            words.text = txtmsh[Random.Range(0,5)];
             words.transform.localScale = new Vector3(1f, 1f, 1f);
            words.transform.localPosition = new Vector3(0,0, 0);
            sphere.GetComponent<Renderer>().enabled = false;

            //Physics.IgnoreCollision(sphere.GetComponent<Collider>(),Camera.main.GetComponent<Collider>());
        }

        if (currentBall != null)
        {
            currentBall.transform.position = pos3;
        }
    }
}
