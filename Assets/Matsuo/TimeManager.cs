using UnityEngine;
using System.Collections;
 
public class TimeManager : MonoBehaviour
{

	//�@Time.timeScale�ɐݒ肷��l
	[SerializeField]
	 float timeScale = 0.1f;
	//�@���Ԃ�x�����Ă��鎞��
	[SerializeField]
	 float slowTime = 1f;
	//�@�o�ߎ���
	 float elapsedTime = 0f;
	//�@���Ԃ�x�����Ă��邩�ǂ���
	 bool isSlowDown = false;

	void Update()
	{
		//�@�X���[�_�E���t���O��true�̎��͎��Ԍv��
		if (isSlowDown)
		{
			elapsedTime += Time.unscaledDeltaTime;
			if (elapsedTime >= slowTime)
			{
				SetNormalTime();
			}
		}
	}
	/// <summary>
	/// ���Ԃ�x�点�鏈��(�q�b�g�X�g�b�v)
	/// </summary>
	public void SlowDown()
	{
		elapsedTime = 0f;
		Time.timeScale = timeScale;
		isSlowDown = true;
		Debug.Log("SlowDown" + Time.timeScale);

	}
	/// <summary>
	/// ���Ԃ����ɖ߂�����
	/// </summary>
	public void SetNormalTime()
	{
		Time.timeScale = 1f;
		isSlowDown = false;
	}
}