using UnityEngine;

public class Effect : MonoBehaviour {
    public static void Upscale()
    {
#if false
        if (isUpScale == true)
        {
            //ƨ�ܳ��� 2d���� z������ ƨ�ܳ��⿡ ���ٹ��� ����Ͽ� �ð����� ��ü���� �ش�.
            gBackFruit.transform.localScale = new Vector3(fUpSize, fUpSize, 0);

            fUpSize += 0.1f; //������ ����
        }


        if (fUpSize >= 6)
        {
            Destroy(gBackFruit);
            fUpSize = 0.2f;
            isUpScale = false;
        }
#endif
    }
}