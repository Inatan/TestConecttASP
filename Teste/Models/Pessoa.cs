using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Models
{
    [Table("Pessoa")]
    public partial class Pessoa
    {
        public Pessoa() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})$", ErrorMessage = "Digite um CPF válido")]
        public String CPF { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[RegularExpression(@"^(?:(?:31(\/)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$$", ErrorMessage = "Digite uma data válida")]
        public DateTime Nascimento { get; set; }

        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Digite um email válido")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        public String Empresa { get; set; }

        [RegularExpression(@"^\([1-9]{2}\)[0-9]{4,5}\-[0-9]{4}$", ErrorMessage = "Digite um número válido")]
        public String TelefoneComercial { get; set; }

        [RegularExpression(@"^\([1-9]{2}\)[0-9]{4,5}\-[0-9]{4}$", ErrorMessage = "Digite um número válido")]
        public String TelefoneCelular { get; set; }

        public int Idade { get; set; }

    }
}