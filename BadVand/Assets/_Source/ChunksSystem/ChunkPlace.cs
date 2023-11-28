using System;
using System.Collections.Generic;
using PoolObjects;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

namespace ChunksSystem
{
    public class ChunkPlace : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Chunk[] chunks;
        [SerializeField] private Chunk firstChunk;
        [SerializeField] private Chunk lastChunk;
        [SerializeField] private int preloadCount;

        private Transform _lastSpawnedChunk;
        
        private int _sizeOfLvl;

        private PoolBase<Chunk> _chunkPool;

        private List<Chunk> _spawnedChunks = new List<Chunk>();
        
        private void Start()
        {
           _sizeOfLvl = PlayerPrefs.GetInt("LVL");
            _sizeOfLvl *= 7;
            _spawnedChunks.Add(firstChunk);
            _chunkPool = new PoolBase<Chunk>(Preload, GetAction, ReturnAction, preloadCount);
        }

        private void Update()
        {
            if (player.position.x > _spawnedChunks[_spawnedChunks.Count - 1].End.position.x - 30 && _sizeOfLvl>=0)
            {
                SpawnChunk();
            }
        }

        private void SpawnChunk()
        {
            if (_sizeOfLvl != 0)
            {
                Chunk newChunk = _chunkPool.Get();
                newChunk.transform.position =
                    _spawnedChunks[_spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
                _spawnedChunks.Add(newChunk);
                --_sizeOfLvl;
                _lastSpawnedChunk = newChunk.End;
            }
            else
            {
                _spawnedChunks.Add(lastChunk);
                lastChunk.transform.position = _lastSpawnedChunk.position - lastChunk.Begin.localPosition;
            }
            
            if (_spawnedChunks.Count >= 7 && _sizeOfLvl!=0)
            {
                _chunkPool.Return(_spawnedChunks[_spawnedChunks.Count - 7]);
                //Destroy(_spawnedChunks[0].gameObject);
                //_spawnedChunks.RemoveAt(0);
            }
        }
        
        public Chunk Preload() => Instantiate(chunks[Random.Range(0, chunks.Length)]);
        public void ReturnAction(Chunk chunk) => chunk.gameObject.SetActive(false);
        public void GetAction(Chunk chunk) => chunk.gameObject.SetActive(true);
    }
}
