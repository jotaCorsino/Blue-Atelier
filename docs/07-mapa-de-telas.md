# blue atelier — mapa de telas

## 1. objetivo do documento

Este documento define o mapa completo de telas do **Blue Atelier**.

O objetivo é descrever as áreas principais do app, sua função, navegação, hierarquia visual esperada, ações disponíveis, estados especiais e relação entre telas.

Este documento não define o design visual final. Cores, tipografia, espaçamentos, componentes, densidade visual e regras finais de aparência devem ser definidos em `docs/08-design-system.md`.

Nenhum código, projeto .NET, componente Razor ou tela real deve ser criado nesta etapa.

## 2. princípios gerais das telas

- A navegação deve ser visual, simples e confortável.
- Coleções, modelos e galerias devem privilegiar mosaicos e imagens.
- Áreas operacionais, como arquivos, materiais, fila e configurações, podem usar listas, tabelas e formulários.
- A tela inicial deve funcionar como painel do atelier.
- A hierarquia principal deve ser: coleção > modelo > detalhes do modelo.
- O app deve mostrar apenas áreas opcionais quando houver dados.
- Caminhos locais e de rede devem ser tratados com clareza, incluindo estados offline ou ausentes.
- Visual aprovado não poderá ser alterado pelo Codex sem autorização explícita.

## 3. estrutura geral da navegação lateral

A navegação lateral será a entrada principal do app.

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

Comportamento esperado:

- O item ativo deve indicar claramente a área atual.
- A navegação lateral deve permanecer estável entre telas.
- A tela de detalhe pode destacar o item principal relacionado, como coleções ou modelos.
- A navegação lateral não deve ficar sobrecarregada com subtelas.
- Subtelas devem ser acessadas por ações contextuais, abas internas ou breadcrumbs.

Observações de UX/UI:

- A navegação deve parecer uma ferramenta de trabalho, não um menu administrativo pesado.
- A estrutura final de ícones, largura, colapso e comportamento responsivo será definida no design system.

## 4. comportamento da barra superior

A barra superior deve apoiar navegação, busca e ações rápidas.

Conteúdo previsto:

- título ou contexto da tela atual;
- campo ou acionador da busca global;
- acesso à barra rápida de favoritos, se ela não estiver fixa em outro lugar;
- ações contextuais principais da tela;
- indicador de alerta para caminhos de rede offline, quando necessário;
- acesso rápido às configurações, se aprovado no design system.

Comportamento esperado:

- Em telas de listagem, a barra superior pode mostrar ação de criação.
- Em telas de detalhe, a barra superior pode mostrar voltar, editar, favoritar ou abrir pasta.
- Em formulários, a barra superior pode mostrar salvar, cancelar ou voltar.
- A busca global deve estar acessível de qualquer área importante.

Observações de UX/UI:

- A barra superior deve ser funcional e discreta.
- A organização visual final será definida depois, sem fechar design nesta etapa.

## 5. comportamento da busca global

A busca global deve ser uma forma central de navegação.

Escopo da busca:

- coleções;
- modelos;
- tags;
- links;
- arquivos;
- materiais;
- status;
- notas;
- descrições;
- configurações relevantes, se fizer sentido.

Comportamento esperado:

- Deve poder ser acionada a partir da barra superior ou da tela de busca.
- Deve exibir resultados agrupados por tipo.
- Cada resultado deve permitir abrir o item correspondente.
- Deve mostrar contexto, como coleção de origem, modelo relacionado ou tipo de arquivo.
- Deve lidar com ausência de resultados.
- Deve respeitar regras futuras para itens arquivados.

Observações de UX/UI:

- A busca deve ser rápida, direta e sem excesso de filtros na primeira interação.
- Filtros avançados podem ficar na tela completa de busca.

## 6. comportamento da barra rápida de favoritos

A barra rápida de favoritos deve funcionar como atalhos pessoais do atelier.

Conteúdo previsto:

- links globais fixados;
- atalhos para coleções favoritas, se aprovado;
- atalhos para modelos favoritos, se aprovado;
- atalhos para materiais ou fornecedores importantes, se aprovado.

Comportamento esperado:

- Deve aparecer em local constante, definido pelo design system.
- Deve permitir abrir links externos no navegador padrão.
- Deve permitir navegar para itens internos do app.
- Deve permitir distinguir item interno de link externo.
- Deve lidar com favorito removido, link inválido ou item arquivado.

Observações de UX/UI:

- A barra deve ser rápida e leve.
- A tela completa de favoritos deve conter edição, organização e busca.

## 7. hierarquia de navegação coleção > modelo > detalhes

Hierarquia principal:

```txt
coleções
└── detalhe da coleção
    ├── modelos da coleção
    ├── galeria da coleção
    ├── links da coleção
    └── detalhe do modelo
        ├── galeria do modelo
        ├── arquivos vinculados
        ├── links do modelo
        ├── materiais usados
        ├── checklist
        ├── histórico
        └── fila de impressão
```

Regras:

- Uma coleção pode existir sem modelos.
- Um modelo deve estar relacionado a uma coleção, salvo decisão diferente futura.
- A tela do modelo é a ficha operacional completa.
- Galeria, links, materiais e arquivos podem aparecer como seções internas ou telas relacionadas.
- A navegação deve permitir voltar ao contexto anterior sem perder o lugar.

