# blue atelier - referencias visuais do stitch

## 1. objetivo do documento

Este documento cataloga as referencias visuais exportadas do Stitch para o **Blue Atelier**.

Ele registra quais arquivos foram encontrados, qual papel cada tipo de arquivo deve cumprir e quais regras devem proteger a direcao visual aprovada.

Este documento nao cria codigo, projeto .NET, Razor Components, CSS final ou telas reais. Ele serve como ponte entre a aprovacao visual feita no Stitch e a implementacao futura em .NET MAUI Blazor Hybrid.

## 2. localizacao da pasta de referencias visuais

A pasta oficial de referencias visuais do Stitch esta em:

```txt
referencias-visuais/stitch/
```

Estrutura encontrada:

```txt
referencias-visuais/stitch/
├── anotacoes/
│   └── direcao-visual-aprovada.md
├── html/
├── imagens/
├── design.md
└── readme.md
```

## 3. regra de protecao visual

Os arquivos exportados do Stitch sao referencia visual aprovada.

O Codex pode ler, catalogar e usar esses arquivos como base de interpretacao visual.

O Codex nao pode:

- alterar os HTMLs exportados;
- reescrever os HTMLs exportados;
- alterar imagens exportadas;
- redesenhar a interface por conta propria;
- mudar cores, espacamentos, cards, botoes, filtros, listas, navegacao ou densidade visual sem autorizacao;
- transformar a proposta em dashboard corporativo;
- simplificar ou desfigurar a proposta visual aprovada.

Qualquer alteracao visual futura precisa de autorizacao explicita do usuario.

## 4. papel do arquivo design.md ou DESIGN.md

O arquivo encontrado foi:

```txt
referencias-visuais/stitch/design.md
```

Em sistemas Windows, `design.md` e `DESIGN.md` podem ser tratados como o mesmo arquivo por causa da insensibilidade a maiusculas e minusculas. A referencia real presente na pasta e `design.md`.

Esse arquivo contem informacoes importantes sobre:

- nome da direcao visual: **Artisanal Digital Atelier**;
- paleta de cores;
- uso do azul como destaque;
- superficies claras, neutras e confortaveis;
- tipografia Inter;
- espacamento;
- largura da navegacao lateral;
- raio de borda;
- cards;
- botoes;
- busca;
- barras de progresso;
- sombra e profundidade.

O `design.md` deve orientar a preservacao do estilo quando as telas forem convertidas futuramente para Razor Components.

## 5. papel dos HTMLs exportados

Os HTMLs em `referencias-visuais/stitch/html/` sao referencias visuais aprovadas de tela.

Eles devem ser usados para observar:

- composicao geral;
- hierarquia visual;
- navegacao lateral;
- barra superior;
- cards e mosaicos;
- listas e tabelas;
- botoes;
- filtros;
- busca;
- estados especiais;
- temas claro e escuro;
- densidade da interface.

Eles nao devem ser tratados como implementacao final nem como codigo definitivo do app.

A implementacao futura deve traduzir a intencao visual para .NET MAUI Blazor Hybrid, Razor Components e CSS proprio, sem copiar dependencias temporarias de prototipo como CDN, Tailwind de exportacao, Font Awesome ou imagens remotas do Stitch.

## 6. papel das imagens exportadas

As imagens em `referencias-visuais/stitch/imagens/` sao capturas visuais aprovadas.

Elas devem ser usadas para comparacao visual durante a implementacao futura.

As imagens ajudam a validar:

- proporcao das telas;
- composicao;
- peso visual;
- relacao entre sidebar, topo e conteudo;
- aparencia dos cards;
- espacamento;
- estados;
- uso de cor;
- consistencia geral.

As imagens nao devem ser alteradas, comprimidas, redesenhadas ou substituidas sem autorizacao.

## 7. lista de telas encontradas em referencias-visuais/stitch/html/

Arquivos encontrados:

```txt
01-inicio.html
02-colecoes.html
03-detalhe-colecao.html
04-detalhe-modelo.html
05-galeria-modelo.html
06-visualizacao-imagem.html
07-arquivos-vinculados.html
08-fila-impressao.html
09-arquivos-recentes.html
10-materiais.html
11-detalhe-material.html
12-favoritos.html
13-busca-global.html
14-configuracoes-gerais.html
15-configuracoes-caminhos.html
16-configuracoes-aparencia.html
17-modelo-pastas.html
18-backup-dados.html
19-estados-vazios-erros-offline.html
```

