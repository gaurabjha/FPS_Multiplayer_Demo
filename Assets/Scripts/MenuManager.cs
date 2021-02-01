using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager> 
{

    [SerializeField]
    private Menu[] menus;

    public void OpenMenu(string menuName)
    {
        OpenMenuAndReturn(menuName);
    }

    public Menu OpenMenuAndReturn(string MenuName)
    {
        Menu menu = null;
        for(int i = 0; i < menus.Length; i++)
        {
            if (menus[i].MenuName == MenuName) { menu = OpenMenu(menus[i]); }
            else if (menus[i].open) { CloseMenu(menus[i]); }
        }
        return menu;
    } 

    private void CloseMenu(Menu menu) => menu.Close();
    public Menu OpenMenu(Menu menu)
    {
        menu.Open();
        return menu;
    }

}
