namespace Law.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("Paises")]
    [Description(description: "País")]
    public class Pais
    {
        public Pais()
        {
            // this.Normas = new HashSet<Norma>();
        }

        [Key]
        [HiddenInput()]
        public int PaisId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Código ISO", Description = "ISO 3166-1 Country code")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "El campo {0} debe contener entre {1} y {2} caracteres.  El estandar ISO 3166-1 solo admite 2 caracteres.")]
        public string ISO { get; set; }

        [Required]
        [Display(Name = "País", Description = "Nombre País")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "50 caracteres maximo.")]
        public string DscPais { get; set; }

        [Display(Name = "Fecha Registro")]
        [HiddenInput()]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Registro { get; set; }

        [Display(Name = "Fecha Modificación")]
        [HiddenInput()]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime? Modificacion { get; set; }

        [Display(Name = "Identificador")]
        [HiddenInput()]
        public Guid? Identificador { get; set; }
    }
}