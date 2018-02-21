using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {
    private static Globals _instance;
    public static Globals Instance { get { return _instance; } }

    private Dictionary<string, GameObject> dictionary;

    private void Awake()
    {
        //Singleton -------------------------------
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
        // ----------------------------------------
        dictionary = new Dictionary<string, GameObject>();
    }

    public void RegisterGlobal(string nameOfObject, GameObject item)
    {
        dictionary.Add(nameOfObject, item);
    }
    
    public GameObject Global(string nameOfObject)
    {
        GameObject item;
        if (dictionary.TryGetValue(nameOfObject, out item))
            return item;
        else
        {
            item = new GameObject();
            item.name = "not found";
            return item;
        }

    }

    public void DeleteGlobal(string nameOfObject)
    {
        dictionary.Remove(nameOfObject);
    }
}
