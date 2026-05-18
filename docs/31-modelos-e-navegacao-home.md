# blue atelier - modelos e navegacao da Home

## motivo da correcao

Durante a revisao visual da etapa da Fila de Impressao, o usuario identificou dois pontos de navegacao:

- na Home, os cards de colecao exibidos visualmente ainda nao abriam a colecao;
- o item Models/Modelos da sidebar ainda nao parecia ativo porque a rota `/modelos` nao existia.

A correcao ativou esses fluxos visuais sem implementar funcionalidade real, banco ou persistencia.

## correcao da navegacao das colecoes na Home

Os cards de colecoes na Home passaram a ter navegacao visual.

O card principal/mockado da colecao Eldritch Horrors navega para:

```txt
/colecoes/eldritch-horrors
```

O card inteiro segue o padrao de area clicavel ja aprovado no app, preservando o visual e o hover existentes.

## criacao e ativacao da rota /modelos

Foi criada a rota:

```txt
/modelos
```

A rota apresenta uma tela visual mockada de Modelos, preparada para futuramente listar modelos cadastrados por colecao, status e etapa de producao.

## estrutura visual da tela Modelos

A tela Modelos contem:

- cabecalho com titulo e descricao curta;
- acoes visuais para novo modelo, importar modelo e organizar modelos;
- filtros visuais/provisorios;
- grid/lista de cards de modelos;
- capas/mock visuals em CSS;
- nome do modelo;
- colecao relacionada;
- status ou etapa;
- progresso visual;
- informacao curta de material ou arquivo;
- affordance visual para abrir o item.

## dados mockados usados

Modelos de exemplo:

- Cthulhu Idol;
- Deep One Bust;
- Tentacle Beast;
- Ancient Cultist;
- Abyssal Statue;
- Dragon Bust;
- Dungeon Tiles;
- Tavern Props.

Os dados sao apenas visuais e nao representam persistencia real.

## navegacao do card Cthulhu Idol

O card Cthulhu Idol na tela Modelos navega para:

```txt
/colecoes/eldritch-horrors/modelos/cthulhu-idol
```

Essa navegacao reutiliza a tela Detalhe do Modelo ja aprovada.

## ajuste da sidebar para Models

O item Models/Modelos da sidebar foi habilitado para navegar para:

```txt
/modelos
```

A sidebar marca Models como ativo em:

- `/modelos`;
- `/colecoes/eldritch-horrors/modelos/cthulhu-idol`;
- `/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria`;
- `/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria/main-reference`;
- `/colecoes/eldritch-horrors/modelos/cthulhu-idol/arquivos`.

## o que ainda e provisorio

- dados exibidos na tela Modelos;
- filtros;
- acoes;
- progresso;
- status;
- materiais;
- capas mockadas;
- navegacao para modelos alem do Cthulhu Idol.

## o que ainda nao foi implementado

- cadastro real de modelos;
- listagem real;
- busca real;
- filtros reais;
- persistencia;
- banco SQLite;
- EF Core;
- migrations;
- servicos reais;
- sistema de arquivos real;
- edicao real;
- importacao real de modelo.

## validacoes executadas

- Home permaneceu visualmente preservada.
- Colecoes permaneceu preservada.
- Detalhe da Colecao permaneceu preservado.
- Detalhe do Modelo permaneceu preservado.
- Galeria do Modelo permaneceu preservada.
- Visualizacao de Imagem permaneceu preservada.
- Arquivos Vinculados permaneceu preservado.
- Fila de Impressao permaneceu preservada.
- Na Home, clicar em uma colecao abre a tela da colecao.
- O card Eldritch Horrors navega para `/colecoes/eldritch-horrors`.
- A pagina `/modelos` existe e abre corretamente.
- O item Models da sidebar navega para `/modelos`.
- O item Models fica ativo na pagina `/modelos` e nas rotas de modelos.
- O card Cthulhu Idol em `/modelos` navega para `/colecoes/eldritch-horrors/modelos/cthulhu-idol`.
- Nenhuma tela aprovada foi redesenhada.
- Nenhum arquivo do Stitch foi alterado.
- Nenhuma funcionalidade real foi implementada.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## confirmacao de aprovacao visual manual

A correcao da navegacao da Home, a ativacao da tela Modelos e o ajuste da sidebar foram validados visualmente pelo usuario e aprovados no estado atual.
