using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add Points
public class PointAdder : Pickup
{
    public int points = 5;

    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        Destroy(this.gameObject);
    }
    void Update()
    {
        Rotation();
    }
}
