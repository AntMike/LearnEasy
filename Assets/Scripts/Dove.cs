using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animals.Birds
{
    public class Dove : Bird
    {
        public override void WhatItDo()
        {
            Debug.Log("Dove is a overrided bird");
        }
    }
}