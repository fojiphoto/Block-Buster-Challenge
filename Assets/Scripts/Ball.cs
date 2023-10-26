using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public static Ball Instance;

    [SerializeField] private Reticle reticleManager;
    [SerializeField] private Projectile projectiles;

    public TextMeshProUGUI textMeshPro;

    private new SpriteRenderer renderer;

    private int startIndex = 0;

    public int startPower = 1;

    private void Awake()
    {
        Instance = this;
        renderer = GetComponent<SpriteRenderer>();
        SetSpriteAndProjectile();
    }

    public void PowerUp()
    {
        startPower += 1;
        SetSpriteAndProjectile();
    }

    void SetSpriteAndProjectile()
    {
        renderer.sprite = projectiles.GetComponent<SpriteRenderer>().sprite;
        reticleManager.SetupProjectile(projectiles.gameObject , startPower);
        textMeshPro.SetText("Power : {0}", startPower);
    }

    private void OnMouseDown()
    {
        reticleManager.Selected(this.gameObject);
    }

    private void OnMouseUp()
    {
        reticleManager.Deselect();
    }
}
