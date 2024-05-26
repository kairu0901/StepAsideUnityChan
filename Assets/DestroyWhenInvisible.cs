using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private GameObject unitychan;
    private float zDestroyThreshold;

    void Start()
    {
        // Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        // Unity����񂪒ʂ�߂����Ƃ݂Ȃ�z���W��臒l��ݒ�i�J��������̋��� + �I�t�Z�b�g�j
        this.zDestroyThreshold = unitychan.transform.position.z - 10.0f; // �K�؂ȃI�t�Z�b�g��ݒ�
    }

    void Update()
    {
        // �I�u�W�F�N�g���J�����̌���ɉ߂����ꍇ�A�I�u�W�F�N�g��j��
        if (transform.position.z < unitychan.transform.position.z - zDestroyThreshold)
        {
            Destroy(gameObject);
        }
    }
}
