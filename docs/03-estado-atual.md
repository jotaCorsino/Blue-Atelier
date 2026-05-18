# blue atelier - estado atual

## status geral

Projeto com base documental inicial concluida, referencias visuais do Stitch catalogadas, solucao base .NET MAUI Blazor Hybrid criada, fundacao visual compartilhada implementada e sete telas reais criadas com dados mockados:

- Home;
- Colecoes;
- Detalhe da Colecao;
- Detalhe do Modelo;
- Galeria do Modelo;
- Visualizacao de Imagem;
- Arquivos Vinculados.

A Home, a tela de Colecoes, a tela de Detalhe da Colecao, a tela de Detalhe do Modelo, a tela Galeria do Modelo, a tela Visualizacao de Imagem, a tela Arquivos Vinculados, a fundacao visual atual, os ajustes globais de UX e os ajustes de responsividade foram validados visualmente pelo usuario e estao aprovados.

O visual aprovado esta protegido. O Codex nao deve redesenhar, reinterpretar, simplificar ou alterar a identidade visual aprovada sem autorizacao explicita do usuario.

## repositorio remoto

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

## ultima tarefa concluida

A ultima tarefa concluida consolidou:

- implementacao da tela Arquivos Vinculados com base em `referencias-visuais/stitch/html/07-arquivos-vinculados.html`;
- rota `/colecoes/eldritch-horrors/modelos/cthulhu-idol/arquivos`;
- navegacao visual a partir do Detalhe do Modelo;
- uso de dados mockados;
- tela com lista/grid de arquivos vinculados;
- acoes visuais de abrir, editar vinculo e remover vinculo;
- paineis laterais de resumo, pasta vinculada e status;
- correcao de sobreposicao dos paineis laterais;
- substituicao das acoes textuais por icones;
- adicao de `title` e `aria-label` nos botoes de acao;
- refinamento da capa/imagem principal no layout;
- preservacao da Home, Colecoes, Detalhe da Colecao, Detalhe do Modelo, Galeria do Modelo e Visualizacao de Imagem;
- aprovacao visual manual pelo usuario.

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
- componente `AppIcon` com icones SVG inline;
- tokens e temas CSS em `wwwroot/css/`;
- Home corrigida e aprovada;
- tela de Colecoes aprovada;
- tela de Detalhe da Colecao aprovada;
- tela de Detalhe do Modelo aprovada;
- tela Galeria do Modelo aprovada;
- tela Visualizacao de Imagem aprovada;
- tela Arquivos Vinculados aprovada;
- hover global de cards clicaveis;
- affordances visuais de edicao futura;
- tipografia moderna com stack de sistema;
- refinamento visual da barra anterior/proxima da Visualizacao de Imagem;
- correcao global de proporcao para capas, thumbnails, previews e imagens mockadas;
- ajuste de layout do Detalhe do Modelo para acompanhar melhor telas largas;
- paineis laterais responsivos da tela Arquivos Vinculados;
- acoes da lista de arquivos como icones com `title` e `aria-label`;
- capa/imagem principal da tela Arquivos Vinculados bem encaixada no header.

Ainda nao implementado:

- tela de Modelos;
- tela Fila de Impressao;
- SQLite;
- EF Core;
- migrations;
- entidades completas;
- servicos reais;
- sistema de arquivos real;
- busca real;
- filtros reais persistidos;
- fila de impressao real;
- configuracoes reais;
- edicao real de colecoes, modelos ou cards.

## arquivos alterados ou criados na ultima tarefa

Implementacao:

- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Pages/DetalheModelo.razor`
- `src/blueatelier.app/Components/Pages/ArquivosVinculados.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/27-arquivos-vinculados.md`
- `docs/28-ajustes-arquivos-vinculados-layout.md`

## validacoes executadas na ultima tarefa

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/07-arquivos-vinculados.html` foi usado para a tela Arquivos Vinculados.
- Home permaneceu preservada.
- Colecoes permaneceu preservada.
- Detalhe da Colecao permaneceu preservado.
- Detalhe do Modelo permaneceu preservado.
- Galeria do Modelo permaneceu preservada.
- Visualizacao de Imagem permaneceu preservada.
- Arquivos Vinculados foi aprovada.
- Paineis laterais nao se sobrepoem ao conteudo principal.
- A capa/imagem principal esta bem encaixada e sem espaco vazio desnecessario.
- Acoes da lista usam icones.
- Botoes de acao possuem `title` e `aria-label`.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.
- Nenhuma funcionalidade real foi implementada.
- Nenhum banco SQLite foi criado.
- Nenhum EF Core foi implementado.
- Nenhuma migration foi criada.
- Nenhum servico real foi implementado.
- Nenhum sistema de arquivos real foi implementado.
- Nenhum CDN, Tailwind, Bootstrap ou biblioteca externa foi usado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## proxima tarefa sugerida

Implementar a tela de Fila de Impressao com base em:

```txt
referencias-visuais/stitch/html/08-fila-impressao.html
```

A proxima tarefa deve preservar a Home, Colecoes, Detalhe da Colecao, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados e a fundacao visual ja aprovadas. Qualquer diferenca visual inevitavel deve ser registrada antes da revisao manual.
