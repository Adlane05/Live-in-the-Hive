using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killinventory : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start(){
        GameObject.Find("Inventory").SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
