using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemBoxSpawner : MonoBehaviour
{
    [SerializeField] CollectableItem _prefab = null;
    [SerializeField] Collider2D _area = null;
    [SerializeField] float _spawnRate = 60f;
    [SerializeField] List<BoxSpawnData> _spawnList = null;

    [Header("Readonly")]
    [SerializeField] int _currentIndex = 0;
    [SerializeField] float _nextSpawn = 0f;
    [SerializeField] List<CollectableItem> _spawnedBoxes = null;

    public List<CollectableItem> SpawnedBoxes { get => _spawnedBoxes; }
    public int CurrentIndex { get => _currentIndex; }

    //public static event UnityAction OnSpawned = null;

    private void Update()
    {
        if (_currentIndex >= _spawnList.Count) return;

        _nextSpawn += Time.deltaTime;

        if (_nextSpawn > _spawnRate)
        {
            _nextSpawn = 0;
            Spawn();
            _currentIndex++;
        }
    }

    public void Spawn()
    {
        var _data = _spawnList[_currentIndex];
        Spawn(_data.itemSO, _data.amount);
    }

    public void Spawn(ItemSO _so, int _amount)
    {
        var _instance = Instantiate(_prefab, RandomPointInBounds(_area.bounds), Quaternion.identity);
        _instance.Init(_so, _amount, RemoveFromList);
        _spawnedBoxes.Add(_instance);
    }

    public static Vector3 RandomPointInBounds(Bounds _bounds)
    {
        return new Vector3(
            Random.Range(_bounds.min.x, _bounds.max.x),
            Random.Range(_bounds.min.y, _bounds.max.y),
            Random.Range(_bounds.min.z, _bounds.max.z)
        );
    }

    private void RemoveFromList(CollectableItem _box)
    {
        _spawnedBoxes.Remove(_box);
    }

    public void SetIndex(int _value)
    {
        _currentIndex = _value;
    }
}

[System.Serializable]
public class BoxSpawnData
{
    public ItemSO itemSO = null;
    public int amount = 1;
}