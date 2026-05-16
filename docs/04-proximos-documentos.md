# blue atelier — próximos documentos

Este arquivo lista os documentos criados, registra o fechamento da base documental inicial do Blue Atelier e acompanha documentos criados depois dessa base.

## documentos já criados

### 1. planejamento de desenvolvimento

Arquivo:

```txt
docs/05-planejamento-de-desenvolvimento.md
```

Objetivo:

Organizar a construção completa do app em etapas, features, dependências e critérios de validação.

### 2. arquitetura técnica

Arquivo:

```txt
docs/06-arquitetura-tecnica.md
```

Objetivo:

Definir stack, camadas, banco de dados, serviços, estrutura de pastas do código, padrões e decisões técnicas.

### 3. mapa de telas

Arquivo:

```txt
docs/07-mapa-de-telas.md
```

Objetivo:

Descrever todas as telas do app, navegação, componentes e comportamento esperado.

### 4. design system

Arquivo:

```txt
docs/08-design-system.md
```

Objetivo:

Definir cores, tipografia, espaçamentos, cards, botões, layout, tema claro, tema escuro e regras visuais.

### 5. prompts para stitch

Arquivo:

```txt
docs/09-prompts-stitch.md
```

Objetivo:

Guardar prompts para geração e refinamento visual das telas no Stitch.

### 6. prompts para antigravity

Arquivo:

```txt
docs/10-prompts-antigravity.md
```

Objetivo:

Guardar prompts para tarefas de implementação assistida, revisão e validação no Antigravity.

### 7. comandos para codex

Arquivo:

```txt
docs/11-comandos-codex.md
```

Objetivo:

Registrar comandos/prompt de cada tarefa enviada ao Codex, mantendo histórico operacional.

### 8. banco de dados

Arquivo:

```txt
docs/12-modelagem-do-banco.md
```

Objetivo:

Definir entidades, relações, campos, índices e regras de persistência.

### 9. sistema de arquivos

Arquivo:

```txt
docs/13-sistema-de-arquivos.md
```

Objetivo:

Definir estrutura de pastas, caminhos, slugs, arquivos aceitos e integração com rede.

### 10. checklist de validação

Arquivo:

```txt
docs/14-checklist-de-validacao.md
```

Objetivo:

Definir critérios para validar tarefas documentais, técnicas, visuais e futuras implementações antes de avançar.

### 11. referências visuais do Stitch

Arquivo:

```txt
docs/15-referencias-visuais-stitch.md
```

Objetivo:

Catalogar e proteger as referências visuais exportadas do Stitch, incluindo HTMLs, imagens, `design.md`, padrões visuais aprovados e regras para implementação futura.

Observação:

Este documento foi criado após a conclusão da base documental inicial.

### 12. estrutura da solução

Arquivo:

```txt
docs/16-estrutura-da-solucao.md
```

Objetivo:

Registrar a solution .NET criada, os projetos de camada, dependências entre projetos, comandos de restore/build, observações sobre MAUI workload e limites do que ainda não foi implementado.

Observação:

Este documento foi criado após o início da fase de implementação base.

### 13. fundação visual

Arquivo:

```txt
docs/17-fundacao-visual.md
```

Objetivo:

Registrar a fundação visual compartilhada do app, incluindo layout base, sidebar, topbar, componentes base, tokens CSS, temas claro/escuro e limites para próximas tarefas visuais.

Observação:

Este documento foi criado após a criação da solução base e marca o início da fundação visual reutilizável.

### 14. tela inicial

Arquivo:

```txt
docs/18-tela-inicial.md
```

Objetivo:

Registrar a implementação da primeira tela real do app, incluindo referência visual usada, seções implementadas, dados mockados, arquivos alterados, validações e limites do que ainda é provisório.

Observação:

Este documento foi criado após a fundação visual e registra que a primeira tela real foi implementada com base no Stitch.

## base documental inicial concluída

A base documental inicial do Blue Atelier está concluída.

Documentos criados nesta base:

- `docs/05-planejamento-de-desenvolvimento.md`
- `docs/06-arquitetura-tecnica.md`
- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/09-prompts-stitch.md`
- `docs/10-prompts-antigravity.md`
- `docs/11-comandos-codex.md`
- `docs/12-modelagem-do-banco.md`
- `docs/13-sistema-de-arquivos.md`
- `docs/14-checklist-de-validacao.md`

## documentos criados após a base documental inicial

- `docs/15-referencias-visuais-stitch.md`
- `docs/16-estrutura-da-solucao.md`
- `docs/17-fundacao-visual.md`
- `docs/18-tela-inicial.md`

O documento `docs/15-referencias-visuais-stitch.md` registra que a direção visual do Stitch foi aprovada e que os arquivos em `referencias-visuais/stitch/` devem ser tratados como referência visual protegida.

O documento `docs/16-estrutura-da-solucao.md` registra que a fase de implementação base foi iniciada após a catalogação das referências visuais.

O documento `docs/17-fundacao-visual.md` registra que a fundação visual foi iniciada após a criação da solução base.

O documento `docs/18-tela-inicial.md` registra que a primeira tela real foi implementada após a fundação visual, ainda usando dados mockados e sem implementar banco, serviços reais ou outras telas.

## próxima etapa sugerida

Implementar a tela de Coleções com base em `referencias-visuais/stitch/html/02-colecoes.html`.

Essa próxima etapa deve usar como base:

- `docs/06-arquitetura-tecnica.md`
- `docs/07-mapa-de-telas.md`
- `docs/08-design-system.md`
- `docs/14-checklist-de-validacao.md`
- `docs/15-referencias-visuais-stitch.md`
- `docs/16-estrutura-da-solucao.md`
- `docs/17-fundacao-visual.md`
- `docs/18-tela-inicial.md`

Nas próximas telas, o Codex deve preservar o visual aprovado do Stitch e não pode redesenhar, reinterpretar ou simplificar a proposta visual sem autorização explícita.
