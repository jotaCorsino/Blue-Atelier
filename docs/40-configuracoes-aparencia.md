# configuracoes de aparencia

## objetivo

Registrar a implementacao da tela Configuracoes de Aparencia no Blue Atelier, consolidando uma area visual/mockada para preferencias de tema, cor de destaque e densidade visual sem aplicar tema real, salvar preferencias ou implementar persistencia.

## referencia visual usada

A tela foi implementada com base em:

```txt
referencias-visuais/stitch/html/16-configuracoes-aparencia.html
referencias-visuais/stitch/imagens/16-configuracoes-aparencia.png
referencias-visuais/stitch/design.md
```

A implementacao tambem preserva a paleta clean/azulada aprovada do Blue Atelier e o padrao visual das telas de Configuracoes ja validadas.

## rota implementada

```txt
/configuracoes/aparencia
```

As rotas abaixo continuam preservadas:

```txt
/configuracoes
/configuracoes/caminhos
```

## arquivos alterados ou criados

Implementacao:

- `src/blueatelier.app/Components/Pages/ConfiguracoesAparencia.razor`
- `src/blueatelier.app/Components/Pages/Configuracoes.razor`
- `src/blueatelier.app/Components/Pages/ConfiguracoesCaminhos.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/38-configuracoes-gerais.md`
- `docs/39-configuracoes-caminhos.md`
- `docs/40-configuracoes-aparencia.md`

## estrutura da tela

A tela Configuracoes de Aparencia contem:

- cabecalho com titulo `Aparencia` e descricao curta;
- navegacao secundaria de Configuracoes;
- painel `Tema`;
- cards de tema `Claro`, `Escuro` e `Automatico`;
- painel `Densidade da Interface`;
- opcoes visuais `Padrao` e `Compacto`;
- painel `Cor de Destaque`;
- swatches de cor;
- acoes visuais `Cancelar` e `Salvar Alteracoes`.

## organizacao da navegacao secundaria

A navegacao secundaria do modulo de Configuracoes foi padronizada:

- `Geral` aponta para `/configuracoes`;
- `Caminhos` aponta para `/configuracoes/caminhos`;
- `Aparencia` aponta para `/configuracoes/aparencia`;
- `Backup` permanece visual/mockado ou futuro;
- `Modelo de Pastas` permanece visual/mockado ou futuro;
- `Dados do App` permanece visual/mockado ou futuro.

Em `/configuracoes`, o item ativo e `Geral`.

Em `/configuracoes/caminhos`, o item ativo e `Caminhos`.

Em `/configuracoes/aparencia`, o item ativo e `Aparencia`.

## padronizacao de layout

As paginas de Configuracoes agora seguem o mesmo esqueleto visual:

- header comum;
- navegacao secundaria fixa a esquerda em telas largas;
- conteudo principal a direita;
- titulo, descricao, navegacao secundaria e conteudo principal alinhados entre paginas;
- mesmo espacamento entre header, navegacao e conteudo;
- mesma largura da navegacao secundaria;
- mesmo padrao de item ativo por rota.

Essa padronizacao foi aplicada em:

```txt
/configuracoes
/configuracoes/caminhos
/configuracoes/aparencia
```

## secoes implementadas

Foram implementadas visualmente:

- `Tema`;
- `Densidade da Interface`;
- `Cor de Destaque`;
- barra final de acoes visuais.

## controles visuais/mockados

Os controles implementados sao apenas affordances visuais:

- cards de tema;
- radios visuais;
- seletor de densidade;
- swatches de cor;
- botao `Restaurar Padrao`;
- botoes `Cancelar` e `Salvar Alteracoes`.

Nenhum controle aplica tema real, altera tokens, salva preferencias ou persiste dados.

## temas visuais/mockados

Os temas exibidos sao:

- `Claro`;
- `Escuro`;
- `Automatico`.

Eles mostram uma previa visual mockada da interface, mas nao alteram o tema real do app.

## cores de destaque/mockadas

A tela exibe swatches mockados para validar o comportamento visual do seletor de cor. A selecao e apenas visual e nao altera `tokens.css`, `themes.css` ou qualquer configuracao real.

## densidade visual/mockada

A tela exibe opcoes mockadas de densidade:

- `Padrao`;
- `Compacto`.

Essas opcoes nao alteram layout real, espacamentos globais ou preferencia persistida.

## previa visual da interface

Os cards de tema contem uma pequena previa visual da interface, reproduzindo a ideia da referencia Stitch sem usar imagens remotas e sem aplicar comportamento real.

## fidelidade ao Stitch

A tela segue a composicao principal da referencia:

- cabecalho da area de Aparencia;
- cards de tema com preview;
- painel lateral de densidade;
- secao ampla de cor de destaque;
- swatches circulares;
- acoes inferiores.

A adaptacao feita foi inserir a tela no esqueleto padronizado do modulo de Configuracoes, mantendo a navegacao secundaria consistente com Configuracoes Gerais e Configuracoes de Caminhos.

## o que ainda e provisorio

- temas exibidos;
- densidade visual;
- swatches de cor;
- botao de restaurar padrao;
- acoes de cancelar e salvar;
- previa visual dos temas.

## o que ainda nao foi implementado

- aplicacao real de tema;
- alteracao real de tokens;
- alteracao real de `themes.css`;
- salvamento real de preferencias;
- persistencia;
- banco de dados;
- EF Core;
- migrations;
- servicos reais;
- APIs nativas.

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
- Confirmado que `referencias-visuais/stitch/html/16-configuracoes-aparencia.html` foi usado como referencia.
- Confirmado que `referencias-visuais/stitch/imagens/16-configuracoes-aparencia.png` foi usada como referencia visual.
- Confirmado que `/configuracoes` abre Configuracoes Gerais.
- Confirmado que `/configuracoes/caminhos` abre Configuracoes de Caminhos.
- Confirmado que `/configuracoes/aparencia` abre Configuracoes de Aparencia.
- Confirmado que a sidebar principal continua apontando Configuracoes para `/configuracoes`.
- Confirmado que a topbar reconhece rotas iniciadas por `configuracoes`.
- Confirmado que a navegacao secundaria usa `Geral -> /configuracoes`.
- Confirmado que a navegacao secundaria usa `Caminhos -> /configuracoes/caminhos`.
- Confirmado que a navegacao secundaria usa `Aparencia -> /configuracoes/aparencia`.
- Confirmado que o item ativo muda corretamente por rota.
- Confirmado que titulo, descricao, navegacao secundaria e conteudo principal estao alinhados nas telas de Configuracoes.
- Confirmado que nenhuma preferencia real foi implementada.
- Confirmado que nenhuma persistencia real foi implementada.
- Confirmado que nenhuma area removida foi reintroduzida.
- Confirmado que nenhum HTML, imagem ou `design.md` do Stitch foi alterado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## aprovacao visual manual

A tela Configuracoes de Aparencia e a padronizacao visual entre as paginas de Configuracoes foram validadas visualmente pelo usuario e estao aprovadas.

## proxima etapa sugerida

Implementar Modelo de Pastas com base em:

```txt
referencias-visuais/stitch/html/17-modelo-pastas.html
```