## 8. telas com mosaico visual

Telas que devem priorizar mosaico:

- tela inicial;
- coleções;
- detalhe da coleção, na área de modelos;
- modelos, quando exibidos como biblioteca visual;
- galeria;
- favoritos globais, quando os favoritos forem visuais;
- materiais, se houver imagem ou cor cadastrada;
- busca global, quando resultados forem coleções, modelos ou imagens.

Objetivo:

- favorecer reconhecimento visual;
- reduzir sensação de planilha;
- aproximar o app de uma biblioteca visual pessoal.

## 9. telas com lista ou tabela

Telas que podem usar lista ou tabela:

- arquivos vinculados;
- fila de impressão;
- arquivos recentes;
- materiais, em modo mais denso;
- links específicos;
- favoritos globais, em modo organizado;
- configurações de caminhos locais;
- configurações de caminhos de rede;
- backup;
- resultados detalhados da busca global.

Objetivo:

- facilitar leitura de metadados;
- permitir ações rápidas por linha;
- comparar status, caminhos, datas e categorias.

## 10. telas com formulário

Telas que devem ter formulário:

- criação e edição de coleção;
- criação e edição de modelo;
- cadastro e edição de material;
- cadastro e edição de link;
- cadastro e edição de caminho local;
- cadastro e edição de caminho de rede;
- configuração de modelo padrão de pastas;
- configurações de tema e aparência;
- configurações de backup;
- edição de metadados de imagem;
- edição de arquivo vinculado.

Objetivo:

- garantir entrada de dados clara;
- reduzir erros;
- permitir validação antes de salvar.

## 11. áreas opcionais

Áreas que só devem aparecer quando houver dados:

- links específicos em coleção ou modelo;
- materiais usados no modelo;
- galeria da coleção, se houver imagens;
- galeria do modelo, se houver imagens;
- histórico de produção, se houver eventos;
- arquivos vinculados, se houver arquivos;
- observações, se estiverem preenchidas e a tela não estiver em edição;
- favoritos fixados, se houver favoritos;
- avisos de rede, se houver caminhos offline ou inacessíveis;
- alertas de erro, se não houver erro ativo.

Quando a área for importante mesmo vazia, deve aparecer como estado vazio com ação clara.

Exemplo:

- coleção sem modelos: mostrar estado vazio com ação para criar modelo;
- modelo sem galeria: mostrar estado vazio com ação para adicionar imagem;
- fila sem itens: mostrar estado vazio explicando que arquivos prontos aparecerão ali.

## 12. tela inicial / dashboard do atelier

### objetivo

Ser o painel principal do atelier, reunindo atalhos visuais, situação de produção e acesso rápido ao que importa no dia a dia.

### entrada na navegação

- Item `início` na navegação lateral.
- Tela padrão ao abrir o app.

### conteúdo principal

- Mosaico de coleções recentes.
- Coleções favoritas.
- Modelos em andamento.
- Itens prontos para impressão.
- Últimos arquivos acessados.
- Favoritos rápidos.
- Campo ou acionador de busca global.
- Avisos de caminhos de rede offline, quando houver.

### ações disponíveis

- Criar nova coleção.
- Abrir coleção.
- Abrir modelo em andamento.
- Abrir item da fila.
- Abrir arquivo recente.
- Abrir favorito.
- Ir para configurações de caminhos quando houver alerta.

### relação com outras telas

- Leva para detalhe da coleção.
- Leva para detalhe do modelo.
- Leva para fila de impressão.
- Leva para arquivos recentes.
- Leva para favoritos.
- Leva para configurações.

### dados exibidos

- Título, capa, status e atualização de coleções.
- Título, capa, status e coleção de modelos.
- Nome, tipo, data e caminho resumido de arquivos recentes.
- Status de caminhos de rede importantes.

### estados especiais

- Sem coleções cadastradas.
- Sem modelos em andamento.
- Sem arquivos recentes.
- Caminho de rede offline.
- Falha ao carregar dados locais.
- Carregamento inicial.

### observações de UX/UI

- Deve transmitir sensação de central visual do atelier.
- Deve evitar excesso de informação.
- Deve priorizar atalhos úteis e imagens reconhecíveis.

## 13. coleções

### objetivo

Exibir todas as coleções ou linhas de miniaturas em formato visual.

### entrada na navegação

- Item `coleções` na navegação lateral.
- Atalhos da tela inicial.
- Resultados da busca global.

### conteúdo principal

- Mosaico de cards de coleções.
- Filtros por status, tags e favoritos.
- Ordenação por atualização, criação, nome ou status.
- Busca local dentro de coleções.

### ações disponíveis

- Criar coleção.
- Abrir detalhe da coleção.
- Editar coleção.
- Arquivar coleção.
- Favoritar coleção, se aprovado.
- Abrir pasta vinculada, se existir.

### relação com outras telas

- Abre detalhe da coleção.
- Abre criação e edição de coleção.
- Pode levar para modelos filtrados por coleção.

### dados exibidos

- Capa.
- Título.
- Status.
- Tags principais.
- Contagem de modelos.
- Data de atualização.
- Indicador de pasta vinculada.

