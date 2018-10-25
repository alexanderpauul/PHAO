namespace Law.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("Estados")]
    [Description(description: "Estado")]
    public class Estado
    {
        public Estado()
        {
            TProyectos = new HashSet<TProyecto>();
            TOrganismos = new HashSet<TOrganismo>();
            Organismos = new HashSet<Organismo>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput()]
        public int EstadoId { get; set; }

        [Display(Name = "Tipo Estado")]
        public int TEstadoId { get; set; }
        public virtual TEstado TEstado { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "El campo {0} debe contener entre {1} y {2} caracteres.")]
        public string DscEstado { get; set; }

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


        public virtual ICollection<TProyecto> TProyectos { get; set; }
        public virtual ICollection<TOrganismo> TOrganismos { get; set; }
        public virtual ICollection<Organismo> Organismos { get; set; }
    }
}