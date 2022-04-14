using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform transformPlayer;
    void Update()
    {
        var position = transformPlayer.position;
        transform.position = new Vector3(
            position.x
            , position.y
            , transform.position.z);
    }
}
