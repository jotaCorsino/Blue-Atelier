# blue atelier — design system

## 1. objetivo do documento

Este documento define a linguagem visual oficial do **Blue Atelier**.

O design system deve orientar a criação futura das telas, componentes, mosaicos, cards, formulários, temas e estados visuais do app.

Este documento não cria CSS real, componentes Razor, projeto .NET ou telas implementadas. Ele define diretrizes visuais para implementação futura.

## 2. princípios visuais

O Blue Atelier deve ser:

- moderno;
- minimalista;
- visual;
- confortável para uso diário;
- pessoal e acolhedor;
- organizado sem parecer burocrático;
- neutro, com azul usado apenas como destaque;
- funcional para rotina de atelier;
- adequado para uso prolongado em tema claro e escuro.

O app deve lembrar uma biblioteca visual de projetos, não um painel administrativo pesado.

As telas devem equilibrar:

- imagens e mosaicos para reconhecimento visual;
- listas e tabelas apenas quando forem úteis;
- formulários simples e diretos;
- ações claras;
- pouco ruído visual;
- boa legibilidade.

## 3. personalidade visual do Blue Atelier

A personalidade visual deve transmitir:

- calma;
- cuidado artesanal;
- organização criativa;
- confiança;
- foco visual;
- simplicidade;
- precisão sem rigidez.

Referências de sensação:

- Pinterest privado, pela organização visual em mosaicos.
- Instagram e álbuns de fotos, pelo destaque para imagens.
- Ferramenta pessoal de atelier, pela utilidade e presença de arquivos, materiais e fila.

O app não deve parecer:

- sistema corporativo pesado;
- dashboard de vendas;
- planilha fantasiada;
- landing page;
- catálogo comercial;
- ferramenta cheia de efeitos decorativos.

## 4. paleta de cores oficial

A paleta oficial deve ser predominantemente neutra, com azul como destaque.

### neutros claros

```txt
fundo claro: #f7f7f5
superfície clara: #ffffff
superfície sutil clara: #f1f2f0
borda clara: #dedfdc
texto principal claro: #171717
texto secundário claro: #5f6368
texto fraco claro: #8a8a8a
```

### neutros escuros

```txt
fundo escuro: #101114
superfície escura: #1a1c20
superfície sutil escura: #23262b
borda escura: #33363d
texto principal escuro: #f2f2f2
texto secundário escuro: #b8bcc4
texto fraco escuro: #8a8f98
```

### destaque

```txt
azul destaque: #3b82f6
azul destaque suave claro: #dbeafe
azul destaque suave escuro: #17345f
```

### apoio visual

```txt
verde sucesso: #22c55e
amarelo atenção: #f59e0b
vermelho erro: #ef4444
cinza neutro: #6b7280
roxo referência: #8b5cf6
ciano informação: #06b6d4
```

As cores de apoio devem ser usadas com moderação. Elas servem para status, feedback e categorias, não para dominar a interface.

## 5. tema claro

O tema claro deve ser limpo, suave e confortável.

Diretrizes:

- Fundo geral em tom claro levemente quente.
- Cards e superfícies principais em branco ou quase branco.
- Bordas discretas.
- Texto principal com contraste forte.
- Texto secundário em cinza.
- Azul usado apenas para ações, links, foco e seleção.
- Sombras leves, quase imperceptíveis.

Uso esperado:

- leitura prolongada;
- organização visual de coleções;
- edição de dados;
- uso diário em ambiente iluminado.

O tema claro não deve parecer branco puro demais nem frio demais.

## 6. tema escuro

O tema escuro deve ser confortável, moderno e sem contraste agressivo.

Diretrizes:

- Fundo geral em cinza muito escuro, não preto absoluto.
- Cards em superfície um pouco mais clara que o fundo.
- Bordas discretas para separar áreas.
- Texto principal claro, sem branco estourado.
- Texto secundário em cinza claro.
- Azul em destaque moderado.
- Estados de erro e sucesso devem ser legíveis sem saturação excessiva.

Uso esperado:

- trabalho à noite;
- revisão visual de imagens;
- uso prolongado com baixa fadiga.

O tema escuro não deve transformar todo o app em uma paleta azul escura. Ele deve continuar neutro.

