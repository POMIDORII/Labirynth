using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezer : Pickup
{
    public int freezeTime = 10;
    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(freezeTime);
        Destroy(this.gameObject);


    }
}
