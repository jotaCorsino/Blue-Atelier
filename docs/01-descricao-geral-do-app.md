# blue atelier — descrição geral do app

## 1. visão geral

O **Blue Atelier** é um aplicativo Windows de uso pessoal, desenvolvido exclusivamente para organizar o fluxo de trabalho de um atelier de impressão 3D com foco em miniaturas impressas e pintadas manualmente.

O app não será comercializado. Ele será utilizado por uma única pessoa, dentro de uma rotina pessoal de criação, pesquisa, organização, impressão, pintura, documentação e arquivamento de miniaturas.

O objetivo principal do app é funcionar como uma central visual e operacional do atelier, reunindo em um único lugar:

- ideias de linhas e coleções de miniaturas;
- modelos individuais dentro de cada linha;
- imagens de referência;
- galerias visuais;
- descrições e padrões de produção;
- links úteis;
- arquivos locais;
- arquivos acessados pela rede;
- arquivos de impressão 3D;
- arquivos de fatiamento;
- fotos do processo;
- fotos finais;
- materiais e utensílios;
- favoritos gerais;
- status da rotina de produção.

O app deve ser visual, minimalista, moderno e confortável para uso diário. Ele deve funcionar como uma combinação entre:

- Pinterest privado;
- galeria visual de projetos;
- organizador de arquivos;
- painel de produção;
- biblioteca pessoal de miniaturas;
- central de atalhos do atelier.

## 2. nome do projeto

Nome do app: **Blue Atelier**

Nome do repositório remoto:

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

Nome recomendado para a pasta local do projeto:

```txt
blue-atelier
```

Todos os arquivos internos, pastas, documentos e slugs gerados pelo app devem usar nomes em letras minúsculas sempre que possível.

## 3. princípios do app

O Blue Atelier deve seguir alguns princípios fundamentais.

### 3.1 uso pessoal

O app será feito para um único usuário. Não precisa ter login, cadastro de usuários, permissões complexas, multiusuário ou painel administrativo.

A prioridade é servir ao fluxo real do atelier pessoal.

### 3.2 visual em primeiro lugar

A navegação principal deve ser visual. O usuário deve reconhecer linhas, coleções e modelos por capas, mosaicos, imagens e galerias.

O app deve parecer mais uma biblioteca visual do que uma planilha ou sistema burocrático.

### 3.3 organização de arquivos como parte central

O app não deve apenas cadastrar ideias. Ele deve ajudar a organizar, localizar, abrir e manter arquivos do atelier.

Os arquivos continuam existindo em pastas normais do Windows. O app funciona como uma camada visual e inteligente por cima dessas pastas.

### 3.4 banco leve e arquivos fora do banco

O banco de dados deve guardar metadados, caminhos, títulos, descrições, status, tags, links e relações.

Arquivos pesados como imagens, STL, OBJ, 3MF, BLEND, CTB, projetos de slicer e fotos devem ficar no sistema de arquivos, não dentro do banco.

### 3.5 local-first

O app deve funcionar localmente no Windows. A internet pode ser usada para abrir links externos, mas a organização principal deve funcionar sem depender de serviços online.

### 3.6 compatível com caminhos de rede

O atelier acessará arquivos e/ou pastas de impressão 3D pela rede. Portanto, o app deve suportar caminhos como:

```txt
D:\atelier-3d\
Z:\atelier-3d\
\\atelier-notebook\fila-impressao\
\\desktop-atelier\arquivos-3d\
\\192.168.18.50\atelier-3d\
```

O app deve conseguir testar se um caminho está acessível, abrir pastas de rede e lidar com o caso de uma pasta estar offline.

### 3.7 visual aprovado não deve ser alterado sem autorização

Depois que uma tela for aprovada visualmente, o Codex não deve alterar layout, espaçamento, cores, tipografia, hierarquia visual, componentes ou comportamento visual sem uma ordem explícita.

O visual será tratado como uma camada protegida.

## 4. arquitetura conceitual do app

O app é dividido em áreas principais:

```txt
blue atelier
├── início
├── coleções
├── modelos
├── fila de impressão
├── arquivos recentes
├── materiais
├── favoritos
├── busca
└── configurações
```

## 5. hierarquia principal dos dados

A hierarquia principal é:

```txt
coleção / linha
└── modelo / miniatura
    ├── galeria
    ├── descrição
    ├── links
    ├── arquivos
    ├── materiais
    ├── checklist
    ├── status
    └── histórico
```

Exemplo prático:

```txt
pokemon — dioramas de kanto
└── bulbasaur — diorama de floresta
    ├── referências visuais
    ├── arquivos stl
    ├── projeto do slicer
    ├── arquivo pronto para impressão
    ├── fotos da impressão
    ├── fotos da pintura
    ├── fotos finais
    ├── paleta de cores
    ├── materiais usados
    └── notas de produção
```