## 7. uso da cor azul de destaque

O azul é a cor de identidade funcional do Blue Atelier.

Usar azul para:

- botão principal;
- item ativo da navegação;
- foco de campo;
- links;
- ação selecionada;
- badge de destaque;
- indicador de seleção;
- pequenos ícones de ação importante.

Evitar azul em:

- grandes fundos;
- cards inteiros;
- mosaicos inteiros;
- áreas decorativas;
- gradientes grandes;
- textos longos;
- todos os ícones ao mesmo tempo.

Regra geral:

O azul deve ajudar o usuário a entender onde agir. Ele não deve virar a cor dominante da tela.

## 8. cores de status

As cores de status devem ser consistentes entre coleções, modelos, fila e caminhos.

### status neutros

```txt
ideia: cinza
pesquisando: ciano
estruturando: roxo
pausada: cinza
arquivada: cinza fraco
```

### produção

```txt
em produção: azul
pronto para fatiar: ciano
fatiado: roxo
enviado para impressão: azul
imprimindo: amarelo
impresso: verde
em preparação: amarelo
em pintura: roxo
finalizado: verde
fotografado: verde
```

### erro ou atenção

```txt
falhou: vermelho
arquivo ausente: vermelho
caminho offline: amarelo
sem configuração: amarelo
cancelado: cinza
```

Diretrizes:

- Status deve combinar cor, texto e, quando possível, ícone.
- Cor sozinha não deve ser a única forma de comunicar o estado.
- Badges devem ser discretos e legíveis.

## 9. tipografia

A tipografia deve usar fontes do sistema Windows.

Fonte preferencial:

```txt
Segoe UI Variable
```

Fallback:

```txt
Segoe UI
```

Diretrizes:

- Usar tipografia simples e legível.
- Evitar fontes decorativas.
- Evitar peso excessivo em muitas áreas.
- Reservar títulos grandes para telas principais.
- Usar texto menor e mais denso em tabelas e metadados.
- Não usar espaçamento negativo entre letras.
- Não escalar fonte diretamente pela largura da viewport.

Escala sugerida:

```txt
título de página: 28px a 32px
título de seção: 20px a 24px
título de card: 15px a 17px
texto padrão: 14px a 16px
texto secundário: 13px a 14px
metadados: 12px a 13px
legendas pequenas: 11px a 12px
```

Esses tamanhos podem ser ajustados na implementação se houver necessidade real, desde que a legibilidade seja preservada.

## 10. escala de espaçamentos

O espaçamento deve ser consistente e calmo.

Escala base sugerida:

```txt
4px
8px
12px
16px
20px
24px
32px
40px
48px
64px
```

Uso recomendado:

- `4px`: separações pequenas entre ícone e texto.
- `8px`: espaço interno compacto.
- `12px`: espaço entre elementos próximos.
- `16px`: padding padrão de cards e blocos.
- `24px`: espaço entre seções.
- `32px`: separação de grupos grandes.
- `48px` ou mais: respiro entre áreas principais.

Diretrizes:

- Mosaicos precisam de espaçamento suficiente para respirar.
- Formulários devem ter grupos claros.
- Listas e tabelas podem ser mais densas, mas não apertadas.

## 11. bordas e cantos arredondados

O app deve usar cantos suaves, sem exagero.

Diretrizes:

- Cards principais: até `8px`.
- Botões e campos: `6px` a `8px`.
- Badges e tags: `6px` a `999px`, conforme o formato final aprovado.
- Imagens em mosaico: `6px` a `8px`.
- Modais ou painéis destacados: até `8px`.

Evitar:

- cantos muito arredondados em todos os elementos;
- aparência de interface infantil;
- cards dentro de cards;
- excesso de molduras decorativas.

## 12. sombras e profundidade

Sombras devem ser sutis.

Uso permitido:

- destacar cards interativos;
- separar menu ou barra superior, se necessário;
- indicar painel flutuante;
- criar leve profundidade em modais.

Evitar:

- sombras pesadas;
- múltiplas camadas de sombra;
- aparência de cartões promocionais;
- profundidade exagerada em todos os elementos.

No tema escuro, sombras devem ser substituídas com frequência por bordas e variação de superfície.

