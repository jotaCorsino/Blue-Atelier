# blue atelier — prompts para stitch

## 1. objetivo do documento

Este documento reúne prompts para usar no Google Stitch com o objetivo de explorar e refinar visualmente as telas do **Blue Atelier**.

O Stitch será usado apenas para ideação visual e refinamento de UI/UX. Ele não é fonte final de código do projeto.

Os prompts devem ajudar a gerar conceitos visuais alinhados com:

- app Windows local;
- uso pessoal;
- atelier de impressão 3D;
- organização visual de coleções e modelos;
- mosaicos, galerias e imagens;
- estilo moderno, minimalista, neutro e confortável;
- azul usado apenas como cor de destaque;
- tema claro e tema escuro;
- ausência de aparência de dashboard corporativo.

Depois que uma tela for aprovada visualmente, o Codex não poderá alterar esse visual sem autorização explícita.

## 2. como usar estes prompts

Use os prompts como ponto de partida no Stitch.

Recomendações:

- Gere poucas variações por vez.
- Avalie a tela antes de pedir refinamentos.
- Não peça código ao Stitch.
- Não aceite uma tela apenas porque parece bonita.
- Verifique se a tela parece uma ferramenta pessoal de atelier.
- Verifique se a navegação e as ações estão claras.
- Verifique se o azul aparece apenas como destaque.
- Registre o que foi aprovado antes de iniciar implementação.

## 3. prompt mestre para stitch

Use este prompt para gerar o primeiro conceito visual geral do app.

```txt
Crie um conceito visual para um aplicativo Windows local chamado Blue Atelier.

Objetivo visual:
Criar uma interface moderna, minimalista, visual e confortável para organizar um atelier pessoal de impressão 3D com miniaturas, coleções, modelos, referências, arquivos, materiais, favoritos e fila de impressão.

Contexto da tela:
O app é de uso pessoal, local-first, sem login e sem aparência comercial. Ele deve parecer uma ferramenta de atelier criativo, uma mistura de Pinterest privado, galeria de projetos, organizador de arquivos e painel de produção pessoal.

Layout esperado:
Use navegação lateral fixa com as áreas: início, coleções, modelos, fila de impressão, arquivos recentes, materiais, favoritos, busca e configurações. Use uma barra superior discreta com busca global e ação principal. A área central deve valorizar mosaicos visuais, cards com imagens, galerias e informações resumidas.

Elementos obrigatórios:
Inclua dashboard inicial, cards de coleções, modelos em andamento, favoritos rápidos, aviso discreto de caminho de rede offline, busca global, tema claro e indicação de que existe tema escuro.

Estilo visual:
Visual neutro, limpo, moderno, com fundos claros suaves, cards brancos, bordas discretas, tipografia legível estilo Segoe UI, cantos suaves até 8px e sombras leves. Use azul apenas como cor de destaque para botões principais, seleção ativa, links e foco.

O que evitar:
Não criar aparência de dashboard corporativo, CRM, SaaS comercial, landing page, sistema administrativo pesado, planilha, painel de métricas ou catálogo de loja. Não usar gradientes grandes, orbs, excesso de azul, roxo dominante ou decoração sem função.

Observações sobre UX:
A interface deve ser confortável para uso diário, com boa leitura, poucas ações por área, mosaicos reconhecíveis e caminho claro entre coleção > modelo > detalhes. Áreas opcionais devem aparecer apenas quando houver dados ou como estado vazio útil.

Instruções importantes:
Não gerar código. Não tratar esta saída como implementação final. Criar apenas uma proposta visual para discussão. O visual aprovado será protegido e não poderá ser alterado futuramente pelo Codex sem autorização explícita.
```

## 4. prompt — tela inicial / dashboard do atelier

