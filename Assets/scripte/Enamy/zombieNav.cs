using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieNav : MonoBehaviour
{
    Transform _playerTranspform;
    private NavMeshPath path;
    public event Action<bool> canNotBeMove = delegate { };

    private void Awake()
    {
        GetComponent<Health>().OnDie += ZombieNav_OnDie;
        _playerTranspform = FindObjectOfType<movement>().transform;
    }

    private void ZombieNav_OnDie()
    {
        this.enabled = false;
    }

    void Start()
    {
        path = new NavMeshPath();

    }


    // Update is called once per frame
    void Update()
    {
        

        var targetPosition = _playerTranspform.position;
        
        
        bool foundPath = NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);


        if (foundPath)
        {
            Vector3 nextDestination = path.corners[1];        
            Vector3 directionToTarget = nextDestination - transform.position;
            directionToTarget = Vector3.Normalize(new Vector3(directionToTarget.x,0,directionToTarget.z));
            var rotation = Quaternion.LookRotation(directionToTarget);
            var finalRotation = Quaternion.Slerp(transform.rotation, rotation,Time.deltaTime);
            transform.rotation = finalRotation;

        }
    }
}