## 13. layout geral

O layout geral deve ter:

- navegação lateral;
- barra superior;
- conteúdo principal;
- áreas visuais em mosaico;
- seções bem separadas;
- largura útil confortável para desktop;
- boa adaptação para janelas redimensionadas.

Diretrizes:

- A tela inicial deve parecer um painel do atelier.
- Coleções e modelos devem ser visualmente dominantes.
- Configurações devem ser organizadas por seções.
- Formulários devem ser claros e sem excesso de campos visíveis ao mesmo tempo.
- Áreas técnicas devem ser úteis, mas discretas.

Evitar:

- layout de landing page;
- hero gigante desnecessário;
- cards aninhados;
- painéis decorativos sem função;
- excesso de blocos coloridos.

## 14. navegação lateral

A navegação lateral deve ser estável e clara.

Itens previstos:

```txt
início
coleções
modelos
fila de impressão
arquivos recentes
materiais
favoritos
busca
configurações
```

Diretrizes:

- Item ativo com indicação visual clara.
- Ícones simples acompanhados de texto.
- Espaçamento confortável.
- Separação sutil entre áreas principais e configurações, se necessário.
- Sem muitos níveis aninhados.

Comportamento visual:

- O item ativo pode usar azul com fundo suave.
- Itens inativos devem ser neutros.
- Hover deve ser discreto.
- Alertas podem aparecer como pequeno indicador, não como bloco chamativo.

## 15. barra superior

A barra superior deve apoiar contexto, busca e ações.

Conteúdo possível:

- título da tela atual;
- breadcrumb curto, quando útil;
- campo ou botão de busca global;
- ação principal da tela;
- alerta de rede offline;
- acesso a favoritos rápidos, se não estiver em outro lugar.

Diretrizes:

- Deve ser funcional, não decorativa.
- Deve manter altura moderada.
- Não deve competir com conteúdo visual.
- A ação principal deve ser fácil de encontrar.

Exemplos:

- em coleções: título, busca local, botão de nova coleção;
- em detalhe do modelo: voltar, título, editar, abrir pasta;
- em configurações: título da seção e salvar quando aplicável.

## 16. barra rápida de favoritos

A barra rápida de favoritos deve ser um acesso leve aos itens mais usados.

Diretrizes:

- Deve mostrar poucos itens.
- Deve usar títulos curtos.
- Deve diferenciar link externo de item interno.
- Deve ter acesso à página completa de favoritos.
- Deve lidar bem com estado vazio.

Visual esperado:

- neutro;
- discreto;
- com ícones simples;
- sem ocupar área demais.

O local definitivo da barra será validado quando as telas forem desenhadas.

## 17. cards de coleção

Cards de coleção são elementos centrais do app.

Conteúdo esperado:

- imagem de capa;
- título;
- status;
- número de modelos;
- tags principais;
- data de atualização, se útil;
- indicador de favorito, se aprovado;
- indicador de pasta vinculada, quando relevante.

Diretrizes:

- A imagem deve dominar o card.
- O título deve ser legível.
- Metadados devem ser discretos.
- Status deve aparecer como badge pequeno.
- Card sem capa deve ter placeholder neutro e elegante.

Interação:

- clique principal abre detalhe da coleção;
- ações secundárias devem ser discretas;
- hover deve indicar interatividade sem exagero.

## 18. cards de modelo

Cards de modelo devem ajudar a reconhecer miniaturas rapidamente.

Conteúdo esperado:

- capa;
- título;
- coleção de origem;
- status de produção;
- tags principais;
- escala, quando houver;
- indicador de arquivo pronto, se aplicável.

Diretrizes:

- A capa deve ser mais importante que os metadados.
- Status de produção deve ser claro.
- O card deve funcionar bem em mosaicos.
- Modelo sem capa deve ter placeholder neutro.

Interação:

- clique principal abre detalhe do modelo;
- ações rápidas podem incluir abrir pasta ou enviar para fila, se houver espaço e aprovação visual.

## 19. cards de favoritos

Cards de favoritos devem funcionar como atalhos.

Conteúdo esperado:

- título;
- categoria;
- tipo do favorito;
- descrição curta;
- URL resumida ou destino interno;
- indicador de fixado na barra rápida.

