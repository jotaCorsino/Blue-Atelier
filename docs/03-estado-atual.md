# blue atelier - estado atual

## status geral

O projeto Blue Atelier mudou de direcao e teve o escopo visual atual simplificado.

O app mantem a base .NET MAUI Blazor Hybrid, a fundacao visual aprovada, a paleta clean/azulada e as telas principais de organizacao de colecoes e modelos. As areas de Fila de Impressao, Arquivos Recentes, Materiais e Detalhe do Material foram removidas do escopo atual.

Telas mantidas no estado atual:

- Home;
- Colecoes;
- Detalhe da Colecao;
- Modelos;
- Detalhe do Modelo;
- Galeria do Modelo;
- Visualizacao de Imagem;
- Arquivos Vinculados.

A Home, Colecoes, Detalhe da Colecao, Modelos, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados, sidebar, topbar, tipografia, responsividade e paleta visual atual foram validados visualmente pelo usuario e estao aprovados.

O visual aprovado esta protegido. O Codex nao deve redesenhar, reinterpretar, simplificar ou alterar a identidade visual aprovada sem autorizacao explicita do usuario.

## repositorio remoto

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

## ultima tarefa concluida

A ultima tarefa concluida consolidou a mudanca de escopo do app:

- remocao completa da tela Fila de Impressao;
- remocao completa da tela Arquivos Recentes;
- remocao completa da tela Materiais;
- remocao do Detalhe do Material criado localmente;
- remocao das rotas `/fila-impressao`, `/arquivos-recentes`, `/materiais` e `/materiais/resin-grey`;
- remocao desses itens da sidebar;
- simplificacao da sidebar para manter Inicio, Colecoes, Modelos, Favoritos, Busca e Configuracoes;
- remocao da logica especifica dessas areas na topbar;
- limpeza de CSS morto relacionado a `print-queue-*`, `recent-files-*`, `materials-*` e `material-detail-*`;
- preservacao das paginas mantidas;
- preservacao da area `Model Info` no Detalhe do Modelo;
- preservacao de uma lista simples de materiais usados dentro do Detalhe do Modelo;
- preservacao da paleta visual clean, moderna, azulada e menos colorida;
- aprovacao visual manual da mudanca de escopo pelo usuario.

## decisoes ja tomadas

- O app se chama Blue Atelier.
- O app sera Windows local, de uso pessoal e completo.
- A stack oficial e .NET MAUI Blazor Hybrid, C#, SQLite, Entity Framework Core, Razor Components e CSS proprio.
- A arquitetura separa interface, dominio, aplicacao, infraestrutura e persistencia.
- Arquivos pesados devem permanecer no sistema de arquivos.
- Caminhos locais e de rede fazem parte do escopo futuro do app.
- Caminho de rede offline deve ser tratado como condicao normal.
- Remover vinculo no app nao deve apagar arquivo real.
- Stitch e fonte de referencia visual aprovada, mas nao e fonte final de codigo.
- Antigravity e apoio estrategico; Codex e o engenheiro principal do projeto.
- GitHub e a fonte de verdade apos cada commit e push.

## mudanca de escopo

Nao fazem mais parte do escopo visual atual:

- Fila de Impressao;
- Arquivos Recentes;
- Materiais;
- Detalhe do Material.

Tambem nao existem no estado atual:

- fila real;
- historico real de arquivos recentes;
- cadastro real de materiais;
- estoque real;
- baixa real de material;
- detalhe de material;
- navegacao para `/materiais`;
- persistencia real.

