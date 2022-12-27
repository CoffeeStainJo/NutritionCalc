using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace NutritionCalc.Web.Shared;

public partial class Tab : ITab, IDisposable
{
    [CascadingParameter] public TabSet ContainerTabSet { get; set; }
    [Parameter] public string Title { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public EventCallback TabActivated { get; set; }
    [Parameter] public string TitleCssClass { get; set; }

    protected override void OnInitialized()
    {
        ContainerTabSet.AddTab(this);
    }

    protected override void OnParametersSet()
    {
        TitleCssClass = CssBuilder
                        .Empty()
                        .AddClass("nav-link")
                        .AddClass("nav-link--active", when: ContainerTabSet.ActiveTab == this)
                        .Build();
    }

    private void Activate()
    {
        TabActivated.InvokeAsync(null);
        ContainerTabSet.SetActivateTab(this);
    }

    public void Dispose() 
        => ContainerTabSet.RemoveTab(this);
}
