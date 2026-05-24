# bloco 6 - galeria

## objetivo

Registrar os recortes iniciais do Bloco 6 da fase funcional do Blue Atelier, conectando a Galeria do Modelo e a Visualizacao de Imagem a metadados reais de imagens no banco local.

Estes recortes trabalham apenas com dados persistidos no SQLite e nao manipulam imagens reais do sistema de arquivos.

## recorte 1 implementado

O Recorte 1 implementa:

- repositorio concreto de imagens do modelo;
- servico de aplicacao para listar imagens por modelo;
- modelo de aplicacao para a galeria;
- seed idempotente com metadados de imagens do `Cthulhu Idol`;
- conexao da Galeria do Modelo com dados reais do banco local;
- estado vazio simples quando o modelo nao possui imagens;
- testes de repositorio, servico e seed.

## recorte 2 implementado

O Recorte 2 implementa:

- busca real de imagem da galeria por slug de colecao, slug de modelo e identificador visual;
- metodo de repositorio para obter a imagem principal de um modelo;
- metodo de servico para obter detalhe de imagem;
- modelo de aplicacao para detalhe da imagem;
- conexao da tela de Visualizacao de Imagem com metadados reais do banco local;
- estado simples quando a imagem nao e encontrada;
- testes de repositorio e servico para detalhe da imagem.

## arquivos criados

Foram criados:

- `src/blueatelier.infrastructure/Repositorios/ImagemModeloRepositorio.cs`;
- `src/blueatelier.application/Contratos/IImagemModeloServico.cs`;
- `src/blueatelier.application/Modelos/ImagemModeloResumo.cs`;
- `src/blueatelier.application/Modelos/ImagemModeloDetalhe.cs`;
- `src/blueatelier.application/Servicos/ImagemModeloServico.cs`;
- `tests/blueatelier.tests/infrastructure/ImagemModeloPersistenciaTests.cs`;
- `docs/51-bloco-6-galeria.md`.

## arquivos alterados

Foram alterados:

- `src/blueatelier.infrastructure/DependencyInjection.cs`;
- `src/blueatelier.infrastructure/Persistencia/BlueAtelierSeed.cs`;
- `src/blueatelier.app/MauiProgram.cs`;
- `src/blueatelier.app/Components/Pages/GaleriaModelo.razor`;
- `src/blueatelier.app/Components/Pages/VisualizacaoImagem.razor`;
- `src/blueatelier.domain/Contratos/IImagemModeloRepositorio.cs`;
- `src/blueatelier.infrastructure/Repositorios/ImagemModeloRepositorio.cs`;
- `src/blueatelier.application/Contratos/IImagemModeloServico.cs`;
- `src/blueatelier.application/Servicos/ImagemModeloServico.cs`;
- `tests/blueatelier.tests/infrastructure/ImagemModeloPersistenciaTests.cs`;
- `docs/03-estado-atual.md`;
- `docs/04-proximos-documentos.md`.

Nenhum arquivo em `src/blueatelier.app/wwwroot/css` foi alterado.

## repositorio criado

Foi criado `ImagemModeloRepositorio`, implementando `IImagemModeloRepositorio`.

O repositorio oferece:

- listar imagens;
- listar imagens por modelo;
- obter a imagem principal por modelo;
- obter por `Id`;
- salvar;
- remover.

As consultas usam `AsNoTracking`, filtram por `ModeloId` quando necessario e ordenam de forma estavel por imagem principal, ordem e titulo.

O repositorio nao le, valida, abre, copia, move ou apaga imagens reais.

## servico criado

Foi criado `ImagemModeloServico`, expondo:

```txt
ListarPorModeloAsync
ObterDetalheAsync
```

O servico usa `IImagemModeloRepositorio` e retorna `ImagemModeloResumo` ou `ImagemModeloDetalhe`, sem expor entidades de dominio diretamente para Razor Components.

Para detalhe de imagem, o servico usa o slug da colecao e do modelo para resolver o `ModeloDetalhe` e, quando o identificador visual e `main-reference`, busca a imagem marcada como principal (`EhPrincipal = true`) para aquele modelo.

O servico nao verifica existencia de caminhos no disco, nao abre imagens, nao gera miniaturas e nao manipula o sistema de arquivos.

## modelo de aplicacao criado

Foi criado `ImagemModeloResumo`, contendo:

- `Id`;
- `ModeloId`;
- `Titulo`;
- `CaminhoLocal`;
- `Tipo`;
- `Ordem`;
- `EhPrincipal`;
- `Observacao`;
- `CriadoEm`.

Foi criado tambem `ImagemModeloDetalhe`, contendo:

- `Id`;
- `ModeloId`;
- `ModeloNome`;
- `ModeloSlug`;
- `ColecaoNome`;
- `ColecaoSlug`;
- `Titulo`;
- `CaminhoLocal`;
- `Tipo`;
- `Ordem`;
- `EhPrincipal`;
- `Observacao`;
- `CriadoEm`.

## seed de imagens

O seed foi ampliado de forma idempotente para criar metadados das imagens vinculadas ao modelo `Cthulhu Idol`:

- `cthulhu-idol-front.jpg`;
- `cthulhu-idol-side.jpg`;
- `cthulhu-idol-primer.jpg`;
- `cthulhu-idol-painting-progress.jpg`;
- `cthulhu-idol-final.jpg`.

