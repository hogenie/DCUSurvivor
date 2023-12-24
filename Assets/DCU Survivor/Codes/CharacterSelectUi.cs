using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUi : MonoBehaviour
{
    public GameObject[] Normal;
    public GameObject[] Doctor;
    public GameObject[] Music;
    public GameObject[] Catolic;
    public GameObject[] Battery;

    public void NormalAniChange()
    {
        for(int index=0;index<Normal.Length;index++)
        {
            if (index == 0)
            {
                Normal[index].SetActive(true);
                Doctor[index].SetActive(true);
                Music[index].SetActive(true);
                Catolic[index].SetActive(true);
                Battery[index].SetActive(true);
            }
            else
            {
                Normal[index].SetActive(false);
                Doctor[index].SetActive(false);
                Music[index].SetActive(false);
                Catolic[index].SetActive(false);
                Battery[index].SetActive(false);
            }
        }
        Normal[0].SetActive(false);
        Normal[1].SetActive(true);
    }
    public void DoctorAniChange()
    {
        for (int index = 0; index < Normal.Length; index++)
        {
            if (index == 0)
            {
                Normal[index].SetActive(true);
                Doctor[index].SetActive(true);
                Music[index].SetActive(true);
                Catolic[index].SetActive(true);
                Battery[index].SetActive(true);
            }
            else
            {
                Normal[index].SetActive(false);
                Doctor[index].SetActive(false);
                Music[index].SetActive(false);
                Catolic[index].SetActive(false);
                Battery[index].SetActive(false);
            }
        }
        Doctor[0].SetActive(false);
        Doctor[1].SetActive(true);
    }
    public void MusicAniChange()
    {
        for (int index = 0; index < Normal.Length; index++)
        {
            if (index == 0)
            {
                Normal[index].SetActive(true);
                Doctor[index].SetActive(true);
                Music[index].SetActive(true);
                Catolic[index].SetActive(true);
                Battery[index].SetActive(true);
            }
            else
            {
                Normal[index].SetActive(false);
                Doctor[index].SetActive(false);
                Music[index].SetActive(false);
                Catolic[index].SetActive(false);
                Battery[index].SetActive(false);
            }
        }
        Music[0].SetActive(false);
        Music[1].SetActive(true);
    }
    public void CatolicAniChange()
    {
        for (int index = 0; index < Normal.Length; index++)
        {
            if (index == 0)
            {
                Normal[index].SetActive(true);
                Doctor[index].SetActive(true);
                Music[index].SetActive(true);
                Catolic[index].SetActive(true);
                Battery[index].SetActive(true);
            }
            else
            {
                Normal[index].SetActive(false);
                Doctor[index].SetActive(false);
                Music[index].SetActive(false);
                Catolic[index].SetActive(false);
                Battery[index].SetActive(false);
            }
        }
        Catolic[0].SetActive(false);
        Catolic[1].SetActive(true);
    }
    public void BatteryAniChange()
    {
        for (int index = 0; index < Normal.Length; index++)
        {
            if (index == 0)
            {
                Normal[index].SetActive(true);
                Doctor[index].SetActive(true);
                Music[index].SetActive(true);
                Catolic[index].SetActive(true);
                Battery[index].SetActive(true);
            }
            else
            {
                Normal[index].SetActive(false);
                Doctor[index].SetActive(false);
                Music[index].SetActive(false);
                Catolic[index].SetActive(false);
                Battery[index].SetActive(false);
            }
        }
        Battery[0].SetActive(false);
        Battery[1].SetActive(true);
    }
}
