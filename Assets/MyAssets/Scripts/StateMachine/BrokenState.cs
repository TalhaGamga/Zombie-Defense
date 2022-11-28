using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BrokenState : DoorBaseState
{
    public override void EnterState(DoorStateManager door)
    {
        door.stats.currentHp= 0;
        door.doorObj.SetActive(false);
        //door.zombieSpawnManager.OnSettingTarget(PlayerManager.Instance.player);
        door.stats.ChangeToPct(door.stats.currentHp, door.stats.maxHp);
        door.gameObject.layer = LayerMask.NameToLayer("BrokenDoor");
         
    }

    public override void FixDoor(DoorStateManager door)
    {
        //throw new System.NotImplementedException();
    }
    public override void Hit(DoorStateManager door, DoorStats stats, float hit, GameObject doorObj)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(DoorStateManager door)
    {
        //throw new System.NotImplementedException();
    }
    public override void OnCollisionEnter(DoorStateManager door, Collision collision)
    {

        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            //door.CallIEOnBase();

            door.CallIEEnteredBase(); 
            //GameObject wood = ObjectPooler.Instance.SpawnFromPool(PriceType.Wood.ToString(), PlayerManager.Instance.collectPoint.position, Quaternion.identity);
            //wood.GetComponent<ICollectable>().PushToDoor(door.transform,door);
        }
    }

    public override void OnCollisionExit(DoorStateManager door, Collision collision)
    {

        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            door.StopIEEnteredBase();
        }
    }
}
