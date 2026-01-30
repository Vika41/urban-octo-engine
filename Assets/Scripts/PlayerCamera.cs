using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject playerCharacter;

    private float height = 0.5f;
    private float distance = 0.5f;
    private float followDamping = 5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerCharacter.transform.TransformPoint(0f, height, -distance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerCharacter.transform.TransformPoint(0f, height, -distance), Time.deltaTime * followDamping);
    }
}
