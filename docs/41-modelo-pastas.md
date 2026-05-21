# modelo de pastas

## objetivo

Registrar a implementacao da tela Modelo de Pastas no Blue Atelier, consolidando uma area visual/mockada para visualizar o padrao de organizacao de pastas de colecoes e modelos sem criar pastas reais, ler diretorios ou salvar configuracoes.

## referencia visual usada

A tela foi implementada com base em:

```txt
referencias-visuais/stitch/html/17-modelo-pastas.html
referencias-visuais/stitch/imagens/17-modelo-pastas.png
referencias-visuais/stitch/design.md
```

A implementacao preserva a paleta clean/azulada aprovada do Blue Atelier e o layout padronizado do modulo de Configuracoes.

## rota implementada

```txt
/configuracoes/modelo-pastas
```

As rotas abaixo continuam preservadas:

```txt
/configuracoes
/configuracoes/caminhos
/configuracoes/aparencia
```

## arquivos alterados ou criados

Implementacao:

- `src/blueatelier.app/Components/Pages/ConfiguracoesModeloPastas.razor`
- `src/blueatelier.app/Components/Pages/Configuracoes.razor`
- `src/blueatelier.app/Components/Pages/ConfiguracoesCaminhos.razor`
- `src/blueatelier.app/Components/Pages/ConfiguracoesAparencia.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/38-configuracoes-gerais.md`
- `docs/39-configuracoes-caminhos.md`
- `docs/40-configuracoes-aparencia.md`
- `docs/41-modelo-pastas.md`

## estrutura da tela

A tela Modelo de Pastas contem:

- cabecalho comum com titulo `Modelo de Pastas` e descricao curta;
- navegacao secundaria de Configuracoes;
- conteudo principal com cards `Colecao` e `Modelo`;
- arvore visual de pastas para cada tipo;
- bloco `Pre-visualizacao do Caminho`;
- acao visual `Salvar Alteracoes`.

## organizacao da navegacao secundaria

A navegacao secundaria do modulo de Configuracoes esta padronizada:

- `Geral` aponta para `/configuracoes`;
- `Caminhos` aponta para `/configuracoes/caminhos`;
- `Aparencia` aponta para `/configuracoes/aparencia`;
- `Backup` permanece visual/mockado ou futuro;
- `Modelo de Pastas` aponta para `/configuracoes/modelo-pastas`;
- `Dados do App` permanece visual/mockado ou futuro.

Em `/configuracoes`, o item ativo e `Geral`.

Em `/configuracoes/caminhos`, o item ativo e `Caminhos`.

Em `/configuracoes/aparencia`, o item ativo e `Aparencia`.

Em `/configuracoes/modelo-pastas`, o item ativo e `Modelo de Pastas`.

## secoes implementadas

Foram implementadas visualmente:

- card `Colecao`;
- card `Modelo`;
- arvore de pastas para colecao;
- arvore de pastas para modelo;
- bloco `Pre-visualizacao do Caminho`;
- linha final de acao com `Salvar Alteracoes`.

## cards Colecao e Modelo

Os cards exibem uma estrutura mockada de diretorios:

Card `Colecao`:

- `{Nome da Colecao}`;
- `Imagens`;
- `Manuais`;
- `Modelos Base`.

Card `Modelo`:

- `{Nome do Modelo}`;
- `Arquivos STL`;
- `Arquivos Suportados`;
- `Fotos`.

Os cards usam icones SVG inline do app, botao visual de edicao e linhas de arvore com conectores discretos.

## pre-visualizacao do caminho

O bloco `Pre-visualizacao do Caminho` exibe um caminho mockado:

```txt
/ 3D_Prints / Fantasy_Miniatures / Guerreiro_Elfo / Arquivos_STL /
```

O nome `Guerreiro_Elfo` recebe destaque visual para mostrar a posicao do modelo dentro da estrutura.

## botao Salvar Alteracoes

O botao `Salvar Alteracoes` e apenas visual/mockado.

Ele foi ajustado para ficar integrado ao layout:

