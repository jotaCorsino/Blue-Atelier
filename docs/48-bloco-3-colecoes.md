# bloco 3 - colecoes

## objetivo

Registrar a consolidacao do primeiro recorte funcional do Bloco 3, conectando a tela `/colecoes` aos dados reais do banco local sem redesenhar a interface aprovada.

Este recorte foi revisado e aprovado pelo usuario, mas nao implementa o Bloco 3 inteiro. Ele cria apenas a base de repositorio, servico de aplicacao, inicializacao segura do banco e listagem real de colecoes.

## escopo implementado

Foi implementado:

- repositorio concreto de colecoes;
- servico de aplicacao para listar resumos de colecoes;
- inicializador de banco com migration e seed;
- registro de dependencias no app;
- seed inicial com as colecoes usadas visualmente na tela aprovada;
- conexao da tela `/colecoes` com dados vindos do banco local;
- testes basicos de repositorio, servico e inicializador.

## arquivos criados

Arquivos de aplicacao:

- `src/blueatelier.application/Contratos/IColecaoServico.cs`;
- `src/blueatelier.application/Modelos/ColecaoResumo.cs`;
- `src/blueatelier.application/Servicos/ColecaoServico.cs`.

Arquivos de infraestrutura:

- `src/blueatelier.infrastructure/Repositorios/ColecaoRepositorio.cs`;
- `src/blueatelier.infrastructure/Persistencia/IBlueAtelierBancoInicializador.cs`;
- `src/blueatelier.infrastructure/Persistencia/BlueAtelierBancoInicializador.cs`;
- `src/blueatelier.infrastructure/DependencyInjection.cs`.

Testes:

- `tests/blueatelier.tests/infrastructure/ColecaoPersistenciaTests.cs`.

Documentacao:

- `docs/48-bloco-3-colecoes.md`.

## arquivos alterados

Foram alterados:

- `src/blueatelier.app/MauiProgram.cs`;
- `src/blueatelier.app/Components/Pages/Colecoes.razor`;
- `src/blueatelier.infrastructure/Persistencia/BlueAtelierSeed.cs`;
- `tests/blueatelier.tests/infrastructure/BlueAtelierDbContextTests.cs`;
- `docs/03-estado-atual.md`;
- `docs/04-proximos-documentos.md`.

Nenhum arquivo em `src/blueatelier.app/wwwroot/css` foi alterado.

## repositorio criado

Foi criado `ColecaoRepositorio`, implementando `IColecaoRepositorio`.

O repositorio oferece:

- listar colecoes;
- obter colecao por `Id`;
- obter colecao por `Slug`;
- salvar colecao;
- remover colecao.

Neste recorte a UI usa apenas a listagem, mas os metodos basicos ficam prontos para os proximos recortes do Bloco 3.

## servico criado

Foi criado `ColecaoServico`, expondo:

```txt
ListarResumoAsync
```

O servico retorna `ColecaoResumo`, evitando expor entidades de dominio diretamente para Razor Components.

## inicializador criado

Foi criado `BlueAtelierBancoInicializador`.

Ele executa:

- `Database.MigrateAsync`;
- `BlueAtelierSeed.AplicarAsync`.

O inicializador e registrado via DI e chamado na inicializacao do app.

O caminho atual do banco no app usa:

```txt
FileSystem.AppDataDirectory/blueatelier.db
```

Esse caminho podera ser refinado em etapas futuras de Configuracoes, sem alterar a UI agora.

## seed de colecoes

O seed foi ampliado de forma idempotente para manter a tela `/colecoes` visualmente proxima do estado aprovado.

Colecoes iniciais:

- Eldritch Horrors;
- Sci-Fi Marines;
- Fantasy Adventurers;
- Dragon Busts;
- Tavern Dioramas;
- Ancient Ruins;
- Painting Studies;
- Miniature Bases.

O seed continua sem criar areas removidas do escopo.

## tela /colecoes

A tela `/colecoes` passou a carregar a lista pelo `IColecaoServico`.

Foram preservados:

- classes CSS existentes;
- estrutura dos cards;
- grid;
- filtros visuais;
- ordenacao visual;
- navegacao para detalhe de `Eldritch Horrors` usando slug;
- acoes visuais mockadas.

Os dados de nome, slug, descricao e status arquivado passam a vir do banco. A capa visual usa a classe persistida quando compativel com o CSS aprovado e recai para metadados visuais locais quando necessario.

Metadados puramente visuais, como contagem de modelos, tags, status textual e data relativa, continuam mockados nesta etapa para preservar a aparencia aprovada sem integrar modelos ainda.

## o que continua mockado

Continuam mockados:

- filtros visuais;
- ordenacao visual;
- contagem de modelos por card;
- tags dos cards;
- status visual textual;
- datas relativas exibidas nos cards;
- acoes de editar;
- criacao de colecao;
- importacao de pasta;
- detalhe completo da colecao;
- modelos associados na UI.

## o que ainda nao foi implementado

Ainda nao foi implementado:

