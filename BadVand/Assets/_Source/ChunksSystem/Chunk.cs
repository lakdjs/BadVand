using UnityEngine;

namespace ChunksSystem
{
    public class Chunk : MonoBehaviour
    {
        [field: SerializeField] public Transform Begin {get; private set;}
        [field: SerializeField] public Transform End {get; private set;}
    }
}
