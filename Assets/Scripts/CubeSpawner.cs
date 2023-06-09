using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var newCube=Instantiate(_cube);
            newCube.transform.position = new Vector3(Random.Range(-5, 5), 30, 10);
        }
    }
}
