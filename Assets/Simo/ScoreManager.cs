using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject scorePrefab;

    private void Start ()
    {
       Instantiate(scorePrefab);
    }
    

}