Materiais agora aparecem apenas como uma lista local/mockada dentro do Detalhe do Modelo, indicando materiais usados naquele modelo. Essa lista nao representa estoque, nao abre pagina propria e nao navega para uma area de Materiais.

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
- Home aprovada e com cards de colecao navegaveis;
- tela de Colecoes aprovada;
- tela de Detalhe da Colecao aprovada;
- tela Modelos em `/modelos` aprovada;
- tela de Detalhe do Modelo aprovada;
- tela Galeria do Modelo aprovada;
- tela Visualizacao de Imagem aprovada;
- tela Arquivos Vinculados aprovada;
- navegacao do card Cthulhu Idol para `/colecoes/eldritch-horrors/modelos/cthulhu-idol`;
- sidebar com Models ativo nas rotas de modelos;
- hover global de cards clicaveis;
- affordances visuais de edicao futura;
- tipografia moderna com stack de sistema;
- paleta visual mais clean, moderna, azulada e menos colorida;
- azul como cor principal de destaque;
- refinamento visual da barra anterior/proxima da Visualizacao de Imagem;
- correcao global de proporcao para capas, thumbnails, previews e imagens mockadas;
- ajuste de layout do Detalhe do Modelo para acompanhar melhor telas largas;
- paineis laterais responsivos da tela Arquivos Vinculados;
- acoes da lista de arquivos como icones com `title` e `aria-label`;
- capa/imagem principal da tela Arquivos Vinculados bem encaixada no header.

Removido do estado atual:

- tela Fila de Impressao;
- tela Arquivos Recentes;
- tela Materiais;
- Detalhe do Material;
- navegacao da sidebar para as areas removidas;
- logicas especificas da topbar para as areas removidas;
- CSS especifico das paginas removidas.

Ainda nao implementado:

- SQLite;
- EF Core;
- migrations;
- entidades completas;
- servicos reais;
- sistema de arquivos real;
- busca real;
- filtros reais persistidos;
- configuracoes reais;
- edicao real de colecoes, modelos ou cards;
- persistencia real.

## arquivos alterados ou removidos na ultima tarefa

Implementacao:

- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Pages/Home.razor`
- `src/blueatelier.app/Components/Pages/DetalheModelo.razor`
- `src/blueatelier.app/Components/Pages/ArquivosVinculados.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`
- `src/blueatelier.app/Components/Pages/FilaImpressao.razor` removido
- `src/blueatelier.app/Components/Pages/ArquivosRecentes.razor` removido
- `src/blueatelier.app/Components/Pages/Materiais.razor` removido
- `src/blueatelier.app/Components/Pages/DetalheMaterial.razor` removido, caso existisse localmente

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/35-mudanca-escopo-remocao-areas.md`
- `docs/29-fila-impressao.md` removido
- `docs/32-arquivos-recentes.md` removido
- `docs/33-materiais.md` removido
- `docs/34-ajustes-layout-responsividade.md` removido

## validacoes executadas na ultima tarefa

- `referencias-visuais/stitch/design.md` permanece protegido.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.
- `/fila-impressao` nao existe mais como rota.
- `/arquivos-recentes` nao existe mais como rota.
- `/materiais` nao existe mais como rota.
- `/materiais/resin-grey` nao existe mais como rota.
- A sidebar nao mostra mais Fila de Impressao.
- A sidebar nao mostra mais Arquivos Recentes.
- A sidebar nao mostra mais Materiais.
- A topbar nao possui mais logica especifica dessas areas.
- O CSS nao mantem blocos grandes mortos dessas paginas.
- O Detalhe do Modelo ainda possui `Model Info`.
- O Detalhe do Modelo ainda possui lista simples de materiais usados.
- Nenhuma funcionalidade real foi implementada.
- Nenhum banco SQLite foi criado.
- Nenhum EF Core foi implementado.
- Nenhuma migration foi criada.
- Nenhum servico real foi implementado.
- Nenhuma persistencia real foi implementada.
- Nenhum CDN, Tailwind, Bootstrap ou biblioteca externa foi usado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## proxima tarefa sugerida

Implementar a tela Favoritos com base em:

```txt
referencias-visuais/stitch/html/12-favoritos.html
```

A proxima tarefa deve preservar Home, Colecoes, Detalhe da Colecao, Modelos, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados e a fundacao visual ja aprovadas. Nao reintroduzir Fila de Impressao, Arquivos Recentes, Materiais ou Detalhe do Material sem nova decisao explicita do usuario.
