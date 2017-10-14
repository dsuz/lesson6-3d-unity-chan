using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーを追いかけてオブジェクトを消し去る機能を持つ。
/// </summary>
[RequireComponent(typeof(Collider))]
public class ObjectSweeperController : MonoBehaviour
{
    [SerializeField] GameObject m_player;

    /// <summary>プレイヤーからどれくらい離れて追いかけるか設定する</summary>
    [SerializeField] float m_distance;

    private void Update()
    {
        if (m_player)
            transform.position = new Vector3(transform.position.x, transform.position.y, m_player.transform.position.z - m_distance);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarTag" ||
            other.gameObject.tag == "TrafficConeTag" ||
            other.gameObject.tag == "CoinTag")
        {
            Destroy(other.gameObject);
        }
    }
}
