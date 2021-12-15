using UnityEngine;
using Random = System.Random;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinPlatfroms;
    public int MaxPlatforms;
    public float DistanceBetweenPlatform;
    public Transform FinishPlatform;
    public Transform CylinderRoot;
    public float ExtraCylinderScale = 1f;
    public Game Game;

    public void Awake()
    {
        int levelIndex = Game.LevelIndex;
        Random random = new Random(levelIndex);
        int platformsCount = random.Next(MinPlatfroms, MaxPlatforms + 1);

        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = random.Next(0, PlatformPrefabs.Length);
            GameObject platformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, random.Next(0, 360), 0);
        }

        FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);

        CylinderRoot.localScale = new Vector3(1, platformsCount * DistanceBetweenPlatform + ExtraCylinderScale, 1);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlatform * platformIndex, 0);
    }
}