```txt
Crie uma proposta visual para a tela inicial do Blue Atelier.

Objetivo visual:
Transmitir a sensação de painel pessoal do atelier, com acesso rápido a coleções, modelos em andamento, arquivos recentes, favoritos e fila de impressão.

Contexto da tela:
Esta é a primeira tela ao abrir o app Windows local. O usuário quer retomar trabalhos, ver referências, abrir pastas, acompanhar impressão e acessar favoritos.

Layout esperado:
Navegação lateral fixa, barra superior com busca global e botão discreto para criar coleção. Área principal com mosaico de coleções recentes, seção de modelos em andamento, itens prontos para impressão, arquivos recentes e barra rápida de favoritos.

Elementos obrigatórios:
Mosaico de coleções recentes, coleções favoritas, modelos em andamento, itens prontos para impressão, últimos arquivos acessados, favoritos rápidos, aviso discreto de caminho de rede offline, busca global e ação para nova coleção.

Estilo visual:
Neutro, moderno, leve, com cards visuais e bastante respiro. Use azul apenas no botão principal, seleção ativa e pequenos indicadores.

O que evitar:
Não parecer dashboard corporativo, painel de métricas, CRM, ferramenta administrativa pesada ou tela cheia de gráficos.

Observações sobre UX:
Priorizar reconhecimento visual. A tela deve ajudar o usuário a continuar a rotina sem pensar muito. Alertas devem ser úteis, mas não alarmistas.
```

## 5. prompt — tela de coleções

```txt
Crie uma proposta visual para a tela de coleções do Blue Atelier.

Objetivo visual:
Mostrar coleções de miniaturas como biblioteca visual em mosaico, com capas, status e metadados discretos.

Contexto da tela:
Uma coleção representa linha, série, tema, estudo ou conjunto criativo do atelier.

Layout esperado:
Navegação lateral fixa, barra superior com título "Coleções", busca local, filtros discretos por status e tags, botão de nova coleção. Conteúdo principal em mosaico de cards.

Elementos obrigatórios:
Cards com imagem de capa, título, status, tags, quantidade de modelos, data de atualização e indicador de pasta vinculada. Incluir estado visual para coleção sem capa.

Estilo visual:
Inspirado em Pinterest e álbuns de fotos, mas com organização de ferramenta local. Fundo neutro, cards claros, bordas suaves, sombras leves. Azul apenas para ação principal, seleção ativa, links e foco.

O que evitar:
Não usar tabela como layout principal. Não parecer e-commerce, CRM, dashboard corporativo ou painel administrativo. Não usar azul como fundo dos cards.

Observações sobre UX:
O usuário deve reconhecer uma coleção pela capa antes de ler tudo. Filtros devem existir, mas não dominar a tela.
```

## 6. prompt — detalhe da coleção

```txt
Crie uma proposta visual para a tela de detalhe de coleção do Blue Atelier.

Objetivo visual:
Mostrar a ficha de uma coleção e destacar os modelos relacionados em mosaico.

Contexto da tela:
O usuário abriu uma coleção específica para ver descrição, status, pasta vinculada, modelos, galeria e links.

Layout esperado:
Topo com capa da coleção, título, status, tags e ações principais. Abaixo, seção visual de modelos da coleção em mosaico. Áreas secundárias para descrição, links, galeria e observações.

Elementos obrigatórios:
Capa, título, status, descrição, tags, botão abrir pasta, botão criar modelo, mosaico de modelos, links da coleção quando houver e galeria opcional.

Estilo visual:
Neutro, visual, editorial e calmo. Use imagem de capa como referência visual, mas sem hero exagerado. Azul apenas em ação principal, links e foco.

O que evitar:
Não parecer página de produto, landing page, dashboard corporativo ou sistema administrativo. Não criar cabeçalho gigante que esconda os modelos.

Observações sobre UX:
A hierarquia deve deixar claro: coleção > modelos. Se a coleção não tiver modelos, mostrar estado vazio com ação para criar modelo.
```

## 7. prompt — tela de modelos

