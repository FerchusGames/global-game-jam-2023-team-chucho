using UnityEngine;

[System.Serializable]
public class MovementManagerPrototype : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField]
    private GameObject[,] matrix = new GameObject[2, 2];

    [SerializeField]
    private GameObject[] serializedMatrix = new GameObject[4];

    public void OnBeforeSerialize()
    {
        int index = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                serializedMatrix[index++] = matrix[i, j];
            }
        }
    }

    public void OnAfterDeserialize()
    {
        int index = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                matrix[i, j] = serializedMatrix[index++];
            }
        }
    }
}