- criar colecao pela UI;
- editar colecao pela UI;
- excluir colecao pela UI;
- formulario;
- modal;
- CRUD visual;
- integracao completa do detalhe da colecao;
- integracao real de modelos;
- busca real;
- favoritos reais;
- leitura real de arquivos;
- escrita real de arquivos.

## recorte 2 - detalhe da colecao por slug

O Recorte 2 foi revisado e aprovado pelo usuario.

### objetivo

O Recorte 2 conecta a tela de Detalhe da Colecao aos dados reais da colecao pelo `slug`, preservando o visual aprovado.

Este recorte implementa apenas:

- busca real de colecao por slug;
- modelo de aplicacao para detalhe;
- metodo de detalhe no servico de Colecoes;
- conexao da rota `/colecoes/{slug}` ao servico;
- estado simples para colecao nao encontrada;
- testes de servico para detalhe existente e slug inexistente.

### arquivos criados

Foi criado:

- `src/blueatelier.application/Modelos/ColecaoDetalhe.cs`.

### arquivos alterados

Foram alterados:

- `src/blueatelier.application/Contratos/IColecaoServico.cs`;
- `src/blueatelier.application/Servicos/ColecaoServico.cs`;
- `src/blueatelier.app/Components/Pages/DetalheColecao.razor`;
- `tests/blueatelier.tests/infrastructure/ColecaoPersistenciaTests.cs`;
- `docs/03-estado-atual.md`;
- `docs/04-proximos-documentos.md`;
- `docs/48-bloco-3-colecoes.md`.

Nenhum arquivo em `src/blueatelier.app/wwwroot/css` foi alterado.

### metodo de detalhe por slug

O contrato `IColecaoServico` passou a expor:

```txt
ObterDetalhePorSlugAsync
```

O metodo usa `IColecaoRepositorio.ObterPorSlugAsync`, retorna `ColecaoDetalhe` e nao expoe entidade de dominio diretamente para Razor Components.

### tela de detalhe conectada ao banco

A tela `DetalheColecao.razor` passou a usar:

```txt
@page "/colecoes/{Slug}"
```

A tela carrega a colecao real pelo `IColecaoServico` e substitui dados basicos por dados persistidos:

- nome;
- slug;
- descricao;
- status arquivado quando aplicavel;
- data de atualizacao como parte do meta visual.

Foram preservados:

- markup principal;
- classes CSS existentes;
- cabecalho visual;
- hero;
- grid de modelos;
- cards;
- aside de links/referencias/notas;
- botoes visuais;
- navegacao de retorno para `/colecoes`.

### estado de colecao nao encontrada

Quando o slug nao existe no banco local, a tela exibe um `AppStateBlock` simples com mensagem curta e caminho de retorno visual para Colecoes.

Nenhuma rota nova foi criada.

### o que continua mockado no detalhe

Continuam mockados:

- modelos internos da colecao;
- contagem real de modelos;
- links laterais;
- galeria/referencias laterais;
- notas;
- botoes de editar colecao, abrir pasta e novo modelo;
- tags visuais;
- arquivos ou caminhos reais.

### confirmacoes do recorte 2

Confirmado:

- modelos da colecao ainda nao foram integrados ao banco;
- nao houve CRUD visual;
- nao houve formulario;
- nao houve modal;
- nao houve edicao real pela UI;
- nao houve exclusao real pela UI;
- nao houve alteracao de CSS visual;
- nenhuma area removida foi reintroduzida.

### testes adicionados

Foram adicionados testes para:

- `ColecaoServico.ObterDetalhePorSlugAsync` retornar `ColecaoDetalhe`;
- `ColecaoServico.ObterDetalhePorSlugAsync` retornar `null` para slug inexistente;
- busca por slug usando dados persistidos.

## recorte 3 - modelos reais no detalhe da colecao

O Recorte 3 conecta a lista interna de modelos do Detalhe da Colecao aos dados reais do banco local, preservando o visual aprovado.

### objetivo

Este recorte implementa apenas:

- repositorio concreto de modelos;
- servico de aplicacao para listar modelos por colecao;
- modelo de aplicacao para resumo de modelo no card da colecao;
- seed idempotente com modelos iniciais de `Eldritch Horrors`;
- conexao dos cards de modelos em `DetalheColecao.razor` ao banco local;
- contagem real de modelos no meta visual da colecao;
- testes de repositorio, servico e seed.

### arquivos criados

Foram criados:

- `src/blueatelier.application/Contratos/IModeloServico.cs`;
- `src/blueatelier.application/Modelos/ModeloResumoColecao.cs`;
- `src/blueatelier.application/Servicos/ModeloServico.cs`;
- `src/blueatelier.infrastructure/Repositorios/ModeloRepositorio.cs`;
- `tests/blueatelier.tests/infrastructure/ModeloPersistenciaTests.cs`.

### arquivos alterados

Foram alterados:

