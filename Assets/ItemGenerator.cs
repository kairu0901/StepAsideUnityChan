using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //Unityちゃんのオブジェクトを取得
    private GameObject unitychan;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //次にアイテムを生成する位置
    private float nextSpawnZ;
    //アイテム生成の間隔
    private float spawnDistance = 15f;
    //アイテム生成の開始位置
    private float startSpawnDistance = 50f;

    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //最初のアイテム生成位置を設定
        this.nextSpawnZ = this.unitychan.transform.position.z + startSpawnDistance;

        //最初のアイテム生成
        UpdateItemGeneration();
    }

    void Update()
    {
        // UnityChanが一定距離進んだらアイテムを生成
        if (unitychan.transform.position.z + startSpawnDistance > nextSpawnZ - spawnDistance)
        {
            UpdateItemGeneration();
        }
        // UnityChanが通り過ぎたオブジェクトを破棄
        DestroyPassedObjects();
    }

    // アイテムを生成するメソッド
    private void UpdateItemGeneration()
    {
        while (nextSpawnZ < unitychan.transform.position.z + startSpawnDistance)
        {
            // どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                // コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, nextSpawnZ);
                    cone.transform.parent = this.transform; // 子オブジェクトに設定
                }
            }
            else
            {
                // レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    // アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    // アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    // 60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        // コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, nextSpawnZ + offsetZ);
                        coin.transform.parent = this.transform; // 子オブジェクトに設定
                    }
                    else if (7 <= item && item <= 9)
                    {
                        // 車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, nextSpawnZ + offsetZ);
                        car.transform.parent = this.transform; // 子オブジェクトに設定
                    }
                }
            }
            // 次のアイテム生成位置を更新
            nextSpawnZ += spawnDistance;
        }
    }

    // UnityChanが通り過ぎたオブジェクトを破棄するメソッド
    private void DestroyPassedObjects()
    {
        foreach (Transform child in transform)
        {
            if (child.position.z < unitychan.transform.position.z - 10)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
