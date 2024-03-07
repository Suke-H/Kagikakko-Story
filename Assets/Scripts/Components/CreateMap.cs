using UnityEngine;

public class CreateMap : MonoBehaviour
{
	public GridSquare gridSquarePrefab;
	[SerializeField] private int columns;
	[SerializeField] private int rows;
	[SerializeField] private Transform entirePlaneTransform;

	private float gridSize;

	void Start()
	{
		// 平面のサイズを取得(スケール * 10)
		float planeOneSideLength = entirePlaneTransform.localScale.x * 10;
		// グリッドサイズを計算
		gridSize = planeOneSideLength / columns;

		GenerateGrid();
	}

	void GenerateGrid()
	{
		float offset = (columns - 1) / 2.0f * gridSize;

		for (int z = 0; z < rows; z++)
		{
			for (int x = 0; x < columns; x++)
			{
				var gridSquare = Instantiate(gridSquarePrefab, new Vector3(-offset + x*gridSize, 0, offset - z*gridSize), Quaternion.identity);
				gridSquare.transform.parent = this.transform; 
				gridSquare.name = $"{z}_{x}";
			}
		}
	}
}