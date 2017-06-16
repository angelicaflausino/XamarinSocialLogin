# Xamarin Social Login
Guia completo para configurar social login no Xamarin utilizando o Azure Mobile Apps e autenticando usuário através do Facebook.

Requisitos
----------

 - [Conta na Azure](https://azure.microsoft.com)
 - [Conta no Facebook Developers](https://developers.facebook.com)

Dependências
-------
- [Windows.Azure.Mobile.Client 3.1.0](https://www.nuget.org/packages/Microsoft.Azure.Mobile.Client/3.1.0)

Passo a passo em Vídeo
-------

- [Alpha2/Youtube](https://www.youtube.com/playlist?list=PLHSGc3f3PK0SqRBJlN67KoEfA93fUnhvw)

## Configurando ambiente no portal da Azure ##

1) Acesse o portal da azure e em + novo pesquise pelo recurso **Mobile Apps QuickStart**. Clique no recurso e em seguida Criar.

![1](https://lh3.googleusercontent.com/BUJlkC2ROyonBOv9Jyj3CwxPJ37TMi3jVPmXCccq4RwgnHebLxHCpi5pc6LpD9-cbDGjDe4N=s0 "1.png")

2) Configure as informações do seu aplicativo, como nome, assinatura, grupo de recursos e prossiga com Criar.

![2](https://lh3.googleusercontent.com/LLjSImptWLgf6OGJlL5HLB8D8cZ22S6AO7fj8XeWTIr6o956tcPld2ymmfM3vBemR_McgmAR=s0 "2.png")

3) Depois de implementado o recurso, você pode facilmente localiza-lo no painel inicial, ou em todos os recursos no menu. Após localizar o aplicativo, no menu selecione Autenticação / Autorização.

![3](https://lh3.googleusercontent.com/gxc748sNUlj6xmji2UcOiewlt2TFX1cBN9cPwU-hk9WE2i6tfLGqUtvSEWw3BCn-bL1S9F7G=s0 "3.png")

4) Clique em Ativado para liberar mais configurações e clique no Facebook para editar as informações do provedor.

![4](https://lh3.googleusercontent.com/Zy2J-Cd4Xak6TGsCl7-JzUSb2AZimsiOvNJWV0W_bi7kGsfjAt8xIsDZ5rjXyv0qEFoZT9v8=s0 "4.png")

5) Nesse passo, será necessário configurar o aplicativo no portal de desenvolvedores do Facebook disponível no [link](https://developers.facebook.com/)

![5](https://lh3.googleusercontent.com/cwFIHOaQCxERn6PlP3pPhLqP3GjmEj-uIGDbxxpsK9XgfqPIgfTKrY-5CT67acU8ijbSrbVz=s0 "5.png")

6) Presumindo que você já tem uma conta, clique em meus aplicativos e adicionar um novo aplicativo.

![6](https://lh3.googleusercontent.com/vYUcqwEzS5uVKJbZBX8wVWaQTG9hZaD7mhQL1AMeomSxhoo1tUtaC-xNqrkOIgTKFXFZTQM0=s0 "6.png")

7) Preencha as informações do seu novo aplicativo, lembrando que o nome do app será visível para os usuários. Informe seu e-mail e prossiga com as confirmações.

![7a](https://lh3.googleusercontent.com/dndBjvSa56NJ7azWTYDpMXWi7jizmvwnprZV9d5htZjpzb83TDDZ2Sd8h76NpvQwFtBYrIy0=s0 "7.png")

![7b](https://lh3.googleusercontent.com/MdWSy7Rcqz39m0WoGKvy0ShXeRMtygozle-bYyXio6YhxeurnN1fvjy11KzsTXBVTJshZngU=s0 "8.png")

8) No menu selecione adicionar produto e clique em Login com Facebook

 ![8](https://lh3.googleusercontent.com/ECqFzDZVB6E9K2Cmi7R_mwDVFEctnw7jRAetk7_baf4mvwOJcWaLF9l539HXjCgQO04Uxb1J=s0 "9.png")

9) Agora será necessário a url do seu recurso na azure, então vá para o portal da azure, em visão geral e copie a URL do canto superior direito.

![9](https://lh3.googleusercontent.com/qrYuuAV9f3W5cRFxlU12eFVJ2Fy5P4lmj32dqLsPltpP41vfAwza__PTrzjAwPJ54C_fqC_6=s0 "10.png")

10) Volte ao Facebook e em URL de retorno de chamada cole 
sua url + /.auth/login/facebook/callback 
Portanto ficará assim:
**https://suaurl.azurewebsites.net/.auth/login/facebook/callback**
Clique em Salvar alterações.

![10](https://lh3.googleusercontent.com/B2IWfyVqBcTBlAn7G5r18nydg_VKBZL4d2iE8FG9wr7QziXWNePD1dTtRvnYherGJ1IjiErN=s0 "11.png")

11) Lembre-se de copiar no painel do Facebook o Id do Aplicativo e a Chave secreta.

![11](https://lh3.googleusercontent.com/Ve3vJJploe-lp-nBXuy42JPTUZwepHcoWGbpCFXOG1bNi97pq8802_CrzqNzvtRPH_k2WZxi=s0 "12.png")

12) Volte para o portal da Azure e em Autenticação/Autorização clique no Facebook e insira as informações que copiou no passo anterior. Lembrando de selecionar as informações que seu aplicativo vai solicitar para o seu usuário. Para testes utilize somente a primeiro opção public_profile e desmarque as outras. Clique em Salvar.

![12](https://lh3.googleusercontent.com/cwFIHOaQCxERn6PlP3pPhLqP3GjmEj-uIGDbxxpsK9XgfqPIgfTKrY-5CT67acU8ijbSrbVz=s0 "5.png")

**Pronto nosso serviço da Azure já está pronto para receber requisições do app e autenticar no Facebook!**

Caso você queira acompanhar o tutorial completo de como configurar a Azure e o projeto do Xamarin eu fiz um vídeo que explica passo a passo de como criar o social login e consumir as informações do facebook do usuário através do API de gráfico do Facebook. Confira no vídeo e não caia no sono!

