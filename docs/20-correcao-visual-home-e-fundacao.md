# blue atelier - correcao visual da Home e fundacao

## 1. motivo da correcao visual

A primeira implementacao da Home e da fundacao visual estava funcional, mas se afastava demais da referencia aprovada do Stitch.

O usuario solicitou que a implementacao deixasse de ser apenas inspirada no Stitch e passasse a preservar com mais fidelidade:

- layout;
- espacamentos;
- proporcoes;
- hierarquia visual;
- aparencia dos cards;
- disposicao dos elementos;
- sensacao geral da interface.

## 2. telas corrigidas

Foram corrigidas:

- Home;
- fundacao visual global;
- shell/layout base;
- sidebar;
- topbar;
- cards e mosaicos usados pela Home.

A tela de Colecoes ja estava aprovada e foi preservada durante a correcao.

## 3. referencias usadas

Referencias principais:

```txt
referencias-visuais/stitch/design.md
referencias-visuais/stitch/html/01-inicio.html
referencias-visuais/stitch/imagens/01-inicio.png
referencias-visuais/stitch/html/02-colecoes.html
referencias-visuais/stitch/imagens/02-colecoes.png
docs/15-referencias-visuais-stitch.md
docs/17-fundacao-visual.md
docs/18-tela-inicial.md
```

## 4. principais ajustes feitos

### Home

- Remocao do aspecto de dashboard generico.
- Remocao dos cards de metricas que nao apareciam na referencia do Stitch.
- Reorganizacao em secoes mais fieis ao `01-inicio.html`.
- Uso de cards visuais em mosaico para colecoes recentes e modelos em andamento.
- Uso de cards horizontais para itens prontos para impressao.
- Aviso de caminho de rede offline movido para a topbar da Home, como condicao normal.

### Fundacao visual

- Criacao de modo visual especifico para Home no shell.
- Preservacao do modo visual ja aprovado da tela de Colecoes.
- Ajuste de espacamento e densidade visual para aproximar a Home do Stitch.

### Sidebar

- A sidebar recebeu um modo visual especifico para Home, com aparencia escura mais proxima do `01-inicio.html`.
- A navegacao para `/` e `/colecoes` foi preservada.
- A tela de Colecoes continua usando a experiencia visual aprovada.

### Topbar

- A topbar passou a ter comportamento contextual por rota.
- Em `/colecoes`, foram preservados busca, `Importar pasta` e `+ Nova colecao`.
- Em `/`, a topbar exibe busca e aviso de caminho de rede offline, seguindo a referencia da Home.

### Cards e mosaicos

- Os cards da Home passaram a usar proporcao e hierarquia mais proximas do Stitch.
- Os grids da Home foram reorganizados em tres colunas nas secoes principais.
- A secao `Ready to Print` passou a usar cards horizontais.

## 5. confirmacao de que Home foi aprovada visualmente

O usuario validou visualmente a Home corrigida.

A Home corrigida esta aprovada e deve ser preservada nas proximas tarefas.

## 6. confirmacao de que Colecoes permaneceu aprovada

Durante a correcao da Home e da fundacao visual, a tela de Colecoes foi tratada como referencia protegida.

O usuario confirmou que a tela de Colecoes permanece aprovada no estado atual.

## 7. limitacoes e diferencas restantes em relacao ao Stitch

As capas internas dos cards da Home usam representacoes visuais em CSS, nao as imagens remotas do HTML exportado pelo Stitch.

Motivo:

- o app nao deve usar imagens remotas como base final;
- os HTMLs e imagens do Stitch sao referencia visual protegida, nao implementacao final;
- nenhum asset exportado do Stitch foi alterado ou copiado para ser usado como codigo final.

A titlebar nativa da janela nao foi recriada dentro da Home em Razor.

Motivo:

- a janela pertence ao shell MAUI/Windows;
- a correcao concentrou-se na interface Blazor interna: sidebar, topbar, conteudo, cards e mosaicos.

## 8. validacoes executadas

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/01-inicio.html` foi usado para corrigir a Home.
- `referencias-visuais/stitch/html/02-colecoes.html` foi usado para validar a preservacao de Colecoes.
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

## 9. estado aprovado

Estao aprovados visualmente pelo usuario:

- Home corrigida;
- tela de Colecoes;
- fundacao visual corrigida.

As proximas tarefas devem preservar esse estado visual aprovado.
