# bloco 2 - banco local

## objetivo

Registrar a consolidacao do Bloco 2 da fase funcional do Blue Atelier, criando a base inicial de persistencia local com SQLite e EF Core.

Este bloco cria infraestrutura de banco, mas ainda nao integra as telas, nao substitui mocks, nao cria CRUD visual e nao implementa leitura/escrita real de arquivos.

## projeto usado

A solution ja possuia o projeto:

```txt
src/blueatelier.infrastructure
```

Por isso, a base de persistencia foi criada nessa camada, mantendo `blueatelier.app` sem alteracoes visuais e mantendo as entidades no projeto `blueatelier.domain`.

## pacotes adicionados

Pacotes adicionados em `src/blueatelier.infrastructure/BlueAtelier.Infrastructure.csproj`:

- `Microsoft.EntityFrameworkCore` 10.0.8;
- `Microsoft.EntityFrameworkCore.Sqlite` 10.0.8;
- `Microsoft.EntityFrameworkCore.Design` 10.0.8.

Nenhum pacote foi adicionado ao projeto visual do app.

## DbContext criado

Foi criado:

```txt
src/blueatelier.infrastructure/Persistencia/BlueAtelierDbContext.cs
```

O contexto expoe `DbSet` para:

- `Colecoes`;
- `Modelos`;
- `ImagensDoModelo`;
- `ArquivosVinculados`;
- `LinksFavoritos`;
- `PastasFavoritos`;
- `ConfiguracoesApp`;
- `CaminhosConfigurados`;
- `ModelosPastas`;
- `RegistrosBackup`.

## entidades mapeadas

Os mapeamentos foram feitos via Fluent API no `OnModelCreating`, sem atributos de banco nas entidades de dominio.

Foram mapeados:

- chaves primarias;
- campos obrigatorios;
- tamanhos maximos de strings;
- conversoes de enums para string;
- relacionamentos entre colecoes e modelos;
- relacionamentos entre modelos, imagens e arquivos vinculados;
- relacionamento opcional entre links favoritos e pastas;
- indices para slugs, nomes, chaves, ordem e status quando apropriado.

## factory e caminho do banco

Foi criado:

```txt
src/blueatelier.infrastructure/Persistencia/BlueAtelierDbContextFactory.cs
```

A factory permite criar um `BlueAtelierDbContext` a partir de um caminho SQLite simples.

O caminho definitivo do banco no ambiente MAUI ainda nao foi decidido. Ele deve ser refinado em etapa futura, antes da integracao com o app visual.

## migration criada

Foi criada a migration inicial:

```txt
src/blueatelier.infrastructure/Persistencia/Migrations/*_InitialCreate.cs
```

A migration cria apenas tabelas relacionadas as entidades do dominio atual.

Observacao: o `dotnet ef` disponivel no ambiente esta na versao 10.0.5 e avisou que o runtime EF Core esta em 10.0.8. Nao existe manifesto local versionado em `.config/dotnet-tools.json`, entao a ferramenta global/local da maquina nao foi alterada nesta etapa. A migration foi gerada corretamente e o projeto compila/testa com EF Core 10.0.8.

## seed inicial

Foi criado:

```txt
src/blueatelier.infrastructure/Persistencia/BlueAtelierSeed.cs
```

O seed inicial e minimo e idempotente. Ele cria, quando ausentes:

- colecao `Eldritch Horrors`;
- modelo `Cthulhu Idol`;
- pasta favorita `Referencias`;
- links favoritos `ArtStation` e `Thingiverse`;
- configuracao `app.idioma = pt-BR`.

O seed nao e chamado pela UI nesta etapa.

## testes criados

Foi criado:

```txt
tests/blueatelier.tests/infrastructure/BlueAtelierDbContextTests.cs
```

Os testes validam:

- criacao de banco SQLite temporario;
- aplicacao da migration via `MigrateAsync`;
- persistencia e consulta de `Colecao`;
- persistencia e consulta de `Modelo` vinculado a colecao;
- persistencia e consulta de `LinkFavorito`;
- persistencia e consulta de `ConfiguracaoApp`;
- execucao idempotente do seed.

Os testes nao dependem de caminhos fixos da maquina.

## o que ainda nao foi integrado

Ainda nao foi integrado:

- telas Razor com banco;
- substituicao dos mocks visuais;
- CRUD real nas telas;
- servicos de aplicacao complexos;
- repositorios concretos usando os contratos do dominio;
- leitura real de arquivos;
- escrita real de arquivos;
- backup real;
- exportacao/importacao real;
- busca real;
- favoritos reais na UI;
- configuracoes reais no app.

## preservacao visual

Confirmado neste bloco:

- nenhuma tela aprovada foi alterada;
- nenhum CSS visual foi alterado;
- sidebar e topbar nao foram alteradas;
- nenhuma rota nova foi criada;
- os dados mockados das telas continuam intactos;
- nenhuma area removida foi reintroduzida.

As areas Fila de Impressao, Arquivos Recentes, Materiais e Detalhe do Material continuam fora do escopo atual.

## validacoes executadas

Executadas nesta etapa:

```txt
dotnet restore BlueAtelier.sln
dotnet build BlueAtelier.sln
dotnet test BlueAtelier.sln --no-build
```

Resultado esperado e observado:

- restore concluido com sucesso;
- build concluido com sucesso;
- testes concluidos com sucesso, incluindo testes de persistencia SQLite.

## proxima etapa sugerida

Com o Bloco 2 aprovado, a proxima etapa sugerida e iniciar o Bloco 3 - Colecoes.

O Bloco 3 deve conectar gradualmente a tela de Colecoes aos dados reais, preservando o visual aprovado e evitando redesenho.
