using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationManager : MonoBehaviour
{
   public static InformationManager Instance;
   public GameObject Shauna;
   public CharResources ShaunaResources;

   void Awake()
    {
        Instance = this;
        Shauna = GameObject.Find("Shauna");
        ShaunaResources = Shauna.GetComponent<CharResources>();

        Debug.Log(Shauna);

    }
}
