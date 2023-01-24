using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingPlayer : MonoBehaviour
{
    public GameObject player;
    public float smoothing;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position != null)
        {
            if (transform.position != player.transform.position)
            {
                Vector3 targetPos = player.transform.position;
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);
                targetPos.z = -10;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }
}
