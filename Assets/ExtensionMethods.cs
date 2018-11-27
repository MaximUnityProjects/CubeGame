using UnityEngine;

namespace ExtensionMethods {

    public static class ExtensionMethods {

        //Округляет координаты вектора
        public static Vector3 Round(this Vector3 vec) {
            vec.x = Mathf.Round(vec.x);
            vec.y = Mathf.Round(vec.y);
            vec.z = Mathf.Round(vec.z);
            return vec;
        }


        // Возвращает компонент или создаёт если его нет
        public static T SetComponent<T>(this GameObject gameObject) where T : Component {
            var comp = gameObject.GetComponent<T>();
            if (comp == null) comp = gameObject.AddComponent<T>();
            return comp;
        }

        
    }



}