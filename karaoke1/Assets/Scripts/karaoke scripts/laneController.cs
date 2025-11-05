using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class laneController : MonoBehaviour
{
    public GameObject lane;
    public Material normalLane;
    public Material failLane;
    public Material winLane;
    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = lane.GetComponent<MeshRenderer>();
        winLane.mainTextureScale = normalLane.mainTextureScale;
        failLane.mainTextureScale = normalLane.mainTextureScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (counterController.Instance.Score > 5)
        {

            if (counterController.Instance.Score == 10)
            {
                meshRenderer.material = winLane;
                Debug.Log("YOU GOT THE HIGHEST POSSIBLE SCORE");
            }
        }

        else if (counterController.Instance.Score < 0)
        {
            meshRenderer.material = failLane;
        }
        else
        {
            meshRenderer.material = normalLane;
        }
    }
    
}
