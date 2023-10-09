using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using MonoGame.Extended.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public sealed class GameManager : StateMachine
{

    //non-lazy singleton pattern for the game manager
    private static readonly GameManager gm = new();
    private Screen _activeScreen;

    static GameManager() {

    }
    private GameManager() {

    }

    public static GameManager GM {
        get {
            return gm;
        }
    }

    public void Start() {
        Debug.WriteLine(" Object is not valid for this category.");
    }

    public Keys keyboardUP = Keys.W;
    public Keys keyboardDOWN = Keys.S;
    public Keys keyboardLEFT = Keys.A;
    public Keys keyboardRIGHT = Keys.D;
}

