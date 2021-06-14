using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontrol : MonoBehaviour
{
    private Transform target;

    public void SetTarget(Transform target)
        {
            this.target = target;
        }
}
