using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 触れたオブジェクト（アイテム）を消し去る機能を持つ。
/// カメラの子オブジェクトとなるオブジェクトにスクリプトを追加することにより、プレイヤーを追従してオブジェクトを掃除させる。
/// </summary>
[RequireComponent(typeof(Collider))]
public class ObjectSweeperController : MonoBehaviour
{
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
