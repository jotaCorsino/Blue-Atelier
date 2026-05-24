# bloco 5 - arquivos vinculados

## objetivo

Registrar a consolidacao progressiva do Bloco 5 da fase funcional do Blue Atelier, conectando metadados de arquivos vinculados ao banco local sem manipular arquivos reais.

Este recorte preserva o visual aprovado e atua apenas sobre dados persistidos no SQLite.

## recorte 1 implementado

O Recorte 1 implementa:

- repositorio concreto de arquivos vinculados;
- servico de aplicacao para listar arquivos por modelo;
- modelo de aplicacao para a secao `Linked Files`;
- seed idempotente com metadados de arquivos do `Cthulhu Idol`;
- conexao da secao `Linked Files` do Detalhe do Modelo com dados reais do banco local;
- estado vazio simples quando o modelo nao possui arquivos vinculados;
- testes de repositorio, servico e seed.

## recorte 2 implementado

O Recorte 2 implementa:

- listagem real de arquivos vinculados na tela `/arquivos`;
- metodo de servico para listar todos os arquivos vinculados;
- reutilizacao do modelo de aplicacao `ArquivoVinculadoResumo`;
- uso dos metadados persistidos pelo seed do `Cthulhu Idol`;
- estado vazio simples quando nao existem arquivos vinculados;
- testes de repositorio, servico, seed e listagem geral.

## arquivos criados

Foram criados:

- `src/blueatelier.infrastructure/Repositorios/ArquivoVinculadoRepositorio.cs`;
- `src/blueatelier.application/Contratos/IArquivoVinculadoServico.cs`;
- `src/blueatelier.application/Modelos/ArquivoVinculadoResumo.cs`;
- `src/blueatelier.application/Servicos/ArquivoVinculadoServico.cs`;
- `tests/blueatelier.tests/infrastructure/ArquivoVinculadoPersistenciaTests.cs`;
- `docs/50-bloco-5-arquivos-vinculados.md`.

## arquivos alterados

Foram alterados:

- `src/blueatelier.application/Contratos/IArquivoVinculadoServico.cs`;
- `src/blueatelier.application/Servicos/ArquivoVinculadoServico.cs`;
- `src/blueatelier.infrastructure/DependencyInjection.cs`;
- `src/blueatelier.infrastructure/Persistencia/BlueAtelierSeed.cs`;
- `src/blueatelier.app/MauiProgram.cs`;
- `src/blueatelier.app/Components/Pages/DetalheModelo.razor`;
- `src/blueatelier.app/Components/Pages/ArquivosVinculados.razor`;
- `tests/blueatelier.tests/infrastructure/ArquivoVinculadoPersistenciaTests.cs`;
- `docs/03-estado-atual.md`;
- `docs/04-proximos-documentos.md`.

Nenhum arquivo em `src/blueatelier.app/wwwroot/css` foi alterado.

## repositorio criado

Foi criado `ArquivoVinculadoRepositorio`, implementando `IArquivoVinculadoRepositorio`.

O repositorio oferece:

- listar arquivos vinculados;
- listar arquivos por modelo;
- obter por `Id`;
- salvar;
- remover.

As consultas usam `AsNoTracking`, filtram por `ModeloId` quando necessario e ordenam de forma estavel por tipo e nome.

O repositorio nao le, valida, abre, copia, move ou apaga arquivos reais.

## servico criado

Foi criado `ArquivoVinculadoServico`, expondo:

```txt
ListarResumoAsync
ListarPorModeloAsync
```

O servico usa `IArquivoVinculadoRepositorio` e retorna `ArquivoVinculadoResumo`, sem expor entidades de dominio diretamente para Razor Components.

O servico nao verifica existencia de caminhos no disco, nao abre arquivos e nao normaliza caminhos acessando o sistema de arquivos.

## modelo de aplicacao criado

Foi criado `ArquivoVinculadoResumo`, contendo:

- `Id`;
- `ModeloId`;
- `Nome`;
- `CaminhoLocal`;
- `Tipo`;
- `Extensao`;
- `TamanhoBytes`;
- `CriadoEm`;
- `AtualizadoEm`.

Como a entidade de dominio atual possui apenas `CriadoEm`, o resumo usa esse valor tambem como `AtualizadoEm` neste recorte.

## seed de arquivos vinculados

O seed foi ampliado de forma idempotente para criar metadados dos arquivos vinculados ao modelo `Cthulhu Idol`:

