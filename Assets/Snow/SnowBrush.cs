using UnityEngine;

public class SnowBrush : MonoBehaviour
{
    public CustomRenderTexture SnowHeightMap;
    public Material HeightMapUpdate;

    public float SecondsToRestore = 100;

    public GameObject[] Tires;

    private Camera mainCamera;
    private int tireIndex;

    private float timeToRestoreOneTick;
    
    private static readonly int DrawPosition = Shader.PropertyToID("_DrawPosition");
    private static readonly int DrawAngle = Shader.PropertyToID("_DrawAngle");
    private static readonly int RestoreAmount = Shader.PropertyToID("_RestoreAmount");

    [SerializeField] private int AngelDraw;

    private void Start()
    {
        SnowHeightMap.Initialize();
        mainCamera = Camera.main;
        Tires[0] = GameObject.FindGameObjectWithTag("PlayerModel");
    }

    private void Update()
    {
        // Раскомментируйте одну из этих строчек, чтобы выбрать какие объекты будут копать снег
        DrawWithTires();

        // Считаем таймер до восстановления каждого пикселя текстуры на единичку 
        timeToRestoreOneTick -= Time.deltaTime;
        if (timeToRestoreOneTick < 0)
        {
            // Если в этот update мы хотим увеличить цвет всех пикселей карты высот на 1
            HeightMapUpdate.SetFloat(RestoreAmount, 1 / 250f);
            timeToRestoreOneTick = SecondsToRestore / 250f;
        }
        else
        {
            // Если не хотим
            HeightMapUpdate.SetFloat(RestoreAmount, 0);
        }
        
        // Обновляем текстуру вручную, можно это убрать и поставить Update Mode: Realtime
        SnowHeightMap.Update();
    }

    private void DrawWithTires()
    {
        GameObject tire = Tires[tireIndex++ % Tires.Length];

        Ray ray = new Ray(tire.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector2 hitTextureCoord = hit.textureCoord;
            float angle = tire.transform.rotation.eulerAngles.y;

            HeightMapUpdate.SetVector(DrawPosition, hitTextureCoord);
            HeightMapUpdate.SetFloat(DrawAngle, (angle + AngelDraw) * Mathf.Deg2Rad );
        }
    }
}
