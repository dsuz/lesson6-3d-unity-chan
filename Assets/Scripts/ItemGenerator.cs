using UnityEngine;
using System.Collections;

/// <summary>
/// レッスンの発展課題を実装したクラス。実装のポイントは「レッスンの内容から、なるべく少ない変更で発展課題の条件を満たす」ようにした。
/// </summary>
public class ItemGenerator : MonoBehaviour
{
    //unitychan の参照を入れる
    GameObject unitychan;
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //次にこの場所に unitychan が到達したらアイテムを生成する地点
    private int nextItemGenerationPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //unitychan のいる場所の何ｍ前方にアイテムを生成するかという距離
    private int itemGenerationDistance = 50;
    //アイテムを生成する間隔
    private int itemGenerationInterval = 15;

    void Start()
    {
        unitychan = GameObject.Find("unitychan");
    }

    void Update()
    {
        float i = unitychan.transform.position.z + itemGenerationDistance;    // i は「アイテムを生成する z 座標」（本来ならばこのような変数の名前を i にはしないが、レッスンからの変更箇所を最小限に抑えるためにやむを得ず i をこのように利用している）

        //一定の距離ごとにアイテムを生成
        if (unitychan.transform.position.z > nextItemGenerationPos && i < goalPos)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j < 2; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
            nextItemGenerationPos += itemGenerationInterval;    // アイテムを生成したら、次に生成するポイントに更新する
        }
    }
}