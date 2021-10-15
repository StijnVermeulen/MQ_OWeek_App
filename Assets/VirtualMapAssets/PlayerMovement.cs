using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerState
    {
        Walking,
        Reading
    }
    public PlayerState myState;

    public float PlayerSpeed = 10f;
    public LayerMask clickableFloor;
    public LayerMask UIMask;
    public GameObject minimapCam;
    public SplashEffect mySplashEffect;

    private NavMeshAgent myAgent;

    private void Start()
    {
        myAgent = this.GetComponent<NavMeshAgent>();
        myState = PlayerState.Walking;
    }

    void Update()
    {
        HandleCamera();

        if (myState != PlayerState.Walking)
            return;

        if (Input.GetMouseButton(0))
            MouseMove();
        //else
        //    KeyMove();

        if (Input.GetMouseButtonUp(0))
            PlaySplashAnimation();
    }

    private void HandleCamera()
    {
        Camera.main.transform.position = this.transform.position + new Vector3(0,25,-7);
        minimapCam.transform.position = this.transform.position + new Vector3(0,100,0);
    }

    private void MouseMove()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) // Checks if the click was NOT on a UI element
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, clickableFloor))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }
    }

    private void PlaySplashAnimation()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) // Checks if the click was NOT on a UI element
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, clickableFloor))
            {
                Instantiate(mySplashEffect, hitInfo.point, Quaternion.identity);
            }
        }
    }

    void KeyMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * PlayerSpeed * Time.deltaTime);
        }
    }
}
