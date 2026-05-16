# blue atelier — planejamento de desenvolvimento

## 1. objetivo do documento

Este documento organiza o desenvolvimento completo do **Blue Atelier** em fases claras, sequenciais e verificáveis.

O objetivo é permitir que o app seja construído de forma controlada, uma tarefa por vez, respeitando a documentação viva do projeto, o uso pessoal do aplicativo, a prioridade visual, o funcionamento local no Windows e a integração com arquivos, pastas, caminhos de rede, SQLite, favoritos, materiais, galerias, fila de impressão e configurações completas.

Este planejamento não define a stack final. A escolha técnica definitiva deve ser feita no documento de arquitetura técnica.

## 2. princípios de execução

- Cada fase pode ser dividida em várias tarefas pequenas.
- Cada tarefa deve ter escopo claro, validação possível, commit próprio e push ao final.
- Nenhuma fase deve alterar visual aprovado sem autorização explícita.
- A documentação deve ser atualizada sempre que uma decisão importante for tomada.
- O app deve ser completo, mas construído de forma incremental.
- Arquivos pesados devem permanecer no sistema de arquivos; o banco deve guardar metadados, relações, caminhos e estados.
- O app deve funcionar localmente no Windows e lidar com caminhos locais e caminhos de rede.

## 3. fases de desenvolvimento

## fase 1 — documentação e base do projeto

### objetivo

Consolidar a documentação inicial, registrar regras de trabalho e manter o projeto pronto para desenvolvimento controlado por tarefas.

### features incluídas

- Descrição geral do app.
- Regras de desenvolvimento com Codex.
- Estado atual do projeto.
- Lista de próximos documentos.
- Planejamento completo de desenvolvimento.
- Histórico de decisões já tomadas.
- Registro de pendências e próximas tarefas.

### arquivos e documentos envolvidos

- `docs/01-descricao-geral-do-app.md`
- `docs/02-regras-de-desenvolvimento-com-codex.md`
- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/05-planejamento-de-desenvolvimento.md`
- `readme.md`

### critérios de validação

- Todos os documentos principais existem.
- O planejamento cobre as áreas centrais do app.
- O arquivo de estado atual registra a tarefa concluída.
- Nenhum código do app foi criado nesta fase.
- O commit contém apenas alterações documentais previstas.

### dependências

- Descrição geral do app aprovada como referência principal.
- Regras de desenvolvimento com Codex registradas.

### observações importantes

Esta fase serve como base de controle. Ela deve evitar decisões técnicas prematuras e preparar o terreno para arquitetura, UX/UI e implementação.

## fase 2 — definição visual e UX/UI

### objetivo

Definir a experiência visual do Blue Atelier antes da implementação das telas, garantindo que o app seja moderno, confortável, visual e adequado ao uso diário em um atelier pessoal de impressão 3D.

### features incluídas

- Mapa inicial de telas.
- Fluxo de navegação principal.
- Propostas visuais para tela inicial, coleções, modelos, favoritos, materiais, fila de impressão e configurações.
- Diretrizes de mosaicos, cards, galerias e painéis.
- Regras para tema claro, tema escuro e cor de destaque.
- Definição de estados visuais importantes, como vazio, carregando, offline, erro, sucesso e item favorito.
- Prompts para exploração visual no Stitch, quando necessário.

### arquivos e documentos envolvidos

- `docs/01-descricao-geral-do-app.md`
- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/09-prompts-stitch.md`
- `docs/14-checklist-de-validacao.md`

### critérios de validação

- Telas principais descritas em documento próprio.
- Fluxos principais documentados.
- Design system inicial registrado.
- Tema claro e tema escuro planejados.
- Nenhuma tela implementada antes de aprovação visual.
- Visual aprovado protegido contra alterações não autorizadas.

### dependências

- Planejamento de desenvolvimento concluído.
- Decisão de quais telas serão desenhadas primeiro.

### observações importantes

A definição visual deve vir antes da implementação das telas. Stitch pode ajudar na ideação, mas não deve ser tratado como fonte final de código.

## fase 3 — arquitetura técnica e estrutura inicial do app

### objetivo

Definir a stack final, a arquitetura do projeto, a organização das camadas e a estrutura inicial do app Windows local.

