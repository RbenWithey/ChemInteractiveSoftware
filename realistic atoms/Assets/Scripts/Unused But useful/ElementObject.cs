using UnityEngine;
using System.Collections.Generic;
public class ElementObject : MonoBehaviour
{
    public static List<GameObject> list = new List<GameObject>();
    void Start()
    {
        list.Add(gameObject);
    }
    void OnDestroy()
    {
        list.Remove(gameObject);
    }
}
