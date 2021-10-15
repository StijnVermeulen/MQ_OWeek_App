using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour
{
    void Update()
    {
        if (this.transform.localScale.x <= 5.0f)
        {
            this.transform.localScale += new Vector3(20*Time.deltaTime, 1f*Time.deltaTime, 20*Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
