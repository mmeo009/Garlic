using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStates
{
    Idle,
    Run,
    Attack,
    Jump,
    Die
}
public class GeneralAnimation : CreatureStats
{
    protected CharacterStates nowState;
    //�ڷ�ƾ �й�� : ���°��� String ������ ��ȯ�Ͽ� �ڷ�ƾ�� �����ϰ� ����

    //yield return null : ���� �����ӿ� ������ �簳
    //yield return new WaitForSeconds : ������ �ð� �Ŀ� �簳
    //yield return new WaitForSecondsRealtime :  Time.timescale ���� ������ ���� �ʰ� ������ �ð� �Ŀ� �簳
    //yield return new WaitForFixedUpdate : ��� ��ũ��Ʈ���� ��� FixedUpdate�� ȣ��� �Ŀ� �簳
    //yield return new WaitForEndOfFrame : ��� ī�޶�� GUI�� �������� �Ϸ��ϰ�, ��ũ���� �������� ǥ���ϱ� ���� ȣ��
    //yield return StartCoroutine() : �ڷ�ƾ�� �����ϰ� �ڷ�ƾ�� �Ϸ�� �Ŀ� �簳

    protected virtual void StateUpdate(CharacterStates newState)
    {
        StopCoroutine(nowState.ToString());
        nowState = newState;
        //Debug.Log(nowState);
        StartCoroutine(nowState.ToString());
    }
    IEnumerator Idle()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Run()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Attack()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Jump()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Die()
    {
        while (true)
        {
            yield return null;
        }
    }
}
