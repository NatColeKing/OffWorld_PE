using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geyser_ColumnController : MonoBehaviour {

    private const float COLUMN_FORCE_MULTIPLIER = 10f;
    public float columnStrength;
    public float columnHeight;

    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, columnHeight, transform.localScale.z);
        transform.localPosition = new Vector3(transform.localPosition.x, columnHeight / 2 + .5f, transform.localPosition.z); // adding .5 to account for height of base
    }

    private void OnTriggerStay(Collider other)
    {
        if (CheckIsShip(other))
            ApplyForce(other);
    }

    private bool CheckIsShip(Collider other)
    {
        return (other.tag == "Player" || other.tag == "Ship");
    }

    private void ApplyForce(Collider other)
    {
        Rigidbody shipRigidbody = other.GetComponent<Rigidbody>();
        float distance = DistanceFromBase(other);
        float forceMultiplier = COLUMN_FORCE_MULTIPLIER * columnStrength / Mathf.Pow(distance, 2f);
        shipRigidbody.AddForce(forceMultiplier * transform.up);
    }

    private float DistanceFromBase(Collider other)
    {
        Vector3 shipPosition = other.gameObject.transform.position;
        Vector3 basePosition = BasePosition();
        float distance = Vector3.Distance(shipPosition, basePosition);
        distance = Mathf.Abs(distance);
        return distance;
    }

    private Vector3 BasePosition()
    {
        Vector3 basePosition = new Vector3(transform.position.x, (transform.position.y - (columnHeight / 2)), transform.position.z);
        return basePosition;
    }
}
