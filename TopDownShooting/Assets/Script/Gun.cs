using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform mMuzzle;
    public Projectile mProjectile;
    public float mBetweenShotsInMS = 100;
    public float mMuzzleVelocity = 35;

    float nextShotTime;

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + mBetweenShotsInMS / 1000;
            Projectile newProjectile = Instantiate(mProjectile, mMuzzle.position, mMuzzle.rotation) as Projectile;
            newProjectile.SetSpeed(mMuzzleVelocity);
        }
    }
}
