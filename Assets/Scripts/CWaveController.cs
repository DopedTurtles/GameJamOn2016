using UnityEngine;
using System.Collections;

public class CWaveController : MonoBehaviour {

	private CWaveSpawnerController mSpawerController;
	private int mRow;
	private float mSpeed;
	private float mMaxDisplacement;
	private float mDisplacement;

	public int Row
	{
		set{
			mRow = value;
		}
	}
	public CWaveSpawnerController SpawerController
	{
		set{
			mSpawerController = value;
		}
	}
	public float Speed
	{
		set{
			mSpeed = value;
		}
	}
	public float MaxDisplacement
	{
		set{
			mMaxDisplacement = value;
		}
	}
		
	void Start () {
		mDisplacement = 0.0f;
	}

	void FixedUpdate () {
		transform.localPosition += new Vector3(0.0f, 0.0f, -Time.deltaTime * mSpeed);
		mDisplacement += Time.deltaTime * mSpeed;
		if (mDisplacement >= mMaxDisplacement) {
			mSpawerController.CreateNewPaddingRow (mRow);
			GameObject.Destroy (gameObject);
		}
	}
}
