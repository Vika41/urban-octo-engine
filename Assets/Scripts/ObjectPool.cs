using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    public GameObject _objectToPool1;
    public GameObject _objectToPool2;
    public GameObject _objectToPool3;
    public GameObject _objectToPool4;

    public List<GameObject> _pooledObjects;

    public int _amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       _pooledObjects = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < _amountToPool; i+=4)
        {
            tmp = Instantiate(_objectToPool1);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }

        for (int i = 1; i < _amountToPool; i+=4)
        {
            tmp = Instantiate(_objectToPool2);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }

        for (int i = 2; i < _amountToPool; i += 4)
        {
            tmp = Instantiate(_objectToPool3);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }

        for (int i = 3; i < _amountToPool; i += 4)
        {
            tmp = Instantiate(_objectToPool4);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject(int index)
    {
        //for (int i = 0; i < _amountToPool; i++)
        //{
            //if (!_pooledObjects[i].activeInHierarchy)
            //{
                //return _pooledObjects[i];
            //}
        //}
        //return null;
        if (!_pooledObjects[index].activeInHierarchy)
        {
            return _pooledObjects[index];
        }
        return null;
    }
}
