using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public Transform Goal;
    GameObject[] AI;
    GameObject ground;
    public float SpaceBetween = 1.5f;
    public float allowedGround = 5f;
    public float smooth = 8;
    // Start is called before the first frame update
    void Start()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");
        ground = GameObject.FindGameObjectWithTag("Ground");
    }

    void Update()
    {
        Vector3 direction = Goal.position - transform.position;
        transform.Translate(direction * Time.deltaTime);

        foreach (GameObject go in AI)
        {
            if (go != gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, this.transform.position);
                if (distance <= SpaceBetween)
                {
                    direction = transform.position - go.transform.position;
                    transform.Translate(direction * Time.deltaTime);
                }
            }
        }
    }
}
