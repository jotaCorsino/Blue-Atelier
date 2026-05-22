# bloco 1 - arquitetura funcional minima

## objetivo

Registrar a consolidacao do inicio da fase funcional do Blue Atelier com uma base minima de dominio e contratos.

Este bloco prepara o projeto para persistencia local futura, mas ainda nao implementa banco, EF Core, SQLite, migrations, repositorios concretos, servicos reais ou integracao com as telas.

## escopo implementado

O Bloco 1 foi revisado e aprovado pelo usuario. Esta consolidacao criou apenas:

- entidades simples de dominio;
- enums basicos;
- contratos/interfaces de repositorio;
- testes unitarios simples de dominio;
- documentacao da estrutura criada.

Nenhuma tela Razor foi alterada e nenhum CSS visual foi modificado.

## estrutura criada

Como a solution ja possuia projetos de camada, a implementacao foi feita nos projetos existentes:

```txt
src/blueatelier.domain/Entidades
src/blueatelier.domain/enums
src/blueatelier.domain/Contratos
tests/blueatelier.tests/domain
```

A estrutura sugerida originalmente dentro do app nao foi usada para evitar duplicar arquitetura dentro da camada visual. O projeto `blueatelier.app` permanece apenas como interface.

## entidades criadas

Foram criadas entidades simples, sem atributos de banco e sem dependencia de EF Core:

- `Colecao`;
- `Modelo`;
- `ImagemDoModelo`;
- `ArquivoVinculado`;
- `LinkFavorito`;
- `PastaFavoritos`;
- `ConfiguracaoApp`;
- `CaminhoConfigurado`;
- `ModeloPastas`;
- `RegistroBackup`.

As entidades usam `Guid` como identificador e `DateTimeOffset` para datas.

## enums criados

Foram criados enums basicos para vocabulario do dominio:

- `EtapaModelo`;
- `TipoArquivoVinculado`;
- `TipoImagemModelo`;
- `TipoCaminhoConfigurado`;
- `StatusBackup`.

Os enums sao simples e nao representam regras completas de negocio. Eles servem apenas como base inicial para evitar strings soltas em pontos centrais do dominio.

## contratos criados

Foram criados contratos de repositorio, sem implementacao concreta:

- `IRepositorio<TEntidade>`;
- `IColecaoRepositorio`;
- `IModeloRepositorio`;
- `IArquivoVinculadoRepositorio`;
- `IImagemModeloRepositorio`;
- `IFavoritosRepositorio`;
- `IConfiguracoesRepositorio`.

Esses contratos definem operacoes assincronas basicas como listar, obter, salvar e remover, alem de consultas especificas simples como listar modelos por colecao ou arquivos por modelo.

Nenhum repositorio concreto foi criado nesta etapa.

## testes criados

Foi criado o arquivo:

```txt
tests/blueatelier.tests/domain/EntidadesDominioTests.cs
```

Os testes cobrem:

- criacao de `Colecao`;
- criacao de `Modelo`;
- vinculo logico entre `Modelo` e `ColecaoId`;
- criacao de `LinkFavorito`;
- criacao de `CaminhoConfigurado`;
- criacao de `ArquivoVinculado` com tamanho opcional.

Os testes sao intencionalmente simples para validar a base sem criar regras frageis.

## o que ainda nao foi implementado

Ainda nao foi implementado:

- SQLite;
- EF Core;
- `DbContext`;
- migrations;
- seed real;
- repositorios concretos;
- servicos de aplicacao com logica real;
- persistencia local;
- leitura real de arquivos;
- escrita real de arquivos;
- backup real;
- integracao com Razor Components;
- substituicao dos dados mockados nas telas.

## preservacao visual

Confirmado neste bloco:

- nenhuma tela aprovada foi alterada;
- nenhum layout foi alterado;
- nenhum CSS visual foi alterado;
- sidebar e topbar nao foram alteradas;
- nenhuma rota nova foi criada;
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
- build concluido com sucesso, sem avisos e sem erros;
- testes concluidos com sucesso, incluindo os testes simples de dominio.

## proxima etapa sugerida

Apos revisao e aprovacao do Bloco 1, a proxima etapa sugerida e iniciar o Bloco 2 - Banco local, planejando SQLite, EF Core, `DbContext`, migrations e seed inicial de forma incremental.

O Bloco 2 so deve comecar apos aprovacao explicita do usuario e deve continuar preservando todo o visual aprovado.
