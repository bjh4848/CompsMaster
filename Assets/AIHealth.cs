using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public float maxHealth;
    public float dieForce;
    [HideInInspector]
    public float currentHealth;
    MeshRenderer meshRenderer;
    Color origColor;

    public float blinkIntensity;
    public float blinkDuration;
    float blinkTimer;

    public AudioSource hitSound;


    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        origColor = meshRenderer.material.color;
        currentHealth = maxHealth;

        var rigidBodies = GetComponentsInChildren<Rigidbody>();
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("TakeDamageStart");
        currentHealth -= amount;
        FlashStart();
        hitSound.Play();

        if (currentHealth < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void FlashStart()
    {
        meshRenderer.material.color = Color.white;
        Invoke("FlashStop", .15f);
    }

    void FlashStop()
    {
        meshRenderer.material.color = Color.red;
    }

    public IEnumerator EnemyFlash()

    {
        Debug.Log("EnemyFlashStart");
        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().material.color = origColor;
        StopCoroutine("EnemyFlash");
    }


    private void Update()
    {

    }
}
