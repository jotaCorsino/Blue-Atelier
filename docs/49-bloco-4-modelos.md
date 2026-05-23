# bloco 4 - modelos

## objetivo

Registrar a consolidacao do inicio do Bloco 4 da fase funcional do Blue Atelier, conectando a tela geral `/modelos` e, no recorte seguinte, o Detalhe do Modelo aos modelos reais do banco local sem alterar o visual aprovado.

O Bloco 4 ainda nao implementa o recorte inteiro de Modelos. Os recortes atuais substituem a lista mockada da tela geral de modelos e os dados basicos do Detalhe do Modelo por dados persistidos, mantendo CRUD visual, galeria real, arquivos vinculados reais, links reais, referencias reais e favoritos reais fora do escopo.

## recorte implementado

O Recorte 1 foi revisado e aprovado pelo usuario. Ele implementa:

- listagem real de modelos na rota `/modelos`;
- metodo de servico para listar resumos gerais de modelos;
- modelo de aplicacao para card da tela geral de modelos;
- uso dos modelos ja persistidos pelo seed de `Eldritch Horrors`;
- estado vazio simples caso nao existam modelos;
- testes de repositorio e servico;
- documentacao do recorte.

## arquivos criados

Foi criado:

- `src/blueatelier.application/Modelos/ModeloResumo.cs`.

Documentacao:

- `docs/49-bloco-4-modelos.md`.

## arquivos alterados

Foram alterados:

- `src/blueatelier.application/Contratos/IModeloServico.cs`;
- `src/blueatelier.application/Servicos/ModeloServico.cs`;
- `src/blueatelier.app/Components/Pages/Modelos.razor`;
- `tests/blueatelier.tests/infrastructure/ModeloPersistenciaTests.cs`;
- `docs/03-estado-atual.md`;
- `docs/04-proximos-documentos.md`.

Nenhum arquivo em `src/blueatelier.app/wwwroot/css` foi alterado.

## metodo criado no servico

O contrato `IModeloServico` passou a expor:

```txt
ListarResumoAsync
```

Esse metodo usa `IModeloRepositorio.ListarAsync` para obter os modelos e `IColecaoRepositorio.ListarAsync` para resolver nome e slug da colecao de cada modelo.

## modelo de aplicacao criado

Foi criado `ModeloResumo`, contendo os dados necessarios para a tela geral `/modelos`:

- `Id`;
- `ColecaoId`;
- `ColecaoNome`;
- `ColecaoSlug`;
- `Nome`;
- `Slug`;
- `Descricao`;
- `EtapaAtual`;
- `ProgressoPercentual`;
- `TipoArquivo`;
- `Escala`;
- `TempoEstimado`;
- `MaterialSugerido`;
- `AtualizadoEm`.

O Razor Component nao recebe entidades de dominio diretamente.

## tela /modelos com dados reais

A tela `Modelos.razor` passou a carregar dados pelo `IModeloServico`.

Foram preservados:

- layout principal;
- grid;
- cards;
- classes CSS;
- filtros visuais;
- botoes visuais;
- navegacao do `Cthulhu Idol` para `/colecoes/eldritch-horrors/modelos/cthulhu-idol`.

Os dados reais usados nos cards sao:

- nome;
- colecao;
- etapa/status derivado da etapa atual;
- progresso percentual;
- material/escala quando disponiveis.

Capas e tons visuais continuam definidos por metadados locais para preservar o visual aprovado sem alterar CSS.

## o que continua mockado

Continuam mockados:

- filtros visuais;
- ordenacao visual;
- botoes `Novo modelo`, `Importar modelo` e `Organizar modelos`;
- capas e tons visuais dos cards;
- detalhes reais de outros modelos alem da rota aprovada do `Cthulhu Idol`;
- galeria real;
- arquivos vinculados reais;
- links reais;
- referencias reais;
- notas reais;
- favoritos reais;
- busca real.

## o que ainda nao foi implementado

Ainda nao foi implementado:

- criar modelo pela UI;
- editar modelo pela UI;
- excluir modelo pela UI;
- formulario;
- modal;
- CRUD visual;
- detalhe real do modelo;
- galeria real;
- arquivos vinculados reais;
- leitura real de arquivos;
- escrita real de arquivos;
- backup real.

## testes adicionados

Foram adicionados ou atualizados testes para:

- `ModeloRepositorio.ListarAsync` retornar modelos persistidos;
- `ModeloServico.ListarResumoAsync` retornar `ModeloResumo`;
- listagem geral incluir os modelos criados pelo seed;
- listagem por colecao continuar sem misturar modelos de outra colecao.

## preservacao visual

Confirmado neste recorte:

- nenhum CSS visual foi alterado;
- nenhuma tela fora de `/modelos` foi alterada;
- sidebar e topbar nao foram alteradas;
- nenhuma rota nova foi criada;
- nenhuma area removida foi reintroduzida;
- nao houve redesenho da tela `/modelos`;
- nao houve CRUD visual.

## recorte 2 - detalhe do modelo com dados reais

