# configuracoes gerais

## objetivo

Registrar a implementacao da tela Configuracoes Gerais no Blue Atelier, consolidando uma area visual/mockada para preferencias gerais do app sem implementar configuracoes reais.

## referencia visual usada

A tela foi implementada com base em:

```txt
referencias-visuais/stitch/html/14-configuracoes-gerais.html
referencias-visuais/stitch/imagens/14-configuracoes-gerais.png
referencias-visuais/stitch/design.md
```

A primeira versao da tela foi revisada visualmente e depois corrigida para ficar mais fiel a composicao do Stitch.

## rota implementada

```txt
/configuracoes
```

## arquivos alterados ou criados

Implementacao:

- `src/blueatelier.app/Components/Pages/Configuracoes.razor`
- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/38-configuracoes-gerais.md`

## estrutura da tela

A tela Configuracoes Gerais contem:

- cabecalho simples com titulo e descricao;
- navegacao secundaria de configuracoes;
- painel `Caminhos Principais`;
- painel `Rede`;
- painel `Aparencia`;
- painel `Programas Padrao`.

A estrutura foi reorganizada para acompanhar a referencia `14-configuracoes-gerais.png`, com navegacao secundaria a esquerda e paineis principais a direita.

## secoes implementadas

Foram implementadas visualmente:

- `Caminhos Principais`, com pasta principal e pasta de colecoes;
- `Rede`, com destino mockado e estado offline visual;
- `Aparencia`, com opcoes de tema e seletor visual de cor;
- `Programas Padrao`, com campos visuais para slicer e modelagem.

## controles visuais/mockados

Os controles implementados sao apenas affordances visuais:

- inputs readonly para caminhos;
- botoes `Alterar` e `Testar`;
- seletores de tema;
- swatches de cor;
- selects visuais para programas padrao;
- indicadores de status `Status: OK` e `Offline`.

Nenhum controle salva, testa, le, grava ou altera configuracoes reais.

## comportamento visual

A tela usa a paleta clean/azulada ja aprovada, respeitando o design system atual do app. Os cards, campos e botoes foram ajustados para se aproximarem do peso visual, espacamento, hierarquia e proporcoes da referencia Stitch.

## fidelidade corrigida em relacao ao Stitch

A tela foi corrigida apos revisao visual porque a primeira implementacao havia se afastado da referencia.

Foram removidos ou substituidos elementos que nao existiam no Stitch, como:

- cards de informacoes gerais do app;
- lista de switches de preferencias gerais;
- secao de idioma/regiao;
- secao de comportamento inicial;
- atalhos futuros em formato de cards;
- painel de salvamento visual.

A composicao final segue mais diretamente a referencia:

- navegacao secundaria lateral;
- painel largo de caminhos;
- paineis `Rede` e `Aparencia` lado a lado;
- painel largo de `Programas Padrao`.

## o que ainda e provisorio

- caminhos exibidos;
- estados `Status: OK` e `Offline`;
- seletores de tema;
- swatches de cor;
- programas padrao;
- botoes de alterar e testar.

## o que ainda nao foi implementado

- configuracoes reais;
- salvamento real;
- persistencia;
- banco de dados;
- EF Core;
- migrations;
- servicos reais;
- leitura ou gravacao de arquivos;
- teste real de caminho;
- aplicacao real de tema;
- selecao real de programas padrao.

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
- Confirmado que `referencias-visuais/stitch/html/14-configuracoes-gerais.html` foi usado como referencia.
- Confirmado que `referencias-visuais/stitch/imagens/14-configuracoes-gerais.png` foi usado como referencia visual.
- Confirmado que `/configuracoes` abre corretamente.
- Confirmado que a sidebar navega para `/configuracoes`.
- Confirmado que a topbar reconhece `/configuracoes`.
- Confirmado que Configuracoes Gerais aparece como tela visual/mockada.
- Confirmado que nenhuma configuracao real foi implementada.
- Confirmado que nenhum salvamento real foi implementado.
- Confirmado que nenhuma persistencia real foi implementada.
- Confirmado que nenhuma area removida foi reintroduzida.
- Confirmado que nenhum HTML, imagem ou `design.md` do Stitch foi alterado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## aprovacao visual manual

A tela Configuracoes Gerais foi validada visualmente pelo usuario apos a correcao de fidelidade com o Stitch e esta aprovada.

## proxima etapa sugerida

Implementar Configuracoes de Caminhos com base em:

```txt
referencias-visuais/stitch/html/15-configuracoes-caminhos.html
```