Catalogo das telas:

| arquivo | tela representada | papel visual |
| --- | --- | --- |
| `01-inicio.html` | inicio / dashboard do atelier | referencia da tela inicial, sidebar, busca, colecoes recentes, modelos em andamento, itens prontos e aviso de caminho de rede offline |
| `02-colecoes.html` | colecoes | referencia de mosaico de colecoes, filtros por status e acao de nova colecao |
| `03-detalhe-colecao.html` | detalhe da colecao | referencia de cabecalho visual de colecao, tags, botoes de acao, grid de modelos e painel lateral |
| `04-detalhe-modelo.html` | detalhe do modelo | referencia de pagina detalhada de modelo, metadados, imagem principal e secoes relacionadas |
| `05-galeria-modelo.html` | galeria do modelo | referencia de galeria visual em mosaico |
| `06-visualizacao-imagem.html` | visualizacao de imagem | referencia de visualizador focado, com imagem grande e acoes discretas |
| `07-arquivos-vinculados.html` | arquivos vinculados | referencia de organizacao de arquivos por categorias e acoes de arquivo |
| `08-fila-impressao.html` | fila de impressao | referencia de lista operacional, cards de resumo, status e acoes por item |
| `09-arquivos-recentes.html` | arquivos recentes | referencia de lista visual de arquivos acessados recentemente |
| `10-materiais.html` | materiais | referencia de catalogo de materiais com busca, categorias e cards |
| `11-detalhe-material.html` | detalhe de material | referencia de detalhe com informacoes, modelos relacionados e historico |
| `12-favoritos.html` | favoritos globais | referencia de area de favoritos com cards e filtros |
| `13-busca-global.html` | busca global | referencia de resultados agrupados e busca ampla |
| `14-configuracoes-gerais.html` | configuracoes gerais | referencia de tela de configuracoes com secoes de caminhos, rede, aparencia e programas |
| `15-configuracoes-caminhos.html` | caminhos locais e rede | referencia de configuracao e status de caminhos locais/rede |
| `16-configuracoes-aparencia.html` | aparencia | referencia de opcoes de tema, densidade e preferencias visuais |
| `17-modelo-pastas.html` | modelo padrao de pastas | referencia de configuracao de estrutura de pastas |
| `18-backup-dados.html` | backup e dados | referencia de backup manual, exportacao, importacao e restauracao |
| `19-estados-vazios-erros-offline.html` | estados vazios, erros e offline | referencia oficial de estados especiais e alertas |

## 8. lista de imagens encontradas em referencias-visuais/stitch/imagens/

Arquivos encontrados:

```txt
01-inicio.png
02-colecoes.png
03-detalhe-colecao.png
04-detalhe-modelo.png
05-galeria-modelo.png
06-visualizacao-imagem.png
07-arquivos-vinculados.png
08-fila-impressao.png
09-arquivos-recentes.png
10-materiais.png
11-detalhe-material.png
12-favoritos.png
13-busca-global.png
14-configuracoes-gerais.png
15-configuracoes-caminhos.png
16-configuracoes-aparencia.png
17-modelo-pastas.png
18-backup-dados.png
19-estados-vazios-erros-offline.png
```

As imagens correspondem aos HTMLs exportados e devem ser usadas como evidencia visual aprovada para comparacao futura.

## 9. padroes visuais identificados

Padroes recorrentes:

- aparencia de ferramenta pessoal de atelier, nao de sistema administrativo pesado;
- uso de superficies neutras, off-white e branco no tema claro;
- uso de azul apenas como destaque, foco, acao primaria e item ativo;
- tipografia Inter;
- textos pequenos e medios, com hierarquia controlada;
- cards com bordas suaves, sombra leve e sensacao tatil;
- espacamento generoso entre blocos;
- icones como apoio visual para navegacao e acoes;
- estados representados com icones grandes, texto curto e acoes claras;
- feedback visual por chips, badges, pontos de status e barras de progresso;
- interface com densidade confortavel, sem ficar vazia demais.

## 10. padroes de navegacao identificados

