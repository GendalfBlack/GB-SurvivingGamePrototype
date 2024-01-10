using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecourceObject : MonoBehaviour
{
    public string Res_name = "";
    public int amount = 0;
    int Hp = 100;
    public int Max_Hp = 100;
    void Start()
    {
        Hp = Max_Hp;   
    }
    
    public int Mine(int mine_strength)
    {
        if (Hp > 0) { Hp -= mine_strength; return 0; }
        else { return amount; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { other.gameObject.GetComponent<PlayerResources>().resources_objects.Add(gameObject); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") { other.gameObject.GetComponent<PlayerResources>().resources_objects.Remove(gameObject); }
    }
}
