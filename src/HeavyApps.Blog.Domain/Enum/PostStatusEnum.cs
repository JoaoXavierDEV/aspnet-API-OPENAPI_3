using System.ComponentModel;

namespace HeavyApps.Blog.Domain.Enum;

// TODO! Refatorar
public enum StatusPostEnum
{
    [Description("Pendente")]
    Pendente = 0,
    Publicado = 1,
    Rascunho = 2,
    Excluido = 3,
    Revisao = 4,
    Aprovado = 5,
    Reprovado = 6,
    Programado = 7,
    Arquivado = 8,
    EmAndamento = 9,
    Concluido = 10,

}
