using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private GameObject unitychan;
    private float zDestroyThreshold;

    void Start()
    {
        // Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        // Unityちゃんが通り過ぎたとみなすz座標の閾値を設定（カメラからの距離 + オフセット）
        this.zDestroyThreshold = unitychan.transform.position.z - 10.0f; // 適切なオフセットを設定
    }

    void Update()
    {
        // オブジェクトがカメラの後方に過ぎた場合、オブジェクトを破棄
        if (transform.position.z < unitychan.transform.position.z - zDestroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}