```txt
Crie uma proposta visual para a tela de modelos do Blue Atelier.

Objetivo visual:
Exibir miniaturas e modelos como biblioteca visual com filtros de produção.

Contexto da tela:
O usuário quer encontrar modelos por coleção, status, tags, escala ou etapa de produção.

Layout esperado:
Navegação lateral, barra superior com busca e ação para criar modelo, filtros por coleção/status/tags, mosaico de cards de modelos.

Elementos obrigatórios:
Cards com capa, título, coleção de origem, status de produção, tags, escala quando houver e indicador de pasta/arquivo pronto quando aplicável.

Estilo visual:
Visual e neutro, com imagens em destaque e metadados discretos. Azul apenas para foco, seleção ativa e ação principal.

O que evitar:
Não transformar a tela em tabela principal. Não parecer catálogo de loja ou dashboard corporativo.

Observações sobre UX:
O status de produção deve ser fácil de perceber sem abrir o modelo. Modelo sem capa deve ter placeholder elegante.
```

## 8. prompt — detalhe do modelo

```txt
Crie uma proposta visual para a tela de detalhe do modelo no Blue Atelier.

Objetivo visual:
Criar a ficha completa da miniatura, equilibrando visual, descrição, arquivos, materiais, checklist e histórico de produção.

Contexto da tela:
O usuário acompanha uma miniatura específica desde referência até impressão, pintura, fotos finais e arquivamento.

Layout esperado:
Topo com capa grande moderada, título, coleção, status e ações. Corpo com seções organizadas: galeria, descrição, arquivos, links, materiais, checklist, histórico e notas.

Elementos obrigatórios:
Capa, título, status, tags, coleção de origem, botões abrir pasta/arquivos 3D/fatiamento, galeria visual, descrição, links específicos, materiais, checklist, arquivos vinculados, histórico e notas.

Estilo visual:
Ficha rica, visual e confortável. Usar cards ou seções discretas, sem cards aninhados. Azul apenas para ações principais e links.

O que evitar:
Não parecer tela administrativa cheia de campos, dashboard corporativo ou layout técnico pesado. Não usar muitos blocos coloridos.

Observações sobre UX:
Áreas opcionais só aparecem quando houver dados ou quando forem estados vazios úteis. O usuário deve entender rapidamente o estado atual do modelo.
```

## 9. prompt — galeria

```txt
Crie uma proposta visual para a tela de galeria do Blue Atelier.

Objetivo visual:
Organizar imagens de referência, renders, processo, pintura, fotos finais, paletas e texturas em mosaico visual.

Contexto da tela:
A galeria pode pertencer a uma coleção ou a um modelo específico.

Layout esperado:
Topo com contexto da coleção/modelo, filtro por tipo de imagem e ação adicionar imagem. Área principal com mosaico de imagens em proporções estáveis.

Elementos obrigatórios:
Mosaico, filtros por tipo, tags discretas, indicador de imagem usada como capa, ação abrir imagem, ação definir como capa e placeholder para imagem ausente.

Estilo visual:
Inspirado em álbuns de fotos e Pinterest, neutro e focado nas imagens. Azul apenas para seleção ativa e ação principal.

O que evitar:
Não usar molduras pesadas, decoração exagerada, dashboard corporativo ou aparência de rede social pública.

Observações sobre UX:
O mosaico deve continuar organizado mesmo com imagem ausente. Filtros devem ser simples e rápidos.
```

## 10. prompt — visualização de imagem

```txt
Crie uma proposta visual para a tela de visualização de imagem do Blue Atelier.

Objetivo visual:
Permitir ver uma imagem em tamanho maior, com metadados e ações sem tirar o foco da imagem.

Contexto da tela:
O usuário abriu uma imagem de referência, processo, pintura, render, paleta ou foto final.

Layout esperado:
Imagem em destaque no centro ou à esquerda, painel lateral discreto com título, descrição, tipo, tags, caminho e relação com coleção/modelo.

Elementos obrigatórios:
Imagem grande, voltar à galeria, definir como capa, abrir no visualizador padrão, abrir pasta, copiar caminho, editar metadados e indicador de arquivo ausente.

Estilo visual:
Limpo, neutro, com foco na imagem. Tema escuro pode ser especialmente confortável para visualização. Azul apenas para ações principais, links e foco.

O que evitar:
Não encher a tela de controles. Não parecer dashboard corporativo, editor profissional de imagem ou rede social.

Observações sobre UX:
A imagem deve ser a protagonista. Ações devem existir, mas ficar discretas.
```

