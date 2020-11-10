using UnityEngine;

public class ItemSweeper : MonoBehaviour
{
    void Update()
    {
        if (this.transform.position.z < Camera.main.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
