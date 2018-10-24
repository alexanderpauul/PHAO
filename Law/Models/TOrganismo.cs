namespace Law.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("TOrganismos")]
    [Description(description: "Tipo de Organismo")]
    public class TOrganismo
    {
        public TOrganismo()
        {
            Organismos = new HashSet<Organismo>();
        }

        [Key]
        [HiddenInput()]
        public int TOrganismoId { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "El campo {0} debe contener entre {1} y {2} caracteres.")]
        public string DscTOrganismo { get; set; }

        [Display(Name = "Usuario")]
        [DisplayFormat(NullDisplayText = "N/D", ApplyFormatInEditMode = true)]
        [HiddenInput()]
        public string UserId { get; set; }

        [Display(Name = "Registro")]
        [HiddenInput()]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Registro { get; set; }

        [Display(Name = "Modificación")]
        [HiddenInput()]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime? Modificacion { get; set; }

        [Display(Name = "Identificador")]
        [HiddenInput()]
        public Guid? Identificador { get; set; }

        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }

        public virtual ICollection<Organismo> Organismos { get; set; }
    }
}