A navegacao principal usa sidebar lateral fixa com largura aproximada de 260px.

Itens recorrentes:

- Inicio / Home;
- Colecoes / Collections;
- Modelos / Models;
- Fila de Impressao / Print Queue;
- Arquivos Recentes / Recent Files;
- Materiais / Materials;
- Favoritos / Favorites;
- Buscar / Search;
- Configuracoes / Settings.

Padroes importantes:

- item ativo destacado por fundo suave e marca azul lateral ou icone azul;
- separacao visual entre areas principais e busca/configuracoes em algumas telas;
- barra superior discreta com busca, status, notificacoes, usuario ou acoes contextuais;
- em algumas telas ha barra de titulo simulando app Windows;
- a hierarquia visual favorece sidebar + conteudo principal rolavel.

## 11. padroes de layout identificados

O layout aprovado segue um modelo fixo-fluido:

- sidebar fixa;
- conteudo principal flexivel;
- margem de pagina generosa;
- gutter recorrente entre cards;
- largura maxima em telas com conteudo mais denso;
- rolagem interna no conteudo principal;
- cabecalhos de pagina com titulo, subtitulo e acoes;
- paineis laterais em telas de detalhe;
- grades responsivas para colecoes, modelos, galeria, materiais e favoritos;
- listas estruturadas para arquivos, fila e configuracoes.

## 12. padroes de cards/mosaicos identificados

Cards e mosaicos sao parte central da identidade visual do Blue Atelier.

Padroes identificados:

- cards de colecao e modelo com imagem no topo;
- imagens geralmente em proporcao 16:9 ou quadrada, conforme contexto;
- metadados na parte inferior do card;
- badges de status;
- tags discretas;
- barras de progresso pequenas;
- hover com sombra, borda ou leve escala da imagem;
- bordas arredondadas;
- cards brancos ou em superficie elevada no tema claro;
- cards escuros no tema escuro, mantendo contraste suave.

A implementacao futura deve preservar a sensacao de mosaico visual inspirada em Pinterest, Instagram e albuns de fotos.

## 13. padroes de listas/tabelas identificados

Listas e tabelas aparecem principalmente em:

- fila de impressao;
- arquivos recentes;
- arquivos vinculados;
- materiais relacionados;
- historico de uso;
- backup e dados;
- configuracoes.

Padroes identificados:

- linhas com thumbnail ou icone;
- nome principal em destaque;
- metadados secundarios menores;
- chips de status;
- acoes por linha com icones;
- estrutura visual tipo tabela sem peso corporativo;
- separadores leves;
- cabecalho de lista discreto;
- uso de grids para alinhar colunas sem parecer planilha pesada.

## 14. padroes de botoes e acoes

Padroes identificados:

- botao primario azul com texto branco;
- botoes secundarios neutros, brancos ou azul muito claro;
- botoes de acao com icone e texto;
- botoes de toolbar frequentemente apenas com icone;
- cantos arredondados;
- sombras leves em acoes principais;
- hover discreto;
- acoes perigosas em vermelho apenas quando necessario;
- acoes de retorno e abertura de pasta aparecem como botoes secundarios.

O azul deve continuar reservado para acoes principais, foco e selecao.

## 15. padroes de filtros e busca

Padroes identificados:

- campo de busca na barra superior;
- busca local em telas operacionais;
- placeholder recorrente para modelos, impressoes e materiais;
- filtros em formato de pills;
- filtro ativo com fundo azul e texto branco;
- filtros inativos com fundo neutro, borda leve e texto secundario;
- foco do campo de busca com borda ou anel azul.

A busca deve parecer parte natural da ferramenta, nao um bloco pesado de formulario.

## 16. padroes de estados vazios, erro e offline

O arquivo `19-estados-vazios-erros-offline.html` e a referencia principal para estados especiais.

Padroes identificados:

- estado vazio com icone grande, texto direto e CTA primario;
- erro com borda ou fundo em tom de erro, icone e acoes de recuperacao;
- offline tratado como condicao normal, com botao de reconectar ou aviso discreto;
- alertas inline para sucesso, aviso e informacao;
- estados especiais nao devem travar o app nem esconder dados importantes;
- arquivos ausentes e caminhos offline devem continuar visiveis para correcao futura.

## 17. padroes de tema claro