Os caminhos locais sao ficticios e armazenados apenas como texto, por exemplo:

```txt
C:/BlueAtelier/EldritchHorrors/CthulhuIdol/gallery/cthulhu-idol-front.jpg
```

O seed nao verifica se esses caminhos existem e nao duplica os registros quando executado mais de uma vez.

## Galeria do Modelo conectada ao banco

A tela `GaleriaModelo.razor` passou a usar a rota parametrizada:

```txt
/colecoes/{ColecaoSlug}/modelos/{ModeloSlug}/galeria
```

A rota aprovada continua funcionando:

```txt
/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria
```

A tela carrega `ModeloDetalhe` pelo `IModeloServico` e, depois disso, chama `IImagemModeloServico.ListarPorModeloAsync` para substituir a lista mockada por metadados persistidos no banco local.

Foram preservados:

- markup principal;
- classes CSS existentes;
- grid/mosaico da galeria;
- cards e placeholders visuais;
- filtros visuais;
- botoes visuais;
- link visual da imagem principal para a visualizacao ja existente.

Os dados reais usados nos cards sao:

- titulo;
- tipo/categoria;
- observacao ou caminho local como texto quando necessario;
- flag de imagem principal.

Se o modelo nao possuir imagens, a tela exibe um `AppStateBlock` compacto.

## Visualizacao de Imagem conectada ao banco

A tela `VisualizacaoImagem.razor` passou a usar a rota parametrizada:

```txt
/colecoes/{ColecaoSlug}/modelos/{ModeloSlug}/galeria/{ImagemSlug}
```

A rota aprovada continua funcionando:

```txt
/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria/main-reference
```

A tela chama `IImagemModeloServico.ObterDetalheAsync` e substitui dados fixos por metadados persistidos no banco local.

Foram preservados:

- markup principal;
- classes CSS existentes;
- area principal da imagem;
- placeholder visual da imagem;
- painel lateral de informacoes;
- botoes visuais;
- navegacao visual anterior/proxima.

Os dados reais usados na tela sao:

- titulo;
- modelo;
- colecao;
- tipo/categoria;
- observacao;
- data de criacao do metadado.

O identificador visual `main-reference` resolve a imagem principal do modelo, ou seja, o registro de imagem com `EhPrincipal = true`.

Se a imagem nao for encontrada, a tela exibe um `AppStateBlock` simples. Nenhuma rota nova foi criada.

## o que continua mockado

Continuam mockados:

- miniaturas reais;
- preview real de imagem;
- visualizacao real de imagem;
- detalhe real da imagem como arquivo aberto/renderizado;
- filtros funcionais;
- acoes de abrir imagem;
- acoes de importar;
- acoes de organizar;
- favoritos;
- validacao de caminho;
- status real de imagem existente ou ausente;
- qualquer manipulacao de imagem ou arquivo real.

## o que nao foi implementado

Nao foi implementado:

- leitura real de imagem;
- abertura real de imagem;
- upload/importacao real de imagem;
- seletor de arquivos do sistema;
- validacao real de caminho;
- geracao real de miniatura;
- copia de imagem;
- movimentacao de imagem;
- exclusao de imagem real;
- CRUD visual;
- formulario;
- modal;
- criacao, edicao ou exclusao real pela UI;
- visualizacao real de imagem;
- zoom real de imagem;
- busca real;
- favoritos reais;
- backup real.

## preservacao visual

Confirmado neste recorte:

- nenhum CSS visual foi alterado;
- nenhuma tela fora da Galeria do Modelo e da Visualizacao de Imagem foi alterada;
- sidebar e topbar nao foram alteradas;
- referencias Stitch nao foram alteradas;
- nenhuma area removida foi reintroduzida;
- nao houve CRUD visual.

## testes criados

Foram adicionados testes para:

- `ImagemModeloRepositorio.ListarPorModeloAsync` retornar imagens do modelo correto;
- `ImagemModeloRepositorio.ListarPorModeloAsync` nao misturar imagens de outro modelo;
- `ImagemModeloRepositorio.ObterPrincipalPorModeloAsync` retornar a imagem principal do modelo correto;
- `ImagemModeloRepositorio.ObterPrincipalPorModeloAsync` nao misturar imagem principal de outro modelo;
- `ImagemModeloServico.ListarPorModeloAsync` retornar `ImagemModeloResumo`;
- `ImagemModeloServico.ObterDetalheAsync` retornar `ImagemModeloDetalhe` para `main-reference`;
- `ImagemModeloServico.ObterDetalheAsync` retornar `null` para colecao, modelo ou imagem inexistente;
- seed criar imagens para `Cthulhu Idol` sem duplicar;
- servico nao expor entidade de dominio para UI;
- listagem trabalhar apenas com metadados, mesmo quando o caminho informado nao existe;
- detalhe de imagem trabalhar apenas com metadados, mesmo quando o caminho informado nao existe.

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

Apos revisao do Recorte 2 do Bloco 6, a proxima etapa sugerida e continuar Galeria de forma progressiva, ainda sem manipular imagens reais. Visualizacao real renderizada a partir do disco, importacao, validacao de caminho, imagem principal editavel e CRUD visual devem permanecer para recortes especificos e aprovados separadamente.