- alinhado ao conteudo principal;
- com margem coerente em relacao ao preview;
- sem parecer solto fora da composicao;
- responsivo em telas menores.

## ajustes de espacamento

A revisao visual corrigiu:

- espacamento entre os cards `Colecao` e `Modelo`;
- gap horizontal e vertical dos cards;
- padding interno dos cards;
- ritmo visual das linhas da arvore de pastas;
- alinhamento do bloco de pre-visualizacao;
- encaixe do botao final.

Tambem foi removida a dependencia de um token de espacamento inexistente no CSS, garantindo que o `gap` real seja aplicado pelo navegador.

## ajustes de responsividade

A responsividade do modulo de Configuracoes foi revisada para:

- manter a navegacao secundaria legivel em telas menores;
- transformar grids em uma coluna quando necessario;
- evitar cards espremidos;
- preservar `min-width: 0` em containers de grid/flex;
- permitir overflow interno controlado no caminho mockado;
- evitar scroll horizontal indevido na pagina;
- manter padding confortavel em cards e paineis.

Essa revisao abrangeu:

```txt
/configuracoes
/configuracoes/caminhos
/configuracoes/aparencia
/configuracoes/modelo-pastas
```

## controles visuais/mockados

Os controles exibidos sao apenas affordances visuais:

- botoes de edicao dos cards;
- arvore de pastas;
- pre-visualizacao de caminho;
- botao `Salvar Alteracoes`.

Nenhum controle cria pastas, grava configuracoes, le diretorios ou persiste dados.

## fidelidade ao Stitch

A tela segue a composicao principal da referencia Stitch:

- titulo e descricao;
- dois cards superiores lado a lado em telas largas;
- arvores de pastas com conectores;
- bloco largo de pre-visualizacao;
- botao final alinhado a direita.

A adaptacao feita foi inserir a referencia dentro do esqueleto padronizado do modulo de Configuracoes, com navegacao secundaria a esquerda e conteudo principal a direita.

## o que ainda e provisorio

- estrutura de pastas exibida;
- caminho de pre-visualizacao;
- botoes de edicao;
- botao `Salvar Alteracoes`;
- comportamento da navegacao secundaria para areas futuras.

## o que ainda nao foi implementado

- criacao real de pastas;
- leitura real de diretorios;
- gravacao real de configuracao;
- persistencia;
- banco de dados;
- EF Core;
- migrations;
- servicos reais;
- APIs nativas;
- validacao real de caminhos.

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
- Confirmado que `referencias-visuais/stitch/html/17-modelo-pastas.html` foi usado como referencia.
- Confirmado que `referencias-visuais/stitch/imagens/17-modelo-pastas.png` foi usada como referencia visual.
- Confirmado que `/configuracoes` abre Configuracoes Gerais.
- Confirmado que `/configuracoes/caminhos` abre Configuracoes de Caminhos.
- Confirmado que `/configuracoes/aparencia` abre Configuracoes de Aparencia.
- Confirmado que `/configuracoes/modelo-pastas` abre Modelo de Pastas.
- Confirmado que a sidebar principal continua apontando Configuracoes para `/configuracoes`.
- Confirmado que a navegacao secundaria marca o item ativo correto por rota.
- Confirmado que os cards `Colecao` e `Modelo` tem espacamento adequado.
- Confirmado que o bloco `Pre-visualizacao do Caminho` esta alinhado.
- Confirmado que o botao `Salvar Alteracoes` esta integrado ao layout.
- Confirmado que a responsividade das paginas de Configuracoes foi revisada.
- Confirmado que nenhuma criacao real de pastas foi implementada.
- Confirmado que nenhuma persistencia real foi implementada.
- Confirmado que nenhuma area removida foi reintroduzida.
- Confirmado que nenhum HTML, imagem ou `design.md` do Stitch foi alterado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## aprovacao visual manual

A tela Modelo de Pastas e os ajustes de responsividade das paginas de Configuracoes foram validados visualmente pelo usuario e estao aprovados.

## proxima etapa sugerida

Implementar Backup/Dados com base em:

```txt
referencias-visuais/stitch/html/18-backup-dados.html
```
