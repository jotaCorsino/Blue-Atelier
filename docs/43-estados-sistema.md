# estados do sistema

## objetivo

Registrar a criacao do padrao visual reutilizavel de estados do sistema no Blue Atelier, cobrindo estados como vazio, erro, offline, sem resultados, caminho indisponivel, loading e sincronizacao pendente.

Esse padrao deve ser usado futuramente dentro das telas reais quando uma situacao exigir feedback visual, sem criar uma tela navegavel propria.

## referencia visual usada

O padrao foi criado com base em:

```txt
referencias-visuais/stitch/html/19-estados-vazios-erros-offline.html
referencias-visuais/stitch/imagens/19-estados-vazios-erros-offline.png
referencias-visuais/stitch/design.md
```

## motivo de nao criar rota ou tela navegavel

A referencia 19 representa um guia visual de componentes e estados do sistema, nao uma area funcional do app.

Por isso, nao foram criadas:

- rota `/estados-vazios-erros-offline`;
- pagina `src/blueatelier.app/Components/Pages/EstadosVaziosErrosOffline.razor`;
- item de sidebar;
- tela de demonstracao final navegavel.

O resultado aprovado e um componente compartilhado pronto para reutilizacao.

## componente criado

Foi criado:

```txt
src/blueatelier.app/Components/Shared/AppStateBlock.razor
```

O componente renderiza um bloco visual de estado com icone, titulo, descricao, conteudo opcional e acoes visuais.

## parametros disponiveis

O componente possui parametros simples e reutilizaveis:

- `Variant`;
- `Title`;
- `Description`;
- `Icon`;
- `ActionLabel`;
- `SecondaryActionLabel`;
- `IsCompact`;
- `Class`;
- `Role`;
- `AriaLive`;
- `ChildContent`.

## variantes visuais disponiveis

As variantes aceitas incluem:

- `empty`;
- `error`;
- `offline`;
- `no-results`;
- `unavailable`;
- `unavailable-path`;
- `path-unavailable`;
- `loading`;
- `sync-pending`;
- `success`;
- `warning`;
- `info`.

As variantes `unavailable-path` e `path-unavailable` sao aliases para a mesma apresentacao de caminho indisponivel.

## estilos CSS adicionados

Os estilos foram adicionados em:

```txt
src/blueatelier.app/wwwroot/css/app.css
```

As classes sao genericas e reutilizaveis:

- `app-state-block`;
- `app-state-block-empty`;
- `app-state-block-error`;
- `app-state-block-offline`;
- `app-state-block-no-results`;
- `app-state-block-unavailable`;
- `app-state-block-loading`;
- `app-state-block-sync-pending`;
- `app-state-block-compact`;
- `app-state-actions`.

Tambem foram adicionadas classes de apoio para icone, texto, conteudo extra e acoes.

## icones adicionados

Foram adicionados icones genericos em:

```txt
src/blueatelier.app/Components/Shared/AppIcon.razor
```

Icones adicionados:

- `folder-off`;
- `broken-image`;
- `wifi-off`;
- `loader`;
- `sync-pending`.

Eles sao reutilizaveis e nao pertencem a uma tela especifica.

## como usar futuramente

Exemplo de uso futuro:

```razor
<AppStateBlock
    Variant="empty"
    Title="Nenhuma colecao encontrada"
    Description="Crie sua primeira colecao para organizar os modelos do atelier."
    ActionLabel="Criar colecao" />
```

Outro exemplo:

```razor
<AppStateBlock
    Variant="offline"
    Title="Caminho de rede indisponivel"
    Description="O caminho configurado nao respondeu. Verifique a conexao antes de continuar."
    ActionLabel="Tentar novamente"
    SecondaryActionLabel="Alterar caminho" />
```

Esses usos ainda serao aplicados apenas quando uma tela real precisar desse estado.

## o que e apenas visual/mockado

- variantes de estado;
- icones;
- textos;
- botoes de acao;
- estado compacto;
- animacao visual de loading.

## o que nao foi implementado

- logica real de erro;
- detector real de offline;
- retry funcional;
- loading real;
- sincronizacao real;
- servicos;
- persistencia;
- banco de dados;
- EF Core;
- migrations;
- APIs nativas.

## preservacao das telas aprovadas

Nenhuma tela aprovada foi redesenhada ou alterada visualmente.

Continuam preservadas:

- Home;
- Colecoes;
- Detalhe da Colecao;
- Modelos;
- Detalhe do Modelo;
- Galeria do Modelo;
- Visualizacao de Imagem;
- Arquivos Vinculados;
- Favoritos;
- Busca;
- Configuracoes Gerais;
- Configuracoes de Caminhos;
- Configuracoes de Aparencia;
- Modelo de Pastas;
- Backup/Dados.

## preservacao da sidebar e topbar

A sidebar e a topbar foram preservadas.

Nao houve:

- novo item de navegacao;
- nova rota de estados;
- ajuste de topbar para estados;
- pagina navegavel de demonstracao.

## areas removidas fora do escopo

As areas abaixo continuam fora do escopo atual e nao foram reintroduzidas:

- Fila de Impressao;
- Arquivos Recentes;
- Materiais;
- Detalhe do Material.

As rotas abaixo continuam inexistentes:

```txt
/fila-impressao
/arquivos-recentes
/materiais
/materiais/resin-grey
```

## validacoes executadas

- Confirmado que `referencias-visuais/stitch/design.md` foi respeitado.
- Confirmado que `referencias-visuais/stitch/html/19-estados-vazios-erros-offline.html` foi usado como referencia.
- Confirmado que `referencias-visuais/stitch/imagens/19-estados-vazios-erros-offline.png` foi usada como referencia visual.
- Confirmado que `AppStateBlock.razor` foi criado como componente compartilhado.
- Confirmado que nenhuma rota `/estados-vazios-erros-offline` foi criada.
- Confirmado que nenhuma pagina `EstadosVaziosErrosOffline.razor` foi criada.
- Confirmado que a sidebar foi preservada.
- Confirmado que a topbar foi preservada.
- Confirmado que nenhuma tela aprovada foi redesenhada.
- Confirmado que nenhuma area removida foi reintroduzida.
- Confirmado que nenhuma logica real foi implementada.
- Confirmado que nenhum HTML, imagem ou `design.md` do Stitch foi alterado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## aprovacao visual manual

O usuario validou a direcao correta da referencia 19 como padrao reutilizavel de estados do sistema, sem tela navegavel e sem rota propria.

## proxima etapa sugerida

Revisar a documentacao geral, validar a cobertura visual implementada e planejar a proxima fase funcional do Blue Atelier.
