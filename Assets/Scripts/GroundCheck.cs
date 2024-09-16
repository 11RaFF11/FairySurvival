using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public bool isGrounded;

    private void OnTriggerStay(Collider collider)
    {
        isGrounded = collider != null & (((1 << collider.gameObject.layer) & groundLayerMask) != 0);
    }

    private void OnTriggerExit(Collider collision)
    {
        isGrounded = false;
    }
}
