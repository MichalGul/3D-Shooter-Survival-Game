using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    private Rigidbody rb;
    public float bulletSpeed;
    public float lifeTime = 7;
    public int BulletDmg;

	
	void Start ()
    {
        // tu trzeba bedzie zmienic bo dziwnie lata jakos hmmm
         rb = GetComponent<Rigidbody>();
       //rb.rotation = Quaternion.Euler(90f, 0f, 0f);
        rb.velocity = -transform.up * bulletSpeed; // tu musi byc pozycja myszki
    

        //niszczenie obiektu po pewnym czasie
        Destroy(gameObject, lifeTime);

    }
	// niszczenie pocisku jesli czegoś dotknie
    void OnCollisionEnter (Collision coll)
    {
        Destroy(gameObject);// jezeli pocisk dotknie czegokolwiek to znika


    }


	
}
