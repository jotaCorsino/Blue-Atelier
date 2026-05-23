# bloco 4 - modelos

## objetivo

Registrar a consolidacao do inicio do Bloco 4 da fase funcional do Blue Atelier, conectando a tela geral `/modelos` aos modelos reais do banco local sem alterar o visual aprovado.

Este recorte nao implementa o Bloco 4 inteiro. Ele apenas substitui a lista mockada da tela geral de modelos por dados persistidos e mantem CRUD visual, detalhe real do modelo, galeria real e arquivos vinculados reais fora do escopo.

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

## proxima etapa sugerida

Apos revisao do Recorte 1 do Bloco 4, a proxima etapa sugerida e conectar o Detalhe do Modelo aos dados reais do banco local, preservando integralmente o visual aprovado e mantendo galeria, arquivos vinculados, links e favoritos fora do escopo ate recortes especificos.
