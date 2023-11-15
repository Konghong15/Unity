using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask mCollisionMask;
    float mSpeed = 10f;

    public void SetSpeed(float speed)
    {
        mSpeed = speed;
    }

    void Update()
    {
        float moveDistance = mSpeed * Time.deltaTime;
        CheckCollisions(moveDistance);

        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward); // ����ü�� ��ġ�� �������� ���� ����
        RaycastHit hit;

        // QueryTriggerInteraction.Collide�ϸ� isTrigger�� �޾ƿ� �� �ִ�.
        // �̹� �����ӿ� �����θ�ŭ�� ���а� �浹�ϴ� ���� �ִٸ�?
        if (Physics.Raycast(ray, out hit, moveDistance, mCollisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        print(hit.collider.gameObject.name);
        GameObject.Destroy(gameObject);
    }
}