### estados especiais

- Nenhuma coleção cadastrada.
- Nenhum resultado para filtro aplicado.
- Capa ausente.
- Pasta vinculada ausente ou inacessível.
- Erro ao carregar coleções.

### observações de UX/UI

- Deve ser uma tela visual em mosaico.
- Não deve parecer uma tabela como padrão.
- Filtros devem ajudar sem dominar a tela.

## 14. detalhe da coleção

### objetivo

Mostrar a ficha de uma coleção e servir como entrada para seus modelos, galeria, links e pasta vinculada.

### entrada na navegação

- Clique em coleção no mosaico.
- Resultado da busca global.
- Atalho em favoritos, se aprovado.

### conteúdo principal

- Capa da coleção.
- Título.
- Status.
- Descrição.
- Tags.
- Pasta vinculada.
- Modelos da coleção em mosaico.
- Links gerais da coleção, quando houver.
- Galeria da coleção, quando houver.
- Observações.

### ações disponíveis

- Editar coleção.
- Criar modelo dentro da coleção.
- Abrir pasta da coleção.
- Adicionar imagem à galeria.
- Definir capa.
- Adicionar link específico.
- Arquivar coleção.
- Copiar caminho da pasta.

### relação com outras telas

- Leva para modelos da coleção.
- Leva para detalhe do modelo.
- Leva para galeria.
- Leva para links específicos.
- Leva para arquivos vinculados da coleção, se existirem.

### dados exibidos

- Metadados da coleção.
- Lista ou mosaico de modelos relacionados.
- Links, imagens e observações.
- Status de pasta vinculada.

### estados especiais

- Coleção sem modelos.
- Coleção sem galeria.
- Coleção sem links.
- Pasta vinculada ausente.
- Coleção arquivada.
- Erro ao abrir pasta.

### observações de UX/UI

- A coleção deve ser reconhecível pela capa e pelo nome.
- Modelos devem aparecer como área visual principal.
- Áreas vazias devem sugerir próximas ações.

## 15. criação e edição de coleção

### objetivo

Permitir criar ou alterar uma coleção com seus metadados principais.

### entrada na navegação

- Ação `criar coleção` na tela inicial.
- Ação `criar coleção` na tela de coleções.
- Ação `editar` no detalhe da coleção.

### conteúdo principal

- Campo de título.
- Slug gerado ou editável conforme regra futura.
- Descrição.
- Status.
- Tags.
- Capa.
- Pasta vinculada.
- Cor opcional, se aprovada.
- Observações.

### ações disponíveis

- Salvar.
- Cancelar.
- Selecionar capa.
- Selecionar pasta.
- Criar estrutura padrão de pastas, se aprovado.
- Remover capa.
- Arquivar, quando em edição.

### relação com outras telas

- Ao salvar, volta para detalhe da coleção ou listagem.
- Pode abrir seletor de pasta do Windows.
- Pode criar pastas conforme configurações.

### dados exibidos

- Dados atuais da coleção, em edição.
- Validações de campos obrigatórios.
- Status do caminho selecionado.

### estados especiais

- Título vazio.
- Slug duplicado.
- Pasta inválida.
- Sem permissão para acessar pasta.
- Erro ao salvar.
- Alterações não salvas.

### observações de UX/UI

- Deve ser formulário simples.
- Não deve forçar dados que podem ser preenchidos depois.
- A criação deve ser rápida, pois coleções podem começar como ideias.

## 16. modelos

### objetivo

Exibir modelos e miniaturas como biblioteca visual, com filtros por coleção, status, tags e etapa de produção.

### entrada na navegação

- Item `modelos` na navegação lateral.
- Detalhe de coleção.
- Tela inicial.
- Busca global.

### conteúdo principal

- Mosaico de modelos.
- Filtros por coleção, status, tags e escala.
- Ordenação por atualização, criação, nome ou status.
- Alternância futura entre mosaico e lista, se aprovada.

### ações disponíveis

- Criar modelo.
- Abrir detalhe do modelo.
- Editar modelo.
- Abrir pasta principal.
- Enviar arquivo para fila, quando houver arquivo pronto.
- Arquivar modelo.

### relação com outras telas

- Abre detalhe do modelo.
- Abre criação e edição de modelo.
- Pode filtrar por coleção.
- Pode se conectar à fila de impressão.

### dados exibidos

- Capa.
- Título.
- Coleção.
- Status.
- Tags.
- Escala, quando houver.
- Data de atualização.

### estados especiais

- Nenhum modelo cadastrado.
- Nenhum resultado para filtros.
- Modelo sem capa.
- Modelo arquivado.
- Pasta principal ausente.

### observações de UX/UI

- Deve ser visual por padrão.
- Status de produção deve ser fácil de perceber.
- Não deve exigir abertura do detalhe para reconhecer um modelo.

## 17. detalhe do modelo

### objetivo

Ser a ficha completa da miniatura, reunindo descrição, galeria, arquivos, materiais, links, checklist, status e histórico.

### entrada na navegação

- Clique em modelo.
- Detalhe de coleção.
- Tela inicial.
- Busca global.
- Fila de impressão.

### conteúdo principal

