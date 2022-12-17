using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AvoidAI : MonoBehaviour
{
    GameObject[] AI;
    public float SpaceBetween = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject go in AI)
        {
            if(go != gameObject) 
            {
                float distance = Vector3.Distance(go.transform.position, this.transform.position);
                if(distance <=SpaceBetween)
                {
                    Vector3 direction = transform.position - go.transform.position;
                    transform.Translate(direction * Time.deltaTime);
                }
            }
        }
    }
}
