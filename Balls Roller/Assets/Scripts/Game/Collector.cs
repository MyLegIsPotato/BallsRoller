using System;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int CollectedAmount { get => collected.Count; }
    private List<Collectible> collected = new List<Collectible>();
    
    public Action<Collector, int> OnCollect;


    public void Collect(Collectible collectible)
    {
        collected.Add(collectible);
        OnCollect?.Invoke(this, CollectedAmount);
    }
}
