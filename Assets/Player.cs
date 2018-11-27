using ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] Camera camera;
    [SerializeField] float distance = 15;

    Collider target;
    Color tardetColor;

    GameObject selectCube, preViewCube;

    void Start() {
        selectCube = Instantiate(Game.selectCube);
        preViewCube = Instantiate(Game.preViewCube);
        selectCube.SetActive(false);
    }

    void Update() {
        if (transform.position.y < -100) ReZero();
            
        

        var start = camera.transform.position;
        var dir = camera.transform.rotation * Vector3.forward;

        Ray ray = new Ray(start, dir);
        Debug.DrawRay(start, dir * distance);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, distance);

        var hitCollider = hit.collider;
        var onHit = hitCollider != null;


        Debug.DrawLine(camera.transform.position, hit.point, Color.red);

        if (onHit) {
            //hit.triangleIndex
            var hitPoint = hit.point;
            //var colliderCenter = hit.collider.transform.position;

            hitPoint += (camera.transform.position - hitPoint).normalized * 0.01f;
            hitPoint = hitPoint.Round();

            preViewCube.SetActive(true);
            preViewCube.transform.position = hitPoint;

            if (Input.GetMouseButtonDown(1)) {
                Cube.NewCube(hitPoint);
            }
            if (Input.GetMouseButtonDown(0)) {
                Cube.Destroy(hit.collider.gameObject);
                preViewCube.SetActive(false);
                selectCube.SetActive(false);
                
            }
        }
        else {
            preViewCube.SetActive(false);
        }


        if (hitCollider != target) {

            if (target) {
                //target.GetComponent<Renderer>().material.color = tardetColor;
                selectCube.SetActive(false);
                target = null;
            }

            if (onHit) {
                var rend = hitCollider.GetComponent<Renderer>();
                if (rend) {
                    target = hitCollider;
                    //tardetColor = rend.material.color;
                    //rend.material.color = Color.red;
                    selectCube.SetActive(true);
                    selectCube.transform.position = target.transform.position;
                }
            }

        }

    }






    void ReZero() {
        var p = Vector3.zero;
        p.y = 2;
        if (!Cube.GetCube(Vector3.zero)) Cube.NewCube(Vector3.zero);

        var y1 = Cube.GetCube(Vector3.zero + Vector3.up);
        if (y1) Destroy(y1.gameObject);
        var y2 = Cube.GetCube(Vector3.zero + Vector3.up*2);
        if (y2) Destroy(y2.gameObject);

        if (!Cube.GetCube(Vector3.zero)) Cube.NewCube(Vector3.zero);

        transform.position = p;
    }
}