### features incluídas

- Escolha definitiva da stack.
- Estrutura inicial do projeto.
- Separação entre interface, domínio, persistência, serviços e integrações.
- Configuração inicial de build.
- Configuração inicial de testes.
- Convenções de nomes, pastas e responsabilidades.
- Estratégia para execução local no Windows.
- Estratégia para empacotamento futuro.

### arquivos e documentos envolvidos

- `docs/06-arquitetura-tecnica.md`
- `docs/10-prompts-antigravity.md`
- `docs/11-comandos-codex.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros do projeto do app, após escolha da stack.

### critérios de validação

- Stack final documentada e justificada.
- Estrutura inicial criada conforme a arquitetura aprovada.
- Projeto compila, quando a implementação começar.
- Testes iniciais executam, mesmo que mínimos.
- Nenhuma feature visual ou regra de negócio é adicionada fora do escopo.

### dependências

- Planejamento concluído.
- Decisão técnica registrada no documento de arquitetura.
- Visual inicial já direcionado ou, no mínimo, regras claras para não bloquear a base técnica.

### observações importantes

Esta fase deve criar apenas a fundação técnica. A stack sugerida na descrição geral pode orientar a decisão, mas a escolha definitiva deve ficar registrada no documento de arquitetura.

## fase 4 — entidades e banco de dados SQLite

### objetivo

Modelar e implementar a persistência local do app usando SQLite para metadados, relações, caminhos, estados, tags, links, favoritos, materiais, configurações e histórico.

### features incluídas

- Modelagem de coleções.
- Modelagem de modelos.
- Modelagem de galerias e imagens.
- Modelagem de arquivos vinculados.
- Modelagem de links globais e específicos.
- Modelagem de favoritos.
- Modelagem de materiais.
- Modelagem da fila de impressão.
- Modelagem de configurações.
- Modelagem de tags, status, checklist e histórico.
- Migrações ou estratégia equivalente de evolução do banco.
- Dados iniciais controlados, se forem úteis para desenvolvimento.

### arquivos e documentos envolvidos

- `docs/12-modelagem-do-banco.md`
- `docs/06-arquitetura-tecnica.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros de entidades, repositórios, contexto de banco e migrações.

### critérios de validação

- Entidades documentadas antes da implementação.
- Relações principais representam a hierarquia coleção, modelo, galeria, arquivos, links, materiais e fila.
- Banco SQLite é criado localmente.
- Operações básicas de criação, leitura, atualização e remoção são testadas.
- Arquivos pesados não são armazenados no banco.
- Caminhos são armazenados como metadados e validados pelos serviços apropriados.

### dependências

- Stack final definida.
- Arquitetura técnica aprovada.
- Regras de persistência documentadas.

### observações importantes

O banco deve ser leve e local. A prioridade é confiabilidade e simplicidade para uso pessoal, sem complexidade de multiusuário.

## fase 5 — sistema de arquivos e pastas

### objetivo

Implementar a camada responsável por organizar, localizar, abrir, validar e estruturar arquivos e pastas do atelier.

### features incluídas

- Configuração da pasta principal do atelier.
- Estrutura padrão de pastas para coleções.
- Estrutura padrão de pastas para modelos.
- Criação automática de pastas.
- Validação de existência de arquivos e pastas.
- Abertura de arquivo no programa padrão do Windows.
- Abertura de pasta no Explorador de Arquivos.
- Cópia de caminho.
- Cópia e movimentação de arquivos.
- Identificação de arquivos ausentes.
- Cadastro de extensões relevantes para impressão 3D, imagem, texto e documentação.

### arquivos e documentos envolvidos