## 11. prompt — arquivos vinculados

```txt
Crie uma proposta visual para a tela de arquivos vinculados do Blue Atelier.

Objetivo visual:
Mostrar arquivos e pastas relacionados a coleções e modelos com clareza operacional.

Contexto da tela:
O app organiza arquivos reais do Windows, incluindo STL, OBJ, 3MF, BLEND, CTB, imagens, textos e documentos.

Layout esperado:
Lista ou tabela leve com filtros por tipo, categoria e status. Ações por linha para abrir arquivo, abrir pasta, copiar caminho e enviar para fila.

Elementos obrigatórios:
Nome, extensão, tipo, categoria, tamanho, datas, caminho resumido, status de existência, relação com coleção/modelo e ações por linha.

Estilo visual:
Mais operacional, mas ainda neutro e confortável. Usar tabela limpa, com linhas bem espaçadas e status discretos. Azul apenas para ações principais, links e foco.

O que evitar:
Não parecer explorador de arquivos antigo, planilha pesada, dashboard corporativo ou painel corporativo.

Observações sobre UX:
Caminhos longos devem ser truncados com opção de copiar. Arquivos ausentes devem ser visíveis sem quebrar a tela.
```

## 12. prompt — fila de impressão

```txt
Crie uma proposta visual para a tela de fila de impressão do Blue Atelier.

Objetivo visual:
Organizar modelos e arquivos prontos para impressão com status, destino e histórico.

Contexto da tela:
A fila não controla a impressora. Ela ajuda o usuário a enviar arquivos para uma pasta local ou de rede e acompanhar tentativas.

Layout esperado:
Lista ou tabela com agrupamento por status, filtros discretos, alerta de destino offline quando houver e ações por item.

Elementos obrigatórios:
Modelo relacionado, arquivo, status, caminho do arquivo, destino de rede, data de envio, observação, histórico resumido, ações abrir arquivo, copiar para rede, marcar enviado/impresso/falha.

Estilo visual:
Ferramenta operacional leve, neutra, confiável. Status coloridos discretos. Azul apenas em ação principal e seleção.

O que evitar:
Não parecer painel industrial, dashboard corporativo ou sistema de gestão pesado.

Observações sobre UX:
Destino offline deve ser claro, mas não alarmista. A fila vazia deve explicar que arquivos prontos aparecerão ali.
```

## 13. prompt — arquivos recentes

```txt
Crie uma proposta visual para a tela de arquivos recentes do Blue Atelier.

Objetivo visual:
Ajudar o usuário a retomar rapidamente arquivos vinculados, acessados ou alterados recentemente.

Contexto da tela:
O usuário trabalha com arquivos locais e de rede dentro da rotina de impressão 3D.

Layout esperado:
Lista limpa com filtros por período, coleção, modelo, tipo e status. Pode haver uma pequena área de resumo no topo.

Elementos obrigatórios:
Nome do arquivo, extensão, tipo, data de acesso ou atualização, caminho resumido, relação com coleção/modelo, status de existência e ações abrir/copiar caminho/abrir pasta.

Estilo visual:
Neutro, discreto, rápido de escanear. Azul apenas para ação principal ou link.

O que evitar:
Não parecer tabela de sistema antigo ou dashboard corporativo.

Observações sobre UX:
Arquivos ausentes e caminhos offline devem ser indicados com clareza sem impedir a navegação.
```

## 14. prompt — materiais

