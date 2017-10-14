using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSweeperController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CarTag" ||
            collision.gameObject.tag == "TrafficConeTag" ||
            collision.gameObject.tag == "CoinTag")
        {
            Debug.Log("Destroy " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Collide with " + collision.gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarTag" ||
            other.gameObject.tag == "TrafficConeTag" ||
            other.gameObject.tag == "CoinTag")
        {
            Destroy(other.gameObject);
        }
    }
}