- Capa grande.
- Título.
- Coleção de origem.
- Status atual.
- Tags.
- Escala e tamanho estimado.
- Descrição.
- Ações de pasta e arquivos.
- Galeria visual.
- Links específicos.
- Materiais usados.
- Arquivos vinculados.
- Checklist de produção.
- Histórico.
- Notas.

### ações disponíveis

- Editar modelo.
- Abrir pasta principal.
- Abrir arquivos 3D.
- Abrir fatiamento.
- Adicionar imagem.
- Definir capa.
- Adicionar arquivo.
- Adicionar link.
- Vincular material.
- Marcar checklist.
- Registrar histórico.
- Enviar arquivo para fila de impressão.
- Arquivar modelo.

### relação com outras telas

- Volta para detalhe da coleção.
- Abre galeria.
- Abre visualização de imagem.
- Abre arquivos vinculados.
- Abre links específicos.
- Abre materiais relacionados.
- Abre fila de impressão com contexto do modelo.

### dados exibidos

- Metadados completos do modelo.
- Galeria e capa.
- Caminhos vinculados.
- Status de produção.
- Materiais, links e checklist.

### estados especiais

- Modelo sem galeria.
- Modelo sem arquivos.
- Modelo sem links.
- Modelo sem materiais.
- Pasta ausente.
- Arquivo pronto ausente.
- Modelo arquivado.
- Erro ao abrir caminho.

### observações de UX/UI

- Deve ser a tela mais rica do app.
- Áreas opcionais não devem ocupar espaço quando vazias, salvo quando forem chamadas à ação.
- A ficha deve equilibrar visual e operação.

## 18. criação e edição de modelo

### objetivo

Permitir cadastrar ou alterar um modelo dentro de uma coleção.

### entrada na navegação

- Ação `criar modelo` no detalhe da coleção.
- Ação `criar modelo` na tela de modelos.
- Ação `editar` no detalhe do modelo.

### conteúdo principal

- Título.
- Slug.
- Coleção relacionada.
- Status.
- Capa.
- Descrição.
- Tags.
- Escala.
- Tamanho estimado.
- Pasta principal.
- Observações.

### ações disponíveis

- Salvar.
- Cancelar.
- Selecionar coleção.
- Selecionar capa.
- Selecionar pasta.
- Criar estrutura padrão de pastas do modelo.
- Remover capa.
- Arquivar, quando em edição.

### relação com outras telas

- Ao salvar, abre detalhe do modelo ou retorna à origem.
- Pode abrir seletor de pasta.
- Pode criar pastas conforme configurações.

### dados exibidos

- Dados atuais do modelo.
- Coleção selecionada.
- Validações.
- Status do caminho.

### estados especiais

- Título vazio.
- Sem coleção selecionada.
- Slug duplicado dentro da coleção.
- Pasta inválida.
- Erro ao salvar.
- Alterações não salvas.

### observações de UX/UI

- Deve permitir salvar modelo ainda incompleto.
- O fluxo deve favorecer criação rápida a partir de uma coleção.

## 19. galeria

### objetivo

Exibir e organizar imagens de referência, renders, processo, pintura, fotos finais, paletas e texturas.

### entrada na navegação

- Seção de galeria no detalhe da coleção.
- Seção de galeria no detalhe do modelo.
- Ação `ver galeria`.

### conteúdo principal

- Mosaico de imagens.
- Filtro por tipo.
- Tags.
- Ação para adicionar imagem.
- Indicação de imagem usada como capa.

### ações disponíveis

- Adicionar imagem.
- Abrir imagem.
- Editar metadados.
- Definir como capa.
- Remover vínculo da imagem.
- Copiar caminho.
- Abrir pasta da imagem.

### relação com outras telas

- Abre visualização de imagem.
- Atualiza capa de coleção ou modelo.
- Volta ao detalhe da coleção ou modelo.

### dados exibidos

- Miniatura.
- Tipo de imagem.
- Título.
- Tags.
- Indicador de capa.
- Status de arquivo existente ou ausente.

### estados especiais

- Galeria vazia.
- Imagem ausente.
- Tipo sem resultados.
- Erro ao abrir imagem.
- Erro ao definir capa.

### observações de UX/UI

- Deve ser visual em primeiro lugar.
- Filtros devem ajudar sem quebrar a navegação.
- Imagens ausentes devem ser visíveis, mas não devem quebrar o mosaico.

## 20. visualização de imagem

### objetivo

Permitir ver uma imagem em tamanho maior e acessar seus metadados e ações.

### entrada na navegação

- Clique em imagem na galeria.
- Clique em capa, quando permitido.
- Resultado da busca global.

### conteúdo principal

- Imagem em destaque.
- Título.
- Descrição.
- Tipo.
- Tags.
- Caminho.
- Relação com coleção ou modelo.

### ações disponíveis

- Voltar à galeria.
- Definir como capa.
- Abrir no visualizador padrão.
- Abrir pasta.
- Copiar caminho.
- Editar metadados.
- Remover vínculo.

### relação com outras telas

- Volta para galeria.
- Pode atualizar detalhe da coleção ou modelo ao definir capa.

### dados exibidos

- Imagem.
- Metadados.
- Status do arquivo.

### estados especiais