```txt
Crie uma proposta visual para a tela de materiais do Blue Atelier.

Objetivo visual:
Organizar materiais e utensílios do atelier de forma simples e útil.

Contexto da tela:
Materiais incluem resina, tintas, primer, verniz, pincéis, lixas, álcool, pigmentos, cola e outros itens usados em modelos.

Layout esperado:
Lista visual leve ou mosaico compacto, com filtros por tipo, marca, cor, fornecedor e favoritos.

Elementos obrigatórios:
Nome, tipo, marca, cor quando houver, fornecedor, link de compra, favorito, quantidade opcional e ação para abrir detalhe do material.

Estilo visual:
Neutro e organizado, com pequenos swatches de cor quando houver. Azul apenas em ações e links.

O que evitar:
Não criar controle de estoque complexo, dashboard corporativo, dashboard administrativo ou tela de compras.

Observações sobre UX:
Deve ser simples o suficiente para cadastro pessoal. Materiais vinculados a modelos devem ser fáceis de identificar.
```

## 15. prompt — favoritos globais

```txt
Crie uma proposta visual para a tela de favoritos globais do Blue Atelier.

Objetivo visual:
Criar uma central de atalhos pessoais do atelier, parecida com favoritos de navegador, mas integrada ao contexto criativo.

Contexto da tela:
Favoritos podem ser marketplaces, fornecedores, tutoriais, comunidades, referências, coleções, modelos ou materiais.

Layout esperado:
Cards ou lista visual por categoria, com busca, filtros e opção de fixar na barra rápida.

Elementos obrigatórios:
Título, categoria, tipo de favorito, descrição curta, URL ou destino interno, tags, status de fixado, ação abrir, editar, remover e fixar.

Estilo visual:
Leve, neutro, rápido de usar. Ícones simples podem distinguir tipos. Azul apenas para links e ações.

O que evitar:
Não parecer página de anúncios, loja, portal de links público ou dashboard corporativo.

Observações sobre UX:
Favoritos externos e internos devem ser visualmente distinguíveis. A barra rápida deve parecer extensão natural desta tela.
```

## 16. prompt — configurações gerais

```txt
Crie uma proposta visual para a tela de configurações gerais do Blue Atelier.

Objetivo visual:
Organizar configurações completas sem parecer sistema administrativo pesado.

Contexto da tela:
Configurações controlam caminhos, rede, tema, modelo de pastas, programas padrão e backup.

Layout esperado:
Tela com categorias claras em seções ou lista lateral interna: caminhos locais, caminhos de rede, modelo de pastas, tema/aparência e backup. Mostrar resumo de status.

Elementos obrigatórios:
Resumo de caminhos principais, status de rede, tema atual, backup, modelo de pastas e atalhos para cada seção.

Estilo visual:
Neutro, organizado, simples. Usar cards ou seções discretas sem aninhamento excessivo. Azul apenas para ação ativa e foco.

O que evitar:
Não parecer painel de administração empresarial, dashboard corporativo, tela de servidor, CRM ou página técnica demais.

Observações sobre UX:
Configurações devem ser completas, mas fáceis de entender. Alertas devem orientar o usuário sem assustar.
```

## 17. prompt — configurações de caminhos locais e rede

```txt
Crie uma proposta visual para configurações de caminhos locais e caminhos de rede do Blue Atelier.

Objetivo visual:
Permitir configurar, testar e entender caminhos usados pelo atelier sem confusão.

Contexto da tela:
O app usa pastas locais e caminhos de rede como D:\atelier-3d\, Z:\atelier-3d\ e \\servidor\pasta\.

Layout esperado:
Duas seções claras: caminhos locais e caminhos de rede. Usar lista/tabela limpa com nome, caminho, tipo, status, último teste e ações.

Elementos obrigatórios:
Pasta principal do atelier, pasta de coleções, backup, envio para impressão, arquivos 3D compartilhados, status online/offline, botão testar conexão, abrir pasta e copiar caminho.

Estilo visual:
Ferramenta local, limpa e confiável. Status de rede em amarelo/cinza quando offline, verde quando ok. Azul apenas para ações principais.

O que evitar:
Não parecer painel de TI corporativo, dashboard corporativo, console técnico ou dashboard de infraestrutura.

Observações sobre UX:
Caminho offline deve ser tratado como normal e recuperável. Não bloquear o uso local.
```

