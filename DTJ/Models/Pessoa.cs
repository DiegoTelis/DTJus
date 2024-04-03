using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTJ.Models;

    [Table("Pessoa")]
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Nome não informado")]
        [MaxLength(150, ErrorMessage = "Nome não pode passar de 150 caracteres")]
        public string? Nome { get; set; }

        //[Required(ErrorMessage = "Endereco não informado")]
        [MaxLength(250, ErrorMessage = "Endereco não pode passar de 250 caracteres")]
        public string? Endereco { get; set; }
    ///-------------------------------------------------------------------

        //[Required(ErrorMessage = "Cidade não informado")]
        [MaxLength(80, ErrorMessage = "Cidade não pode passar de 80 caracteres")]
        public string? Cidade { get; set; }

        //[Required(ErrorMessage = "Estado não informado")]
        [MaxLength(2, ErrorMessage = "Estado não pode passar de 2 caracteres")]
        public string? Estado { get; set; }

        //[Required(ErrorMessage = "CEP não informado")]
        [MaxLength(8, ErrorMessage = "CEP não pode passar de 8 caracteres")]
        public string? CEP { get; set; }

    ///---------------------------------------------------------

        [Required(ErrorMessage = "CPF não informado")]
        [MaxLength(11, ErrorMessage = "CPF não pode passar de 11 caracteres")]
        public string CPF { get; set; } = null!;

        //[Required(ErrorMessage = "Email não informado")]
        [MaxLength(70, ErrorMessage = "Email não pode passar de 70 caracteres")]
        public string? Email { get; set; }
    
        //[Required(ErrorMessage = "Telefone não informado")]
        [MaxLength(15, ErrorMessage = "Telefone não pode passar de 15 caracteres")]
        public string? Telefone { get; set; }


    }

