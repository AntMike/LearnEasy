using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animals.Dogs
{
    public class Sheepdog : Dog
    {
        public override void WhatItDo()
        {
            Debug.Log("Sheepdog is a overrided dog");
        }
    }
}
