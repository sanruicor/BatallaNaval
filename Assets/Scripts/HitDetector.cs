using System;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    [SerializeField] private string label;
    public string Label => label;
    public delegate void OnHitDelegate(HitDetector detector, Collision c);
    public OnHitDelegate OnHit;

    void OnCollisionEnter(Collision collision)
    {
        OnHit?.Invoke(this, collision);
    }
}
