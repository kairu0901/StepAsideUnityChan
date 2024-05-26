using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;
    //coinPrefab������
    public GameObject coinPrefab;
    //conePrefab������
    public GameObject conePrefab;
    //Unity�����̃I�u�W�F�N�g���擾
    private GameObject unitychan;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;
    //���ɃA�C�e���𐶐�����ʒu
    private float nextSpawnZ;
    //�A�C�e�������̊Ԋu
    private float spawnDistance = 15f;
    //�A�C�e�������̊J�n�ʒu
    private float startSpawnDistance = 50f;

    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
        //�ŏ��̃A�C�e�������ʒu��ݒ�
        this.nextSpawnZ = this.unitychan.transform.position.z + startSpawnDistance;

        //�ŏ��̃A�C�e������
        UpdateItemGeneration();
    }

    void Update()
    {
        // UnityChan����苗���i�񂾂�A�C�e���𐶐�
        if (unitychan.transform.position.z + startSpawnDistance > nextSpawnZ - spawnDistance)
        {
            UpdateItemGeneration();
        }
        // UnityChan���ʂ�߂����I�u�W�F�N�g��j��
        DestroyPassedObjects();
    }

    // �A�C�e���𐶐����郁�\�b�h
    private void UpdateItemGeneration()
    {
        while (nextSpawnZ < unitychan.transform.position.z + startSpawnDistance)
        {
            // �ǂ̃A�C�e�����o���̂��������_���ɐݒ�
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                // �R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, nextSpawnZ);
                    cone.transform.parent = this.transform; // �q�I�u�W�F�N�g�ɐݒ�
                }
            }
            else
            {
                // ���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    // �A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);
                    // �A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    // 60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        // �R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, nextSpawnZ + offsetZ);
                        coin.transform.parent = this.transform; // �q�I�u�W�F�N�g�ɐݒ�
                    }
                    else if (7 <= item && item <= 9)
                    {
                        // �Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, nextSpawnZ + offsetZ);
                        car.transform.parent = this.transform; // �q�I�u�W�F�N�g�ɐݒ�
                    }
                }
            }
            // ���̃A�C�e�������ʒu���X�V
            nextSpawnZ += spawnDistance;
        }
    }

    // UnityChan���ʂ�߂����I�u�W�F�N�g��j�����郁�\�b�h
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
