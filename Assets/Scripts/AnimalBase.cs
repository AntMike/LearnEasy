using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animals
{
    public class AnimalBase : MonoBehaviour
    {
        public string AnimalSort;


        public virtual void WhatItDo()
        {
            Debug.Log("We have animal");
        }
    }
}
