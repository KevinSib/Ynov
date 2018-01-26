using System;
using System.ComponentModel.DataAnnotations;
namespace YnovShop.Models
{
    public class CreateProductModel
    {
        [Required(ErrorMessage = "Veuillez indiquer votre nom de produit")]
        [Display(Name = "Nom du produit")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer la description du produit")]
        [Display(Name = "Description du produit")]
        public string Descritption { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer le nombre de stock disponible pour ce produit")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Veuillez indiquer le prix du produit")]
        [Display(Name = "Prix")]
        public double Price { get; set; }

    }
}