O Recorte 2 conecta a tela Detalhe do Modelo aos dados reais do banco local por slug de colecao e slug de modelo, preservando integralmente o visual aprovado.

### objetivo

O objetivo foi substituir apenas os dados fixos principais do modelo por dados vindos do servico de aplicacao:

- nome;
- colecao;
- descricao;
- etapa/status;
- progresso;
- tipo de arquivo;
- escala;
- tempo estimado;
- material sugerido;
- observacoes disponiveis no modelo de aplicacao.

### arquivos criados

Foi criado:

- `src/blueatelier.application/Modelos/ModeloDetalhe.cs`.

### arquivos alterados

Foram alterados:

- `src/blueatelier.domain/Contratos/IModeloRepositorio.cs`;
- `src/blueatelier.infrastructure/Repositorios/ModeloRepositorio.cs`;
- `src/blueatelier.application/Contratos/IModeloServico.cs`;
- `src/blueatelier.application/Servicos/ModeloServico.cs`;
- `src/blueatelier.app/Components/Pages/DetalheModelo.razor`;
- `tests/blueatelier.tests/infrastructure/ModeloPersistenciaTests.cs`;
- `docs/03-estado-atual.md`;
- `docs/04-proximos-documentos.md`;
- `docs/49-bloco-4-modelos.md`.

Nenhum arquivo em `src/blueatelier.app/wwwroot/css` foi alterado.

### metodo criado no repositorio

O contrato `IModeloRepositorio` e a implementacao `ModeloRepositorio` passaram a expor:

```txt
ObterPorColecaoESlugAsync
```

Esse metodo filtra por `ColecaoId` e `Slug`, usa consulta `AsNoTracking` e retorna `null` quando o modelo nao existe para a colecao informada.

### metodo criado no servico

O contrato `IModeloServico` e a implementacao `ModeloServico` passaram a expor:

```txt
ObterDetalhePorSlugAsync
```

Esse metodo busca a colecao por slug, retorna `null` se ela nao existir, busca o modelo por `ColecaoId` e slug do modelo e retorna `ModeloDetalhe`, sem expor entidade de dominio diretamente para Razor.

### modelo de aplicacao criado

Foi criado `ModeloDetalhe`, contendo os dados necessarios para a tela Detalhe do Modelo:

- `Id`;
- `ColecaoId`;
- `ColecaoNome`;
- `ColecaoSlug`;
- `Nome`;
- `Slug`;
- `Descricao`;
- `EtapaAtual`;
- `ProgressoPercentual`;
- `TipoArquivo`;
- `Escala`;
- `TempoEstimado`;
- `MaterialSugerido`;
- `Observacoes`;
- `CriadoEm`;
- `AtualizadoEm`.

### tela Detalhe do Modelo com dados reais

A tela `DetalheModelo.razor` passou a usar rota parametrizada:

```txt
/colecoes/{ColecaoSlug}/modelos/{ModeloSlug}
```

A rota aprovada continua funcionando:

```txt
/colecoes/eldritch-horrors/modelos/cthulhu-idol
```

A tela carrega `ModeloDetalhe` pelo `IModeloServico` e substitui os dados fixos principais por dados reais do banco local. O markup e as classes CSS foram preservados o maximo possivel.

Quando o modelo nao e encontrado, a tela usa `AppStateBlock` com uma mensagem curta e mantem um link visual de retorno para `/modelos`.

### o que continua mockado

Continuam mockados:

- galeria;
- imagens;
- arquivos vinculados;
- links;
- referencias;
- notas editaveis;
- favoritos;
- acoes de edicao;
- botoes de abrir pasta, importar ou exportar;
- qualquer leitura real de arquivo.

### testes adicionados

Foram adicionados ou atualizados testes para:

- `ModeloRepositorio.ObterPorColecaoESlugAsync` retornar o modelo correto;
- `ModeloRepositorio.ObterPorColecaoESlugAsync` nao retornar modelo de outra colecao;
- `ModeloServico.ObterDetalhePorSlugAsync` retornar `ModeloDetalhe`;
- `ModeloServico.ObterDetalhePorSlugAsync` retornar `null` para colecao inexistente;
- `ModeloServico.ObterDetalhePorSlugAsync` retornar `null` para modelo inexistente;
- `ModeloDetalhe` ser modelo de aplicacao, sem expor entidade de dominio para a UI.

### preservacao visual do recorte 2

Confirmado neste recorte:

- nenhum CSS visual foi alterado;
- nenhuma tela fora de Detalhe do Modelo foi alterada visualmente;
- sidebar e topbar nao foram alteradas;
- nenhuma rota removida foi recriada;
- nenhuma area removida foi reintroduzida;
- nao houve CRUD visual;
- nao houve formulario ou modal;
- nao houve galeria real ou arquivos vinculados reais.

## proxima etapa sugerida

Apos revisao do Recorte 2 do Bloco 4, a proxima etapa sugerida e continuar Modelos de forma progressiva, sem redesenhar a interface e sem implementar CRUD visual amplo. Galeria real, arquivos vinculados reais, links reais e referencias reais devem permanecer para recortes especificos.