- Arquivo ausente.
- Formato não suportado para preview.
- Erro ao abrir arquivo externo.

### observações de UX/UI

- Deve focar na imagem.
- Ações devem ser claras, mas não competir com a visualização.

## 21. arquivos vinculados

### objetivo

Listar arquivos e pastas relacionados a coleções e modelos, com ações de abertura, cópia, validação e envio para fila.

### entrada na navegação

- Seção de arquivos no detalhe do modelo.
- Seção de arquivos no detalhe da coleção, se houver.
- Busca global.
- Arquivos recentes.

### conteúdo principal

- Lista ou tabela de arquivos.
- Filtros por tipo, categoria e status.
- Caminho resumido.
- Indicador de existência.
- Relação com coleção ou modelo.

### ações disponíveis

- Adicionar arquivo.
- Adicionar pasta.
- Abrir arquivo.
- Abrir pasta.
- Copiar caminho.
- Validar existência.
- Mover ou copiar arquivo, se aprovado.
- Enviar para fila de impressão.
- Editar metadados.
- Remover vínculo.

### relação com outras telas

- Pode abrir fila de impressão.
- Pode abrir detalhe do modelo.
- Pode aparecer em resultados de busca.

### dados exibidos

- Nome.
- Extensão.
- Tipo.
- Categoria.
- Tamanho.
- Datas.
- Caminho.
- Status.

### estados especiais

- Nenhum arquivo vinculado.
- Arquivo ausente.
- Pasta inacessível.
- Caminho de rede offline.
- Erro ao abrir.
- Conflito ao copiar ou mover.

### observações de UX/UI

- Deve ser mais operacional que visual.
- Lista ou tabela é adequada por causa de caminhos e metadados.

## 22. fila de impressão

### objetivo

Organizar arquivos e modelos prontos para impressão, com status, destino e histórico de tentativa.

### entrada na navegação

- Item `fila de impressão` na navegação lateral.
- Ação no detalhe do modelo.
- Ação em arquivos vinculados.
- Tela inicial.

### conteúdo principal

- Lista ou tabela de itens da fila.
- Agrupamento ou filtro por status.
- Destino local ou de rede.
- Histórico resumido.
- Alertas de caminhos offline.

### ações disponíveis

- Abrir arquivo.
- Abrir pasta.
- Copiar para pasta de rede.
- Marcar como enviado.
- Marcar como imprimindo.
- Marcar como impresso.
- Registrar falha.
- Cancelar.
- Arquivar.
- Adicionar observação.

### relação com outras telas

- Abre detalhe do modelo.
- Abre arquivos vinculados.
- Abre configurações de caminhos de rede quando destino estiver offline.

### dados exibidos

- Modelo relacionado.
- Arquivo relacionado.
- Status.
- Caminho do arquivo.
- Destino.
- Data de envio.
- Observação.
- Histórico de tentativa.

### estados especiais

- Fila vazia.
- Arquivo ausente.
- Destino offline.
- Sem destino configurado.
- Erro ao copiar.
- Arquivo já existe no destino.
- Operação concluída com sucesso.

### observações de UX/UI

- Deve ser clara e confiável.
- Não deve tentar controlar a impressora diretamente.
- Ações com risco de sobrescrita devem exigir confirmação futura.

## 23. arquivos recentes

### objetivo

Mostrar arquivos vinculados, acessados, importados ou alterados recentemente.

### entrada na navegação

- Item `arquivos recentes` na navegação lateral.
- Card ou seção na tela inicial.

### conteúdo principal

- Lista de arquivos recentes.
- Filtros por período.
- Filtros por coleção, modelo, tipo e status.
- Indicador de arquivo existente ou ausente.

### ações disponíveis

- Abrir arquivo.
- Abrir pasta.
- Copiar caminho.
- Abrir modelo ou coleção relacionada.
- Validar existência.
- Enviar para fila, quando aplicável.

### relação com outras telas

- Leva para detalhe do modelo.
- Leva para detalhe da coleção.
- Leva para arquivos vinculados.
- Pode enviar para fila de impressão.

### dados exibidos

- Nome.
- Extensão.
- Tipo.
- Caminho resumido.
- Data de acesso ou atualização.
- Relação com coleção ou modelo.

### estados especiais

- Nenhum arquivo recente.
- Arquivo ausente.
- Caminho offline.
- Erro ao abrir.

### observações de UX/UI

- Deve ajudar a retomar trabalho rapidamente.
- Lista é mais adequada que mosaico como padrão.

## 24. materiais

### objetivo

Listar materiais e utensílios usados no atelier.

### entrada na navegação

- Item `materiais` na navegação lateral.
- Detalhe do modelo, na seção de materiais usados.
- Busca global.

### conteúdo principal

- Lista, tabela ou mosaico leve de materiais.
- Filtros por tipo, marca, cor, fornecedor e favoritos.
- Busca local.

### ações disponíveis

- Criar material.
- Abrir detalhe de material.
- Editar material.
- Favoritar material.
- Abrir link de compra.
- Vincular a modelo, quando em contexto de modelo.

### relação com outras telas

- Abre detalhe de material.
- Pode voltar ao modelo relacionado.
- Pode aparecer em favoritos e busca.

