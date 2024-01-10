using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public int mining_speed = 5;

    public List<string> recources_names;
    public static Dictionary<string, int> resources;
    public List<GameObject> resources_objects;
    void Start()
    {
        resources = new Dictionary<string, int>();
        resources_objects = new List<GameObject>();
        foreach (string r in recources_names)
        {
            resources[r] = 0;
        }
    }

    void Update()
    {
        if(Input.GetAxis("Collect") > 0.75 && resources_objects.Count > 0)
        {
            RecourceObject ro = resources_objects[0].GetComponent<RecourceObject>();
            int amount = ro.Mine(mining_speed);
            if(amount > 0) {
                if (resources.ContainsKey(ro.Res_name)) { resources[ro.Res_name] += amount; }
                else { resources[ro.Res_name] = amount; recources_names.Add(ro.Res_name); }
                GameObject go = resources_objects[0];
                resources_objects.Remove(go);
                Destroy(go);
            }
        }
    }
}
