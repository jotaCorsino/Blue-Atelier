# blue atelier — tela inicial

## 1. objetivo da tela inicial

A tela inicial é o primeiro painel real do Blue Atelier. Ela apresenta uma visão visual e confortável do atelier, com atalhos para coleções, modelos em andamento, itens prontos para impressão, arquivos recentes e favoritos rápidos.

Ela substitui o placeholder visual criado na fundação do app, mas ainda não implementa dados reais, banco SQLite, busca real, fila de impressão real ou integração com arquivos.

## 2. referência visual usada

Referência principal:

```txt
referencias-visuais/stitch/html/01-inicio.html
```

Referências de apoio:

```txt
referencias-visuais/stitch/design.md
docs/08-design-system.md
docs/15-referencias-visuais-stitch.md
docs/17-fundacao-visual.md
```

A tela foi traduzida para Razor Components e CSS próprio. O HTML exportado pelo Stitch não foi copiado como código final.

## 3. arquivos alterados ou criados

Arquivos alterados:

- `src/blueatelier.app/Components/Pages/Home.razor`
- `src/blueatelier.app/wwwroot/css/app.css`
- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`

Arquivo criado:

- `docs/18-tela-inicial.md`

## 4. seções implementadas

Foram implementadas as seguintes seções visuais:

- Cabeçalho da Home com título `Início`, subtítulo curto e ações principais.
- Botão principal `Criar nova coleção`.
- Botão secundário `Importar modelo`.
- Aviso discreto de caminho de rede offline.
- Cards de resumo do atelier.
- Mosaico de coleções recentes.
- Cards de modelos em andamento com progresso visual.
- Lista visual de itens prontos para impressão.
- Lista de arquivos recentes.
- Favoritos rápidos.

## 5. dados mockados usados

Os dados são estáticos e existem apenas para representação visual.

Coleções recentes:

- Eldritch Horrors
- Sci-Fi Marines
- Fantasy Adventurers
- Dragon Busts

Modelos em andamento:

- Cthulhu Idol
- Deep One Bust
- Tentacle Beast

Itens prontos para impressão:

- Ancient Cultist
- Abyssal Statue

Arquivos recentes:

- `cthulhu-idol-ready.ctb`
- `stone-texture-reference.jpg`
- `painting-notes.md`

Favoritos rápidos:

- MyMiniFactory
- Resin Settings
- Stone Textures

## 6. componentes criados

Nenhum componente novo foi criado nesta tarefa.

A tela usa os componentes base já existentes:

- `AppCard`
- `AppBadge`
- `AppButton`

Os blocos específicos da Home ficaram dentro de `Home.razor` para manter a tarefa simples e limitada à primeira tela real.

## 7. o que ainda é provisório

- Os botões são visuais e ainda não executam ações reais.
- O aviso de caminho de rede offline é mockado.
- Os cards de resumo usam números fixos.
- As coleções, modelos, arquivos e favoritos são exemplos estáticos.
- O progresso dos modelos é visual e não vem de banco.
- A ação `Enviar` nos itens prontos para impressão é provisória.

## 8. o que ainda não foi implementado

Ainda não foram implementados:

- Tela de Coleções.
- Tela de Modelos.
- Galeria.
- Busca global real.
- Favoritos persistidos.
- Banco SQLite.
- Entity Framework Core.
- Migrations.
- Serviços internos reais.
- Sistema de arquivos real.
- Caminhos locais e de rede reais.
- Fila de impressão real.
- Importação de arquivos.
- Abertura de arquivos e pastas.

## 9. validações executadas

Validações de referência:

- `referencias-visuais/stitch/design.md` foi lido.
- `referencias-visuais/stitch/html/01-inicio.html` foi consultado.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- A tela foi implementada em Razor Components e CSS próprio.
- Somente a tela inicial foi implementada.
- Nenhuma outra tela real foi implementada.

Validações técnicas:

- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- Build finalizado com 0 avisos e 0 erros.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.
- 1 teste aprovado.

Validações de escopo:

- Nenhum banco SQLite foi criado.
- Nenhum EF Core foi implementado.
- Nenhuma migration foi criada.
- Nenhum serviço real foi implementado.
- Nenhum sistema de arquivos real foi implementado.
- Nenhuma busca real foi implementada.
- Nenhuma fila de impressão real foi implementada.
- Tailwind, Bootstrap externo e CDN não foram usados.

Evidência visual descrita:

A tela inicial mostra a sidebar e topbar existentes, um cabeçalho com ações principais, aviso discreto de rede offline, cards de resumo, mosaico de coleções recentes, cards de modelos com barra de progresso, lista de itens prontos para impressão, arquivos recentes e favoritos rápidos. O visual permanece neutro, espaçoso e usa azul apenas como destaque e ação.

## 10. próxima etapa sugerida

Implementar a tela de Coleções com base em:

```txt
referencias-visuais/stitch/html/02-colecoes.html
```

A próxima tarefa deve continuar preservando a fundação visual, sem redesenhar a identidade aprovada pelo Stitch e sem implementar funcionalidades reais fora do escopo da tela solicitada.
