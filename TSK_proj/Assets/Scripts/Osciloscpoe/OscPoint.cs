using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscPoint : MonoBehaviour
{
    public OscPoint(float t, float v)
    {
        this.time = t;
        this.value = v;
    }
    public float time;
    public float value;
}
