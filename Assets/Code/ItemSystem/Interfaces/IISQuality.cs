using UnityEngine;
using System.Collections;

namespace GG.ItemSystem
{
    public interface IISQuality
    {
        string Name { set; get; }
        Sprite Icon { set; get; }
    }
}