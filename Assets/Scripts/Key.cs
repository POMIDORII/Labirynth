using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Pickup
{
    public KeyColor keyColor;
    public override void Picked()
    {
        GameManager.gameManager.AddKey(keyColor);
        Destroy(this.gameObject);
    }
}