### dados exibidos

- Nome.
- Tipo.
- Marca.
- Cor.
- Fornecedor.
- Quantidade opcional.
- Unidade opcional.
- Favorito.

### estados especiais

- Nenhum material cadastrado.
- Nenhum resultado para filtros.
- Link de compra ausente.
- Material sem fornecedor.

### observações de UX/UI

- Deve ser simples e útil, sem virar estoque complexo nesta fase.
- Pode ter modo visual se cor ou imagem fizerem sentido no design futuro.

## 25. detalhe de material

### objetivo

Mostrar dados completos de um material e seus vínculos com modelos.

### entrada na navegação

- Clique em material.
- Busca global.
- Detalhe do modelo.
- Favoritos, se material puder ser favorito.

### conteúdo principal

- Nome.
- Tipo.
- Marca.
- Cor.
- Observação.
- Link de compra.
- Fornecedor.
- Quantidade e unidade opcionais.
- Modelos relacionados.

### ações disponíveis

- Editar material.
- Abrir link de compra.
- Favoritar.
- Vincular a modelo.
- Remover vínculo com modelo.
- Remover material, se permitido.

### relação com outras telas

- Leva para modelos relacionados.
- Leva para favoritos.
- Leva para edição de material.

### dados exibidos

- Dados do material.
- Lista de modelos que usam o material.
- Status de favorito.

### estados especiais

- Material sem modelos vinculados.
- Link inválido ou ausente.
- Erro ao abrir link.

### observações de UX/UI

- Deve ser uma ficha simples.
- Modelos relacionados devem ter acesso visual quando possível.

## 26. favoritos globais

### objetivo

Centralizar links e atalhos importantes do atelier.

### entrada na navegação

- Item `favoritos` na navegação lateral.
- Barra rápida de favoritos.
- Busca global.

### conteúdo principal

- Favoritos por categoria.
- Cards ou lista de favoritos.
- Busca e filtros.
- Indicação de tipo: link externo, coleção, modelo, material ou outro.

### ações disponíveis

- Criar favorito.
- Editar favorito.
- Remover favorito.
- Abrir link externo.
- Abrir item interno.
- Fixar ou remover da barra rápida.
- Reorganizar, se aprovado.

### relação com outras telas

- Abre navegador padrão para links externos.
- Abre detalhe de coleção, modelo ou material para itens internos.
- Alimenta a barra rápida de favoritos.

### dados exibidos

- Título.
- Categoria.
- Tipo.
- Descrição curta.
- Tags.
- URL ou destino interno.
- Status de fixado.

### estados especiais

- Nenhum favorito cadastrado.
- Favorito com link inválido.
- Item interno arquivado.
- Erro ao abrir link.

### observações de UX/UI

- Deve lembrar favoritos de navegador, mas adaptado ao atelier.
- Pode usar cards visuais para atalhos importantes.

## 27. barra rápida de favoritos

### objetivo

Dar acesso imediato aos favoritos mais usados.

### entrada na navegação

- Área persistente definida pelo layout futuro.
- Pode aparecer na tela inicial, topo ou lateral, conforme design system.

### conteúdo principal

- Favoritos fixados.
- Atalhos externos e internos.
- Indicador de favorito inválido, se necessário.

### ações disponíveis

- Abrir favorito.
- Remover da barra rápida.
- Ir para tela completa de favoritos.

### relação com outras telas

- Abre links externos.
- Navega para coleções, modelos ou materiais.
- Sincroniza com favoritos globais.

### dados exibidos

- Título curto.
- Tipo ou categoria.
- Ícone futuro, se definido no design system.

### estados especiais

- Nenhum favorito fixado.
- Link inválido.
- Item interno arquivado ou removido.

### observações de UX/UI

- Deve ser discreta e rápida.
- Não deve ocupar espaço demais das telas principais.

## 28. links específicos de coleção/modelo

### objetivo

Mostrar links vinculados a uma coleção ou modelo específico.

### entrada na navegação

- Seção de links no detalhe da coleção.
- Seção de links no detalhe do modelo.
- Busca global.

### conteúdo principal

- Lista ou cards de links.
- Categoria.
- Descrição curta.
- Tags.
- Status de favorito.

### ações disponíveis

- Adicionar link.
- Editar link.
- Remover link.
- Abrir link.
- Marcar como favorito.
- Copiar URL.

### relação com outras telas

- Pode alimentar favoritos globais.
- Volta para coleção ou modelo relacionado.

### dados exibidos

- Título.
- URL.
- Categoria.
- Descrição.
- Tags.
- Datas.
- Favorito sim ou não.

### estados especiais

- Nenhum link cadastrado.
- URL inválida.
- Erro ao abrir link externo.

### observações de UX/UI

- A seção só deve aparecer no detalhe quando houver links ou quando o usuário acionar adicionar.
- Links devem ser úteis e não competir com galeria e arquivos.

## 29. busca global

### objetivo

Oferecer uma tela completa para localizar qualquer informação importante do app.

### entrada na navegação

- Item `busca` na navegação lateral.
- Campo ou acionador da barra superior.
- Atalho de teclado futuro, se aprovado.

### conteúdo principal

