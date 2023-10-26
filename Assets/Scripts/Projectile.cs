using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject vfxSuccess;
    [SerializeField] private GameObject vfxFail;
    [SerializeField] private GameObject vfxPowerUp;

    public float power;

    private void Awake()
    {
        power = 0;
    }

    public void SetPower(float numbPower)
    {
        power = numbPower;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Block"))
        {
            GameObject vfx = Instantiate(vfxSuccess, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            if (power >= collision.GetComponent<Block>().numb)
            {
                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(collision.gameObject);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                GameManager.Instance.CheckLevelUp();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (collision != null && collision.gameObject.CompareTag("PowerUp")) 
        {
            GameObject vfx = Instantiate(vfxPowerUp, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);
            Ball.Instance.PowerUp();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            GameObject vfx = Instantiate(vfxFail, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);
            Destroy(gameObject);
        }
    }
}
