using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetConstraint : MonoBehaviour
{
    [SerializeField] private Transform _targetPlanet;

    private void FixedUpdate()
    {
        Quaternion _rotation = Quaternion.FromToRotation(-transform.up, _targetPlanet.position - transform.position);
        transform.rotation = _rotation * transform.rotation;
    }
}
