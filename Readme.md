
# Projeto de API para Estudos e Testes de Documentação

Este projeto tem como objetivo estudar a criação de APIs REST utilizando **ASP.NET 9** e experimentar diferentes formas de **documentação com OpenAPI 3**.

 A estrutura é inspirada no estilo do framework Flask (Python), a qual exibe a pagína index com as opções de documentação, para isso foi necessário incluir o suporte a RazorPages para suportar a exibição de páginas *.cshtml
```csharp
+ builder.Services.AddRazorPages();
```

```csharp
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

+ app.MapStaticAssets();

+ app.MapRazorPages();

app.Run();
```

![Image](https://github.com/user-attachments/assets/614564c0-03fb-49e3-bc92-7d8253010f2d)

## ✨ Objetivos

- Aprender e praticar a criação de APIs REST em .NET 9
- Testar formas diferentes de documentar uma API usando o padrão OpenAPI 3
- Explorar múltiplas interfaces de visualização e exportação de documentação

## 🛠 Tecnologias Utilizadas

- **ASP.NET Core 9**
- **OpenAPI 3**
- **Interfaces de Documentação:**
  - Swagger UI
  - Redoc
  - RapiDoc
  - RapiPDF
  - Scalar
  - Elements

## 🚀 Como Executar o Projeto

1. Clone o repositório:
 ```bash
   git clone https://github.com/seu-usuario/nome-do-repo.git
   cd nome-do-repo
   ```

2.  **Restaure os pacotes:**
 ```csharp
	dotnet restore
 ```
    
3.  **Execute o projeto:**
 ```csharp
	dotnet run 
```

   | Interface  | URL                                                                        |
| ---------- | -------------------------------------------------------------------------- |
| Swagger UI | [http://localhost:5000/swagger](http://localhost:5000/swagger)             |
| Redoc      | [http://localhost:5000/api-docs/](http://localhost:5000/docs/redoc)       |
| RapiDoc    | [http://localhost:5000/docs/rapidoc](http://localhost:5000/docs/rapidoc)   |
| RapiPDF    | [http://localhost:5000/docs/rapipdf](http://localhost:5000/docs/rapipdf)   |
| Scalar     | [http://localhost:5000/scalar](http://localhost:5000/docs/scalar)     |
| Elements   | [http://localhost:5000/docs/elements](http://localhost:5000/docs/elements) |

/src
  └── ApiEstudos/
      ├── Controllers/
      ├── Documentation/
      ├── Program.cs
      └── ApiEstudos.csproj

📌 Notas Finais
Este projeto é experimental e voltado exclusivamente para estudos pessoais.

A ideia principal é entender o funcionamento e as possibilidades do ecossistema .NET com OpenAPI.

Futuras extensões podem incluir autenticação JWT, versionamento de API, testes automatizados e deploy em nuvem.

✍️ Autor
Desenvolvido por Seu Nome — com foco em aprendizado, boas práticas e testes de documentação.