using System.ComponentModel.DataAnnotations;

namespace API_Model;

public class Contact
{
    [Key]public int Id { get; set; }
    public string? Nom { get; set; }
    public string? Prenom { get; set; }
    public string? Nom_Complet { get; set; }
    public string? Sexe { get; set; }
    public string? Date_Naissance { get; set; }
    public string Avatar { get;set; }
}