using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TargetCamera : MonoBehaviour
{
     CinemachineTargetGroup _cinemachineTargetGroup;
  

    
    public Transform[] _objects = new Transform[2];
    // Start is called before the first frame update
    void Start()
    {
        _cinemachineTargetGroup = GetComponent<CinemachineTargetGroup>();

        //OnTarget();
    }

   
    
   
    public void OnTarget()
    {
        for (var i= 0; i < _objects.Length; i++)
        _cinemachineTargetGroup.AddMember(_objects[i], 1, 5);
    }


}
