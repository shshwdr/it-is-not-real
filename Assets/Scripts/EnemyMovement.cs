using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //public float detectPlayerRange = 1f;
    public float chasingPlayerTime = 2f;
    float currentChasingTimer = 0f;
    float updatePositionTime = 0.5f;
    float updatePositionTimer = 0f;
    Vector3 originalPosition;
    CharacterPathFinding pathFinding;
    bool isChasing = false;
    private void Awake()
    {
        pathFinding = GetComponent<CharacterPathFinding>();
        originalPosition = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing) {

            currentChasingTimer += Time.deltaTime;
            updatePositionTimer += Time.deltaTime;
            if (currentChasingTimer >= chasingPlayerTime)
            {
                currentChasingTimer = 0;
                isChasing = false;
                pathFinding.setTarget(originalPosition);
            }
            else if (updatePositionTimer >= updatePositionTime && pathFinding.isPathFindingDone())
            {
                updatePositionTimer = 0;
                pathFinding.updateTarget();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            Debug.Log("found player!");
            currentChasingTimer = 0;
            if (!isChasing)
            {
                isChasing = true;
                pathFinding.setTarget(collision.transform);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            currentChasingTimer = 0;
        }
    }

    void finishedPath()
    {
        Debug.Log("finished path");
    }
}
