namespace SmartAccounting.Domain.Entities;

public class Empresa
{
    public int EmpresaId { get; set; }
    public string Cnpj { get; set; } = string.Empty;
    public string RazaoSocial { get; set; } = string.Empty;
    public string? NomeFantasia { get; set; }
    public bool Ativa { get; set; } = true;

    public ICollection<Exercicio> Exercicios { get; set; } = new List<Exercicio>();
}