## 18. prompt — configurações de tema/aparência

```txt
Crie uma proposta visual para configurações de tema e aparência do Blue Atelier.

Objetivo visual:
Permitir escolher tema claro, tema escuro, tamanho dos cards e densidade da interface dentro do design system aprovado.

Contexto da tela:
O usuário quer adaptar o app para uso diário sem quebrar a identidade visual.

Layout esperado:
Seções simples para tema, cor de destaque, tamanho dos cards e densidade. Incluir prévia visual pequena de cards e botões.

Elementos obrigatórios:
Opções tema claro, tema escuro, tema automático se aprovado, cor azul de destaque, tamanho dos cards, densidade confortável/compacta e restaurar padrão.

Estilo visual:
Limpo, neutro e demonstrativo. Usar azul só na seleção ativa e exemplo de botão principal.

O que evitar:
Não criar personalização infinita, dashboard corporativo, editor visual complexo ou tela com muitas cores decorativas.

Observações sobre UX:
A tela deve deixar claro que as opções respeitam o design system. Visual aprovado não deve ser alterado sem autorização.
```

## 19. prompt — estados vazios

```txt
Crie propostas visuais para estados vazios do Blue Atelier.

Objetivo visual:
Mostrar ausência de dados de forma útil, calma e orientada à próxima ação.

Contexto da tela:
Estados vazios aparecem quando ainda não há coleções, modelos, galeria, favoritos, materiais, arquivos ou fila de impressão.

Layout esperado:
Área central simples com mensagem curta, explicação discreta e uma ação principal. Pode usar ícone simples, sem ilustração obrigatória.

Elementos obrigatórios:
Exemplos de estado vazio para coleções, modelos, galeria, fila de impressão, favoritos e materiais.

Estilo visual:
Neutro, confortável, com bastante respiro. Azul apenas no botão de ação principal.

O que evitar:
Não usar ilustrações grandes demais, tom infantil, mensagens longas, dashboard corporativo ou aparência de landing page.

Observações sobre UX:
O estado vazio deve ajudar o usuário a começar, não apenas dizer que não há dados.
```

## 20. prompt — estados de erro/offline

```txt
Crie propostas visuais para estados de erro e offline do Blue Atelier.

Objetivo visual:
Comunicar problemas de arquivo, banco, caminho local ou caminho de rede de forma clara e não alarmista.

Contexto da tela:
O app lida com arquivos reais e caminhos de rede que podem estar ausentes ou offline.

Layout esperado:
Alertas discretos no contexto da tela, linhas com status, cards de aviso quando necessário e ações para tentar novamente, abrir configurações ou copiar caminho.

Elementos obrigatórios:
Arquivo ausente, imagem ausente, caminho de rede offline, destino de fila indisponível, erro ao salvar e erro ao abrir pasta.

Estilo visual:
Usar amarelo para offline/atenção, vermelho para erro real, cinza para estado neutro. Azul apenas para ações.

O que evitar:
Não bloquear todo o app por caminho de rede offline. Não parecer dashboard corporativo nem tela crítica de sistema corporativo.

Observações sobre UX:
Offline deve ser tratado como condição normal. A mensagem deve explicar o problema e sugerir próximo passo.
```

## 21. prompt — versão em tema claro

