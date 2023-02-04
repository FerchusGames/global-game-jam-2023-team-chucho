// Inheriting from SerializedMonoBehaviour is only needed if you want Odin to serialize the multi-dimensional arrays for you.
// If you prefer doing that yourself, you can still make Odin show them in the inspector using the ShowInInspector attribute.
using Sirenix.OdinInspector;
using UnityEngine;
using Sirenix.Utilities;

public class TableMatrixExamples : SerializedMonoBehaviour
{
    [BoxGroup("Tile Map Objects")]
    [TableMatrix(HorizontalTitle = "X axis", VerticalTitle = "Y axis")]
    public GameObject[,] TileMapObjectsTable = new GameObject[15, 10];


}
