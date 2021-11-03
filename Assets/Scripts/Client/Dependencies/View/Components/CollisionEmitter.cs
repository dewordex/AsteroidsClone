using System.Collections.Generic;
using CustomEcs;
using GameLogic.Dependencies.View;
using GameLogic.Events;
using UnityEngine;

namespace Client.Dependencies.View.Components
{
    public class CollisionEmitter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var senderEntity = GetComponent<IView>().EntityLink;
            var targetEntity = other.GetComponent<IView>().EntityLink;

            if (senderEntity.IsAlive && targetEntity.IsAlive)
            {
                if (senderEntity.Has<CollisionEvent>())
                {
                    senderEntity.Get<CollisionEvent>().CollisionList.Add((senderEntity, targetEntity));
                }
                else
                {
                    senderEntity.Replace(new CollisionEvent() { CollisionList = new List<(EcsEntity sender, EcsEntity target)>() { (senderEntity, targetEntity) } });
                }
            }
        }
    }
}