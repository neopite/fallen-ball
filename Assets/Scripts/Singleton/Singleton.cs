using UnityEngine;

namespace Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) {return _instance; }

                var objects = GameObject.FindObjectsOfType<T>();
                if (objects.Length > 0)
                {
                    if (objects.Length == 1) return _instance = objects[0];
                    for (int i = 1; i < objects.Length; i++)
                    {
                        Destroy(objects[i]);
                    }
                }
                return _instance = new GameObject($"({nameof(Singleton)}{typeof(T)})").AddComponent<T>();
            }
        }
    }
}