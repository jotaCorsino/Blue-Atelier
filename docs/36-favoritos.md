# favoritos

## objetivo

Registrar a implementacao da tela Favoritos no Blue Atelier, consolidando a area visual para itens marcados pelo usuario e a barra de links favoritos inspirada na barra de favoritos do Google Chrome.

## referencia visual usada

A tela foi implementada com base em:

```txt
referencias-visuais/stitch/html/12-favoritos.html
referencias-visuais/stitch/design.md
```

A referencia do Stitch foi traduzida para Razor Components e CSS proprio, respeitando a paleta clean, moderna, azulada e menos colorida aprovada no app.

## rota implementada

```txt
/favoritos
```

## arquivos alterados ou criados

Implementacao:

- `src/blueatelier.app/Components/Pages/Favoritos.razor`
- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Shared/AppIcon.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/36-favoritos.md`

## estrutura da tela

A tela Favoritos contem:

- cabecalho com titulo, descricao curta e resumo visual;
- acoes visuais gerais da tela;
- barra de links favoritos;
- filtros visuais/provisorios;
- area de favoritos fixados;
- grid de favoritos gerais mockados;
- resumo visual de favoritos.

## barra de links favoritos

A barra de links favoritos foi adicionada como uma area visual compacta logo apos as acoes principais da tela.

Ela representa uma barra inspirada no Chrome, mas adaptada ao visual do Blue Atelier:

- itens organizados da esquerda para a direita;
- quebra automatica de linha quando falta largura;
- links em quadrados grandes;
- quadrados sem borda visivel;
- fundo elevado e discreto;
- hover com transicao suave;
- nenhuma persistencia real;
- nenhuma reordenacao real.

## comportamento visual dos links

Os links da barra:

- aparecem como quadrados grandes, sem nome fixo visivel;
- usam iniciais e formas CSS como favicons mockados;
- usam `title`/tooltip nativo com o nome do link;
- ficam monocromaticos e discretos no estado normal;
- ganham cor, leve escala e sombra sutil no hover;
- podem ter `href` externo simples, mas nao usam servico nativo para abrir navegador.

Links mockados usados:

- YouTube;
- Pinterest;
- ArtStation;
- Thingiverse;
- MyMiniFactory;
- Cults3D;
- Google Drive;
- ChatGPT;
- Vallejo;
- Elegoo.

## comportamento visual das pastas

As pastas da barra:

- aparecem como quadrados;
- exibem nome visivel seguindo a linha do icone;
- mantem visual compacto;
- usam icone SVG inline de pasta;
- podem exibir contagem discreta;
- nao abrem modal real;
- nao contem links reais nesta etapa.

Pastas mockadas usadas:

- Pintura;
- Referencias;
- Impressao 3D;
- Lojas.

## menu de contexto com segundo botao do mouse

A barra possui um menu de contexto visual/provisorio acionado pelo segundo botao do mouse.

O menu:

- usa `@oncontextmenu:preventDefault`;
- aparece no ponto do clique;
- tem fundo elevado, sombra sutil, cantos arredondados e hover discreto;
- fecha automaticamente ao clicar fora dele;
- permanece aberto ao clicar dentro do proprio menu ate uma opcao ser selecionada;
- troca para o novo item ao acionar o botao direito em outro favorito;
- nao executa acoes reais;
- nao persiste nenhuma alteracao.

## acoes mockadas do menu

O menu de contexto exibe:

- Novo link;
- Deletar link;
- Editar link;
- Nova pasta;
- Renomear;
- Alterar favicon;
- Abrir.

Todas as acoes sao apenas visuais/mockadas.

## favoritos gerais mockados

Foram usados favoritos mockados para representar diferentes tipos de item:

- `Cthulhu Idol`;
- `Eldritch Horrors`;
- `Main reference`;
- `Dark Paint Guide`;
- `cthulhu-idol.stl`;
- `Abyssal Statue`;
- `Stone texture`;
- `Inspiration Board`.

## navegacoes visuais habilitadas

Alguns favoritos apontam para telas reais ja existentes:

- `Cthulhu Idol` navega para `/colecoes/eldritch-horrors/modelos/cthulhu-idol`;
- `Eldritch Horrors` navega para `/colecoes/eldritch-horrors`;
- `Main reference` navega para `/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria/main-reference`;
- `cthulhu-idol.stl` navega para `/colecoes/eldritch-horrors/modelos/cthulhu-idol/arquivos`.

Itens sem tela real permanecem como affordance visual.

## o que ainda e provisorio

- favoritos sao dados mockados;
- filtros sao apenas visuais;
- acoes gerais nao executam logica real;
- menu de contexto nao cria, edita, remove ou abre itens de verdade;
- links da barra nao possuem persistencia;
- pastas nao possuem conteudo real;
- ordem dos links nao e salva;
- favicons sao simulados por CSS/iniciais.

## o que ainda nao foi implementado

- favoritos reais;
- persistencia;
- banco de dados;
- EF Core;
- migrations;
- servicos reais;
- drag and drop real;
- edicao real;
- download automatico de favicon;
- abertura nativa via servico;
- sistema de arquivos real.

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
- Confirmado que `referencias-visuais/stitch/html/12-favoritos.html` foi usado como referencia.
- Confirmado que `/favoritos` abre corretamente.
- Confirmado que a sidebar navega para `/favoritos`.
- Confirmado que Favoritos aparece como tela visual/mockada.
- Confirmado que a barra de links favoritos aparece na tela Favoritos.
- Confirmado que links aparecem como quadrados grandes, sem nome fixo visivel.
- Confirmado que pastas exibem nome visivel seguindo a linha do icone.
- Confirmado que quadrados nao possuem borda visivel.
- Confirmado que o hover monocromatico/colorido foi preservado.
- Confirmado que o menu de contexto aparece com segundo botao do mouse.
- Confirmado que o menu de contexto fecha ao clicar fora dele.
- Confirmado que o clique dentro do menu nao fecha o menu indevidamente.
- Confirmado que as acoes do menu sao mockadas.
- Confirmado que nenhuma area removida foi reintroduzida.
- Confirmado que nenhum HTML, imagem ou `design.md` do Stitch foi alterado.
- Confirmado que nenhuma funcionalidade real foi implementada.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## aprovacao visual manual

A tela Favoritos e a barra de links favoritos foram validadas visualmente pelo usuario e estao aprovadas.

## proxima etapa sugerida

Implementar a tela Busca com base em:

```txt
referencias-visuais/stitch/html/13-busca.html
```
