# configuracoes de caminhos

## objetivo

Registrar a implementacao da tela Configuracoes de Caminhos no Blue Atelier, consolidando uma area visual/mockada para caminhos locais e caminhos de rede sem implementar selecao, teste, leitura, gravacao ou persistencia real.

## referencia visual usada

A tela foi implementada com base em:

```txt
referencias-visuais/stitch/html/15-configuracoes-caminhos.html
referencias-visuais/stitch/imagens/15-configuracoes-caminhos.png
referencias-visuais/stitch/design.md
```

A implementacao foi ajustada apos revisao visual para ficar mais fiel ao Stitch e para corrigir a navegacao secundaria de Configuracoes.

## rota implementada

```txt
/configuracoes/caminhos
```

A rota `/configuracoes` permanece dedicada a Configuracoes Gerais.

## arquivos alterados ou criados

Implementacao:

- `src/blueatelier.app/Components/Pages/ConfiguracoesCaminhos.razor`
- `src/blueatelier.app/Components/Pages/Configuracoes.razor`
- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/39-configuracoes-caminhos.md`

## estrutura da tela

A tela Configuracoes de Caminhos contem:

- cabecalho com retorno para Configuracoes Gerais;
- navegacao secundaria de configuracoes;
- card `Diretorios Principais`;
- lista visual de caminhos mockados;
- card `Descoberta de Rede`;
- toggle visual/mockado para busca futura de caminhos na rede local.

## organizacao da navegacao secundaria

A navegacao secundaria foi padronizada para evitar ambiguidade:

- `Geral` aponta para `/configuracoes`;
- `Caminhos` aponta para `/configuracoes/caminhos`;
- `Aparencia`, `Backup`, `Modelo de Pastas` e `Dados do App` permanecem como itens visuais/mockados ou futuros, sem rota criada nesta etapa.

Em `/configuracoes`, o item ativo e `Geral`.

Em `/configuracoes/caminhos`, o item ativo e `Caminhos`.

## correcao da duplicidade

A primeira versao da navegacao secundaria tinha dois itens relacionados a caminhos:

- `Caminhos Locais`;
- `Caminhos de Rede`.

Como ambos apontavam para a mesma rota, a duplicidade foi removida. A navegacao agora tem apenas o item `Caminhos`.

Caminhos locais e caminhos de rede passaram a ser tratados como conteudo interno da mesma tela, seguindo a decisao visual aprovada pelo usuario.

## secoes implementadas

Foram implementadas visualmente:

- `Diretorios Principais`;
- linha para `Diretorio Principal (Main)`;
- linha para `Colecoes (Collections)`;
- linha para `Arquivos Preparados (Prepared Files)`;
- `Descoberta de Rede`.

A referencia Stitch inclui uma linha de Fila de Impressao. Como essa area foi removida do escopo atual, a linha foi adaptada para `Arquivos Preparados (Prepared Files)` sem reintroduzir tela, rota ou funcionalidade de fila.

## campos visuais/mockados

Os caminhos exibidos sao mockados:

- `C:\BlueAtelier\MainLibrary`;
- `Z:\NetworkDrive\BlueAtelier\Collections`;
- `Diretorio nao configurado`.

Eles aparecem como campos visuais/readonly e nao representam leitura real do sistema de arquivos.

## botoes visuais/mockados

Foram implementados apenas como affordances visuais:

- `Alterar`;
- `Criar`;
- botao visual de copiar caminho;
- botao visual de reconectar caminho;
- toggle de descoberta de rede.

Nenhum botao seleciona pasta, testa caminho, reconecta rede, cria diretorio, copia para area de transferencia ou salva configuracao real.

## status visuais/mockados

Foram usados status visuais:

- `Conectado`;
- `Offline`;
- `Ausente`.

Esses estados sao mockados e servem apenas para validar a leitura visual da tela.

## fidelidade ao Stitch

A tela segue a composicao principal do Stitch:

- cabecalho com retorno;
- titulo `Caminhos Locais e Rede`;
- descricao curta;
- card de diretorios principais;
- linhas com icone, nome, status, acao e campo de caminho;
- card de descoberta de rede;
- toggle visual.

A adaptacao feita em relacao ao Stitch foi necessaria para respeitar a mudanca de escopo: Fila de Impressao nao foi reintroduzida.

## o que ainda e provisorio

- caminhos exibidos;
- status dos caminhos;
- botoes de alterar, criar, copiar e reconectar;
- toggle de descoberta de rede;
- validacao visual de caminho offline ou ausente.

## o que ainda nao foi implementado

- selecao real de pastas;
- teste real de caminhos;
- leitura real de diretorios;
- gravacao real de configuracao;
- persistencia;
- banco de dados;
- EF Core;
- migrations;
- servicos reais;
- APIs nativas;
- integracao real com rede local;
- criacao real de diretorios.

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
- Confirmado que `referencias-visuais/stitch/html/15-configuracoes-caminhos.html` foi usado como referencia.
- Confirmado que `referencias-visuais/stitch/imagens/15-configuracoes-caminhos.png` foi usada como referencia visual.
- Confirmado que `/configuracoes` abre Configuracoes Gerais.
- Confirmado que `/configuracoes/caminhos` abre Configuracoes de Caminhos.
- Confirmado que a sidebar principal continua apontando Configuracoes para `/configuracoes`.
- Confirmado que a navegacao secundaria usa `Geral -> /configuracoes`.
- Confirmado que a navegacao secundaria usa `Caminhos -> /configuracoes/caminhos`.
- Confirmado que nao existem dois links diferentes apontando para `/configuracoes/caminhos`.
- Confirmado que a topbar reconhece rotas iniciadas por `configuracoes`.
- Confirmado que nenhuma area removida foi reintroduzida.
- Confirmado que nenhum HTML, imagem ou `design.md` do Stitch foi alterado.
- Confirmado que nenhuma funcionalidade real foi implementada.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## aprovacao visual manual

A tela Configuracoes de Caminhos e a correcao da navegacao secundaria foram validadas visualmente pelo usuario e estao aprovadas.

## proxima etapa sugerida

Implementar Configuracoes de Aparencia com base em:

```txt
referencias-visuais/stitch/html/16-configuracoes-aparencia.html
```
