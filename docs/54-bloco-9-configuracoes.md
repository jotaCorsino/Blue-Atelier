# bloco 9 - configuracoes

## objetivo

Registrar o Recorte 1 do Bloco 9 da fase funcional do Blue Atelier, conectando Configuracoes Gerais a dados reais de configuracao no banco local.

Este recorte trabalha apenas com dados persistidos no SQLite. Ele nao acessa o sistema operacional, nao valida caminhos reais, nao altera tema real do app, nao le ou escreve arquivos externos e nao implementa salvamento pela UI.

## recorte implementado

O Recorte 1 implementa:

- repositorio concreto para configuracoes do app, usando o contrato existente `IConfiguracoesRepositorio`;
- servico de aplicacao para ler configuracoes gerais;
- modelo de aplicacao para resumo de Configuracoes Gerais;
- seed idempotente com chaves gerais minimas;
- conexao da tela `/configuracoes` com dados vindos do banco local;
- valores padrao quando alguma chave ainda nao existe;
- testes de repositorio, servico e seed.

## arquivos criados

Foram criados:

- `src/blueatelier.infrastructure/Repositorios/ConfiguracoesRepositorio.cs`;
- `src/blueatelier.application/Contratos/IConfiguracoesServico.cs`;
- `src/blueatelier.application/Modelos/ConfiguracoesGeraisResumo.cs`;
- `src/blueatelier.application/Servicos/ConfiguracoesServico.cs`;
- `tests/blueatelier.tests/infrastructure/ConfiguracoesPersistenciaTests.cs`;
- `docs/54-bloco-9-configuracoes.md`.

## arquivos alterados

Foram alterados:

- `src/blueatelier.infrastructure/DependencyInjection.cs`;
- `src/blueatelier.infrastructure/Persistencia/BlueAtelierSeed.cs`;
- `src/blueatelier.app/MauiProgram.cs`;
- `src/blueatelier.app/Components/Pages/Configuracoes.razor`;
- `docs/03-estado-atual.md`;
- `docs/04-proximos-documentos.md`.

Nenhum arquivo em `src/blueatelier.app/wwwroot/css` foi alterado.

## repositorio criado

Foi criado `ConfiguracoesRepositorio`, implementando o contrato existente `IConfiguracoesRepositorio`.

O repositorio oferece:

- listar configuracoes;
- obter configuracao por chave;
- salvar configuracao;
- listar caminhos configurados;
- salvar caminho configurado;
- obter modelo de pastas;
- salvar modelo de pastas.

As consultas usam `AsNoTracking`, ordenam configuracoes por chave e nao acessam sistema operacional, nao validam caminhos reais e nao leem ou escrevem arquivos externos.

Mesmo existindo metodos de salvamento no contrato de repositorio, a UI de Configuracoes Gerais nao salva alteracoes neste recorte.

## servico criado

Foi criado `ConfiguracoesServico`, expondo:

```txt
ObterGeraisAsync
```

O servico usa `IConfiguracoesRepositorio` e retorna `ConfiguracoesGeraisResumo`, sem expor entidades de dominio diretamente para Razor Components.

O servico aplica valores padrao quando alguma chave ainda nao existe e nao acessa sistema operacional, nao valida diretorios, nao altera tema real e nao salva preferencias pela UI.

## modelo de aplicacao criado

Foi criado `ConfiguracoesGeraisResumo`, contendo:

- `Idioma`;
- `Tema`;
- `Densidade`;
- `CorDestaque`;
- `DiretorioRaiz`;
- `DiretorioModelos`;
- `DiretorioBackups`;
- `BackupAutomatico`;
- `UltimaAtualizacao`.

## chaves de configuracao usadas

O seed passou a garantir, de forma idempotente, as chaves:

- `app.idioma`;
- `app.tema`;
- `app.densidade`;
- `app.corDestaque`;
- `caminhos.raiz`;
- `caminhos.modelos`;
- `caminhos.backups`;
- `backup.automatico`.

Valores iniciais:

```txt
pt-BR
system
comfortable
blue
C:/BlueAtelier
C:/BlueAtelier/Modelos
C:/BlueAtelier/Backups
false
```

Os caminhos sao apenas texto persistido. O seed nao verifica se eles existem.

## Configuracoes Gerais conectada ao banco

A tela `Configuracoes.razor`, rota `/configuracoes`, passou a carregar dados pelo `IConfiguracoesServico`.

Foram preservados:

- markup principal;
- classes CSS existentes;
- layout aprovado;
- navegacao secundaria de Configuracoes;
- cards e paineis;
- botoes visuais;
- sidebar e topbar.

Os dados reais usados na tela sao:

- pasta principal do atelier a partir de `caminhos.raiz`;
- pasta de colecoes/modelos a partir de `caminhos.modelos`;
- caminho exibido no painel de rede a partir de `caminhos.backups`;
- tema visual ativo a partir de `app.tema`;
- cor de destaque ativa a partir de `app.corDestaque`.

Programas Padrao, botoes e status visuais continuam mockados.

## o que continua mockado

Continuam mockados:

- botao salvar alteracoes;
- botao restaurar padroes;
- edicao real de campos;
- alteracao real de tema;
- alteracao real de aparencia;
- alteracao real de idioma;
- seletor de pasta;
- validacao de caminhos;
- leitura de diretorios;
- programas padrao;
- status real de rede/caminho;
- backup real.

## o que nao foi implementado

Nao foi implementado:

- salvamento funcional pela UI;
- CRUD visual;
- formulario novo;
- modal;
- alteracao real de tema;
- alteracao real de idioma;
- alteracao real de aparencia;
- seletor de pasta;
- validacao real de caminho;
- leitura real de diretorios;
- escrita de arquivos externos;
- backup real;
- acesso ao sistema operacional.

## preservacao visual

Confirmado neste recorte:

- nenhum CSS visual foi alterado;
- nenhuma tela fora de Configuracoes Gerais foi alterada;
- sidebar e topbar nao foram alteradas;
- referencias Stitch nao foram alteradas;
- nenhuma area removida foi reintroduzida;
- nao houve redesenho;
- nao houve CRUD visual.

## testes criados

Foram adicionados testes para:

- `ConfiguracoesRepositorio.ListarConfiguracoesAsync` retornar configuracoes persistidas;
- `ConfiguracoesRepositorio.ObterConfiguracaoAsync` retornar configuracao por chave;
- `ConfiguracoesServico.ObterGeraisAsync` retornar `ConfiguracoesGeraisResumo`;
- seed criar configuracoes gerais sem duplicar;
- servico aplicar valores padrao quando chaves nao existem;
- servico nao expor entidade de dominio para UI;
- servico nao validar caminhos reais.

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

Apos revisao do Recorte 1 do Bloco 9, a proxima etapa sugerida e continuar Configuracoes em recortes pequenos, ainda sem redesenhar telas e sem acessar o sistema operacional.

Configurar caminhos com seletor real, validar diretorios, aplicar tema real, salvar preferencias pela UI e integrar backup real devem permanecer para recortes especificos e aprovados separadamente.
