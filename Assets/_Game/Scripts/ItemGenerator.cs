using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject spawnParent;
    public GameObject itemPrefab;
    public int maxCount = 10;
    
    private static GameObject _itemPrefab;
    private static List<Transform> _spawnPoints = new List<Transform>();
    private static List<GameObject> _generatedObjects = new List<GameObject>();
    private static HashSet<Transform> _usedTransforms = new HashSet<Transform>();

    private void Start()
    {
        _itemPrefab = itemPrefab;
        GetSpawnPoints();

        for (int i = 0; i < maxCount; i++)
        {
            GenerateTransformObject();
        }
    }
    

    private void GetSpawnPoints() // transformlari listede topluyor
    {
        foreach (Transform child in spawnParent.transform)
        {
            _spawnPoints.Add(child);
        }
    }
    
    public static void GenerateTransformObject() // item uretiyor
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        Transform selectedTransform = _spawnPoints[randomIndex];

        // isaretlenmis transformlari kontrol ediyor
        if (_usedTransforms.Contains(selectedTransform))
        {
            GenerateTransformObject();
            return;
        }
        GameObject newObject = Instantiate(_itemPrefab, selectedTransform.position, selectedTransform.rotation);
        newObject.GetComponent<Transform>().SetPositionAndRotation(selectedTransform.position, selectedTransform.rotation);
        
        _generatedObjects.Add(newObject);
        _usedTransforms.Add(selectedTransform);
    }
    
    public static void DestroyTransformObject(GameObject destroyedObject) // silip tekrar uretiyor
    {
        _generatedObjects.Remove(destroyedObject);

        Transform destroyedTransform = destroyedObject.transform;
        
        if (_usedTransforms.Contains(destroyedTransform)) // kullanilmis transformlardan cikartiyorki tekrar secilsin
        {
            _usedTransforms.Remove(destroyedTransform);

            GenerateTransformObject();
        }

        Destroy(destroyedObject);
    }
    
    
}
