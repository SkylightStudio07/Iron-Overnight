using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern3 : MonoBehaviour
{

    public Transform Boss_MissilePos;
    public GameObject Boss_Stage_2_Torpedo;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.Stage_3_CannnotFire = true;
        StartCoroutine(Pattern3());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Pattern3() {
        while(true) {
        yield return new WaitForSeconds(5.0f);

        for(int i = 0; i<2; i++) {
            Instantiate(Boss_Stage_2_Torpedo, Boss_MissilePos.transform.position, Boss_MissilePos.transform.rotation);
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(10.0f);
    }

}
}
