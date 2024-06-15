using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]private GameObject[] prefabsSpawn;
    [SerializeField]private Material[] renderMaterial;

    [SerializeField]private CustomRenderTexture[] renderTexture;

    float WorldPositionSpawn = 0;
    int indexMaterial = 0;

    void Start()
    {
        InvokeRepeating("SpawnObject", 5f, 1f);
        FirstLoaded();
    }

    void FirstLoaded()
    {
        for(int i = 0; i < 10; i++)
        {
            InstantiateObject();
        }
    }    

    void SpawnObject()
    {
        InstantiateObject();
    }

    void InstantiateObject()
    {
        GameObject newObject = new GameObject();
        Transform t = newObject.transform;

        t.position = new Vector3(WorldPositionSpawn, 0f, 0f);
        WorldPositionSpawn += 20f;
        GameObject obj = Instantiate(prefabsSpawn[Random.Range(0, prefabsSpawn.Length)], t);

        ChangeSettingsInChildren(obj);
    }

    /// <summary>
    /// Меняет настройки дочернего объекта
    /// </summary>
    void ChangeSettingsInChildren(GameObject obj)
    {
        Transform childrenTransform = obj.transform.Find("Plane");

        if (childrenTransform != null)
        {
            GameObject childrenObject = childrenTransform.gameObject;

            int index = IndexMaterialUp();

            MeshRenderer meshRenderer = childrenObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.material = renderMaterial[index];
            }
            else
            {
                Debug.LogWarning("MeshRenderer component not found on child object.");
            }

            SnowBrush snowBrush = childrenObject.GetComponent<SnowBrush>();
            if (snowBrush != null)
            {
                snowBrush.SnowHeightMap = renderTexture[index];
                snowBrush.HeightMapUpdate = renderMaterial[index];
            }
            else
            {
                Debug.LogWarning("SnowBrush component not found on child object.");
            }
        }
        else
        {
            Debug.LogWarning("Child object with name 'Plane' not found.");
        }
    }


    int IndexMaterialUp()
    {
        if(indexMaterial >= renderMaterial.Length-1)
        {
            indexMaterial = 0;
        } else
        {
            indexMaterial++;
        }

        return indexMaterial;
    }
}
