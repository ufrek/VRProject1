using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    GameObject[] spawnPoints;
    bool[] activeTargets;
    bool setTarget = false;
    bool hasTarget = false;
    Vector3 target;

    [SerializeField]
    float moveSpeed = .5f;
    [SerializeField]
    float turnSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Init", .1f);
    }

    void Init()
    {
        spawnPoints = SpawnManager.S.getSpawnPoints();
        activeTargets = SpawnManager.S.getActiveApples();
    }
    // Update is called once per frame
    void Update()
    {
        if (!SpawnManager.S.getGameOver())
        {
            if (!setTarget)
            {
                setTarget = true;
                StartCoroutine(FindTarget());
                

            }
            else 
            {
                if (hasTarget)
                {
                    rotateTowards(target);
                    transform.position = Vector3.MoveTowards(transform.position, (transform.position +transform.forward), moveSpeed);
                }
            }
                
        }

    }

    private IEnumerator FindTarget()
    {
        bool isFound = false;
        while (!isFound)
        {
            yield return new WaitForSeconds(.03f);
            int randIndex = Random.Range(0, activeTargets.Length);
            if (activeTargets[randIndex])
            {
                target = spawnPoints[randIndex].gameObject.GetComponentInChildren<Apple>().transform.position;
                isFound = true;
                hasTarget = true;
            }
        }
        
    }

    protected void rotateTowards(Vector3 to)
    {
        Vector3 lookDifference = to - transform.position;

        Quaternion lookRotation =
            Quaternion.LookRotation((lookDifference).normalized);

        //over time
        transform.rotation =
            Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void resetTarget()
    {
        setTarget = false;
        hasTarget = false;
    }
}