Diretrizes:

- Devem ser simples e rápidos de escanear.
- Links externos e destinos internos devem ser visualmente distinguíveis.
- Não precisam ter imagem obrigatória.
- Podem usar ícones e cores suaves por categoria.

Evitar:

- cards muito grandes;
- texto longo;
- aparência de anúncio.

## 20. mosaicos e galerias

Mosaicos e galerias são parte da identidade do app.

Uso principal:

- coleções;
- modelos;
- imagens de galeria;
- referências visuais;
- fotos finais;
- favoritos visuais, se aprovados.

Diretrizes:

- Imagens devem ter proporção estável.
- Cards não devem mudar de tamanho ao carregar metadados.
- Espaçamento entre itens deve ser consistente.
- Imagens ausentes devem ter placeholder claro.
- Galerias devem permitir reconhecer tipo de imagem.

Tipos de mosaico possíveis:

- grade regular;
- grade responsiva por largura de janela;
- mosaico visual com tamanhos controlados, se aprovado.

O app pode se inspirar em Pinterest e álbuns de fotos, mas deve manter organização e previsibilidade.

## 21. listas e tabelas

Listas e tabelas devem ser usadas quando dados precisam ser comparados.

Uso recomendado:

- arquivos vinculados;
- fila de impressão;
- arquivos recentes;
- caminhos locais;
- caminhos de rede;
- backups;
- materiais em modo denso.

Diretrizes:

- Cabeçalhos claros.
- Linhas com boa altura.
- Ações por linha visíveis, mas discretas.
- Status fácil de escanear.
- Caminhos longos devem ser truncados com opção de copiar.
- Tabelas não devem dominar áreas visuais quando mosaico for mais adequado.

Estados:

- linha com arquivo ausente;
- linha com caminho offline;
- linha selecionada;
- linha com erro;
- linha recém-atualizada.

## 22. formulários

Formulários devem ser simples e calmos.

Uso:

- criar e editar coleção;
- criar e editar modelo;
- material;
- link;
- caminhos;
- tema;
- backup;
- modelo de pastas.

Diretrizes:

- Agrupar campos por assunto.
- Mostrar campos obrigatórios com clareza.
- Evitar formulários longos sem seções.
- Permitir salvar itens incompletos quando fizer sentido.
- Validar antes de salvar.
- Mostrar erros próximos ao campo.
- Evitar linguagem técnica demais.

Campos de caminho devem ter:

- campo de texto;
- botão de selecionar pasta, quando aplicável;
- botão de testar;
- status do último teste.

## 23. botões

Botões devem indicar ação com clareza.

Tipos:

- primário;
- secundário;
- discreto;
- perigo;
- ícone;
- link visual.

Uso:

- primário: ação principal da tela;
- secundário: ação alternativa;
- discreto: ações de apoio;
- perigo: remover, arquivar ou cancelar com impacto;
- ícone: ações recorrentes como abrir pasta, copiar, editar, favoritar.

Diretrizes:

- Não usar azul em todos os botões.
- Botão primário deve ser azul.
- Botão de perigo deve usar vermelho com moderação.
- Botões de ícone devem ter tooltip futuro.
- Ações destrutivas devem exigir confirmação futura.

## 24. campos de busca

Campos de busca devem ser rápidos e fáceis de reconhecer.

Uso:

- busca global;
- busca local em coleções;
- busca local em modelos;
- busca em favoritos;
- busca em materiais;
- busca em arquivos.

Diretrizes:

- Ícone de busca à esquerda.
- Placeholder curto e contextual.
- Botão para limpar quando houver texto.
- Foco visual com azul discreto.
- Resultados devem aparecer rapidamente.

Estados:

- vazio;
- digitando;
- sem resultados;
- erro;
- carregando.

## 25. badges, tags e status

Badges, tags e status devem organizar informação sem poluir.

Badges:

- status de coleção;
- status de modelo;
- status da fila;
- status de caminho;
- tipo de arquivo;
- tipo de imagem.

Tags:

- temas;
- materiais;
- categorias;
- referências;
- estilos.

Diretrizes:

