# blue atelier - estado atual

## status geral

Projeto com base documental inicial concluida, referencias visuais do Stitch catalogadas, solucao base .NET MAUI Blazor Hybrid criada, fundacao visual compartilhada implementada e onze telas reais criadas com dados mockados:

- Home;
- Colecoes;
- Detalhe da Colecao;
- Detalhe do Modelo;
- Galeria do Modelo;
- Visualizacao de Imagem;
- Arquivos Vinculados;
- Fila de Impressao;
- Modelos;
- Arquivos Recentes;
- Materiais.

A Home, Colecoes, Detalhe da Colecao, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados, Fila de Impressao, Modelos, Arquivos Recentes, Materiais, sidebar, topbar, tipografia, responsividade e paleta visual atual foram validados visualmente pelo usuario e estao aprovados.

O visual aprovado esta protegido. O Codex nao deve redesenhar, reinterpretar, simplificar ou alterar a identidade visual aprovada sem autorizacao explicita do usuario.

## repositorio remoto

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

## ultima tarefa concluida

A ultima tarefa concluida consolidou:

- implementacao da tela Materiais com base em `referencias-visuais/stitch/html/10-materiais.html`;
- rota `/materiais`;
- uso de dados mockados;
- cards/lista de materiais;
- filtros visuais;
- acoes visuais provisorias;
- resumo visual de materiais;
- navegacao visual a partir da sidebar;
- correcao de contraste das tags de categoria dos materiais;
- correcao de sobreposicao das tags;
- correcoes de layout e responsividade em:
  - `/materiais`;
  - `/modelos`;
  - `/colecoes/eldritch-horrors/modelos/cthulhu-idol/galeria/main-reference`;
  - `/fila-impressao`;
  - `/arquivos-recentes`;
- tabelas com conteudo acessivel;
- cards sem corte de conteudo importante;
- preservacao das telas ja aprovadas;
- preservacao da paleta visual clean, moderna, azulada e menos colorida;
- aprovacao visual manual pelo usuario.

## decisoes ja tomadas

- O app se chama Blue Atelier.
- O app sera Windows local, de uso pessoal e completo.
- A stack oficial e .NET MAUI Blazor Hybrid, C#, SQLite, Entity Framework Core, Razor Components e CSS proprio.
- A arquitetura separa interface, dominio, aplicacao, infraestrutura e persistencia.
- O banco SQLite guardara metadados, relacoes, caminhos, status, tags, links, favoritos, materiais, configuracoes e historico.
- Arquivos pesados devem permanecer no sistema de arquivos.
- Caminhos locais e de rede fazem parte do escopo do app.
- Caminho de rede offline deve ser tratado como condicao normal.
- Remover vinculo no app nao deve apagar arquivo real.
- Stitch e fonte de referencia visual aprovada, mas nao e fonte final de codigo.
- Antigravity e apoio estrategico; Codex e o engenheiro principal do projeto.
- GitHub e a fonte de verdade apos cada commit e push.

## referencias visuais protegidas

Estes arquivos permanecem protegidos:

```txt
referencias-visuais/stitch/design.md
referencias-visuais/stitch/html/
referencias-visuais/stitch/imagens/
```

Regras vigentes:

- nao alterar HTMLs exportados do Stitch;
- nao alterar imagens exportadas do Stitch;
- nao alterar `design.md`;
- nao redesenhar telas aprovadas;
- nao transformar a interface em dashboard corporativo;
- nao usar Tailwind, Bootstrap externo, CDN ou imagens remotas como base do app.

## estado da implementacao

Implementado:

