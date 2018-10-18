namespace Law.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("Personas")]
    [Description(description: "Persona")]
    public class Persona
    {
        public Persona()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput()]
        public Guid PersonaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "El campo {0} debe contener entre {1} y {2} caracteres.")]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DisplayName("Primer Apellido")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "El campo {0} debe contener entre {1} y {2} caracteres.")]
        public string PrimerApellido { get; set; }

        [DisplayName("Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [DisplayName("País")]
        public string PaisId { get; set; }

        [DisplayName("Nacionalidad")]
        public string NacionalidadId { get; set; }

        [DisplayName("Sexo")]
        public string SexoId { get; set; }

        [DisplayName("Estado Civil")]
        public int ECivilId { get; set; }

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
        [HiddenInput(DisplayValue = true)]
        public Guid? Identificador { get; set; }

        [DisplayName("Estado")]
        public int? EstadoId { get; set; }

        [NotMapped]
        public string NombreCompleto
        {
            get
            {
                return string.Format("{0} {1} {2}", Nombre, PrimerApellido, SegundoApellido).Trim();
            }
        }


        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}