- Campo de busca.
- Resultados agrupados.
- Filtros por tipo.
- Histórico de buscas recentes, se aprovado.

### ações disponíveis

- Pesquisar.
- Filtrar resultados.
- Abrir resultado.
- Limpar busca.
- Copiar caminho, quando resultado for arquivo.
- Abrir pasta, quando aplicável.

### relação com outras telas

- Abre coleção.
- Abre modelo.
- Abre arquivo vinculado.
- Abre link.
- Abre material.
- Abre configuração relacionada, se fizer sentido.

### dados exibidos

- Tipo do resultado.
- Título.
- Contexto.
- Trecho de descrição, nota ou caminho.
- Status, quando útil.

### estados especiais

- Busca vazia.
- Sem resultados.
- Erro ao pesquisar.
- Resultado aponta para arquivo ausente.

### observações de UX/UI

- Deve favorecer ação rápida.
- Resultados visuais podem usar miniaturas quando forem coleções, modelos ou imagens.

## 30. configurações

### objetivo

Centralizar ajustes do app, caminhos, rede, tema, pastas, programas padrão e backup.

### entrada na navegação

- Item `configurações` na navegação lateral.
- Alertas da tela inicial.
- Alertas de fila de impressão.

### conteúdo principal

- Categorias de configuração.
- Resumo de caminhos principais.
- Status de caminhos de rede.
- Tema atual.
- Backup.
- Modelo de pastas.

### ações disponíveis

- Abrir configurações de caminhos locais.
- Abrir configurações de caminhos de rede.
- Abrir modelo padrão de pastas.
- Abrir tema e aparência.
- Abrir backup.
- Testar caminhos.

### relação com outras telas

- Afeta criação de coleções e modelos.
- Afeta fila de impressão.
- Afeta tema do app.
- Afeta sistema de arquivos.

### dados exibidos

- Resumo das principais configurações.
- Status de caminhos.
- Alertas de pendência.

### estados especiais

- Primeira configuração do app.
- Caminhos obrigatórios ausentes.
- Caminhos de rede offline.
- Erro ao salvar configuração.

### observações de UX/UI

- Configurações devem ser completas, mas organizadas por seções.
- Não deve parecer uma única tela longa e confusa.

## 31. configurações de caminhos locais

### objetivo

Configurar pastas locais usadas pelo atelier.

### entrada na navegação

- Configurações.
- Alertas de caminho local ausente.

### conteúdo principal

- Pasta principal do atelier.
- Pasta de coleções.
- Pasta de backups.
- Pasta temporária.
- Pasta de importação.
- Pasta de exportação.

### ações disponíveis

- Selecionar pasta.
- Testar caminho.
- Abrir pasta.
- Copiar caminho.
- Salvar.
- Restaurar padrão, se aprovado.

### relação com outras telas

- Afeta criação de coleções.
- Afeta criação de modelos.
- Afeta backup.
- Afeta importação e exportação.

### dados exibidos

- Nome do caminho.
- Caminho completo.
- Status.
- Último teste.
- Observação.

### estados especiais

- Caminho vazio.
- Caminho inexistente.
- Sem permissão.
- Caminho válido.
- Erro ao abrir pasta.

### observações de UX/UI

- Deve deixar claro o impacto de cada pasta.
- Testar caminho deve ser uma ação simples.

## 32. configurações de caminhos de rede

### objetivo

Configurar e testar caminhos de rede usados para impressão, arquivos compartilhados e backups.

### entrada na navegação

- Configurações.
- Alerta de rede offline.
- Fila de impressão.

### conteúdo principal

- Lista de caminhos de rede.
- Tipo do caminho.
- Status.
- Último teste.
- Observações.

### ações disponíveis

- Adicionar caminho.
- Editar caminho.
- Remover caminho.
- Testar conexão.
- Abrir pasta.
- Copiar caminho.
- Marcar como destino padrão da fila, se aprovado.

### relação com outras telas

- Afeta fila de impressão.
- Afeta alertas da tela inicial.
- Afeta arquivos vinculados em rede.
- Afeta backups em rede.

### dados exibidos

- Nome.
- Caminho.
- Tipo.
- Status.
- Último teste.
- Observação.

### estados especiais

- Nenhum caminho de rede configurado.
- Caminho offline.
- Caminho inacessível por permissão.
- Caminho válido.
- Erro ao testar.

### observações de UX/UI

- O app deve lidar bem com rede instável.
- Caminho offline deve informar, não bloquear o uso local.

## 33. configurações de modelo padrão de pastas

### objetivo

Permitir definir quais pastas serão criadas automaticamente para coleções e modelos.

### entrada na navegação

- Configurações.
- Fluxo de criação de coleção ou modelo, quando for necessário revisar estrutura.

### conteúdo principal

- Modelo de pastas para coleção.
- Modelo de pastas para modelo.
- Lista hierárquica de subpastas.
- Indicação de pastas obrigatórias e opcionais, se aprovado.

### ações disponíveis

- Adicionar pasta.
- Renomear pasta.
- Remover pasta.
- Reordenar pasta, se aprovado.
- Restaurar modelo sugerido.
- Salvar.
- Visualizar prévia da estrutura.

### relação com outras telas

- Afeta criação de coleção.
- Afeta criação de modelo.
- Afeta organização automática de arquivos.

