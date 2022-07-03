using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OziLib
{
    public sealed class EventTags
    {
        //Test Action
        static public string TEST = "TEST";
        static public string TEST_DATA = "TEST_DATA";
        static public string TEST_I = "TEST_I";

        //Game Action
        static public string LEVEL_START = "LEVEL_START";
        static public string LEVEL_END = "LEVEL_END";
        static public string NEXT_LEVEL = "NEXT_LEVEL";
        static public string COIN_COLLECT = "COIN_COLLECT";
        
        //Special Action
        static public string THREE_AMMO = "THREE_AMMO";
        static public string TWO_AMMO = "TWO_AMMO";
        static public string FIRE_RATE_BOOST = "FIRE_RATE_BOOST";
        static public string AMMO_SPEED_BOOST = "AMMO_SPEED_BOOST";
        static public string CHARACTER_SPEED_BOOST = "CHARACTER_SPEED_BOOST";

        //Data Name
        static public string LEVEL_COUNTER = "LEVEL_COUNTER";
        static public string COIN_COUNTER = "COIN_COUNTER";

        //Const Data
        static public string AMMO_TAG = "Ammo";
    }
}