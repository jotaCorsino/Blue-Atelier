# blue atelier - ajustes de paleta visual

## motivo da recalibracao visual

A revisao visual da Fila de Impressao mostrou que os badges e estados estavam ficando coloridos demais. A interface comecava a perder a direcao clean, moderna e editorial desejada para o Blue Atelier.

O usuario aprovou uma recalibracao controlada da paleta para reduzir excesso de cores e deixar o app mais harmonico, com azul como destaque principal.

## direcao aprovada pelo usuario

A direcao aprovada e:

- app clean;
- moderno;
- leve;
- quase monocromatico;
- voltado para azul;
- azul usado como principal cor de destaque;
- cores como verde, amarelo e vermelho usadas apenas em estados reais de sistema;
- bom contraste;
- menos efeitos decorativos;
- menos cores concorrentes;
- mais harmonia visual.

A referencia conceitual considerada foi:

```txt
azul/preto profundo: #21222D
azul/lilas de destaque: #958CE8
azul claro suave: #ACD1FD
cinza claro azulado: #DBDBE5
```

Essas cores serviram como direcao, nao como copia obrigatoria literal.

## reducao de cores excessivas

Foram reduzidos usos desnecessarios de:

- verde;
- amarelo;
- laranja;
- vermelho;
- ciano muito chamativo;
- glows coloridos;
- fundos coloridos concorrentes;
- efeitos decorativos sem funcao.

Cards comuns, metricas comuns, filtros, hover e selecao passaram a depender mais de neutros azulados e do azul de destaque.

## azul como cor principal de destaque

O azul passou a ser a base para:

- acoes principais;
- links e navegacao;
- itens ativos;
- hover de cards clicaveis;
- foco visual discreto;
- estados comuns ou neutros destacados;
- indicadores de atividade nao critica.

Essa direcao aproxima o app de uma ferramenta visual de atelier digital, com leitura mais calma e coesa.

## uso restrito de verde, amarelo e vermelho

As cores de sistema ficaram reservadas para estados reais:

- verde: conclusao ou sucesso tecnico;
- amarelo/ambar: pausa, atencao ou pendencia;
- vermelho/coral: erro, arquivo ausente, risco ou remocao.

Mesmo nesses casos, o uso deve ser discreto e legivel, sem transformar a interface em um painel multicolorido.

## tokens ou classes de cor ajustadas

Arquivos envolvidos:

- `src/blueatelier.app/wwwroot/css/tokens.css`
- `src/blueatelier.app/wwwroot/css/themes.css`
- `src/blueatelier.app/wwwroot/css/app.css`

Foram ajustados tokens e classes relacionados a:

- acento principal;
- superficies;
- bordas;
- hover;
- foco visual;
- badges;
- estados da fila;
- indicadores de sistema;
- contraste em tema claro e escuro.

A intencao foi centralizar a direcao visual em tokens reutilizaveis, evitando cores soltas espalhadas pelo CSS.

## impacto nos badges/status

Na Fila de Impressao, os badges/status foram recalibrados para evitar a aparencia de elementos muito coloridos ou infantis.

Direcao aplicada:

- Em impressao: azul de destaque;
- Pronto: neutro azulado;
- Pausado: atencao discreta;
- Arquivo ausente: erro discreto;
- Concluido: sucesso discreto;
- Com erro: erro claro e legivel, quando aplicavel.

Os badges continuam legiveis e compactos, mas com menos competicao visual entre si.

## preservacao do layout aprovado

A recalibracao foi limitada a cores, tokens, badges, indicadores, botoes e pequenos acentos.

Nao foram redesenhados:

- estrutura das telas;
- sidebar;
- topbar;
- grids;
- cards;
- espacamentos principais;
- hierarquia visual;
- rotas;
- dados mockados.

## validacoes executadas

- O app ficou mais clean e menos colorido.
- O azul virou o destaque principal.
- Verde, amarelo e vermelho ficaram restritos a estados reais de sistema.
- A Fila de Impressao nao parece mais excessivamente colorida.
- Os badges/status continuam legiveis.
- A navegacao manteve bom contraste.
- A sidebar continua clara e legivel.
- Os botoes mantem hierarquia visual clara.
- Nenhuma tela aprovada foi redesenhada.
- Nenhum arquivo do Stitch foi alterado.
- Nenhuma funcionalidade real foi implementada.
- `dotnet restore BlueAtelier.sln` executado com sucesso.
- `dotnet build BlueAtelier.sln` executado com sucesso.
- `dotnet test BlueAtelier.sln --no-build` executado com sucesso.

## confirmacao de aprovacao visual manual

A recalibracao visual da paleta foi validada visualmente pelo usuario e aprovada no estado atual.

O estado aprovado deve ser preservado nas proximas tarefas, salvo correcao tecnica minima ou autorizacao explicita do usuario.