- `cthulhu-idol.stl`;
- `cthulhu-idol-supported.lys`;
- `cthulhu-idol-ready.ctb`;
- `painting-notes.md`.

Os caminhos locais sao ficticios e armazenados apenas como texto, por exemplo:

```txt
C:/BlueAtelier/EldritchHorrors/CthulhuIdol/cthulhu-idol.stl
```

O seed nao verifica se esses caminhos existem e nao duplica os registros quando executado mais de uma vez.

## Detalhe do Modelo com Linked Files reais

A tela `DetalheModelo.razor` continua carregando `ModeloDetalhe` pelo `IModeloServico`.

Apos carregar o modelo, a tela chama `IArquivoVinculadoServico.ListarPorModeloAsync` e substitui a lista mockada da secao `Linked Files` por metadados persistidos no banco local.

Foram preservados:

- markup principal da secao;
- classes CSS existentes;
- link visual `Ver arquivos`;
- layout do Detalhe do Modelo;
- cards e secoes laterais;
- botoes visuais.

Se o modelo nao possuir arquivos vinculados, a secao exibe um `AppStateBlock` compacto.

## tela /arquivos com metadados reais

A tela `ArquivosVinculados.razor` passou a aceitar a rota geral `/arquivos` e continua preservando a rota aprovada do modelo:

```txt
/colecoes/eldritch-horrors/modelos/cthulhu-idol/arquivos
```

A tela chama `IArquivoVinculadoServico.ListarResumoAsync` e substitui a lista mockada por metadados persistidos no banco local.

Foram preservados:

- markup principal da tela;
- classes CSS existentes;
- cards/listas/tabelas existentes;
- filtros visuais;
- acoes e botoes como mockados;
- painel lateral;
- visual aprovado.

A tela usa dados reais para:

- nome;
- extensao;
- tipo/categoria visual;
- caminho local como texto;
- tamanho, quando disponivel.

Se nao houver arquivos vinculados, a tela exibe um `AppStateBlock` compacto.

## o que continua mockado

Continuam mockados:

- galeria;
- imagens;
- links;
- referencias;
- notas editaveis;
- favoritos;
- acoes de edicao;
- botoes de abrir pasta, importar ou exportar;
- leitura, abertura ou validacao de caminhos reais.

## o que nao foi implementado

Nao foi implementado:

- upload/importacao real de arquivos;
- seletor de arquivos do sistema;
- leitura real de diretorios;
- validacao real de existencia do caminho;
- abertura de arquivo ou pasta pelo sistema operacional;
- copia de arquivo;
- movimentacao de arquivo;
- exclusao de arquivo real;
- CRUD visual;
- formulario;
- modal;
- criacao, edicao ou exclusao real pela UI;
- busca real;
- favoritos reais;
- backup real.

## preservacao visual

Confirmado neste recorte:

- nenhum CSS visual foi alterado;
- nenhuma tela fora de Detalhe do Modelo e Arquivos Vinculados foi alterada neste bloco;
- a tela `/arquivos` foi conectada ao banco sem redesenho;
- sidebar e topbar nao foram alteradas;
- referencias Stitch nao foram alteradas;
- nenhuma area removida foi reintroduzida;
- nao houve CRUD visual.

## testes criados

Foram adicionados testes para:

- `ArquivoVinculadoRepositorio.ListarPorModeloAsync` retornar arquivos do modelo correto;
- `ArquivoVinculadoRepositorio.ListarPorModeloAsync` nao misturar arquivos de outro modelo;
- `ArquivoVinculadoRepositorio.ListarAsync` retornar arquivos persistidos;
- `ArquivoVinculadoServico.ListarPorModeloAsync` retornar `ArquivoVinculadoResumo`;
- `ArquivoVinculadoServico.ListarResumoAsync` retornar `ArquivoVinculadoResumo`;
- seed criar arquivos vinculados para `Cthulhu Idol` sem duplicar;
- listagem geral incluir arquivos do seed para `Cthulhu Idol`;
- servico nao expor entidade de dominio para UI;
- listagem geral trabalhar apenas com metadados, mesmo quando o caminho informado nao existe.

## validacoes executadas

Este recorte foi validado com:

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

Apos revisao do Recorte 2 do Bloco 5, a proxima etapa sugerida e continuar Arquivos Vinculados de forma progressiva, ainda sem manipular arquivos reais. Abertura nativa, validacao de caminho, importacao e CRUD visual devem permanecer para recortes especificos e aprovados separadamente.
