using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBean_W : BaseWeapon
{
    public GameObject bullet;
    public Transform bulletLocation;
    void Update()
    {
        Tick();
    }
}
