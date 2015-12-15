using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

    private ObjectModel eObject;

    //public void SetColliderSize(float x, float y, float z) {
    //    gameObject.AddComponent<BoxCollider>();
    //    gameObject.GetComponent<BoxCollider>().size = new Vector3(x, y, z);
    //}

    public void SetObject(ObjectModel e) {
        eObject = e;
    }

    public ObjectModel GetObject() {
        return eObject;
    }

    void OnTriggerEnter(Collider col) {
        //print("Collision: " + gameObject);
        if (col.GetComponent<CollisionController>() != null) {
            ObjectModel oModel = col.GetComponent<CollisionController>().GetObject();
            print("Object: " + oModel);
            if (oModel is Bullet) {
                print("Bullet Type" + ((Bullet)oModel).GetType());
                if (((Bullet)oModel).GetType() == BulletType.PLAYER) {
                    print("It's Player Bullet");
                    print("Bullet Damage: " + ((Bullet)oModel).GetDamage());
                    ((EnemyBehaviour)eObject).GiveDamage(((Bullet)oModel).GetDamage());
                    Destroy(oModel.GetModel());
                }
                //    print("BulletType: " + col.GetComponent<CollisionController>().GetObject().GetType());
            //    if (col.GetComponent<CollisionController>().GetObject().GetType().GetType().Equals(BulletType.PLAYER)) {
            //        print("BulletPlayer");
            //        ((EnemyBehaviour)eObject).GiveDamage(((Bullet)col).GetDamage());
            //        GameObject.Destroy(((Bullet)col).GetModel());
            //    }
            }
        }
    }
}
