using UnityEngine;
using System.Collections;

public class CWaveSpawnerController : MonoBehaviour {

	[SerializeField]
	private GameObject[] mSeaObjects;
	[SerializeField]
	private int mLenght = 10;
	[SerializeField]
	private int mWidth = 3;
	[SerializeField]
	private int mPadding = 1;
	[SerializeField]
	private float mCellSize = 1.0f;
	[SerializeField]
	private float mSpeed = 0.0f;


	private float mhalfLength;
	private float mhalfWidth;
	private GameObject newGameObject;


	// Use this for initialization
	void Start () {
		mhalfLength = (mLenght / 2.0f + mPadding) * mCellSize;
		mhalfWidth = mWidth / 2.0f * mCellSize;
		InitializeGrid ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, 0.1f);
		float halfLength = (mLenght / 2.0f + mPadding) * mCellSize;
		float halfWidth = mWidth / 2.0f * mCellSize;

		int i;
		for (i = 0; i <= mLenght + 2 * mPadding; ++i) {
			Gizmos.DrawLine(transform.TransformPoint(new Vector3(-halfWidth, 0.0f, -halfLength + mCellSize*i)), 
				transform.TransformPoint(new Vector3(halfWidth, 0.0f, -halfLength + mCellSize*i)));
		}
		for (i = 0; i <= mWidth; ++i) {
			Gizmos.DrawLine(transform.TransformPoint(new Vector3(-halfWidth + mCellSize*i, 0.0f, -halfLength)), 
				transform.TransformPoint(new Vector3(-halfWidth + mCellSize*i, 0.0f, halfLength)));
		}
	}

	void InitializeGrid()
	{
		int seaId;
		CWaveController newWaveController;
		Vector3 minCenter = new Vector3 (-mhalfWidth + mCellSize / 2.0f, 0.0f, -mhalfLength + mCellSize / 2.0f);
		Vector3 wavePosition;
		if (mSeaObjects.Length > 0) {
			for (int i = 0; i < mLenght + 2 * mPadding; ++i) {
				for (int e = 0; e < mWidth; ++e) { 
					seaId = Random.Range (0, mSeaObjects.Length);
					newGameObject = Instantiate (mSeaObjects [seaId]) as GameObject;
					newGameObject.transform.rotation *= transform.rotation;
					newGameObject.transform.parent = transform;
					wavePosition = minCenter + new Vector3 (e * mCellSize, 0.0f, i * mCellSize);
					newGameObject.transform.localPosition = wavePosition;

					newWaveController = newGameObject.GetComponent<CWaveController> ();
					if (newWaveController) {
						newWaveController.Row = e;
						newWaveController.MaxDisplacement = mCellSize * (mPadding + i);
						newWaveController.SpawerController = this;
						newWaveController.Speed = mSpeed;
					} else {
						Debug.LogWarning ("CWaveSpawnerController::InitializeGrid -> Instantiate Object without CWaveController component.");
					}
				}
			}
		} else {
			Debug.LogWarning ("CWaveSpawner::InitializeGrid -> There aren't sea objects to instantiate");
		}
	}
		
	public void CreateNewPaddingRow(int row)
	// Create padding at specified row (Z positive side).
	{
		int seaId;
		CWaveController newWaveController;
		Vector3 minCenter = new Vector3 (-mhalfWidth + mCellSize / 2.0f, 0.0f, -mhalfLength + mCellSize / 2.0f);
		int column;
		Vector3 wavePosition;
		for (int i = 0; i < mPadding; ++i) {
			column = i + mLenght + mPadding;
			seaId = Random.Range (0, mSeaObjects.Length);
			newGameObject = Instantiate (mSeaObjects [seaId]) as GameObject;
			newGameObject.transform.rotation *= transform.rotation;
			newGameObject.transform.parent = transform;
			wavePosition = minCenter + new Vector3 (row * mCellSize, 0.0f, column * mCellSize);
			newGameObject.transform.localPosition = wavePosition;

			newWaveController = newGameObject.GetComponent<CWaveController>();
			if (newWaveController) {
				newWaveController.Row = row;
				newWaveController.MaxDisplacement = mCellSize * (mPadding + column);
				newWaveController.SpawerController = this;
				newWaveController.Speed = mSpeed;
			} else {
				Debug.LogWarning ("CWaveSpawnerController::InitializeGrid -> Instantiate Object without CWaveController component.");
			}
		}
	}
}
