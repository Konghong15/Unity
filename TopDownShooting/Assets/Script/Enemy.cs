using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    NavMeshAgent mPathFinder;
    Transform mTarget;

    void Start()
    {
        mPathFinder = GetComponent<NavMeshAgent>();
        mTarget = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }

    void Update()
    {
        // mPathFinder.SetDestination(mTarget.position); // �� �����Ӹ��� ���ο� ��θ� ã�� ����̴�. ȣ�� ����� ���� �ʿ䰡 �ֵ�.
    }

    // �ڷ�ƾ�� �� �� ����Ǹ� ������ ���鼭 refreshRate�� ��ٸ� �� ��ȯ�Ѵ�.
    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;

        while (mTarget != null)
        {
            Vector3 targetPosition = new Vector3(mTarget.position.x, 0, mTarget.position.z);
            mPathFinder.SetDestination(targetPosition);

            yield return new WaitForSeconds(refreshRate); //
        }
    }
}
