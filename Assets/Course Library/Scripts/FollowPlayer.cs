using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0f, 3.5f, -5.5f);

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}