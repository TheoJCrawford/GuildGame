using UnityEngine;
using System.Collections;

public class Species {
    #region variables
    private string _name;
    private string _desript;
    private Sprite _icon;
    #endregion
    #region
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string descript
    {
        get { return _desript; }
        set { _desript = value; }
    }
    public Sprite icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
    #endregion
    public Species()
    {
        _name = string.Empty;
        _desript = string.Empty;
        _icon = new Sprite();
    }

}
