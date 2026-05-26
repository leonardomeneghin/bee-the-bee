# índice:
- [requisitos](#requisitos)
- [O que vamos fazer](#o-que-vamos-fazer)
- [dicas de segurança para evitar scam](#dicas-de-segurança-para-evitar-scam)
- [passo-a-passo](#passo-a-passo)
- [o que esta acontecendo](#o-que-esta-acontecendo)
- [referencias](#referencias)
- [autor](#autor)

# requisitos:
	Ter uma conta no https://itch.io/
	Ter uma conta no https://github.com/
	Ter um projeto no godot v4.3.stable.mono.official [77dcf97d8] 
> note que se você trocar a versão, terá que modificar o build.yml para que o runner do github baixe o template correto! Ou irá dar erro. Ou seja, use a versão indicada.

# o que vamos fazer:
- Configurar template windows no seu projeto godot
- Configurar template linux no seu projeto godot
- criar o arquivo build.yml na pasta ".github/workflows"
- adicionar o conteúdo do arquivo [build.yml](https://github.com/leonardomeneghin/bee-the-bee/blob/main/.github/workflows/build.yml) em seu próprio projeto.
- fazer um commit na main.
- ver o build do projeto no itch.io
> Note que não estamos seguindo boas práticas de controle de versionamento de branch. Para projetos profissionais, use gitflow, branches de versão e seja feliz. Se você está apenas estudando, não se preocupe, faça seu teste, resolva seu problema e viva bem.

# dicas de segurança para evitar scam
- não compartilhe seu token do itch.io
- não dê permissões para usuários desconhecidos no seu repositório (ele que crie um fork e se vire!)
- em equipes profissionais, onde o repositório é privado, dê acesso GRANULAR ao repositório, não permita push direto na MAIN e não permita PRs na MAIN. Apenas VOCÊ ou outro integrante de SUA CONFIANÇA deve ter essa permissão.
- não tire fotos do seu token para 'gravar' melhor, simplesmente vá e gere outro!
- não faça videos do seu token...
- não coloque seu token no código do repositório. Sério.
- não adicione tokens de terceiros no seu projeto. O token é seu, você gera, você cuida, você organiza. O projeto é seu, o jogo é seu, a página é sua! Dê os créditos no itch.io, mas não fique 'sambando' com tokens no repositório.

# passo a passo:
1. Crie um projeto em godot na versão 4.3 que utilize Csharp com monogame. Existem diversos tutoriais na internet de como baixar e configurar.
2. Com seu projeto em mãos, abra o godot e configure um template seguindo os passos abaixo:
3. Instale o modelo usando os seguintes passos:

```
- Vá em 'EDITOR' e depois 'GERENCIAR MODELOS DE EXPORTAÇÃO'
- Procure pelo modelo 4.3.stable.mono clicando em 'Baixar e Instalar'
```
4. Agora vá em 'PROJETO' e 'EXPORT', você irá configurar cada build, um para WINDOWS e outro para LINUX
```
WINDOWS
PASSO A) clique no botão 'ADICIONAR' escolha a opção WINDOWS
PASSO B) Do lado direito, existe um botão chamado 'Executável' ative-o!
PASSO C) Opções avançadas deve estar DESATIVADO
PASSO D) Caminho de exportação: eu coloco em 'build/windows/nome-do-meu-jogo.x86_64
	tip: Coloque aí, pois facilita pro runner depois.
PASSO E) Arquitetura: use X86_64

LINUX
- Repita o PASSO A, porém agora escolha LINUX
- Repita o passo B e C
- Repita o passo D, porém troque o caminho para: 'build/linux/nome-do-meu-jogo.x86_64
- Repita o passo E

Agora dê um mortal.
```

5. crie uma pasta chamada .github e dentro dessa pasta, crie outra chamada workflows
6. Copie o arquivo (https://github.com/leonardomeneghin/bee-the-bee/blob/main/.github/workflows/build.yml) para a pasta 'workflows'
7. Agora edite o seu arquivo build.yml para que aponte para o SEU ITCH.IO e para SEU projeto. Você irá alterar uma secção chamada 'env':
```
env:
  DOTNET_CLI_TELEMETRY_OPTOUT: true
  DOTNET_NOLOGO: true
  DOTNET_SKIP_FIRST_TIME_EXPERIENCE: true
  GODOT_VERSION: "4.3"
  EXPORT_NAME: "bee-the-bee" //AQUI altere para a página do seu jogo!
  ITCH_USER_NAME: "meneghin" //AQUI: ALTERE PARA SEU NOME DE USUÁRIO, no caso para 'https://meneghin.itch.io/' o nome colocado é apenas 'meneghin'
  URL_BUTLER_ITCH: "https://broth.itch.zone/butler/linux-amd64/LATEST/archive/default"
```
>_Normalmente o EXPORT_NAME refere-se ao itch.io + nome do executável, mas você pode optar por trocar isso no build.yml. Eu gosto de usar assim, mas você pode personalizar._

8. Agora você precisará acessar sua página do itch.io para obter uma CHAVE SEGURANÇA ou TOKEN DE SEGURANÇA.
	1. Abra seu itch.io
	2. Vá em 'settings'
	3. vá em 'API KEYS'
	4. Insira sua senha
	5. Gere seu token (só tem um botão ai)
	6. Copie o token
>⚠️ ESSE TOKEN É SEU! E DE NINGUÉM MAIS! NÃO MOSTRE PARA OUTROS USUÁRIOS, NÃO FORNEÇA PARA NINGUÉM! CONFIGURE NO SEU GITHUB APENAS⚠️ Leia a secção de boas práticas para evitar scam, isso é importante demais para ser negligenciado! Eu não me responsabilizo por scams, você é responsável por sua segurança! O aviso está dado!
 
 9. Com o token da etapa anterior, abra seu github e vá no seu projeto
	1. Vá em 'settings'
	2. Procure por 'Secrets and variables' ou 'segredos e variáveis'
	3. Clique em 'Actions' ou 'ações'
	4. use o botão 'New repository secret' ou 'novo segredo de repositório'
	5. No campo 'Name' coloque o nome desejado. Nesse tutorial, usamos: 'API_KEY_ITCH'
	6. no valor do 'Secret' cole sua key.
	7. Clique no botão Add secret
> Se o github mudar e você não encontrar o botão, pesquise online onde colocar sua chave de API de maneira segura no github.

10. Agora você precisa testar seu primeiro build e ver se funciona. Na configuração atual, o build irá ocorrer automaticamente se você fizer um commit e fizer um PUSH na main.

# o que esta acontecendo?
De forma simples, dentro de um container em um ambiente em nuvem, nesse container totalmente isolado de sistema operacional, estamos:
- copiando nosso projeto para dentro do container
- baixando as dependências necessárias para fazer a integração na API do itch
- baixando os templates do godot
- baixando unzip para descompactar/compactar arquivos. 
- usamos comandos de linha (CLI - Command Line Interface) do godot e do dotnet para gerar os binários e exportar nosso jogo para as pastas de builds.
- copiamos os builds gerados e enviamos pelo butler para o itch.io
- Pronto! Nossa demo está On e pronto para divertir milhões de pessoas!

# referencias:
Porque não tiramos as coisas do nada, usamos documentação para fundamentar nossas ações.
- (CICD no godot) [https://github.com/marketplace/actions/setup-godot-action]
- claude code (sim, ele acelerou o desenvolvimento disso)
- (guia markdown) [https://github.com/mende1/guia-definitivo-de-markdown/blob/master/README.md#c%C3%B3digos]

# autor
Meneghin
- (Linkedin)[https://www.linkedin.com/in/meneghin/]
- (itch.io)[https://meneghin.itch.io/]
- (github)[https://github.com/leonardomeneghin]