- `src/blueatelier.app/MauiProgram.cs`;
- `src/blueatelier.app/Components/Pages/DetalheColecao.razor`;
- `src/blueatelier.infrastructure/DependencyInjection.cs`;
- `src/blueatelier.infrastructure/Persistencia/BlueAtelierSeed.cs`;
- `docs/03-estado-atual.md`;
- `docs/04-proximos-documentos.md`;
- `docs/48-bloco-3-colecoes.md`.

Nenhum arquivo em `src/blueatelier.app/wwwroot/css` foi alterado.

### repositorio de modelos

Foi criado `ModeloRepositorio`, implementando `IModeloRepositorio`.

O repositorio oferece:

- listar modelos;
- listar modelos por colecao;
- obter modelo por `Id`;
- salvar modelo;
- remover modelo.

Neste recorte, a UI usa apenas a listagem por colecao.

### servico de modelos

Foi criado `ModeloServico`, expondo:

```txt
ListarPorColecaoAsync
```

O servico retorna `ModeloResumoColecao`, evitando expor entidades de dominio diretamente para Razor Components.

### seed de modelos

O seed foi ampliado de forma idempotente para criar, dentro da colecao `Eldritch Horrors`, os modelos:

- Cthulhu Idol;
- Deep One Bust;
- Tentacle Beast;
- Ancient Cultist;
- Forgotten Horror;
- Abyssal Statue.

Cada modelo possui dados simples de etapa, progresso, tipo de arquivo, escala, tempo estimado, material sugerido e descricao curta.

O seed nao cria areas removidas do escopo e nao duplica modelos ao ser executado mais de uma vez.

### detalhe da colecao com modelos reais

A tela `DetalheColecao.razor` continua carregando a colecao real por `slug` e agora carrega os modelos reais pelo `IModeloServico`.

Foram preservados:

- markup principal dos cards;
- classes CSS existentes;
- grid visual de modelos;
- capas e tons visuais por metadados locais;
- navegacao do `Cthulhu Idol` para `/colecoes/eldritch-horrors/modelos/cthulhu-idol`;
- links laterais;
- referencias;
- notas;
- botoes visuais.

Os dados reais usados nos cards sao:

- nome;
- etapa atual;
- progresso percentual;
- status textual derivado da etapa/progresso.

A contagem exibida no meta visual da colecao passou a usar a quantidade real de modelos carregados para a colecao.

### o que continua mockado no recorte 3

Continuam mockados:

- links laterais;
- referencias/galeria lateral;
- notas;
- botoes de editar colecao, abrir pasta e novo modelo;
- capas e tons visuais dos cards;
- detalhes reais de outros modelos alem da rota aprovada do `Cthulhu Idol`;
- galeria real;
- arquivos vinculados reais;
- referencias reais;
- leitura de arquivos ou caminhos reais.

### confirmacoes do recorte 3

Confirmado:

- nao houve CRUD visual;
- nao houve formulario;
- nao houve modal;
- nao houve criacao real pela UI;
- nao houve edicao real pela UI;
- nao houve exclusao real pela UI;
- nao houve alteracao de CSS visual;
- links, referencias e notas ainda nao foram integrados;
- nenhuma area removida foi reintroduzida.

### testes adicionados no recorte 3

Foram adicionados testes para:

- `ModeloRepositorio.ListarPorColecaoAsync` retornar apenas modelos da colecao correta;
- `ModeloServico.ListarPorColecaoAsync` retornar `ModeloResumoColecao`;
- seed criar os modelos de `Eldritch Horrors` sem duplicar;
- listagem de modelos nao misturar modelos de outra colecao.

## preservacao visual

Confirmado neste recorte:

- nenhum CSS visual foi alterado;
- nenhuma tela fora de `/colecoes` foi alterada;
- sidebar e topbar foram preservadas;
- as rotas existentes foram preservadas;
- a tela `/colecoes` manteve o layout e as classes aprovadas;
- os mocks das demais telas continuam intactos.

## areas removidas fora do escopo

Continuam inexistentes:

- `/fila-impressao`;
- `/arquivos-recentes`;
- `/materiais`;
- `/materiais/resin-grey`;
- `FilaImpressao.razor`;
- `ArquivosRecentes.razor`;
- `Materiais.razor`;
- `DetalheMaterial.razor`.

## testes criados

Foram adicionados testes para:

- `ColecaoRepositorio` listar colecoes;
- `ColecaoRepositorio` obter colecao por slug;
- `ColecaoServico` retornar `ColecaoResumo`;
- `BlueAtelierBancoInicializador` aplicar migration e seed sem duplicar dados.

## validacoes executadas

Executadas nesta etapa:

```txt
dotnet restore BlueAtelier.sln
dotnet build BlueAtelier.sln
dotnet test BlueAtelier.sln --no-build
```

Resultado observado:

- restore concluido com sucesso;
- build concluido com sucesso;
- testes concluidos com sucesso.

## proxima etapa sugerida

Apos revisao do Recorte 3, a proxima etapa sugerida e continuar o Bloco 3 com um recorte pequeno para planejar criacao/edicao de colecoes ou iniciar a integracao funcional de modelos, sempre preservando o visual aprovado e sem implementar CRUD visual amplo de uma vez.
