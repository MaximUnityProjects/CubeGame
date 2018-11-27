using UnityEngine;

public class Aim : MonoBehaviour {



    [SerializeField] Texture2D texture;
    [SerializeField] float size = 40;


    public void OnGUI() {
        GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, size, size), texture);
    }


}
