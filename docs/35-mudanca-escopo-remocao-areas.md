# mudanca de escopo e remocao de areas

## objetivo

Registrar a mudanca de direcao do Blue Atelier e consolidar a remocao das areas que nao fazem mais parte do escopo visual atual.

## motivo da mudanca de escopo

O projeto foi simplificado para concentrar o app nas telas centrais de organizacao de colecoes, modelos, galeria, visualizacao de imagem e arquivos vinculados. As areas de fila, recentes e materiais foram removidas para evitar aumento de escopo antes da validacao do fluxo principal.

## paginas removidas

Foram removidas do app:

- Fila de Impressao;
- Arquivos Recentes;
- Materiais;
- Detalhe do Material, caso existisse localmente.

## rotas removidas

As rotas abaixo nao existem mais:

```txt
/fila-impressao
/arquivos-recentes
/materiais
/materiais/resin-grey
```

## arquivos removidos

Foram removidos, quando existentes:

```txt
src/blueatelier.app/Components/Pages/FilaImpressao.razor
src/blueatelier.app/Components/Pages/ArquivosRecentes.razor
src/blueatelier.app/Components/Pages/Materiais.razor
src/blueatelier.app/Components/Pages/DetalheMaterial.razor
```

## itens removidos da sidebar

A sidebar nao exibe mais:

- Fila de Impressao / Print Queue;
- Arquivos Recentes / Recent Files;
- Materiais / Materials.

A navegacao atual mantem:

- Inicio / Home;
- Colecoes / Collections;
- Modelos / Models;
- Favoritos / Favorites;
- Busca / Search;
- Configuracoes / Settings.

## logicas removidas da topbar

Foram removidas as ramificacoes especificas para as areas excluidas, incluindo metodos e placeholders associados a:

- `IsPrintQueuePage`;
- `IsRecentFilesPage`;
- `IsMaterialsPage`;
- `IsMaterialDetailPage`.

A topbar continua com comportamentos contextuais apenas para as telas mantidas.

## CSS removido

Foram removidos blocos especificos das paginas fora do escopo:

- `print-queue-*`;
- `recent-files-*`;
- `materials-*`;
- `material-detail-*`.

Tokens globais, temas, estilos compartilhados e estilos das telas mantidas foram preservados.

As correcoes de responsividade uteis para telas mantidas, especialmente Modelos e Visualizacao de Imagem, permaneceram no CSS.

## paginas preservadas

Permanecem no app:

- Home;
- Colecoes;
- Detalhe da Colecao;
- Modelos;
- Detalhe do Modelo;
- Galeria do Modelo;
- Visualizacao de Imagem;
- Arquivos Vinculados.

Rotas preservadas:

```txt
/
/colecoes
/colecoes/eldritch-horrors
/modelos
/colecoes/eldritch-horrors/modelos/cthulhu-idol
/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria
/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria/main-reference
/colecoes/eldritch-horrors/modelos/cthulhu-idol/arquivos
```

## detalhe do Modelo

A tela Detalhe do Modelo permanece como parte central do fluxo.

A area `Model Info` foi preservada com campos visuais como:

- Current stage;
- Progress;
- File type;
- Scale;
- Estimated time;
- Suggested material.

Essa area continua preparada visualmente para futura edicao dos campos, mas nao implementa edicao real.

## lista simples de materiais usados

Materiais nao sao mais uma area propria do app no escopo atual.

No Detalhe do Modelo, permanece apenas uma lista visual/mockada de materiais usados no modelo:

- Resin grey;
- Primer black;
- Deep green paint;
- Purple wash.

Essa lista:

- nao navega para `/materiais`;
- nao abre Detalhe do Material;
- nao representa estoque real;
- nao cria cadastro de materiais;
- nao implementa baixa de material;
- nao possui persistencia real.

## fora do escopo atual

Nao fazem parte do escopo atual:

- fila de impressao real;
- tela de Fila de Impressao;
- historico de arquivos recentes;
- tela de Arquivos Recentes;
- cadastro de materiais;
- tela de Materiais;
- Detalhe do Material;
- estoque real;
- baixa real de material;
- banco SQLite;
- EF Core;
- migrations;
- servicos reais;
- sistema de arquivos real;
- persistencia real.

## validacoes executadas

- Confirmado que `referencias-visuais/stitch/design.md` foi respeitado e nao alterado.
- Confirmado que nenhum HTML do Stitch foi alterado.
- Confirmado que nenhuma imagem do Stitch foi alterada.
- Confirmado que as paginas removidas nao existem mais no diretorio `Components/Pages`.
- Confirmado que as rotas removidas nao existem mais como `@page`.
- Confirmado que a sidebar nao mostra Fila de Impressao, Arquivos Recentes ou Materiais.
- Confirmado que a topbar nao possui logica especifica das areas removidas.
- Confirmado que o CSS nao mantem blocos grandes mortos das paginas removidas.
- Confirmado que `Model Info` foi preservado no Detalhe do Modelo.
- Confirmado que a lista simples de materiais usados foi preservada no Detalhe do Modelo.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## proxima etapa sugerida

Implementar a tela Favoritos com base em:

```txt
referencias-visuais/stitch/html/12-favoritos.html
```

A proxima etapa deve preservar as telas mantidas e nao reintroduzir Fila de Impressao, Arquivos Recentes, Materiais ou Detalhe do Material sem nova decisao explicita do usuario.