O tema claro e predominante nas referencias.

Padroes principais:

- fundo geral off-white;
- superficies elevadas brancas;
- bordas cinza claras;
- texto principal escuro;
- texto secundario cinza;
- sombras suaves;
- azul apenas em destaque, foco, acao e selecao;
- green/sage para sucesso ou concluido;
- amber para aviso;
- vermelho para erro.

O tema claro deve permanecer confortavel para uso diario e organizacao visual prolongada.

## 18. padroes de tema escuro

Ha referencias de tema escuro, especialmente na tela inicial e em varias telas com suporte `darkMode`.

Padroes identificados:

- fundo escuro neutro;
- sidebar mais escura que o conteudo;
- cards em cinza escuro;
- bordas discretas;
- texto claro com secundarios em cinza;
- azul preservado como destaque;
- contrastes suaves, sem neon e sem excesso de saturacao.

O tema escuro deve ser tratado como equivalente visual do tema claro, nao como redesign separado.

## 19. regras para implementacao futura em Razor Components

Quando a fase de implementacao for autorizada:

1. Usar os HTMLs e imagens como referencia visual protegida.
2. Usar `design.md` como fonte de tokens visuais e decisoes de estilo.
3. Traduzir a estrutura para Razor Components sem copiar o HTML exportado como implementacao final.
4. Criar componentes reutilizaveis apenas quando isso preservar melhor a consistencia visual.
5. Preservar sidebar, barra superior, grids, cards, listas, filtros, busca e estados conforme as referencias.
6. Adaptar textos, dados e caminhos para o app real sem mudar a composicao visual aprovada.
7. Evitar dependencias externas de prototipo usadas nos HTMLs do Stitch.
8. Usar CSS proprio do projeto quando a etapa de CSS for autorizada.
9. Gerar evidencia visual futura por screenshots comparaveis com as imagens exportadas.
10. Registrar qualquer diferenca inevitavel antes de considerar a tela concluida.

## 20. limites do que o Codex podera ajustar futuramente

Com autorizacao para implementacao, o Codex podera ajustar:

- nomes tecnicos de componentes Razor;
- organizacao interna de arquivos do projeto;
- dados ficticios para dados reais;
- pequenos textos para portugues consistente;
- acessibilidade basica;
- responsividade necessaria para janelas Windows;
- detalhes tecnicos exigidos por .NET MAUI Blazor Hybrid;
- composicao de componentes, desde que o resultado visual permaneca fiel.

Esses ajustes nao podem mudar a identidade visual aprovada.

## 21. limites do que o Codex nao podera alterar sem autorizacao

O Codex nao podera alterar sem autorizacao explicita:

- paleta de cores;
- uso do azul;
- espacamentos principais;
- largura e comportamento da sidebar;
- comportamento da barra superior;
- estilo de cards;
- estilo de mosaicos;
- formato dos filtros;
- densidade da interface;
- bordas e cantos arredondados;
- sombras;
- hierarquia visual;
- estilo de estados vazios, erro e offline;
- proposta de tema claro;
- proposta de tema escuro;
- arquivos HTML exportados;
- imagens exportadas;
- `design.md`.

## 22. checklist para validar se uma tela implementada respeita o Stitch

Antes de aprovar uma tela implementada, verificar:

- A tela corresponde ao HTML exportado equivalente.
- A captura da tela implementada foi comparada com a imagem exportada equivalente.
- Sidebar, barra superior e conteudo principal mantem a mesma hierarquia.
- O azul continua sendo apenas destaque e acao.
- Cards e mosaicos preservam proporcao, borda, sombra e espacamento.
- Listas e tabelas continuam leves e visuais, sem aparencia corporativa pesada.
- Filtros e busca mantem formato, foco e comportamento visual previstos.
- Estados vazios, erro e offline seguem `19-estados-vazios-erros-offline.html`.
- Tema claro segue os tons neutros aprovados.
- Tema escuro, quando presente, segue as referencias aprovadas.
- Nenhum HTML exportado foi reescrito.
- Nenhuma imagem exportada foi alterada.
- Nenhuma decisao visual foi reinterpretada sem autorizacao.
- Diferencas tecnicas inevitaveis foram documentadas.
- A tela possui evidencia visual futura antes de ser considerada concluida.
