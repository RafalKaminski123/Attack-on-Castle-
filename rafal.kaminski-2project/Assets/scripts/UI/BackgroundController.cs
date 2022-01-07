using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float speed;
    public float pos;

    private void Update()
    {
        pos = +speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(pos, 0);
    }
}
