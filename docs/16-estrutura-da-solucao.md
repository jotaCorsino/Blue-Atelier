# blue atelier - estrutura da solucao

## 1. objetivo do documento

Este documento registra a estrutura base da solucao .NET criada para o **Blue Atelier**.

A tarefa atual iniciou a fase de implementacao tecnica, mas ainda nao implementou telas finais, banco SQLite, migrations, regras de negocio, sistema de arquivos ou conversao dos HTMLs do Stitch.

## 2. solution criada

Arquivo principal:

```txt
BlueAtelier.sln
```

A solution organiza o app e as camadas previstas na arquitetura tecnica oficial.

## 3. projetos criados

Estrutura criada:

```txt
src/
├── blueatelier.app/
├── blueatelier.domain/
├── blueatelier.application/
├── blueatelier.infrastructure/
└── blueatelier.persistence/

tests/
└── blueatelier.tests/
```

Os nomes das pastas foram mantidos em letras minusculas. Os nomes dos projetos usam o padrao C# definido na arquitetura:

- `BlueAtelier.App`
- `BlueAtelier.Domain`
- `BlueAtelier.Application`
- `BlueAtelier.Infrastructure`
- `BlueAtelier.Persistence`
- `BlueAtelier.Tests`

Arquivos obrigatorios do template MAUI, como `MauiProgram.cs`, `MainPage.xaml`, `App.xaml` e arquivos de plataforma Windows, foram preservados com os nomes gerados pelo template para manter compatibilidade.

## 4. funcao de cada projeto

### BlueAtelier.App

Projeto .NET MAUI Blazor Hybrid.

Responsabilidades futuras:

- hospedar o app Windows local;
- compor Razor Components;
- carregar CSS proprio;
- registrar servicos no container de DI;
- exibir layouts, paginas e estados visuais;
- integrar a interface com os casos de uso da aplicacao.

Estado atual:

- contem apenas um placeholder simples;
- nao recria o visual do Stitch;
- nao possui navegacao completa;
- nao possui telas finais;
- esta direcionado para Windows.

### BlueAtelier.Domain

Camada de dominio.

Responsabilidades futuras:

- entidades;
- enums;
- value objects;
- regras puras de dominio;
- invariantes independentes de infraestrutura.

Estado atual:

- contem apenas marcador de assembly;
- nao possui entidades reais.

### BlueAtelier.Application

Camada de aplicacao.

Responsabilidades futuras:

- casos de uso;
- contratos de servicos;
- validacoes de aplicacao;
- orquestracao entre dominio, persistencia e infraestrutura.

Estado atual:

- referencia `BlueAtelier.Domain`;
- contem apenas marcador de assembly;
- nao possui casos de uso reais.

### BlueAtelier.Infrastructure

Camada de infraestrutura.

Responsabilidades futuras:

- sistema de arquivos;
- caminhos locais;
- caminhos de rede;
- abertura de arquivos e pastas;
- integracoes com Windows;
- servicos tecnicos.

Estado atual:

- referencia `BlueAtelier.Domain` e `BlueAtelier.Application`;
- contem apenas marcador de assembly;
- nao possui servicos reais.

### BlueAtelier.Persistence

Camada de persistencia.

Responsabilidades futuras:

- SQLite;
- Entity Framework Core;
- DbContext;
- configuracoes de entidades;
- repositorios;
- migrations futuras.

Estado atual:

- referencia `BlueAtelier.Domain` e `BlueAtelier.Application`;
- contem apenas marcador de assembly;
- nao possui banco, DbContext, EF Core ou migrations.

### BlueAtelier.Tests

Projeto de testes.

Responsabilidades futuras:

- testes de dominio;
- testes de aplicacao;
- testes de persistencia;
- testes de infraestrutura;
- validacoes de arquitetura.

Estado atual:

- contem teste inicial simples para confirmar que as camadas existem e estao referenciadas.

## 5. dependencias entre projetos

Dependencias atuais:

```txt
BlueAtelier.App
├── BlueAtelier.Application
├── BlueAtelier.Infrastructure
└── BlueAtelier.Persistence

BlueAtelier.Application
└── BlueAtelier.Domain

BlueAtelier.Infrastructure
├── BlueAtelier.Domain
└── BlueAtelier.Application

BlueAtelier.Persistence
├── BlueAtelier.Domain
└── BlueAtelier.Application

BlueAtelier.Tests
├── BlueAtelier.Domain
├── BlueAtelier.Application
├── BlueAtelier.Infrastructure
└── BlueAtelier.Persistence
```

Regra importante:

- `BlueAtelier.Domain` nao deve depender das outras camadas.
- `BlueAtelier.Application` deve depender do dominio, mas nao de MAUI.
- `BlueAtelier.Infrastructure` e `BlueAtelier.Persistence` implementarao detalhes tecnicos futuramente.
- `BlueAtelier.App` fara a composicao final.

## 6. foco Windows local

O template MAUI Blazor Hybrid gera suporte multi-plataforma por padrao.

Como o Blue Atelier e um app local para Windows, o projeto `BlueAtelier.App` foi adaptado para:

```txt
net10.0-windows10.0.19041.0
```

Arquivos de plataformas nao usadas pelo app foram removidos quando seguro. Os arquivos da plataforma Windows foram preservados.

## 7. comandos de restore e build

Comandos usados:

```txt
dotnet restore BlueAtelier.sln
dotnet build BlueAtelier.sln
dotnet test BlueAtelier.sln --no-build
```

Resultado:

- restore concluido com sucesso;
- build concluido com sucesso;
- testes concluidos com sucesso.

Observacao:

No sandbox, `dotnet restore` e `dotnet build` falharam inicialmente porque precisavam ler `C:\Users\Estudos\AppData\Roaming\NuGet\NuGet.Config`. Os comandos foram reexecutados com permissao fora do sandbox e passaram.

## 8. observacoes sobre MAUI workload

Ambiente validado:

```txt
dotnet --version
10.0.203
```

Workloads observados:

- `android`
- `ios`
- `maccatalyst`
- `maui-windows`

O workload relevante para esta fase e `maui-windows`.

## 9. o que ainda nao foi implementado

Ainda nao foi implementado:

- telas finais do Stitch;
- conversao dos HTMLs do Stitch;
- layout base definitivo;
- sidebar;
- topbar;
- tokens visuais finais em CSS;
- tema claro/escuro;
- entidades completas;
- banco SQLite;
- Entity Framework Core;
- migrations;
- sistema de arquivos;
- caminhos de rede;
- fila de impressao;
- configuracoes reais;
- busca global;
- favoritos;
- materiais.

## 10. protecao das referencias visuais

Os arquivos em `referencias-visuais/stitch/` continuam sendo referencia visual protegida.

Nesta tarefa:

- nenhum HTML do Stitch foi alterado;
- nenhuma imagem do Stitch foi alterada;
- nenhuma tela do Stitch foi convertida;
- o placeholder do app nao tenta recriar o visual final.

## 11. proxima etapa tecnica sugerida

A proxima etapa sugerida e criar a fundacao visual do app a partir das referencias aprovadas do Stitch.

Escopo sugerido para a proxima tarefa:

- layout base;
- sidebar;
- topbar;
- tema claro;
- tema escuro;
- tokens visuais iniciais;
- estrutura de CSS proprio;
- componentes base compartilhados.

Essa etapa ainda nao deve implementar todas as telas do app.