- Badges de status devem ter cor e texto.
- Tags devem ser neutras, com destaque baixo.
- Evitar muitas tags visíveis em cards pequenos.
- Quando houver muitas tags, mostrar poucas e indicar quantidade restante.

## 26. estados vazios

Estados vazios devem orientar o próximo passo.

Exemplos:

- sem coleções: sugerir criar primeira coleção;
- coleção sem modelos: sugerir criar modelo;
- modelo sem galeria: sugerir adicionar imagem;
- sem favoritos: sugerir adicionar link favorito;
- fila vazia: explicar que arquivos prontos aparecerão ali;
- sem materiais: sugerir cadastrar material.

Diretrizes:

- Mensagem curta.
- Tom calmo.
- Ação principal clara.
- Ilustração não é obrigatória.
- Não usar excesso de decoração.

## 27. estados de erro

Erros devem ser claros e úteis.

Tipos:

- erro ao salvar;
- erro ao abrir arquivo;
- erro ao abrir pasta;
- erro de caminho inválido;
- erro de banco;
- erro de backup;
- erro ao importar dados.

Diretrizes:

- Explicar o problema em linguagem simples.
- Sugerir próxima ação.
- Não culpar o usuário.
- Manter detalhes técnicos em área expansível futura, se necessário.
- Usar vermelho com moderação.

Erros críticos devem ser visíveis. Erros menores podem aparecer próximos ao campo ou ação.

## 28. estados offline

Estados offline são esperados para caminhos de rede.

Uso:

- caminho de rede indisponível;
- unidade mapeada desconectada;
- pasta compartilhada inacessível;
- destino da fila indisponível;
- backup em rede indisponível.

Diretrizes:

- Usar amarelo ou cinza com aviso claro.
- Não bloquear o uso local do app.
- Oferecer ação de testar novamente.
- Oferecer atalho para configurações de rede.
- Mostrar último teste quando existir.

Offline deve ser tratado como condição normal, não como falha catastrófica.

## 29. estados de sucesso

Estados de sucesso devem confirmar ações importantes sem atrapalhar.

Exemplos:

- coleção salva;
- modelo salvo;
- arquivo enviado para fila;
- caminho testado com sucesso;
- backup concluído;
- imagem definida como capa.

Diretrizes:

- Usar verde com moderação.
- Preferir mensagens breves.
- Não bloquear fluxo com modal quando não for necessário.
- Permitir desfazer no futuro quando fizer sentido.

## 30. estados de carregamento

Carregamento deve ser discreto e previsível.

Uso:

- abertura inicial;
- busca;
- listagem de arquivos;
- teste de caminho;
- backup;
- importação;
- carregamento de galeria.

Diretrizes:

- Usar skeletons em mosaicos e listas quando possível.
- Usar indicador simples em ações curtas.
- Evitar bloquear a tela inteira sem necessidade.
- Operações longas devem mostrar progresso ou mensagem.

## 31. comportamento visual de arquivos ausentes

Arquivos ausentes devem ser visíveis sem quebrar a tela.

Diretrizes:

- Mostrar indicador de ausente.
- Usar vermelho ou amarelo conforme gravidade.
- Manter nome e caminho do arquivo.
- Oferecer ação futura para localizar novamente, remover vínculo ou abrir pasta pai.
- Não remover vínculo automaticamente.

Em galerias:

- imagem ausente deve mostrar placeholder.
- O mosaico deve manter tamanho estável.
- A ação de definir como capa deve ficar indisponível ou indicar erro.

## 32. comportamento visual de caminhos de rede offline

Caminhos de rede offline devem aparecer como alerta controlado.

Diretrizes:

- Mostrar status `offline` ou `inacessível`.
- Mostrar último teste.
- Oferecer testar novamente.
- Oferecer abrir configurações.
- Não travar tela inicial, fila ou arquivos.
- Evitar alerta vermelho quando for apenas indisponibilidade temporária.

Na fila de impressão:

- destino offline deve impedir cópia até novo teste bem-sucedido.
- O item deve continuar visível.
- A ação deve explicar por que está indisponível.

## 33. ícones

Ícones devem ser simples, lineares e familiares.

Uso recomendado:

