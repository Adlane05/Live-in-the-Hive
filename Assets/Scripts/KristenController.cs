using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KristenController : MonoBehaviour
{
    public Material normalKristen;
    public Material failKristen;
    public Material winKristen;
    public MeshRenderer meshRenderer;
    public static KristenController Instance;
    void Start()
    {
        Instance = this;
        meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        winKristen.mainTextureScale = normalKristen.mainTextureScale;
        failKristen.mainTextureScale = normalKristen.mainTextureScale;
    }
}
