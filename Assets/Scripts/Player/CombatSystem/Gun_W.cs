using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_W : BaseWeapon
{
    public GameObject bullet;
    public Transform bulletLocation;
    public float bulletForce = 10;
    void Update()
    {
        Tick();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject _bullet = Instantiate(bullet, bulletLocation.position, Quaternion.identity);
        _bullet.transform.forward = this.transform.forward;
        _bullet.GetComponent<Rigidbody>().AddForce(_bullet.transform.forward * bulletForce, ForceMode.Impulse);
    }
}
