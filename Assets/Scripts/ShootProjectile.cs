using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speed;
    [SerializeField] private float projectilePower;

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, null);
        projectile.transform.position = this.transform.position;
        projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-this.transform.right * speed);
        projectile.GetComponent<Projectile>().SetPower(projectilePower);
    }

    public void SetProjectile(GameObject projectile , float power) 
    {
        projectilePrefab = projectile;
        projectilePower = power;
    }
}