using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Vector3 posOne, posTwo;
    
    private Rigidbody _rb;
    private bool _isPosOne = true;

    public Action DeathAction; 
    public Action EndLevelAction; 
    
    // Start is called before the first frame update
    void Start()
    {
        DeathAction = Death;
        EndLevelAction = EndLevel;
        
        _rb = GetComponent<Rigidbody>();

        posOne = transform.position;
        posTwo = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            transform.position = !_isPosOne ? posOne : posTwo;
            _isPosOne = !_isPosOne;
        }
    }

    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void EndLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
