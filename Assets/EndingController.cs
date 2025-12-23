using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    public static EndingController Instance;
    public GameObject Marya;
    public GameObject DoorCover;
    public GameObject Desolation;
    public GameObject Shabloing1;
    public GameObject Shabloing2;
    public GameObject Shabloing3;
    public GameObject Shabloings; 
    public Animator animator;
    public void Start()
    {
        Instance = this;
    }
}
