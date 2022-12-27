using System.ComponentModel.DataAnnotations;

namespace NutritionCalc.Web.Shared;

public class NutritionService
{
    public NutritionBudget Budget { get; set; }
    public UnitBudget UnitBudget { get; set; }
    public Calories Calories { get; set; }

    public NutritionService()
    {
        Budget = new NutritionBudget();
        UnitBudget = new UnitBudget();
        Calories = new Calories();
    }
}

public class NutritionBudget
{
    [Display(Name = "Antall kcal disponibelt ", Description = "kcal", Prompt = "Kalorier")]
    [Required(ErrorMessage = "Antall kalorier må oppgis.")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdien må være større en 0.")]
    public double? CalorieBudget { get; set; }

    [Display(Name = "Antall kcal i 100 g vare ", Description = "kcal/100 g", Prompt = "I vare")]
    [Required(ErrorMessage = "Antall kalorier i varen må oppgis.", AllowEmptyStrings = true)]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? CaloriesPerHundredGrams { get; set; }

    [Display(Name = "Fett ", Description = "fett/100 g", Prompt = "Gram fett i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfFat { get; set; }

    [Display(Name = "-hvorav mettet fett ", Description = "mettet fett/100", Prompt = "Gram mettet fett i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfSaturatedFat { get; set; }

    [Display(Name = "Karbohydrat ", Description = "karb./100 g", Prompt = "Gram karbohydrat i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfCarbohydrates { get; set; }

    [Display(Name = "-hvorav sukkerarter ", Description = "sukker/100 g", Prompt = "Gram sukker i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfSugars { get; set; }

    [Display(Name = "Protein ", Description = "protein/100 g", Prompt = "Gram protein i 100 gram vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfProtein { get; set; }

    public Nutrition Nutrition { get; set; } = new Nutrition();
}

public class UnitBudget
{
    [Display(Name = "Antall kcal disponibelt ", Description = "kcal", Prompt = "Kalorier")]
    [Required(ErrorMessage = "Antall kalorier må oppgis.")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdien må være større en 0.")]
    public double? CalorieBudgetPerUnit { get; set; }

    [Display(Name = "Vekt vare i gram ", Description = "kcal/100 g", Prompt = "I vare")]
    [Required(ErrorMessage = "Antall gram per i varen må oppgis.", AllowEmptyStrings = true)]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsPerUnitProduct { get; set; }

    [Display(Name = "Antall kilokalorier per enhet vare ", Description = "kcal/100 g", Prompt = "I vare")]
    [Required(ErrorMessage = "Antall kalorier i varen må oppgis.", AllowEmptyStrings = true)]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? CaloriesPerUnitProduct { get; set; }

    [Display(Name = "Fett ", Description = "fett/100 g", Prompt = "Gram fett i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfFatPerUnit { get; set; }

    [Display(Name = "-hvorav mettet fett ", Description = "mettet fett/100", Prompt = "Gram mettet fett i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfSaturatedFatPerUnit { get; set; }

    [Display(Name = "Karbohydrat ", Description = "karb./100 g", Prompt = "Gram karbohydrat i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfCarbohydratesPerUnit { get; set; }

    [Display(Name = "-hvorav sukkerarter ", Description = "sukker/100 g", Prompt = "Gram sukker i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfSugarsPerUnit { get; set; }

    [Display(Name = "Protein ", Description = "protein/100 g", Prompt = "Gram protein i 100 gram vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfProteinPerUnit { get; set; }

    public Nutrition Nutrition { get; set; } = new Nutrition();
}

public class Calories
{
    [Display(Name = "Vekt vare i gram ", Description = "kcal/100 g", Prompt = "I vare")]
    [Required(ErrorMessage = "Antall gram per i varen må oppgis.", AllowEmptyStrings = true)]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsPerUnitProduct { get; set; }

    [Display(Name = "Antall kcal i 100 g vare ", Description = "kcal/100 g", Prompt = "I vare")]
    [Required(ErrorMessage = "Antall kalorier i varen må oppgis.", AllowEmptyStrings = true)]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? CaloriesPerHundredGrams { get; set; }

    [Display(Name = "Fett ", Description = "fett/100 g", Prompt = "Gram fett i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfFat { get; set; }

    [Display(Name = "-hvorav mettet fett ", Description = "mettet fett/100", Prompt = "Gram mettet fett i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfSaturatedFat { get; set; }

    [Display(Name = "Karbohydrat ", Description = "karb./100 g", Prompt = "Gram karbohydrat i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfCarbohydrates { get; set; }

    [Display(Name = "-hvorav sukkerarter ", Description = "sukker/100 g", Prompt = "Gram sukker i vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfSugars { get; set; }

    [Display(Name = "Protein ", Description = "protein/100 g", Prompt = "Gram protein i 100 gram vare")]
    [Range(1, 9999999999999999.99, ErrorMessage = "Verdi må være større en 0.")]
    public double? GramsOfProtein { get; set; }

    public Nutrition Nutrition { get; set; } = new Nutrition();
}

public class Nutrition
{
    public double? Grams { get; set; }
    public double? Fats { get; set; }
    public double? Saturated { get; set; }
    public double? Carbohydrates { get; set; }
    public double? Sugars { get; set; }
    public double? Protein { get; set; }
    public double? Energy { get; set; }
    public double? Units { get; set; }
}