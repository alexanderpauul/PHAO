namespace Law.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("TEstados")]
    [Description(description: "Tipo de Estado")]
    public class TEstado
    {
        public TEstado()
        {
            Estados = new HashSet<Estado>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput()]
        public int TEstadoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "El campo {0} debe contener entre {1} y {2} caracteres.")]
        [Display(Name = "Nombre")]
        [DisplayFormat(NullDisplayText = "ND")]
        public string DscTEstado { get; set; }

        [Display(Name = "Habilitado")]
        public bool Habilitado { get; set; }

        [Display(Name = "Usuario")]
        [DisplayFormat(NullDisplayText = "N/D", ApplyFormatInEditMode = true)]
        [HiddenInput()]
        public string UserId { get; set; }

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

        public virtual ICollection<Estado> Estados { get; set; }
    }
}