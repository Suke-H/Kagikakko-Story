using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
	public GridSquare gridSquarePrefab;
	[SerializeField] private int columns;
	[SerializeField] private int rows;
	[SerializeField] private Transform entirePlaneTransform;
	[SerializeField] private MapTile[] Objects;

	private float gridSize;
	private List<List<GridSquare>> gridMap;
	private List<List<string>> bookMap;
	private List<List<int>> objectMap;

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
		bookMap.Add(new List<string> { "", "私", "は", "目", "を", "覚", "ま", "し", "た", "" });
		bookMap.Add(new List<string> { "", "こ", "こ", "は", "ど", "こ", "だ", "ろ", "う", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });
		bookMap.Add(new List<string> { "", "鍵", "で", "扉", "を", "開", "け", "て", "", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "先", "へ", "進", "ん", "だ" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });
		bookMap.Add(new List<string> { "", "", "", "", "", "", "", "", "", "" });

		objectMap = new List<List<int>>();
		objectMap.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
		objectMap.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
		objectMap.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
		objectMap.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
		objectMap.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 3, 0 });
		objectMap.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
		objectMap.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
		objectMap.Add(new List<int> { 0, 0, 1, 0, 0, 0, 0, 2, 0, 0 });
		objectMap.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
		objectMap.Add(new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

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
				Debug.Log("Vector3(-offset + x*gridSize, 0, offset - z*gridSize) = " + new Vector3(-offset + x * gridSize, 0, offset - z * gridSize));
				gridSquare.transform.parent = this.transform; 
				gridSquare.name = $"{z}_{x}";
				gridSquare.WriteText(bookMap[z][x]);
				gridMap.Add(new List<GridSquare>());

				if (objectMap[z][x] != 0)
				{
					MapTile _object = Instantiate(Objects[objectMap[z][x] - 1], new Vector3(-offset + x * gridSize, 0, offset - z * gridSize), Quaternion.identity);
					// 親オブジェクトをこのスクリプトがアタッチされているオブジェクトにする
					_object.transform.parent = this.transform;

					var spriteRenderer = _object.SpriteRenderer;
					float height = spriteRenderer.bounds.size.y;
					// Y方向にSpriteの高さの半分だけ上げる
					_object.transform.position += new Vector3(0, height / 2, 0);
					Debug.Log("height = " + height);
				}
			}
		}
	}


}