### dados exibidos

- Estrutura de pastas.
- Tipo de estrutura: coleção ou modelo.
- Status de validade dos nomes.

### estados especiais

- Nome inválido.
- Pasta duplicada.
- Estrutura vazia.
- Erro ao salvar.

### observações de UX/UI

- Deve ser claro e seguro.
- Não deve alterar pastas já existentes sem confirmação futura.

## 34. configurações de tema/aparência

### objetivo

Permitir configurar aparência do app dentro dos limites do design system aprovado.

### entrada na navegação

- Configurações.

### conteúdo principal

- Tema claro.
- Tema escuro.
- Tema automático, se aprovado.
- Cor de destaque.
- Tamanho dos cards.
- Densidade da interface.

### ações disponíveis

- Selecionar tema.
- Ajustar tamanho de cards.
- Ajustar densidade.
- Restaurar padrão.
- Salvar.

### relação com outras telas

- Afeta todo o app.
- Deve respeitar design system.
- Deve ser validada visualmente nas principais telas.

### dados exibidos

- Configuração atual.
- Prévia simples futura, se aprovada.

### estados especiais

- Erro ao salvar tema.
- Configuração inválida.
- Tema automático indisponível, se não for implementado.

### observações de UX/UI

- Esta tela não define o design system.
- Ela apenas permite aplicar opções aprovadas.
- Visual aprovado não pode ser alterado pelo Codex sem autorização.

## 35. configurações de backup

### objetivo

Permitir backup, exportação e restauração de dados e configurações.

### entrada na navegação

- Configurações.

### conteúdo principal

- Backup manual.
- Backup automático, se aprovado.
- Pasta de backup.
- Exportar banco.
- Importar banco.
- Exportar configurações.
- Importar configurações.
- Histórico simples de backups, se aprovado.

### ações disponíveis

- Executar backup.
- Escolher pasta de backup.
- Exportar banco.
- Importar banco.
- Exportar configurações.
- Importar configurações.
- Abrir pasta de backup.

### relação com outras telas

- Usa caminhos locais.
- Pode usar caminhos de rede.
- Protege banco SQLite e configurações.

### dados exibidos

- Pasta de backup.
- Último backup.
- Status do backup.
- Tamanho ou data do arquivo, se disponível.

### estados especiais

- Nenhuma pasta de backup configurada.
- Caminho de backup offline.
- Falha ao criar backup.
- Backup concluído com sucesso.
- Importação com risco de sobrescrita.

### observações de UX/UI

- Ações de importação devem exigir confirmação futura.
- Mensagens devem ser claras, pois backup protege o trabalho do atelier.

## 36. estados vazios, erro, offline, sucesso e carregamento

### objetivo

Padronizar como telas devem lidar com ausência de dados, falhas, rede offline, sucesso e carregamento.

### entrada na navegação

- Todos os fluxos do app.

### conteúdo principal

- Estados vazios por área.
- Alertas de erro.
- Alertas de caminho offline.
- Confirmações de sucesso.
- Indicadores de carregamento.

### ações disponíveis

- Criar primeiro item.
- Tentar novamente.
- Abrir configurações.
- Testar caminho.
- Ver detalhes do erro, se útil.
- Fechar mensagem.

### relação com outras telas

- Aparece em coleções, modelos, galeria, arquivos, fila, materiais, favoritos, busca e configurações.
- Deve respeitar contexto da tela.

### dados exibidos

- Mensagem curta.
- Causa provável, quando conhecida.
- Próxima ação recomendada.

### estados especiais

- Sem dados.
- Sem resultados.
- Carregando.
- Erro de banco.
- Erro de arquivo.
- Caminho local ausente.
- Caminho de rede offline.
- Operação concluída.

### observações de UX/UI

- Mensagens devem ser humanas, curtas e úteis.
- Estados vazios devem incentivar a próxima ação.
- Erros não devem culpar o usuário.
- Offline deve ser tratado como condição normal para caminhos de rede.

## 37. regras para evidência visual futura

Quando telas forem implementadas, cada tarefa visual deve gerar evidência adequada.

Evidências recomendadas:

- screenshot da tela principal alterada;
- screenshot em tema claro e escuro, quando houver tema implementado;
- descrição de rota ou caminho para abrir a tela;
- resumo das ações testadas;
- registro de estados vazios ou de erro, quando relevantes.

Regras:

- Não basta dizer que a tela foi criada.
- Deve haver indicação clara de como validar.
- Textos não devem aparecer cortados ou sobrepostos.
- Mosaicos, listas e formulários devem ser conferidos visualmente.
- Visual aprovado não deve ser alterado sem autorização explícita.

## 38. resumo do mapa

O Blue Atelier terá uma navegação centrada em:

- painel inicial;
- coleções visuais;
- modelos como fichas completas;
- galerias de imagens;
- arquivos e caminhos reais do Windows;
- favoritos globais;
- materiais;
- fila de impressão;
- busca global;
- configurações completas.

Este mapa define fluxo e função das telas. O próximo passo é criar `docs/08-design-system.md`, que deverá definir a linguagem visual, temas, componentes, espaçamentos, cards, mosaicos, formulários e regras de aparência.
