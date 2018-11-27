using UnityEngine;

public class Spawn : MonoBehaviour {


    //List<GameObject> ga = new List<GameObject>();
    [SerializeField] int size;

    int sizet;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (size != sizet) {
            sizet = size;
            Draw();
        }



    }



    void Draw() {

    }





}
