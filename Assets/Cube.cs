using ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    MeshFilter meshFilter;
    new Collider collider;
    MeshRenderer meshRenderer;
    Cube cube;
    bool start = false;

    readonly static Matrix4x4 matrix = new Matrix4x4(
        new Vector4(1, 0, 0, 0),
        new Vector4(0, 1, 0, 0),
        new Vector4(0, 0, 1, 0),
        new Vector4(0, 0, 0, 1)
    );

    void Awake() {
        meshFilter = gameObject.SetComponent<MeshFilter>();
        meshRenderer = gameObject.SetComponent<MeshRenderer>();
        collider = gameObject.SetComponent<BoxCollider>();
        cube = gameObject.SetComponent<Cube>();



        if (meshRenderer.material == null) {
            meshRenderer.material.color = UnityEngine.Random.ColorHSV();
        }
        meshRenderer.material.color = UnityEngine.Random.ColorHSV();

    }



    private void Start() {
        Reload();
        start = true;
    }

    private void OnEnable() {
        if (start) Reload();
    }

    private void OnDisable() {
        Disable();
    }



    // Перезагрузка мешей
    private void Reload() {
        collider.enabled = true;
        MeshUpdate();
        UpdateAdjacentMeshes();
    }

    //Удаление куба
    private void Disable() {
        collider.enabled = false;
        UpdateAdjacentMeshes();
    }



    //Обновляет меши соседей
    void UpdateAdjacentMeshes() {
        foreach (var vec in vectors) {
            var neighbor = GetCube(transform.position + vec);
            if (neighbor != null) cube = neighbor.GetComponent<Cube>();
            if (cube != null) cube.MeshUpdate();
        }
    }


    //Смотрит на соседние кубы и удаляет лишние меши
    public void MeshUpdate() {
        var mesh = new Stack<Mesh>();


        for (int i = 0; i < 6; i++) {
            //Debug.DrawLine(transform.position, transform.position + vectors[i], Color.cyan, 10);
            var neighbor = GetCube(transform.position + vectors[i], LayerMask.GetMask("FullBlock"));

            if (neighbor == null) {
                mesh.Push(Game.quads[i]);
            }
        }
        var count = mesh.Count;
        if(count <1) {
            meshRenderer.enabled = false;
            //collider.enabled = false;
            return;
        }
        else {
            meshRenderer.enabled = true;
            //collider.enabled = true;
            var combine = new CombineInstance[count];

            for (int i = 0; i < count; i++) {
                combine[i].mesh = mesh.Pop();
                combine[i].transform = matrix;
            }

            meshFilter.mesh.CombineMeshes(combine, true);
            //collider.sharedMesh = meshFilter.sharedMesh;
        }





    }


    public static Collider GetCube(Vector3 pos,int mask = ~0) {
        Collider[] hitColliders = Physics.OverlapSphere(pos, 0, LayerMask.GetMask("FullBlock"));
        return hitColliders.Length > 0 ? hitColliders[0] : null;
    }


    public static void NewCube(Vector3 pos) {
        if (!GetCube(pos)) {
            GameObject go = Instantiate(Game.defaultCube) as GameObject;
            go.SetComponent<Transform>().position = pos;
        }
        
    }



    public static void DrawDemoCube(Vector3 pos, float time) {
        List<Vector3> verts = new List<Vector3>();

        for (int i = 0; i < 6; i++) {
            verts.AddRange(Game.quads[i].vertices);
        }

        var count = verts.Count;
        var vertAr = verts.ToArray();

        for (int i = 0; i < count; i++) {
            for (int j = i+1; j < count; j++) {
                Debug.DrawLine(pos+verts[i], pos + verts[j],Color.green);
            }
        }
        
    }






    readonly static Vector3[] vectors = new Vector3[] {
        Vector3.up,Vector3.down,Vector3.left,Vector3.right,Vector3.forward,Vector3.back
    };





}
