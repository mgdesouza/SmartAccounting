namespace SmartAccounting.Domain.Entities;

public class Exercicio
{
    public int ExercicioId { get; set; }
    public int EmpresaId { get; set; }
    public int Ano { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public DateTime DataImportacao { get; set; }
    public string? ArquivoECD { get; set; }
    public string Status { get; set; } = "Importado";

    public Empresa Empresa { get; set; } = null!;
}