## 6. tela inicial

A tela inicial deve ser um painel visual com mosaico de coleções e atalhos importantes.

Ela deve exibir:

- mosaico de coleções recentes;
- coleções favoritas;
- modelos em andamento;
- itens prontos para impressão;
- últimos arquivos acessados;
- favoritos rápidos;
- aviso de caminhos de rede offline, quando houver;
- botão para criar nova coleção;
- campo de busca global.

A tela inicial deve transmitir a sensação de “painel do atelier”.

## 7. coleções / linhas

Uma coleção representa uma linha de miniaturas, uma série, uma ideia de produto, um conjunto temático ou uma organização criativa.

Exemplos:

- dioramas de kanto;
- bustos dark fantasy;
- criaturas sci-fi;
- monstros clássicos;
- acessórios de cenário;
- bases medievais;
- estudos de pintura;
- miniaturas autorais.

Cada coleção deve ter:

- título;
- slug;
- capa;
- descrição;
- tags;
- status;
- pasta vinculada;
- cor opcional;
- data de criação;
- data de atualização;
- contagem de modelos;
- modelos relacionados;
- links gerais da coleção;
- galeria opcional da coleção;
- observações.

Status possíveis para coleção:

- ideia;
- pesquisando;
- estruturando;
- em produção;
- pausada;
- finalizada;
- arquivada.

A visualização de coleções deve ser por mosaico de cards, com imagem de capa, título e pequenos metadados.

## 8. modelos / miniaturas

Um modelo representa uma miniatura específica, personagem, peça, busto, diorama, base, acessório, kit ou estudo.

Cada modelo deve ter:

- título;
- slug;
- coleção relacionada;
- capa;
- descrição;
- galeria;
- status;
- tags;
- escala;
- tamanho estimado;
- observações;
- materiais;
- links;
- arquivos vinculados;
- pasta principal;
- checklist;
- histórico de produção;
- fotos finais.

Status possíveis para modelo:

- ideia;
- pesquisando;
- referências coletadas;
- arquivo 3d encontrado;
- arquivo 3d revisado;
- pronto para fatiar;
- fatiado;
- enviado para impressão;
- impresso;
- falhou na impressão;
- lavado;
- curado;
- em preparação;
- em pintura;
- finalizado;
- fotografado;
- arquivado.

A tela do modelo deve ser a ficha completa da miniatura.

## 9. tela do modelo

A tela do modelo deve conter:

- capa grande;
- título;
- status atual;
- tags;
- coleção de origem;
- botão para abrir pasta principal;
- botão para abrir arquivos 3D;
- botão para abrir fatiamento;
- botão para copiar arquivo para fila de impressão;
- galeria visual;
- descrição;
- links específicos;
- materiais;
- checklist;
- arquivos relacionados;
- histórico;
- notas.

A área de links só deve aparecer quando existirem links cadastrados.

A área de materiais só deve aparecer quando existirem materiais cadastrados.

A área de galeria deve ser visual, em mosaico, permitindo definir uma imagem como capa.

## 10. galeria

A galeria deve permitir organizar imagens de referência, fotos do processo, renders, fotos finais e imagens de inspiração.

Tipos de imagem:

- referência;
- render;
- pintura;
- processo;
- foto final;
- paleta;
- textura;
- outro.

A galeria deve permitir:

- adicionar imagem;
- remover imagem;
- abrir imagem;
- definir como capa;
- adicionar título;
- adicionar descrição;
- adicionar tags;
- filtrar por tipo.

## 11. links

O app deve ter dois tipos de links.

### 11.1 links globais

Links gerais do atelier, acessados pela área de favoritos.

Exemplos:

- marketplaces de modelos 3D;
- lojas de resina;
- lojas de tintas;
- lojas de pincéis;
- sites de referência;
- tutoriais;
- comunidades;
- fornecedores.

### 11.2 links específicos

Links vinculados a uma coleção ou modelo.

Exemplos:

- página do modelo 3D;
- tutorial de pintura;
- referência visual;
- paleta de cores;
- pasta externa;
- documentação;
- inspiração.

Cada link deve ter:

- título;
- url;
- categoria;
- descrição curta;
- tags;
- data de criação;
- data de atualização;
- favorito sim/não.

Categorias sugeridas:

- marketplace;
- referência visual;
- tutorial;
- fornecedor;
- material;
- arquivo;
- comunidade;
- pesquisa;
- inspiração;
- outro.

## 12. favoritos

A área de favoritos deve funcionar como uma pequena aba de favoritos semelhante à do navegador, mas voltada ao atelier.

Deve existir:

- barra rápida de favoritos;
- página completa de favoritos;
- categorias;
- cards de favoritos;
- busca;
- edição;
- remoção.

Exemplo de categorias:

