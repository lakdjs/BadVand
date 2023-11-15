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
        [SerializeField] private int preloadCount;

        private PoolBase<Chunk> _chunkPool;

        private List<Chunk> _spawnedChunks = new List<Chunk>();
        
        private void Start()
        {
            _spawnedChunks.Add(firstChunk);
            _chunkPool = new PoolBase<Chunk>(Preload, GetAction, ReturnAction, preloadCount);
        }

        private void Update()
        {
            if (player.position.x > _spawnedChunks[_spawnedChunks.Count - 1].End.position.x - 15)
            {
                SpawnChunk();
            }
        }

        private void SpawnChunk()
        {
            Chunk newChunk = _chunkPool.Get();
            newChunk.transform.position =
                _spawnedChunks[_spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
            _spawnedChunks.Add(newChunk);

            if (_spawnedChunks.Count >= 5)
            {
                _chunkPool.Return(_spawnedChunks[_spawnedChunks.Count - 5]);
                //Destroy(_spawnedChunks[0].gameObject);
                //_spawnedChunks.RemoveAt(0);
            }
        }

        public Chunk Preload() => Instantiate(chunks[Random.Range(0, chunks.Length)]);
        public void ReturnAction(Chunk chunk) => chunk.gameObject.SetActive(false);
        public void GetAction(Chunk chunk) => chunk.gameObject.SetActive(true);
    }
}
