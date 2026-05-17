# blue atelier - estado atual

## status geral

Projeto com base documental inicial concluida, referencias visuais do Stitch catalogadas, solucao base .NET MAUI Blazor Hybrid criada, fundacao visual compartilhada implementada e duas telas reais criadas com dados mockados:

- Home;
- Colecoes.

A tela de Colecoes, a Home corrigida e a fundacao visual corrigida foram validadas visualmente pelo usuario e estao aprovadas no estado atual.

O visual aprovado esta protegido. O Codex nao deve redesenhar, reinterpretar, simplificar ou alterar a identidade visual aprovada sem autorizacao explicita do usuario.

## repositorio remoto

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

## ultima tarefa concluida

A ultima tarefa concluida consolidou:

- implementacao da tela de Colecoes com base em `referencias-visuais/stitch/html/02-colecoes.html`;
- correcao visual da Home com base em `referencias-visuais/stitch/html/01-inicio.html`;
- correcao visual da fundacao visual global;
- preservacao da tela de Colecoes durante a correcao da Home;
- aprovacao visual manual pelo usuario da tela de Colecoes, da Home corrigida e da fundacao visual corrigida.

## decisoes ja tomadas

- O app se chama Blue Atelier.
- O app sera Windows local, de uso pessoal e completo.
- A stack oficial e .NET MAUI Blazor Hybrid, C#, SQLite, Entity Framework Core, Razor Components e CSS proprio.
- A arquitetura separa interface, dominio, aplicacao, infraestrutura e persistencia.
- O banco SQLite guardara metadados, relacoes, caminhos, status, tags, links, favoritos, materiais, configuracoes e historico.
- Arquivos pesados devem permanecer no sistema de arquivos.
- Caminhos locais e de rede fazem parte do escopo do app.
- Caminho de rede offline deve ser tratado como condicao normal.
- Remover vinculo no app nao deve apagar arquivo real.
- Stitch e fonte de referencia visual aprovada, mas nao e fonte final de codigo.
- Antigravity e apoio estrategico; Codex e o engenheiro principal do projeto.
- GitHub e a fonte de verdade apos cada commit e push.

## referencias visuais protegidas

Estes arquivos permanecem protegidos:

```txt
referencias-visuais/stitch/design.md
referencias-visuais/stitch/html/
referencias-visuais/stitch/imagens/
```

Regras vigentes:

- nao alterar HTMLs exportados do Stitch;
- nao alterar imagens exportadas do Stitch;
- nao alterar `design.md`;
- nao redesenhar telas aprovadas;
- nao transformar a interface em dashboard corporativo;
- nao usar Tailwind, Bootstrap externo, CDN ou imagens remotas como base do app.

## estado da implementacao

Implementado:

- solucao `BlueAtelier.sln`;
- projeto .NET MAUI Blazor Hybrid para Windows;
- projetos de camada em `src/`;
- projeto de testes em `tests/`;
- layout base em `MainLayout.razor`;
- sidebar em `AppSidebar.razor`;
- topbar em `AppTopbar.razor`;
- componentes base `AppCard`, `AppBadge` e `AppButton`;
- tokens e temas CSS em `wwwroot/css/`;
- Home corrigida e aprovada;
- tela de Colecoes aprovada.

Ainda nao implementado:

- Detalhe da Colecao;
- tela de Modelos;
- Detalhe do Modelo;
- Galeria;
- SQLite;
- EF Core;
- migrations;
- entidades completas;
- servicos reais;
- sistema de arquivos real;
- busca real;
- filtros reais persistidos;
- fila de impressao real;
- configuracoes reais.

## arquivos alterados ou criados na ultima tarefa

Implementacao:

- `src/blueatelier.app/Components/Layout/MainLayout.razor`
- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Pages/Home.razor`
- `src/blueatelier.app/Components/Pages/Colecoes.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/19-tela-colecoes.md`
- `docs/20-correcao-visual-home-e-fundacao.md`

## validacoes executadas na ultima tarefa

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/01-inicio.html` foi usado para corrigir a Home.
- `referencias-visuais/stitch/html/02-colecoes.html` foi usado para a tela de Colecoes.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.
- Nenhuma tela nova alem de Colecoes foi implementada.
- Nenhum banco SQLite foi criado.
- Nenhum EF Core foi implementado.
- Nenhuma migration foi criada.
- Nenhum servico real foi implementado.
- Nenhum sistema de arquivos real foi implementado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## proxima tarefa sugerida

Implementar a tela de Detalhe da Colecao com base em:

```txt
referencias-visuais/stitch/html/03-detalhe-colecao.html
```

A proxima tarefa deve preservar a tela de Colecoes, a Home e a fundacao visual ja aprovadas. Qualquer diferenca visual inevitavel deve ser registrada antes da revisao manual.