- solucao `BlueAtelier.sln`;
- projeto .NET MAUI Blazor Hybrid para Windows;
- projetos de camada em `src/`;
- projeto de testes em `tests/`;
- layout base em `MainLayout.razor`;
- sidebar em `AppSidebar.razor`;
- topbar em `AppTopbar.razor`;
- componentes base `AppCard`, `AppBadge` e `AppButton`;
- componente `AppIcon` com icones SVG inline;
- tokens e temas CSS em `wwwroot/css/`;
- Home aprovada e com cards de colecao navegaveis;
- tela de Colecoes aprovada;
- tela de Detalhe da Colecao aprovada;
- tela de Detalhe do Modelo aprovada;
- tela Galeria do Modelo aprovada;
- tela Visualizacao de Imagem aprovada;
- tela Arquivos Vinculados aprovada;
- tela Fila de Impressao aprovada;
- tela Modelos em `/modelos` aprovada;
- tela Arquivos Recentes em `/arquivos-recentes` aprovada;
- tela Materiais em `/materiais` aprovada;
- navegacao do card Cthulhu Idol para `/colecoes/eldritch-horrors/modelos/cthulhu-idol`;
- sidebar com Models ativo nas rotas de modelos;
- sidebar com Arquivos Recentes ativo em `/arquivos-recentes`;
- sidebar com Materiais ativo em `/materiais`;
- hover global de cards clicaveis;
- affordances visuais de edicao futura;
- tipografia moderna com stack de sistema;
- paleta visual mais clean, moderna, azulada e menos colorida;
- azul como cor principal de destaque;
- estados reais de sistema com uso discreto de verde, amarelo e vermelho;
- refinamento visual da barra anterior/proxima da Visualizacao de Imagem;
- correcao global de proporcao para capas, thumbnails, previews e imagens mockadas;
- ajuste de layout do Detalhe do Modelo para acompanhar melhor telas largas;
- paineis laterais responsivos da tela Arquivos Vinculados;
- acoes da lista de arquivos como icones com `title` e `aria-label`;
- capa/imagem principal da tela Arquivos Vinculados bem encaixada no header;
- contraste das tags de categoria em Materiais corrigido;
- correcoes de layout e responsividade em Materiais, Modelos, Visualizacao de Imagem, Fila de Impressao e Arquivos Recentes.

Ainda nao implementado:

- tela Detalhe do Material;
- SQLite;
- EF Core;
- migrations;
- entidades completas;
- servicos reais;
- sistema de arquivos real;
- busca real;
- filtros reais persistidos;
- fila de impressao real;
- configuracoes reais;
- leitura real de arquivos recentes;
- fixacao real de arquivos;
- remocao real do historico;
- estoque real;
- cadastro real de materiais;
- baixa real de material;
- edicao real de colecoes, modelos ou cards;
- persistencia real.

## arquivos alterados ou criados na ultima tarefa

Implementacao:

- `src/blueatelier.app/Components/Layout/AppSidebar.razor`
- `src/blueatelier.app/Components/Layout/AppTopbar.razor`
- `src/blueatelier.app/Components/Pages/Materiais.razor`
- `src/blueatelier.app/wwwroot/css/app.css`

Documentacao:

- `docs/03-estado-atual.md`
- `docs/04-proximos-documentos.md`
- `docs/33-materiais.md`
- `docs/34-ajustes-layout-responsividade.md`

## validacoes executadas na ultima tarefa

- `referencias-visuais/stitch/design.md` foi respeitado.
- `referencias-visuais/stitch/html/10-materiais.html` foi usado para a tela Materiais.
- Home permaneceu preservada.
- Colecoes permaneceu preservada.
- Detalhe da Colecao permaneceu preservado.
- Detalhe do Modelo permaneceu preservado.
- Galeria do Modelo permaneceu preservada.
- Visualizacao de Imagem permaneceu preservada e nao quebra mais em larguras medias.
- Arquivos Vinculados permaneceu preservado.
- Fila de Impressao permaneceu preservada e a tabela esta acessivel.
- Modelos permaneceu preservado e responsivo.
- Arquivos Recentes permaneceu preservado e a tabela/lista esta acessivel.
- `/materiais` abre corretamente.
- O item Materiais/Materials da sidebar navega para `/materiais`.
- As tags dos materiais tem contraste legivel.
- As tags dos materiais nao ficam atras do icone/elemento central.
- Os cards de materiais nao cortam conteudo importante.
- A paleta clean/azulada foi preservada.
- Nenhum HTML do Stitch foi alterado.
- Nenhuma imagem do Stitch foi alterada.
- Nenhum `design.md` do Stitch foi alterado.
- Nenhuma funcionalidade real foi implementada.
- Nenhum banco SQLite foi criado.
- Nenhum EF Core foi implementado.
- Nenhuma migration foi criada.
- Nenhum servico real foi implementado.
- Nenhum sistema de arquivos real foi implementado.
- Nenhum CDN, Tailwind, Bootstrap ou biblioteca externa foi usado.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## proxima tarefa sugerida

Implementar a tela Detalhe do Material com base em:

```txt
referencias-visuais/stitch/html/11-detalhe-material.html
```

A proxima tarefa deve preservar a Home, Colecoes, Detalhe da Colecao, Detalhe do Modelo, Galeria do Modelo, Visualizacao de Imagem, Arquivos Vinculados, Fila de Impressao, Modelos, Arquivos Recentes, Materiais e a fundacao visual ja aprovadas. Qualquer diferenca visual inevitavel deve ser registrada antes da revisao manual.
