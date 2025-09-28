using System;
using System.Collections.Generic;
using Godot;
using Godot.Collections;

namespace GUITest.scripts;

public partial class TabContainer : VBoxContainer
{
    // ReSharper disable once MemberCanBePrivate.Global
    public int SelectionNavItemId { get; private set; } = -1;
    private int _lastSelectionNavItemId = -1;
    private int _navItemCount;
    private readonly List<NavItem> _navItems = [];

    [Export] private StyleBox _selectedColor = GD.Load<StyleBox>("res://styles/NavItem/Selected.tres");

    public override void _Ready()
    {
        GetNavItems(GetChildren());
        if (_navItems.Count < 1) return;
        SelectionNavItem(0);
    }

    private void GetNavItems(Array<Node> children)
    {
        foreach (var node in children)
        {
            if (node is Container container)
            {
                GetNavItems(container.GetChildren());
                continue;
            }

            if (node is not NavItem navItem) continue;
            navItem.NavItemId = _navItemCount;
            navItem.TabContainer = this;
            navItem.SelectedStyleBox = _selectedColor;
            _navItems.Add(navItem);
            _navItemCount++;
        }
    }

    public void SelectionNavItem(int navItemId)
    {
        if (_navItems.Count < 1)
            throw new IndexOutOfRangeException("Nav item list is empty");
        if (navItemId == SelectionNavItemId) return;

        _lastSelectionNavItemId = SelectionNavItemId;
        SelectionNavItemId = navItemId;

        var navItem = _navItems[SelectionNavItemId];
        navItem.Selection();

        if (_lastSelectionNavItemId < 0 || _navItems.Count < _lastSelectionNavItemId) return;
        var lastNavItem = _navItems[_lastSelectionNavItemId];
        lastNavItem.UnSelection();
    }
}