using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using NutritionCalc.Web.Shared;

namespace NutritionCalc.Web.Components;

public partial class Calculator
{
    [Inject] public NutritionService Service { get; set; }
    private bool CalorieBudgetIsChanged, BudgetCaloriesPerHundredGramsIsChanged;
    private bool unitCaloriesBudgetChanged, unitGramsChanged, unitCaloriesChanged;
    private bool m_CaloriesChanged, m_GramsChanged;

    private bool m_BudgetFormInvalid = true;
    private bool m_UnitFormInvalid = true;
    private bool m_CaloriesFormInvalid = true;

    private EditContext m_BudgetContext;
    private EditContext m_UnitContext;
    private EditContext m_CaloriesContext;

    private bool m_ShowBudget = true;
    private bool m_ShowUnit;
    private bool m_ShowCalories;

    protected override void OnInitialized()
    {
        m_BudgetContext = new EditContext(Service.Budget);
        m_UnitContext = new EditContext(Service.UnitBudget);
        m_CaloriesContext = new EditContext(Service.Calories);

        m_BudgetContext.OnFieldChanged += (_, __) =>
        {
            if (CalorieBudgetIsChanged && BudgetCaloriesPerHundredGramsIsChanged)
                m_BudgetFormInvalid = !m_BudgetContext.Validate();

            if (!m_BudgetFormInvalid)
            {
                double? currentCount = 0;
                var ratioNumber = (double)Service.Budget.CalorieBudget / (double)Service.Budget.CaloriesPerHundredGrams;
                currentCount = (ratioNumber) * 100;
                currentCount = Math.Round(currentCount ?? 0, 1);
                Service.Budget.Nutrition.Grams = Math.Round(currentCount ?? 0, 1);
                Service.Budget.Nutrition.Fats = Math.Round(Service.Budget.GramsOfFat * ratioNumber ?? 0, 1);
                Service.Budget.Nutrition.Saturated = Math.Round(Service.Budget.GramsOfSaturatedFat * ratioNumber ?? 0, 1);
                Service.Budget.Nutrition.Carbohydrates = Math.Round(Service.Budget.GramsOfCarbohydrates * ratioNumber ?? 0, 1);
                Service.Budget.Nutrition.Sugars = Math.Round(Service.Budget.GramsOfSugars * ratioNumber ?? 0, 1);
                Service.Budget.Nutrition.Protein = Math.Round(Service.Budget.GramsOfProtein * ratioNumber ?? 0, 1);
                Service.Budget.Nutrition.Energy = Service.Budget.CalorieBudget;
            }
            StateHasChanged();
        };

        m_UnitContext.OnFieldChanged += (_, __) =>
        {

            if (unitCaloriesBudgetChanged && unitGramsChanged && unitCaloriesChanged)
                m_UnitFormInvalid = !m_UnitContext.Validate();

            if (!m_UnitFormInvalid)
            {
                var ratioNumber = (double)Service.UnitBudget.CalorieBudgetPerUnit / (double)Service.UnitBudget.CaloriesPerUnitProduct;
                Service.UnitBudget.Nutrition.Units = Math.Round(ratioNumber, 1);
                Service.UnitBudget.Nutrition.Fats = Math.Round(Service.UnitBudget.GramsOfFatPerUnit * ratioNumber ?? 0, 1);
                Service.UnitBudget.Nutrition.Saturated = Math.Round(Service.UnitBudget.GramsOfSaturatedFatPerUnit * ratioNumber ?? 0, 1);
                Service.UnitBudget.Nutrition.Carbohydrates = Math.Round(Service.UnitBudget.GramsOfCarbohydratesPerUnit * ratioNumber ?? 0, 1);
                Service.UnitBudget.Nutrition.Sugars = Math.Round(Service.UnitBudget.GramsOfSugarsPerUnit * ratioNumber ?? 0, 1);
                Service.UnitBudget.Nutrition.Protein = Math.Round(Service.UnitBudget.GramsOfProteinPerUnit * ratioNumber ?? 0, 1);
                Service.UnitBudget.Nutrition.Energy = Service.UnitBudget.CalorieBudgetPerUnit;
            }
            StateHasChanged();
        };

        m_CaloriesContext.OnFieldChanged += (_, __) =>
        {
            if (m_CaloriesChanged && m_GramsChanged)
                m_CaloriesFormInvalid = !m_CaloriesContext.Validate();

            if (!m_CaloriesFormInvalid)
            {
                var x = Service.Calories.GramsPerUnitProduct / 100;
                var y = x * Service.Calories.CaloriesPerHundredGrams;
                Service.Calories.Nutrition.Fats = Math.Round(Service.Calories.GramsOfFat * x ?? 0, 1);
                Service.Calories.Nutrition.Saturated = Math.Round(Service.Calories.GramsOfSaturatedFat * x ?? 0, 1);
                Service.Calories.Nutrition.Carbohydrates = Math.Round(Service.Calories.GramsOfCarbohydrates * x ?? 0, 1);
                Service.Calories.Nutrition.Sugars = Math.Round(Service.Calories.GramsOfSugars * x ?? 0, 1);
                Service.Calories.Nutrition.Protein = Math.Round(Service.Calories.GramsOfProtein * x ?? 0, 1);
                Service.Calories.Nutrition.Energy = y;
                Service.Calories.Nutrition.Grams = x;
            }
            StateHasChanged();
        };
    }

    private void HandleBudgetTabActivated()
    {
        m_ShowBudget = true;
        m_ShowUnit = false;
        m_ShowCalories = false;
    }

    private void HandleUnitTabActivated()
    {
        m_ShowBudget = false;
        m_ShowUnit = true;
        m_ShowCalories = false;
    }

    private void HandleCaloriesTabActivated()
    {
        m_ShowBudget = false;
        m_ShowUnit = false;
        m_ShowCalories = true;
    }

    private bool BudgetIsReady() 
        => m_ShowBudget && m_BudgetFormInvalid;

    private bool UnitIsReady() 
        => m_ShowUnit && m_UnitFormInvalid;

    private bool CaloriesAreReady() 
        => m_ShowCalories && m_CaloriesFormInvalid;
}
