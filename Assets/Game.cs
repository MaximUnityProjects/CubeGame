using UnityEngine;

public class Game : MonoBehaviour {

    public static Mesh upQuad, downQuad, leftQuad, rightQuad, forwardQuad, backQuad;
    public static Mesh[] quads;
    readonly static uint quadCount = 6;
    [SerializeField] GameObject defaultCubeInput,selectCubeInput, preViewCubeInput;
    public static GameObject defaultCube, selectCube, preViewCube;

    private void Awake() {
        QuadInit();
        quads = new Mesh[] { upQuad, downQuad, leftQuad, rightQuad, forwardQuad, backQuad };
        defaultCube = defaultCubeInput;
        selectCube = selectCubeInput;
        preViewCube = preViewCubeInput;


    }







    void QuadInit() {
        upQuad = new Mesh {
            vertices = new Vector3[] {
            (Vector3.up  + Vector3.left +Vector3.forward) * 0.5f,    //lf 0     1 -1 1
            (Vector3.up  + Vector3.left +Vector3.back) * 0.5f,       //lb 1     1 -1 -1
            (Vector3.up  + Vector3.right +Vector3.forward) * 0.5f,   //rf 2     1 1 1
            (Vector3.up  + Vector3.right +Vector3.back) * 0.5f,      //rb 3     1 1 -1
        },
            triangles = new int[] {
            1,0,2,
            1,2,3
        },
            normals = new Vector3[] {
                Vector3.up,Vector3.up,Vector3.up,Vector3.up
            }
        };


        downQuad = new Mesh {
            vertices = new Vector3[] {
            (Vector3.down  + Vector3.left +Vector3.forward) * 0.5f,     //lf 0   -1 -1 1
            (Vector3.down  + Vector3.left +Vector3.back) * 0.5f,        //lb 1   -1 -1 -1
            (Vector3.down  + Vector3.right +Vector3.forward) * 0.5f,    //rf 2   -1
            (Vector3.down  + Vector3.right +Vector3.back) * 0.5f,       //rb 3   -1
        },
            triangles = new int[] {
            1,3,2,
            1,2,0
        },
            normals = new Vector3[] {
                Vector3.down,Vector3.down,Vector3.down,Vector3.down
            }
        };


        leftQuad = new Mesh {
            vertices = new Vector3[] {
            (Vector3.left  + Vector3.up +Vector3.forward) * 0.5f,    //lf 0
            (Vector3.left  + Vector3.up +Vector3.back) * 0.5f,       //lb 1
            (Vector3.left  + Vector3.down +Vector3.forward) * 0.5f,   //rf 2
            (Vector3.left  + Vector3.down +Vector3.back) * 0.5f,      //rb 3
        },
            triangles = new int[] {
            2,0,1,
            2,1,3
        },
            normals = new Vector3[] {
                Vector3.left,Vector3.left,Vector3.left,Vector3.left
            }
        };

        rightQuad = new Mesh {
            vertices = new Vector3[] {
            (Vector3.right  + Vector3.up +Vector3.forward) * 0.5f,    //lf 0
            (Vector3.right  + Vector3.up +Vector3.back) * 0.5f,       //lb 1
            (Vector3.right  + Vector3.down +Vector3.forward) * 0.5f,   //rf 2
            (Vector3.right  + Vector3.down +Vector3.back) * 0.5f,      //rb 3
        },
            triangles = new int[] {
            2,1,0,
            2,3,1
        },
            normals = new Vector3[] {
                Vector3.right,Vector3.right,Vector3.right,Vector3.right
            }
        };

        forwardQuad = new Mesh {
            vertices = new Vector3[] {
            (Vector3.forward  + Vector3.up +Vector3.left) * 0.5f,    //lf 0
            (Vector3.forward  + Vector3.up +Vector3.right) * 0.5f,       //lb 1
            (Vector3.forward  + Vector3.down +Vector3.left) * 0.5f,   //rf 2
            (Vector3.forward  + Vector3.down +Vector3.right) * 0.5f,      //rb 3
        },
            triangles = new int[] {
            1,0,2,
            3,1,2
        },
            normals = new Vector3[] {
                Vector3.forward,Vector3.forward,Vector3.forward,Vector3.forward
            }
        };

        backQuad = new Mesh {
            vertices = new Vector3[] {
            (Vector3.back  + Vector3.up +Vector3.left) * 0.5f,    //lf 0
            (Vector3.back  + Vector3.up +Vector3.right) * 0.5f,       //lb 1
            (Vector3.back  + Vector3.down +Vector3.left) * 0.5f,   //rf 2
            (Vector3.back  + Vector3.down +Vector3.right) * 0.5f,      //rb 3
            },
            triangles = new int[] {
            0,1,2,
            1,3,2
            },
            normals = new Vector3[] {
                Vector3.back,Vector3.back,Vector3.back,Vector3.back
            }
        };
    }


}
