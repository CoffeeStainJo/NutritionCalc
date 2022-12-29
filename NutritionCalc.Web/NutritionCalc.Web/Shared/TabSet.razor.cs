using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace NutritionCalc.Web.Shared;

public partial class TabSet
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public string TabsCssClass { get; set; }
    [Parameter] public string TabsContentCssClass { get; set; }
    public ITab ActiveTab { get; private set; }

    protected override void OnParametersSet()
    {
        TabsCssClass = CssBuilder.Empty().AddClass("tabs").Build();
        TabsContentCssClass = CssBuilder.Empty().AddClass("tabs").AddClass("content").Build();
    }

    public void AddTab(ITab tab)
    {
        if (ActiveTab == null)
            SetActivateTab(tab);
    }

    public void RemoveTab(ITab tab)
    {
        if (ActiveTab == tab)
            SetActivateTab(null);
    }

    public void SetActivateTab(ITab tab)
    {
        if (ActiveTab == tab)
            return;
        ActiveTab = tab;
        StateHasChanged();
    }
}