```txt
Crie uma versão em tema claro para o conceito visual do Blue Atelier.

Objetivo visual:
Validar o tema claro oficial como experiência confortável, neutra e visual.

Contexto da tela:
Use como base uma tela com navegação lateral, barra superior, mosaicos de coleções/modelos, seção de arquivos recentes e favoritos rápidos.

Layout esperado:
Fundo claro levemente quente, superfícies brancas, bordas discretas, textos escuros, cards visuais e azul apenas para destaque.

Elementos obrigatórios:
Navegação lateral ativa, busca global, botão principal azul, cards de coleção, cards de modelo, badge de status, estado de caminho offline discreto e área de favoritos.

Estilo visual:
Claro, limpo, minimalista, sem branco puro agressivo. Deve parecer ferramenta pessoal de atelier.

O que evitar:
Não parecer SaaS corporativo, dashboard corporativo, dashboard de métricas, loja ou landing page.

Observações sobre UX:
Verificar contraste, legibilidade, respiro, equilíbrio entre imagens e informações e uso moderado do azul.
```

## 22. prompt — versão em tema escuro

```txt
Crie uma versão em tema escuro para o conceito visual do Blue Atelier.

Objetivo visual:
Validar o tema escuro oficial como experiência confortável para uso noturno e revisão visual de imagens.

Contexto da tela:
Use como base uma tela com navegação lateral, barra superior, mosaicos de coleções/modelos, galeria e aviso de caminho offline.

Layout esperado:
Fundo cinza muito escuro, superfícies um pouco mais claras, bordas discretas, texto claro sem branco estourado e azul apenas como destaque.

Elementos obrigatórios:
Navegação lateral ativa, busca global, cards visuais, imagens em mosaico, badge de status, alerta offline discreto, botão principal azul e links.

Estilo visual:
Escuro, neutro, moderno e calmo. Deve preservar a identidade do tema claro, sem virar interface azul escura.

O que evitar:
Não usar preto absoluto em excesso, brilho forte, contraste agressivo, dashboard corporativo, gradientes grandes ou azul dominante.

Observações sobre UX:
Verificar se imagens continuam sendo protagonistas e se textos, badges e botões são legíveis.
```

## 23. regras para avaliar saídas do stitch

Use estes critérios antes de aprovar qualquer proposta visual.

### adequação ao app

- A tela parece uma ferramenta pessoal de atelier?
- A tela comunica organização visual de coleções, modelos, imagens e arquivos?
- A tela evita aparência comercial, corporativa ou administrativa pesada?
- A proposta respeita uso local no Windows?

### fidelidade ao design system

- A paleta é predominantemente neutra?
- O azul aparece apenas como destaque?
- O tema claro é confortável?
- O tema escuro é legível e não agressivo?
- Cards têm cantos suaves, sem exagero?
- A interface evita efeitos decorativos desnecessários?

### UX e fluxo

- A ação principal da tela é clara?
- O usuário entende onde está?
- A navegação lateral é estável e legível?
- A busca global é fácil de encontrar?
- A hierarquia coleção > modelo > detalhes está clara?
- Áreas opcionais aparecem apenas quando fazem sentido?

### mosaicos e imagens

- Coleções e modelos são reconhecíveis visualmente?
- Galerias valorizam imagens sem perder organização?
- Cards mantêm proporções estáveis?
- Estados de imagem ausente são tratados sem quebrar o layout?

### áreas operacionais

- Arquivos, fila, caminhos e configurações são legíveis?
- Caminhos longos não bagunçam a tela?
- Status de arquivo ausente e rede offline são claros?
- A fila de impressão parece confiável e simples?

### estados visuais

- Estados vazios orientam a próxima ação?
- Erros são claros e úteis?
- Offline é tratado como condição normal?
- Sucesso é discreto?
- Carregamento não bloqueia a tela sem necessidade?

### decisão de aprovação

Antes de aprovar, responda:

- O visual está confortável para uso diário?
- Eu conseguiria usar esta tela por muito tempo?
- A tela ajuda meu fluxo real do atelier?
- A tela está bonita sem parecer genérica?
- O Codex conseguiria implementar isso sem inventar outro visual?

Se a resposta for não, refine o prompt no Stitch antes de aprovar.

Depois de aprovado, o visual vira referência protegida. O Codex não poderá alterar layout, cores, espaçamentos, tipografia, componentes, hierarquia visual ou comportamento visual sem autorização explícita.
