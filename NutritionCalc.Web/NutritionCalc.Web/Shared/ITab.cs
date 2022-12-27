using Microsoft.AspNetCore.Components;

namespace NutritionCalc.Web.Shared;

public interface ITab
{
    RenderFragment ChildContent { get; }
}
