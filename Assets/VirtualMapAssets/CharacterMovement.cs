using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject MoveTarget;

    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        this.transform.LookAt(MoveTarget.transform);
        this.transform.position = Vector3.Lerp(this.transform.position, MoveTarget.transform.position, 7f * Time.deltaTime);
    }
}
