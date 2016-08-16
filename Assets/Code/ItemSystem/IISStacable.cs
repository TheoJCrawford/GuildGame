using UnityEngine;
using System.Collections;

namespace GG.ItemSystem
{
    public interface IISStacable
    {
        int Stac ( int amount);
            int MaxStack { get; }
    }
}