- `docs/13-sistema-de-arquivos.md`
- `docs/12-modelagem-do-banco.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros de serviços de sistema de arquivos.

### critérios de validação

- Estrutura padrão de pastas documentada.
- Pastas são criadas somente em caminhos configurados pelo usuário.
- Arquivos vinculados mantêm caminho, extensão, tipo, tamanho e datas relevantes.
- O app lida com arquivo ausente sem travar.
- Operações perigosas, como mover arquivos, exigem confirmação visual quando implementadas.

### dependências

- Configurações iniciais de caminhos.
- Entidades de arquivos e pastas.
- Serviços de persistência prontos.

### observações importantes

Esta fase é central para o Blue Atelier. O app deve funcionar como camada visual sobre pastas reais do Windows, não como substituto fechado do sistema de arquivos.

## fase 6 — coleções

### objetivo

Implementar a área de coleções como ponto principal de organização visual das linhas, séries e conjuntos temáticos do atelier.

### features incluídas

- Listagem de coleções em mosaico.
- Criação de coleção.
- Edição de coleção.
- Arquivamento de coleção.
- Definição de capa.
- Descrição, tags, status, cor opcional e observações.
- Vinculação com pasta principal.
- Contagem de modelos relacionados.
- Links gerais da coleção.
- Galeria opcional da coleção.
- Favoritar coleção, se fizer sentido na experiência aprovada.

### arquivos e documentos envolvidos

- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/12-modelagem-do-banco.md`
- `docs/13-sistema-de-arquivos.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros da interface e lógica de coleções.

### critérios de validação

- Coleções podem ser criadas, editadas, visualizadas e arquivadas.
- Mosaico exibe capa, título, status e metadados essenciais.
- Pasta vinculada pode ser aberta.
- Slug é gerado de forma consistente.
- Coleções sem imagem usam estado visual apropriado.
- Visual segue o design aprovado.

### dependências

- Base visual aprovada para mosaicos e cards.
- Banco de dados funcional.
- Sistema de arquivos mínimo implementado.

### observações importantes

Coleções são a camada mais alta da organização criativa. A experiência deve ser visual e leve, evitando aparência de sistema burocrático.

## fase 7 — modelos

### objetivo

Implementar a ficha completa de modelos e miniaturas, conectando descrição, status, arquivos, galeria, links, materiais, checklist, histórico e ações de produção.

### features incluídas

- Listagem de modelos.
- Modelos por coleção.
- Criação e edição de modelo.
- Capa grande.
- Status atual.
- Tags, escala, tamanho estimado e observações.
- Descrição detalhada.
- Pasta principal do modelo.
- Botões para abrir pastas e arquivos importantes.
- Checklist de produção.
- Histórico de produção.
- Relação com materiais.
- Relação com links e arquivos.
- Fotos finais.

### arquivos e documentos envolvidos

- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/12-modelagem-do-banco.md`
- `docs/13-sistema-de-arquivos.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros da interface e lógica de modelos.

### critérios de validação

- Modelo pode ser criado dentro de uma coleção.
- Tela do modelo reúne as informações essenciais.
- Status segue lista aprovada.
- Checklist pode ser marcado e persistido.
- Botões de ação respeitam caminhos configurados.
- Áreas opcionais só aparecem quando houver dados.
- Visual segue o layout aprovado.

### dependências

- Coleções implementadas.
- Banco de dados funcional.
- Sistema de arquivos disponível.
- Design aprovado da tela do modelo.

### observações importantes

A tela do modelo deve ser a ficha operacional da miniatura. Ela precisa servir tanto para organização criativa quanto para acompanhamento de produção.

## fase 8 — galerias

### objetivo

Implementar galerias visuais para referências, renders, fotos do processo, pintura, paletas, texturas e fotos finais.

### features incluídas

- Galeria de coleção.
- Galeria de modelo.
- Adição de imagem.
- Remoção de imagem.
- Abertura de imagem.
- Definição de imagem como capa.
- Título, descrição, tags e tipo de imagem.
- Filtro por tipo.
- Mosaico visual.
- Estado vazio.
- Tratamento de imagem ausente.

### arquivos e documentos envolvidos

- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/12-modelagem-do-banco.md`
- `docs/13-sistema-de-arquivos.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros de componentes de galeria e serviços de imagem.

### critérios de validação

- Imagens são vinculadas por caminho, não armazenadas no banco.
- Galeria permite definir capa de coleção ou modelo.
- Filtros por tipo funcionam.
- Imagem ausente é sinalizada sem quebrar a tela.
- Mosaico mantém proporções visuais consistentes.
- Visual segue o design aprovado.

### dependências

- Entidades de galeria e imagens.
- Sistema de arquivos implementado.
- Coleções e modelos implementados.
- Design visual de mosaicos aprovado.

### observações importantes

Galerias são uma parte essencial da identidade do app. A navegação deve favorecer reconhecimento visual rápido.

## fase 9 — links e favoritos globais

### objetivo

Implementar links vinculados a coleções e modelos, além de uma área de favoritos globais voltada ao atelier.

### features incluídas

- Cadastro de links globais.
- Cadastro de links específicos de coleção.
- Cadastro de links específicos de modelo.
- Categorias de links.
- Tags e descrição curta.
- Marcar link como favorito.
- Barra rápida de favoritos.
- Página completa de favoritos.
- Busca e filtro de favoritos.
- Abertura de links no navegador padrão.
- Edição e remoção de links.

### arquivos e documentos envolvidos

- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/12-modelagem-do-banco.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros da interface e lógica de links e favoritos.

### critérios de validação

- Links globais aparecem na área de favoritos.
- Links específicos aparecem apenas no contexto correto.
- Área de links não aparece quando não houver links cadastrados.
- Favoritos podem ser fixados, editados e removidos.
- URL é validada de forma amigável.
- Abertura externa funciona no Windows.

### dependências

- Banco de dados funcional.
- Coleções e modelos implementados.
- Design de favoritos aprovado.

### observações importantes

Favoritos devem funcionar como atalhos pessoais do atelier, próximos à experiência de favoritos de navegador, mas integrados ao contexto criativo e produtivo do app.

## fase 10 — materiais

### objetivo

Implementar o cadastro de materiais e utensílios usados no atelier, com possibilidade de vínculo a modelos.

### features incluídas

- Cadastro de materiais.
- Tipos de material.
- Marca, cor, fornecedor e observações.
- Link de compra.
- Quantidade e unidade opcionais.
- Favoritar material.
- Busca e filtros.
- Vinculação de materiais a modelos.
- Visualização de materiais usados em cada modelo.

### arquivos e documentos envolvidos

- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/12-modelagem-do-banco.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros da interface e lógica de materiais.

### critérios de validação

- Materiais podem ser criados, editados, listados e removidos.
- Materiais podem ser vinculados a modelos.
- Link de compra pode ser aberto.
- Favoritos de materiais funcionam quando previstos.
- Filtros por tipo, marca, cor ou fornecedor ajudam a localizar itens.

### dependências

- Banco de dados funcional.
- Modelos implementados.
- Design de listagem e detalhe de materiais aprovado.

### observações importantes

O cadastro de materiais deve ser útil sem virar controle de estoque complexo, a menos que isso seja solicitado em tarefa futura.

## fase 11 — fila de impressão

### objetivo

Implementar uma fila operacional para acompanhar arquivos e modelos prontos para impressão, envio para rede, status e histórico de tentativas.

### features incluídas

- Cadastro de item na fila.
- Relação com modelo e arquivo.
- Status da fila.
- Caminho do arquivo pronto.
- Destino local ou de rede.
- Data de envio.
- Observações.
- Histórico de tentativas.
- Ações para abrir arquivo, abrir pasta e copiar para destino.
- Marcar como enviado, imprimindo, impresso, falhou, cancelado ou arquivado.

### arquivos e documentos envolvidos

- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/12-modelagem-do-banco.md`
- `docs/13-sistema-de-arquivos.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros da interface e lógica da fila de impressão.

### critérios de validação

- Arquivo pode ser enviado para a fila a partir do modelo ou da área de arquivos.
- Status da fila é persistido.
- Cópia para pasta configurada funciona.
- Falhas de caminho offline são exibidas de forma clara.
- Histórico de tentativas é registrado.
- Nenhum arquivo é movido ou sobrescrito sem confirmação quando houver risco.

### dependências

- Modelos implementados.
- Arquivos vinculados implementados.
- Configurações de caminhos implementadas ou parcialmente disponíveis.
- Integração com caminhos de rede planejada.

### observações importantes

A fila de impressão deve ser simples e confiável. Ela precisa ajudar na rotina real de produção, não tentar controlar a impressora diretamente nesta fase.

## fase 12 — configurações completas

### objetivo

Implementar uma área de configurações completa para caminhos, rede, tema, programas padrão, estrutura de pastas e backup.

### features incluídas

- Pasta principal do atelier.
- Pasta de coleções.
- Pasta de backups.
- Pasta temporária.
- Pasta de importação.
- Pasta de exportação.
- Caminhos de rede.
- Teste de conexão de caminhos.
- Modelo padrão de pastas para coleções e modelos.
- Tema claro, escuro e automático.
- Cor de destaque.
- Tamanho dos cards.
- Densidade da interface.
- Programas padrão para abrir tipos de arquivo.
- Backup manual.
- Backup automático, se aprovado.
- Exportação e importação de banco e configurações.

### arquivos e documentos envolvidos

- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/12-modelagem-do-banco.md`
- `docs/13-sistema-de-arquivos.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros da interface e lógica de configurações.

### critérios de validação

- Configurações são persistidas localmente.
- Caminhos podem ser testados.
- Caminhos inválidos ou offline são sinalizados.
- Tema selecionado é aplicado de forma consistente.
- Modelo de pastas pode ser ajustado sem quebrar coleções e modelos existentes.
- Exportação e backup preservam dados importantes.

### dependências

- Banco de dados funcional.
- Serviços de sistema de arquivos.
- Design da área de configurações aprovado.

### observações importantes

Configurações são parte central do app, não uma área secundária. O Blue Atelier depende de caminhos bem configurados para funcionar bem.

## fase 13 — busca global

### objetivo

Implementar uma busca rápida e acessível de qualquer tela, capaz de localizar informações em coleções, modelos, arquivos, links, materiais, tags, status e notas.

### features incluídas

- Campo de busca global.
- Busca por coleções.
- Busca por modelos.
- Busca por tags.
- Busca por links.
- Busca por arquivos.
- Busca por materiais.
- Busca por status.
- Busca por notas e descrições.
- Resultados agrupados por tipo.
- Abertura direta do item encontrado.
- Filtros rápidos.

### arquivos e documentos envolvidos

- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/12-modelagem-do-banco.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros da interface e lógica de busca.

### critérios de validação

- Busca encontra registros principais.
- Resultados são rápidos para uma base pessoal de uso local.
- Resultados mostram tipo, título e contexto.
- Busca respeita dados arquivados conforme regra aprovada.
- Interface funciona em tema claro e escuro.

### dependências

- Entidades principais implementadas.
- Banco de dados com dados reais ou dados de teste.
- Design da busca aprovado.

### observações importantes

A busca deve ser uma forma de navegação principal, não apenas uma função auxiliar.

## fase 14 — integração com caminhos de rede

### objetivo

Implementar suporte robusto a caminhos de rede, unidades mapeadas e pastas compartilhadas usadas no fluxo de impressão e arquivamento.

### features incluídas

- Cadastro de caminhos de rede.
- Teste de acessibilidade.
- Status online, offline ou não testado.
- Último teste executado.
- Abertura de pasta de rede.
- Cópia de arquivo para destino de rede.
- Tratamento de indisponibilidade.
- Mensagem visual na tela inicial quando houver caminho importante offline.
- Compatibilidade com caminhos UNC e unidades mapeadas.

### arquivos e documentos envolvidos

- `docs/13-sistema-de-arquivos.md`
- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/12-modelagem-do-banco.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros de serviços de rede e caminhos.

### critérios de validação

- Caminhos como `D:\atelier-3d\`, `Z:\atelier-3d\` e `\\servidor\pasta\` são aceitos.
- App identifica caminho acessível e inacessível.
- App não trava quando uma pasta de rede estiver offline.
- Fila de impressão lida com destino indisponível.
- Tela inicial mostra alerta quando necessário.

### dependências

- Sistema de arquivos implementado.
- Configurações de caminhos implementadas.
- Fila de impressão implementada ou planejada para integração.

### observações importantes

Caminhos de rede devem ser tratados como variáveis e instáveis. O app precisa informar o estado sem interromper o uso local.

## fase 15 — refinamento visual e experiência diária

### objetivo

Refinar a aparência, a navegação e os detalhes de experiência para que o Blue Atelier seja confortável, moderno e prazeroso no uso diário.

### features incluídas

- Ajustes finos de espaçamento, tipografia e hierarquia.
- Revisão de mosaicos e cards.
- Estados vazios mais úteis.
- Feedback visual para ações importantes.
- Melhorias de navegação lateral.
- Consistência entre temas claro e escuro.
- Revisão de densidade da interface.
- Ajustes de acessibilidade básica.
- Polimento de telas principais.

### arquivos e documentos envolvidos

- `docs/08-design-system.md`
- `docs/07-mapa-de-telas.md`
- `docs/14-checklist-de-validacao.md`
- Arquivos futuros de interface, estilos e componentes.

### critérios de validação

- Telas principais seguem o visual aprovado.
- Tema claro e escuro estão consistentes.
- Não há textos cortados ou sobrepostos.
- Mosaicos e cards mantêm proporções adequadas.
- Ações principais são fáceis de encontrar.
- Evidências visuais são geradas quando houver tela implementada.

### dependências

- Telas principais implementadas.
- Design system aprovado.
- Dados suficientes para testar estados reais.

### observações importantes

Esta fase não deve ser usada para redesenhar o app sem aprovação. O objetivo é polir e corrigir inconsistências dentro do visual aprovado.

## fase 16 — testes, validação e empacotamento

### objetivo

Validar o app de ponta a ponta, preparar o uso local no Windows e organizar uma versão empacotada ou instalável quando o projeto estiver maduro.

### features incluídas

- Checklist de validação por área.
- Testes de entidades e serviços.
- Testes de banco SQLite.
- Testes de sistema de arquivos.
- Testes com caminhos inexistentes e caminhos offline.
- Testes de fluxo completo: coleção, modelo, galeria, arquivos, fila e favoritos.
- Validação visual das telas principais.
- Revisão de documentação.
- Estratégia de backup.
- Estratégia de empacotamento para Windows.
- Instruções de instalação e execução local.

### arquivos e documentos envolvidos

- `docs/14-checklist-de-validacao.md`
- `docs/06-arquitetura-tecnica.md`
- `docs/13-sistema-de-arquivos.md`
- `docs/03-estado-atual.md`
- `readme.md`
- Arquivos futuros de testes, build e empacotamento.

### critérios de validação

- Build final executa sem erro.
- Testes automatizados relevantes passam.
- Fluxos principais foram testados manualmente.
- Banco local pode ser criado e aberto.
- Caminhos locais e de rede foram validados.
- App funciona em tema claro e escuro.
- Documentação de execução está atualizada.
- Versão empacotada pode ser instalada ou executada localmente.

### dependências

- Funcionalidades principais implementadas.
- Documentação técnica atualizada.
- Checklist de validação criado.
- Decisão de empacotamento definida.

### observações importantes

Esta fase deve transformar o projeto em uma ferramenta realmente utilizável no atelier. O foco final é confiabilidade no uso pessoal, não distribuição comercial.

## 4. ordem sugerida dos próximos documentos

1. `docs/06-arquitetura-tecnica.md`
2. `docs/07-mapa-de-telas.md`
3. `docs/08-design-system.md`
4. `docs/09-prompts-stitch.md`
5. `docs/10-prompts-antigravity.md`
6. `docs/11-comandos-codex.md`
7. `docs/12-modelagem-do-banco.md`
8. `docs/13-sistema-de-arquivos.md`
9. `docs/14-checklist-de-validacao.md`

## 5. definição de pronto geral

O Blue Atelier será considerado completo quando:

- o usuário conseguir organizar coleções e modelos de forma visual;
- cada modelo tiver ficha completa com descrição, galeria, arquivos, links, materiais, checklist e histórico;
- arquivos locais e de rede puderem ser vinculados, abertos, validados e enviados para a fila;
- favoritos globais funcionarem como central de atalhos do atelier;
- materiais puderem ser cadastrados e relacionados a modelos;
- a fila de impressão acompanhar arquivos prontos e destinos configurados;
- configurações permitirem adaptar caminhos, temas, pastas, backups e programas padrão;
- a busca global localizar os principais dados do app;
- o banco SQLite persistir os metadados com segurança;
- o app funcionar localmente no Windows com tema claro e escuro;
- a documentação refletir o estado real do projeto;
- cada fase tiver sido validada por tarefas, commits e pushes controlados.
