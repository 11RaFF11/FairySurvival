using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    public IEntity entity;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<IEntity>(out entity);
    }

    private void OnTriggerExit(Collider other)
    {
        entity = null;
    }
}