- navegação lateral;
- abrir pasta;
- abrir arquivo;
- copiar caminho;
- editar;
- remover;
- favoritar;
- buscar;
- testar caminho;
- enviar para fila;
- status offline;
- backup.

Diretrizes:

- Usar biblioteca de ícones consistente quando a implementação começar.
- Preferir ícones conhecidos em vez de desenhos personalizados.
- Ícones de ação devem ter tooltip futuro.
- Não usar ícones decorativos sem função.
- Não depender apenas do ícone quando a ação for crítica.

## 34. densidade da interface

A densidade deve ser confortável por padrão.

Modos possíveis:

- confortável;
- compacto, se aprovado futuramente.

Diretrizes:

- Mosaicos devem ter respiro.
- Tabelas podem ser mais densas.
- Formulários devem ser claros.
- Cards não devem ficar lotados de metadados.
- A interface deve funcionar bem em uso diário, não apenas em screenshot.

Configuração futura:

- tamanho dos cards;
- densidade da interface;
- quantidade de metadados visíveis em cards.

## 35. responsividade dentro do Windows

O app será Windows local, mas a janela pode mudar de tamanho.

Diretrizes:

- Layout deve funcionar em janelas largas e médias.
- Mosaicos devem ajustar quantidade de colunas.
- Listas devem preservar ações essenciais.
- Barra lateral pode ter comportamento compacto, se aprovado.
- Formulários podem reorganizar campos em uma ou duas colunas.
- Textos não devem sobrepor ou cortar elementos.

O foco não é mobile. O foco é desktop Windows com boa adaptação de janela.

## 36. acessibilidade básica

A interface deve ser legível e operável.

Diretrizes:

- Contraste suficiente em tema claro e escuro.
- Texto com tamanho confortável.
- Estados não devem depender só de cor.
- Foco de teclado deve ser visível.
- Botões devem ter rótulos ou tooltips.
- Campos devem ter labels claros.
- Mensagens de erro devem estar próximas ao campo ou ação.
- Áreas clicáveis devem ter tamanho confortável.

O app é pessoal, mas ainda deve ser confortável e previsível.

## 37. regras para evidência visual futura

Quando telas forem implementadas, cada tarefa visual deve gerar evidência.

Evidências recomendadas:

- screenshot da tela alterada;
- screenshot em tema claro e escuro, quando ambos existirem;
- screenshot de estado vazio relevante;
- screenshot de erro ou offline, quando a tarefa envolver esses estados;
- descrição de como abrir a tela;
- resumo das ações testadas.

Critérios de revisão visual:

- textos não cortados;
- elementos sem sobreposição;
- mosaicos estáveis;
- cards com proporção correta;
- botões legíveis;
- estados claros;
- tema claro e escuro coerentes;
- azul usado com moderação.

## 38. regras de proteção do visual aprovado

Depois que uma tela ou componente for aprovado visualmente, o Codex não pode alterar sem autorização explícita:

- layout;
- cores;
- espaçamentos;
- tipografia;
- bordas;
- sombras;
- hierarquia visual;
- tamanho de cards;
- densidade;
- comportamento de navegação;
- componentes visuais;
- estados visuais.

Mudanças permitidas sem aprovação visual nova:

- correções técnicas que não alterem aparência;
- ajustes de dados;
- correções internas;
- melhorias de teste;
- correções de bug sem impacto visual.

Mudanças que exigem autorização:

- redesenhar tela;
- trocar posição de áreas;
- mudar paleta;
- alterar tamanho de cards;
- mudar comportamento de mosaico;
- trocar padrão de botões;
- alterar tema claro ou escuro;
- modificar estados visuais aprovados.

Regra principal:

O visual aprovado é uma camada protegida do projeto.

## 39. resumo do design system

O Blue Atelier deve ter uma linguagem visual neutra, moderna, clara e confortável.

A interface deve favorecer imagens, mosaicos, coleções e modelos, mantendo áreas operacionais organizadas e discretas.

O azul deve ser uma cor de ação e destaque, não a cor dominante.

O tema claro e o tema escuro devem ser tratados como experiências completas.

Este documento deve guiar o futuro `docs/09-prompts-stitch.md`, as propostas visuais no Stitch e, depois, a implementação controlada das telas pelo Codex.
