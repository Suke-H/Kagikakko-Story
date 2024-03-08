using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
	public GridSquare gridSquarePrefab;
	[SerializeField] private int columns;
	[SerializeField] private int rows;
	[SerializeField] private Transform entirePlaneTransform;

	private float gridSize;

	private List<List<GridSquare>> gridMap;
	private List<List<string>> bookMap;

	void Start()
	{
		// 平面のサイズを取得(スケール * 10)
		float planeOneSideLength = entirePlaneTransform.localScale.x * 10;
		// グリッドサイズを計算
		gridSize = planeOneSideLength / columns;

		gridMap = new List<List<GridSquare>>();

		bookMap = new List<List<string>>();
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });
		bookMap.Add(new List<string> { "", "私", "は", "目", "を", "覚", "ま", "し", "た", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });
		bookMap.Add(new List<string> { "", "こ", "こ", "は", "ど", "こ", "だ", "ろ", "う", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });

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
				gridSquare.WriteText(bookMap[z][x]);
				gridMap.Add(new List<GridSquare>());
			}
		}
	}


}