- marketplaces;
- materiais;
- utensílios;
- tintas;
- resinas;
- ferramentas;
- tutoriais;
- comunidades;
- referências.

A barra rápida pode aparecer no topo ou lateral do app, com links fixados pelo usuário.

## 13. arquivos

O app deve ser capaz de vincular arquivos e pastas a coleções e modelos.

Tipos de arquivos importantes:

```txt
.stl
.obj
.3mf
.blend
.ctb
.lychee
.chitubox
.png
.jpg
.jpeg
.webp
.pdf
.txt
.md
```

Cada arquivo vinculado deve ter:

- nome;
- caminho;
- extensão;
- tipo;
- tamanho;
- data de criação;
- data de modificação;
- categoria;
- coleção relacionada;
- modelo relacionado;
- observação.

O app deve permitir:

- abrir arquivo;
- abrir pasta do arquivo;
- copiar caminho;
- copiar arquivo;
- mover arquivo para pasta correta;
- enviar arquivo para fila de impressão;
- verificar se o arquivo ainda existe;
- identificar arquivo ausente.

## 14. organização automática de pastas

O app deve criar automaticamente uma estrutura de pastas para cada coleção e modelo.

Estrutura sugerida de coleção:

```txt
colecao/
├── capa/
├── referencias/
├── documentos/
├── modelos/
└── notas/
```

Estrutura sugerida de modelo:

```txt
modelo/
├── capa/
├── referencias/
├── arquivos-3d/
│   ├── stl/
│   ├── obj/
│   ├── 3mf/
│   ├── blend/
│   └── outros/
├── fatiamento/
│   ├── projetos-slicer/
│   └── arquivos-prontos/
├── impressao/
│   ├── enviados/
│   ├── impressos/
│   └── falhas/
├── pintura/
│   ├── referencias/
│   ├── paleta/
│   └── processo/
├── fotos-finais/
└── notas/
```

Essa estrutura deve ser configurável na área de configurações.

## 15. fila de impressão

A fila de impressão deve reunir modelos ou arquivos que estão prontos para serem impressos.

Cada item da fila deve conter:

- modelo relacionado;
- arquivo relacionado;
- status;
- caminho do arquivo;
- destino de rede;
- data de envio;
- observação;
- histórico de tentativa.

Status da fila:

- aguardando fatiamento;
- pronto para enviar;
- enviado;
- imprimindo;
- impresso;
- falhou;
- cancelado;
- arquivado.

Ações da fila:

- abrir arquivo;
- abrir pasta;
- copiar para pasta de rede;
- marcar como enviado;
- marcar como impresso;
- registrar falha;
- adicionar observação.

## 16. arquivos recentes

A área de arquivos recentes deve mostrar arquivos vinculados, importados, acessados ou alterados recentemente.

Deve ser possível filtrar por:

- hoje;
- esta semana;
- este mês;
- coleção;
- modelo;
- tipo de arquivo;
- status.

## 17. materiais

O app deve permitir cadastrar materiais e utensílios usados no atelier.

Exemplos:

- resina;
- primer;
- tinta;
- wash;
- verniz;
- pincel;
- lixa;
- álcool isopropílico;
- luva;
- máscara;
- base;
- massa;
- pigmento;
- cola.

Cada material pode ter:

- nome;
- tipo;
- marca;
- cor;
- observação;
- link de compra;
- fornecedor;
- quantidade opcional;
- unidade opcional;
- favorito sim/não.

Materiais podem ser vinculados a modelos.

## 18. checklist

Cada modelo pode ter um checklist de produção.

Checklist sugerido:

```txt
[ ] referências coletadas
[ ] arquivo 3d encontrado
[ ] arquivo 3d revisado
[ ] arquivo fatiado
[ ] arquivo enviado para impressão
[ ] impressão concluída
[ ] lavagem concluída
[ ] cura concluída
[ ] preparação concluída
[ ] pintura iniciada
[ ] pintura finalizada
[ ] fotos finais feitas
[ ] modelo arquivado
```

O checklist deve ajudar o usuário a seguir a rotina do atelier.

## 19. configurações

A área de configurações deve ser completa e adaptável.

### 19.1 caminhos principais

Configurações de pastas:

- pasta principal do atelier;
- pasta de coleções;
- pasta de backups;
- pasta temporária;
- pasta de importação;
- pasta de exportação.

### 19.2 caminhos de rede

Configurações de rede:

- pasta de envio para impressão;
- pasta compartilhada de arquivos 3D;
- pasta de finalizados;
- pasta de backup em rede;
- unidade mapeada, se existir.

Cada caminho deve ter:

- nome;
- caminho;
- tipo;
- status;
- último teste;
- observação.

O app deve ter botão para testar conexão.

### 19.3 modelo padrão de pastas

O usuário deve poder configurar quais pastas são criadas automaticamente para coleções e modelos.

