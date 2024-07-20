using CsvHelper.Configuration;
using DesafioUbc.Business.Entitys;

namespace DesafioUbc.Api.Helper;

public class StudentMap : ClassMap<Student>
{
    public StudentMap()
    {
        Map(m => m.Nome).Name("Nome");
        Map(m => m.Idade).Name("Idade");
        Map(m => m.Serie).Name("Série");
        Map(m => m.NotaMedia).Name("Nota Média");
        Map(m => m.Endereco).Name("Endereço");
        Map(m => m.NomePai).Name("Nome do Pai");
        Map(m => m.NomeMae).Name("Nome da Mãe");
        Map(m => m.DataNascimento).Name("Data de Nascimento").TypeConverterOption.Format("yyyy-MM-dd");
    }
}