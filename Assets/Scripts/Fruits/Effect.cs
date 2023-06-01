using UnityEngine;

public class Effect : MonoBehaviour {
    public void PunchBack(GameObject target)
    {
        float pushPower = 5.0f;
        float fUpSize = 0.2f;

        target.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * pushPower, ForceMode2D.Impulse);
        while(fUpSize >= 6)
        {
            target.transform.localScale = new Vector3(fUpSize, fUpSize, 0);
            fUpSize += 0.1f;
        }
    }

}