### 19.4 tema

Configurações visuais:

- tema claro;
- tema escuro;
- tema automático;
- cor de destaque;
- tamanho dos cards;
- densidade da interface.

### 19.5 programas padrão

O app pode permitir configurar comandos ou programas para abrir determinados arquivos.

Exemplos:

- slicer para STL/3MF;
- Blender para BLEND/OBJ;
- editor de texto para MD/TXT;
- visualizador de imagens para PNG/JPG.

### 19.6 backup

Configurações de backup:

- backup manual;
- backup automático;
- exportar banco;
- importar banco;
- exportar configurações;
- importar configurações.

## 20. busca global

O app deve ter uma busca global capaz de encontrar:

- coleções;
- modelos;
- tags;
- links;
- arquivos;
- materiais;
- status;
- notas.

A busca deve ser rápida e acessível de qualquer tela.

## 21. aparência e experiência visual

O Blue Atelier deve ter visual moderno, limpo e confortável.

A interface deve ter:

- predominância de tons neutros;
- modo claro e modo escuro;
- uma cor principal usada apenas como destaque;
- cards visuais;
- mosaicos;
- bordas suaves;
- espaçamentos generosos;
- tipografia legível;
- poucos elementos por tela;
- navegação lateral clara;
- feedback visual para ações importantes.

Paleta sugerida:

```txt
fundo claro: #f7f7f5
fundo escuro: #101114
card claro: #ffffff
card escuro: #1a1c20
texto principal claro: #171717
texto principal escuro: #f2f2f2
texto secundário: #8a8a8a
destaque azul: #3b82f6
```

O azul deve ser usado com moderação, apenas para:

- botão principal;
- seleção ativa;
- links;
- ícones importantes;
- indicadores de status;
- pequenos detalhes.

## 22. tecnologia sugerida

Stack sugerida:

- C#;
- .NET;
- app Windows;
- SQLite;
- Entity Framework Core;
- interface com Blazor Hybrid, WPF ou WinUI.

Opção preferencial:

```txt
.net maui blazor hybrid + sqlite + entity framework core
```

Motivos:

- combina com o repertório do projeto;
- permite UI moderna;
- facilita criação de mosaicos e componentes visuais;
- mantém lógica C#;
- permite evolução futura;
- funciona bem para app Windows pessoal.

## 23. integração com ferramentas de IA

### 23.1 stitch

Stitch pode ser usado para explorar telas, composições visuais, layouts e experiências de navegação.

Uso recomendado:

- gerar proposta visual da tela inicial;
- gerar proposta visual da tela de coleção;
- gerar proposta visual da tela do modelo;
- gerar proposta visual da área de configurações;
- gerar proposta visual da área de favoritos;
- refinar o estilo dos cards, mosaicos, menus e estados visuais.

Stitch não deve ser tratado como fonte final de código do projeto. Ele deve servir como ferramenta de ideação visual.

### 23.2 antigravity

Antigravity pode ser usado como ambiente de desenvolvimento agentic para implementar, navegar pelo projeto, executar comandos, revisar arquivos e validar comportamento.

Uso recomendado:

- explorar o projeto;
- aplicar tarefas maiores;
- executar testes;
- gerar evidências visuais;
- verificar builds;
- auxiliar em refatorações.

### 23.3 codex

Codex será tratado como engenheiro principal de implementação.

Codex deve:

- ler a documentação antes de alterar o projeto;
- trabalhar uma tarefa por vez;
- não alterar visual aprovado sem autorização;
- fazer commits pequenos;
- atualizar o repositório remoto ao final de cada tarefa;
- registrar o que foi feito no arquivo de estado atual;
- preservar padrões definidos.

## 24. fluxo de trabalho com github

Repositório remoto:

```txt
https://github.com/jotaCorsino/Blue-Atelier.git
```

Fluxo desejado:

1. O usuário solicita a próxima tarefa.
2. O ChatGPT cria o comando/prompt para o Codex.
3. O Codex implementa a tarefa.
4. O Codex executa validações possíveis.
5. O Codex atualiza o arquivo de estado atual.
6. O Codex faz commit.
7. O Codex faz push para o repositório remoto.
8. O usuário solicita validação ao ChatGPT.
9. O ChatGPT analisa o repositório remoto.
10. Só depois da validação a próxima tarefa é liberada.

## 25. definição final

O Blue Atelier é um aplicativo Windows local e pessoal para organizar, documentar e operacionalizar um atelier de miniaturas impressas em 3D.

Ele deve unir organização visual, estrutura de arquivos, galeria de referências, favoritos, materiais, links, fila de impressão, caminhos de rede e acompanhamento da rotina criativa/produtiva.

O app deve ser completo, mas construído de forma controlada, uma tarefa por vez, com documentação viva e validação após cada commit.
