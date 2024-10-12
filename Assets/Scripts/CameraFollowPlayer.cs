using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject playerObject;
    public float lerpSpeed = 0.5f;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - playerObject.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerObject.transform.position + offset, lerpSpeed);
    }
}
